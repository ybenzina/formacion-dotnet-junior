#Requires -Version 7.0
<#
.SYNOPSIS
    Genera la solución base de CourtConnect con la estructura de capas acordada.

.DESCRIPTION
    Crea la solución, los proyectos, las carpetas de solución, las referencias
    entre proyectos y los paquetes NuGet de partida.

    El script se detiene en el primer error. No sobrescribe nada del repositorio:
    trabaja siempre dentro de -Path, que debe estar vacío.

.PARAMETER Path
    Carpeta destino. Se crea si no existe y debe estar vacía.

.PARAMETER TargetFramework
    Framework de destino. Por defecto net10.0.

.PARAMETER SkipPackages
    Omite la instalación de paquetes NuGet (útil sin conexión).

.PARAMETER IncludeMauiToolkit
    Añade CommunityToolkit.Maui al proyecto MAUI. Desactivado por defecto:
    el toolkit sigue a la última versión del runtime de MAUI y suele ir por
    delante del workload instalado, lo que provoca un NU1605 (degradación de
    Microsoft.Maui.Controls) que rompe la compilación. Si lo necesitas,
    ejecuta antes 'dotnet workload update'.

.EXAMPLE
    .\New-CourtConnectSolution.ps1 -Path C:\tmp\CourtConnect
#>
[CmdletBinding()]
param(
    [Parameter(Mandatory)][string]$Path,
    [string]$TargetFramework = 'net10.0',
    [switch]$SkipPackages,
    [switch]$IncludeMauiToolkit
)

$ErrorActionPreference = 'Stop'

function Invoke-Step {
    param([string]$Description, [string[]]$Arguments)
    Write-Host "==> $Description" -ForegroundColor Cyan
    & dotnet @Arguments
    if ($LASTEXITCODE -ne 0) {
        throw "Falló '$Description'. dotnet devolvió el código $LASTEXITCODE."
    }
}

# --- Preparación -----------------------------------------------------------
if (-not (Test-Path $Path)) {
    New-Item -ItemType Directory -Path $Path | Out-Null
}
if ((Get-ChildItem -Path $Path -Force | Measure-Object).Count -gt 0) {
    throw "La carpeta '$Path' no está vacía. Elige otra para no pisar nada."
}
Push-Location $Path

