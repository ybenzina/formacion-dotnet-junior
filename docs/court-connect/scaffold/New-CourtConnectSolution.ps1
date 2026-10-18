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

.PARAMETER ProfileName
    Qué solución generar. Se invoca como -Profile.

    - Reto (por defecto): los 8 proyectos de docs/court-connect/architecture/README.md.
      Carpetas y .csproj sin prefijo de organización (CourtConnect.*, solución
      CourtConnect.slnx); los namespaces y ensamblados quedan como
      DeemSoft.CourtConnect.* a través de Directory.Build.props.
      Blazor Web App en modo Server más una Razor Class Library. Sin MAUI ni MVC.

    - Completo: la propuesta original de 14 semanas, sin prefijo de organización,
      que añadía MVC, Blazor WebAssembly y MAUI.

.PARAMETER TargetFramework
    Framework de destino. Por defecto net10.0.

.PARAMETER SkipPackages
    Omite la instalación de paquetes NuGet (útil sin conexión).

.PARAMETER IncludeMauiToolkit
    Solo para -Profile Completo. Añade CommunityToolkit.Maui al proyecto MAUI.
    Desactivado por defecto: el toolkit sigue a la última versión del runtime de
    MAUI y suele ir por delante del workload instalado, lo que provoca un NU1605
    (degradación de Microsoft.Maui.Controls) que rompe la compilación. Si lo
    necesitas, ejecuta antes 'dotnet workload update'.

.EXAMPLE
    .\New-CourtConnectSolution.ps1 -Path D:\git\CourtConnect

.EXAMPLE
    .\New-CourtConnectSolution.ps1 -Path D:\git\CourtConnect -Profile Completo
#>
[CmdletBinding()]
param(
    [Parameter(Mandatory)][string]$Path,
    # $Profile es una variable automática de PowerShell, de ahí el nombre real
    # distinto del alias con el que se invoca.
    [Alias('Profile')][ValidateSet('Reto', 'Completo')][string]$ProfileName = 'Reto',
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

# --- Definición de los perfiles --------------------------------------------
# Cada proyecto declara su plantilla, su carpeta de salida, la carpeta de
# solución donde se cuelga y, si hace falta, argumentos extra de 'dotnet new'.
$profiles = @{

    Reto = @{
        SolutionName    = 'CourtConnect'
        NamespacePrefix = 'DeemSoft'
        Projects        = @(
            @{ Template = 'classlib';      Dir = 'src/CourtConnect.Domain';         Folder = 'src\2. Domain' }
            @{ Template = 'classlib';      Dir = 'src/CourtConnect.Application';    Folder = 'src\2. Domain' }
            @{ Template = 'classlib';      Dir = 'src/CourtConnect.Infrastructure'; Folder = 'src\4. Infrastructure' }
            @{ Template = 'webapi';        Dir = 'src/CourtConnect.Api';            Folder = 'src\3. Api' }
            @{ Template = 'razorclasslib'; Dir = 'src/CourtConnect.Ui.Components';  Folder = 'src\1. Ui' }
            @{ Template = 'blazor';        Dir = 'src/CourtConnect.Ui.Web';         Folder = 'src\1. Ui'; Args = @('-int', 'Server') }
            @{ Template = 'xunit';         Dir = 'tests/CourtConnect.UnitTests';        Folder = 'tests' }
            @{ Template = 'xunit';         Dir = 'tests/CourtConnect.IntegrationTests'; Folder = 'tests' }
        )
        References      = @(
            @{ From = 'src/CourtConnect.Application';        To = 'src/CourtConnect.Domain' }
            @{ From = 'src/CourtConnect.Infrastructure';     To = 'src/CourtConnect.Domain' }
            @{ From = 'src/CourtConnect.Infrastructure';     To = 'src/CourtConnect.Application' }
            @{ From = 'src/CourtConnect.Api';                To = 'src/CourtConnect.Application' }
            @{ From = 'src/CourtConnect.Api';                To = 'src/CourtConnect.Infrastructure' }
            @{ From = 'src/CourtConnect.Ui.Web';             To = 'src/CourtConnect.Ui.Components' }
            @{ From = 'tests/CourtConnect.UnitTests';        To = 'src/CourtConnect.Domain' }
            @{ From = 'tests/CourtConnect.UnitTests';        To = 'src/CourtConnect.Application' }
            @{ From = 'tests/CourtConnect.IntegrationTests'; To = 'src/CourtConnect.Api' }
        )
        Packages        = @(
            @{ Project = 'src/CourtConnect.Infrastructure';     Name = 'Microsoft.EntityFrameworkCore.SqlServer' }
            @{ Project = 'src/CourtConnect.Infrastructure';     Name = 'Microsoft.EntityFrameworkCore.Tools' }
            @{ Project = 'tests/CourtConnect.UnitTests';        Name = 'coverlet.collector' }
            @{ Project = 'tests/CourtConnect.IntegrationTests'; Name = 'Microsoft.AspNetCore.Mvc.Testing' }
            @{ Project = 'tests/CourtConnect.IntegrationTests'; Name = 'Testcontainers.MsSql' }
            @{ Project = 'tests/CourtConnect.IntegrationTests'; Name = 'coverlet.collector' }
        )
    }

    Completo = @{
        SolutionName = 'CourtConnect'
        Projects     = @(
            @{ Template = 'classlib'; Dir = 'src/CourtConnect.Domain';         Folder = 'src\2. Domain' }
            @{ Template = 'classlib'; Dir = 'src/CourtConnect.Application';    Folder = 'src\2. Domain' }
            @{ Template = 'classlib'; Dir = 'src/CourtConnect.Infrastructure'; Folder = 'src\3. Common' }
            @{ Template = 'classlib'; Dir = 'src/CourtConnect.Shared';         Folder = 'src\3. Common' }
            @{ Template = 'webapi';   Dir = 'src/CourtConnect.WebApi';         Folder = 'src\3. Api' }
            @{ Template = 'mvc';      Dir = 'src/CourtConnect.Ui.Web.Mvc';     Folder = 'src\1. Ui' }
            @{ Template = 'blazor';   Dir = 'src/CourtConnect.Ui.Blazor';      Folder = 'src\1. Ui'; Args = @('-int', 'Auto') }
            @{ Template = 'maui';     Dir = 'src/CourtConnect.Ui.Maui';        Folder = 'src\1. Ui' }
            @{ Template = 'xunit';    Dir = 'tests/CourtConnect.UnitTests';        Folder = 'tests' }
            @{ Template = 'xunit';    Dir = 'tests/CourtConnect.IntegrationTests'; Folder = 'tests' }
        )
        References   = @(
            @{ From = 'src/CourtConnect.Application';        To = 'src/CourtConnect.Domain' }
            @{ From = 'src/CourtConnect.Infrastructure';     To = 'src/CourtConnect.Domain' }
            @{ From = 'src/CourtConnect.Infrastructure';     To = 'src/CourtConnect.Application' }
            @{ From = 'src/CourtConnect.WebApi';             To = 'src/CourtConnect.Application' }
            @{ From = 'src/CourtConnect.WebApi';             To = 'src/CourtConnect.Infrastructure' }
            @{ From = 'src/CourtConnect.Ui.Web.Mvc';         To = 'src/CourtConnect.Application' }
            @{ From = 'src/CourtConnect.Ui.Web.Mvc';         To = 'src/CourtConnect.Infrastructure' }
            @{ From = 'src/CourtConnect.Ui.Maui';            To = 'src/CourtConnect.Shared' }
            @{ From = 'tests/CourtConnect.UnitTests';        To = 'src/CourtConnect.Domain' }
            @{ From = 'tests/CourtConnect.UnitTests';        To = 'src/CourtConnect.Application' }
            @{ From = 'tests/CourtConnect.IntegrationTests'; To = 'src/CourtConnect.Infrastructure' }
        )
        Packages     = @(
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
    }
}

$selected = $profiles[$ProfileName]

# --- Preparación -----------------------------------------------------------
if (-not (Test-Path $Path)) {
    New-Item -ItemType Directory -Path $Path | Out-Null
}
if ((Get-ChildItem -Path $Path -Force | Measure-Object).Count -gt 0) {
    throw "La carpeta '$Path' no está vacía. Elige otra para no pisar nada."
}
Push-Location $Path

try {
    Write-Host "Perfil: $ProfileName" -ForegroundColor DarkGray
    Write-Host "SDK de .NET en uso: $(dotnet --version)" -ForegroundColor DarkGray
    Write-Host "Framework de destino: $TargetFramework" -ForegroundColor DarkGray

    # --- Solución ----------------------------------------------------------
    # Desde el SDK 10 el formato por defecto es .slnx (XML), no .sln.
    Invoke-Step 'Crear la solución' @('new', 'sln', '-n', $selected.SolutionName)
    $solution = (Get-ChildItem -Filter "$($selected.SolutionName).sln*" | Select-Object -First 1).Name
    if (-not $solution) { throw 'No se generó ningún fichero de solución.' }
    Write-Host "Solución generada: $solution" -ForegroundColor DarkGray

    # --- Directory.Build.props ---------------------------------------------
    # Las carpetas y los .csproj van sin el prefijo de organización para acortar
    # las rutas. El prefijo se restituye aquí sobre el valor que el SDK usa por
    # defecto, así que el namespace y el ensamblado siguen siendo DeemSoft.*.
    $prefix = $selected.NamespacePrefix
    if ($prefix) {
        $props = @'
<?xml version="1.0" encoding="utf-8"?>
<Project>

  <!-- El prefijo de organización va aquí y no en cada .csproj. -->
  <PropertyGroup>
    <RootNamespace>__PREFIX__.$(MSBuildProjectName)</RootNamespace>
    <AssemblyName>__PREFIX__.$(MSBuildProjectName)</AssemblyName>
  </PropertyGroup>

  <!-- Analizadores en el código de producción: avisan en local de buena parte
       de lo que luego marcaría el quality gate. -->
  <PropertyGroup Condition="!($(MSBuildProjectName.Contains('Tests')) or $(MSBuildProjectName.Contains('Test')) or $(MSBuildProjectDirectory.Contains('tests')) or $(MSBuildProjectDirectory.Contains('test')))">
    <EnableNETAnalyzers>true</EnableNETAnalyzers>
    <AnalysisLevel>latest</AnalysisLevel>
    <AnalysisMode>All</AnalysisMode>
    <EnforceCodeStyleInBuild>true</EnforceCodeStyleInBuild>
  </PropertyGroup>

  <!-- Desactivados en los tests: su estilo es distinto y no aporta. -->
  <PropertyGroup Condition="$(MSBuildProjectName.Contains('Tests')) or $(MSBuildProjectName.Contains('Test')) or $(MSBuildProjectDirectory.Contains('tests')) or $(MSBuildProjectDirectory.Contains('test'))">
    <EnableNETAnalyzers>false</EnableNETAnalyzers>
    <EnforceCodeStyleInBuild>false</EnforceCodeStyleInBuild>
  </PropertyGroup>

</Project>
'@ -replace '__PREFIX__', $prefix
        Set-Content -Path 'Directory.Build.props' -Value $props -Encoding utf8
        Write-Host "==> Directory.Build.props: namespaces y ensamblados como $prefix.*" -ForegroundColor Cyan
    }

    # --- Proyectos ---------------------------------------------------------
    # Se crean con el nombre completo para que las plantillas escriban ya los
    # namespaces definitivos (y la ruta ./_content/<ensamblado>/ del RCL), y
    # después se renombra el .csproj a la forma corta.
    foreach ($p in $selected.Projects) {
        $shortName = Split-Path $p.Dir -Leaf
        $fullName = if ($prefix) { "$prefix.$shortName" } else { $shortName }
        # $args es variable automática de PowerShell: no se asigna.
        $newArgs = @('new', $p.Template, '-f', $TargetFramework, '-o', $p.Dir, '-n', $fullName)
        if ($p.Args) { $newArgs += $p.Args }
        Invoke-Step "Crear $($p.Dir)" $newArgs

        if ($prefix) {
            foreach ($csproj in (Get-ChildItem $p.Dir -Recurse -Filter "$prefix.*.csproj")) {
                $target = $csproj.Name.Substring($prefix.Length + 1)
                Write-Host "==> Renombrar $($csproj.Name) -> $target" -ForegroundColor Cyan
                Rename-Item -LiteralPath $csproj.FullName -NewName $target
            }
        }
    }

    # --- Carpetas de solución ----------------------------------------------
    # Se descubren los .csproj en lugar de asumir su ruta: algunas plantillas
    # (Blazor con interactividad Auto) generan más de un proyecto por carpeta.
    foreach ($p in $selected.Projects) {
        foreach ($csproj in (Get-ChildItem $p.Dir -Recurse -Filter '*.csproj')) {
            $relative = Resolve-Path -Relative $csproj.FullName
            Invoke-Step "Añadir $($csproj.Name) a '$($p.Folder)'" @(
                'sln', $solution, 'add', $relative, '--solution-folder', $p.Folder)
        }
    }

    # --- Referencias entre proyectos ---------------------------------------
    foreach ($r in $selected.References) {
        $from = (Get-ChildItem $r.From -Filter '*.csproj' | Select-Object -First 1).FullName
        $to = (Get-ChildItem $r.To -Filter '*.csproj' | Select-Object -First 1).FullName
        Invoke-Step "Referencia $($r.From) -> $($r.To)" @('add', $from, 'reference', $to)
    }

    # --- Paquetes NuGet ----------------------------------------------------
    # Sin versión fija: se resuelve la última estable compatible con $TargetFramework.
    if (-not $SkipPackages) {
        $packages = @($selected.Packages)
        if ($IncludeMauiToolkit -and $ProfileName -eq 'Completo') {
            $packages += @{ Project = 'src/CourtConnect.Ui.Maui'; Name = 'CommunityToolkit.Maui' }
        }
        elseif ($IncludeMauiToolkit) {
            Write-Warning "-IncludeMauiToolkit se ignora: el perfil $ProfileName no genera proyecto MAUI."
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