try {
    Write-Host "SDK de .NET en uso: $(dotnet --version)" -ForegroundColor DarkGray
    Write-Host "Framework de destino: $TargetFramework" -ForegroundColor DarkGray

    # --- Solución ----------------------------------------------------------
    # Desde el SDK 10 el formato por defecto es .slnx (XML), no .sln.
    Invoke-Step 'Crear la solución' @('new', 'sln', '-n', 'CourtConnect')
    $solution = (Get-ChildItem -Filter 'CourtConnect.sln*' | Select-Object -First 1).Name
    if (-not $solution) { throw 'No se generó ningún fichero de solución.' }
    Write-Host "Solución generada: $solution" -ForegroundColor DarkGray

    # --- Proyectos ---------------------------------------------------------
    $projects = @(
        @{ Template = 'classlib'; Output = 'src/CourtConnect.Domain' }
        @{ Template = 'classlib'; Output = 'src/CourtConnect.Application' }
        @{ Template = 'classlib'; Output = 'src/CourtConnect.Infrastructure' }
        @{ Template = 'classlib'; Output = 'src/CourtConnect.Shared' }
        @{ Template = 'webapi';   Output = 'src/CourtConnect.WebApi' }
        @{ Template = 'mvc';      Output = 'src/CourtConnect.Ui.Web.Mvc' }
        @{ Template = 'xunit';    Output = 'tests/CourtConnect.UnitTests' }
        @{ Template = 'xunit';    Output = 'tests/CourtConnect.IntegrationTests' }
    )
    foreach ($p in $projects) {
        Invoke-Step "Crear $($p.Output)" @('new', $p.Template, '-f', $TargetFramework, '-o', $p.Output)
    }

    # Blazor Web App con interactividad Auto: genera el proyecto servidor y su .Client.
    Invoke-Step 'Crear src/CourtConnect.Ui.Blazor (servidor + cliente WASM)' @(
        'new', 'blazor', '-f', $TargetFramework,
        '-o', 'src/CourtConnect.Ui.Blazor', '-n', 'CourtConnect.Ui.Blazor', '-int', 'Auto')

    Invoke-Step 'Crear src/CourtConnect.Ui.Maui' @(
        'new', 'maui', '-f', $TargetFramework, '-o', 'src/CourtConnect.Ui.Maui')

    # --- Carpetas de solución ----------------------------------------------
    $layout = @(
        @{ Project = 'src/CourtConnect.Domain/CourtConnect.Domain.csproj';                 Folder = 'src\2. Domain' }
        @{ Project = 'src/CourtConnect.Application/CourtConnect.Application.csproj';       Folder = 'src\2. Domain' }
        @{ Project = 'src/CourtConnect.Infrastructure/CourtConnect.Infrastructure.csproj'; Folder = 'src\3. Common' }
        @{ Project = 'src/CourtConnect.Shared/CourtConnect.Shared.csproj';                 Folder = 'src\3. Common' }
        @{ Project = 'src/CourtConnect.WebApi/CourtConnect.WebApi.csproj';                 Folder = 'src\3. Api' }
        @{ Project = 'src/CourtConnect.Ui.Web.Mvc/CourtConnect.Ui.Web.Mvc.csproj';         Folder = 'src\1. Ui' }
        @{ Project = 'src/CourtConnect.Ui.Maui/CourtConnect.Ui.Maui.csproj';               Folder = 'src\1. Ui' }
        @{ Project = 'tests/CourtConnect.UnitTests/CourtConnect.UnitTests.csproj';               Folder = 'tests' }
        @{ Project = 'tests/CourtConnect.IntegrationTests/CourtConnect.IntegrationTests.csproj'; Folder = 'tests' }
    )
    foreach ($item in $layout) {
        Invoke-Step "Añadir $($item.Project) a '$($item.Folder)'" @(
            'sln', $solution, 'add', $item.Project, '--solution-folder', $item.Folder)
    }

    # Los proyectos Blazor los localizamos porque el nombre del .Client lo pone la plantilla.
    foreach ($csproj in (Get-ChildItem 'src/CourtConnect.Ui.Blazor' -Recurse -Filter '*.csproj')) {
        $relative = Resolve-Path -Relative $csproj.FullName
        Invoke-Step "Añadir $($csproj.Name) a 'src\1. Ui'" @(
            'sln', $solution, 'add', $relative, '--solution-folder', 'src\1. Ui')
    }

    # --- Referencias entre proyectos ---------------------------------------
    $references = @(
        @{ From = 'src/CourtConnect.Application';    To = 'src/CourtConnect.Domain' }
        @{ From = 'src/CourtConnect.Infrastructure'; To = 'src/CourtConnect.Domain' }
        @{ From = 'src/CourtConnect.Infrastructure'; To = 'src/CourtConnect.Application' }
        @{ From = 'src/CourtConnect.WebApi';         To = 'src/CourtConnect.Application' }
        @{ From = 'src/CourtConnect.WebApi';         To = 'src/CourtConnect.Infrastructure' }
        @{ From = 'src/CourtConnect.Ui.Web.Mvc';     To = 'src/CourtConnect.Application' }
        @{ From = 'src/CourtConnect.Ui.Web.Mvc';     To = 'src/CourtConnect.Infrastructure' }
        @{ From = 'src/CourtConnect.Ui.Maui';        To = 'src/CourtConnect.Shared' }
        @{ From = 'tests/CourtConnect.UnitTests';    To = 'src/CourtConnect.Domain' }
        @{ From = 'tests/CourtConnect.UnitTests';    To = 'src/CourtConnect.Application' }
        @{ From = 'tests/CourtConnect.IntegrationTests'; To = 'src/CourtConnect.Infrastructure' }
    )
    foreach ($r in $references) {
        $from = (Get-ChildItem $r.From -Filter '*.csproj' | Select-Object -First 1).FullName
        $to = (Get-ChildItem $r.To -Filter '*.csproj' | Select-Object -First 1).FullName
        Invoke-Step "Referencia $($r.From) -> $($r.To)" @('add', $from, 'reference', $to)
    }

    # --- Paquetes NuGet ----------------------------------------------------
    # Sin versión fija: se resuelve la última estable compatible con $TargetFramework.
    if (-not $SkipPackages) {
        $packages = @(
            @{ Project = 'src/CourtConnect.Infrastructure'; Name = 'Microsoft.EntityFrameworkCore' }
            @{ Project = 'src/CourtConnect.Infrastructure'; Name = 'Microsoft.EntityFrameworkCore.SqlServer' }
            @{ Project = 'src/CourtConnect.Infrastructure'; Name = 'Microsoft.EntityFrameworkCore.Tools' }
            @{ Project = 'src/CourtConnect.Infrastructure'; Name = 'Microsoft.Data.SqlClient' }
            @{ Project = 'src/CourtConnect.Infrastructure'; Name = 'Dapper' }
            @{ Project = 'src/CourtConnect.WebApi';         Name = 'NLog.Web.AspNetCore' }
            @{ Project = 'src/CourtConnect.Ui.Web.Mvc';     Name = 'NLog.Web.AspNetCore' }
            @{ Project = 'src/CourtConnect.Ui.Maui';        Name = 'CommunityToolkit.Mvvm' }
            @{ Project = 'tests/CourtConnect.UnitTests';    Name = 'Moq' }
            @{ Project = 'tests/CourtConnect.UnitTests';    Name = 'coverlet.collector' }
            @{ Project = 'tests/CourtConnect.IntegrationTests'; Name = 'Microsoft.AspNetCore.Mvc.Testing' }
            @{ Project = 'tests/CourtConnect.IntegrationTests'; Name = 'coverlet.collector' }
        )
        if ($IncludeMauiToolkit) {
            $packages += @{ Project = 'src/CourtConnect.Ui.Maui'; Name = 'CommunityToolkit.Maui' }
        }
        foreach ($pkg in $packages) {
            $csproj = (Get-ChildItem $pkg.Project -Filter '*.csproj' | Select-Object -First 1).FullName
            Invoke-Step "Paquete $($pkg.Name) en $($pkg.Project)" @('add', $csproj, 'package', $pkg.Name)
        }
    }

    Write-Host ''
    Write-Host 'Solución generada correctamente.' -ForegroundColor Green
    Write-Host "Siguiente paso: dotnet build $solution" -ForegroundColor Green
}
finally {
    Pop-Location
}
