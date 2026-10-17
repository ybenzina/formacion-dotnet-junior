# Scaffold de la solución CourtConnect

`New-CourtConnectSolution.ps1` genera la solución base sobre la que se trabajan los ejercicios de las semanas 7 a 14.

## Uso

```powershell
.\New-CourtConnectSolution.ps1 -Path C:\ruta\a\una\carpeta\vacia
```

La carpeta destino debe estar vacía: el script nunca escribe sobre el repositorio. Al terminar:

```powershell
dotnet build CourtConnect.slnx
dotnet test CourtConnect.slnx
```

### Parámetros

| Parámetro | Por defecto | Para qué |
| --- | --- | --- |
| `-Path` | *(obligatorio)* | Carpeta destino, vacía o inexistente. |
| `-TargetFramework` | `net10.0` | Framework de destino. |
| `-SkipPackages` | desactivado | No instala paquetes NuGet. Útil sin conexión. |
| `-IncludeMauiToolkit` | desactivado | Añade `CommunityToolkit.Maui`. Ver la nota más abajo. |

El script se detiene en el primer error, comprobando `$LASTEXITCODE` después de cada llamada a `dotnet`.

## Estructura que genera

Esta es la decisión de diseño que el script materializa; si algún día el script vuelve a quedarse obsoleto, esto es lo que hay que reproducir.

```text
CourtConnect.slnx
├── src
│   ├── 1. Ui
│   │   ├── CourtConnect.Ui.Blazor          (Blazor Web App, interactividad Auto)
│   │   ├── CourtConnect.Ui.Blazor.Client   (cliente WebAssembly, lo crea la plantilla)
│   │   ├── CourtConnect.Ui.Maui            (cliente multiplataforma)
│   │   └── CourtConnect.Ui.Web.Mvc         (UI MVC)
│   ├── 2. Domain
│   │   ├── CourtConnect.Domain             (entidades y value objects)
│   │   └── CourtConnect.Application        (casos de uso, DTOs, interfaces)
│   ├── 3. Api
│   │   └── CourtConnect.WebApi             (API REST)
│   └── 3. Common
│       ├── CourtConnect.Infrastructure     (EF Core, repositorios, adaptadores)
│       └── CourtConnect.Shared             (contratos compartidos con los clientes)
└── tests
    ├── CourtConnect.UnitTests
    └── CourtConnect.IntegrationTests
```

### Referencias entre proyectos

```text
Application      -> Domain
Infrastructure   -> Domain, Application
WebApi           -> Application, Infrastructure
Ui.Web.Mvc       -> Application, Infrastructure
Ui.Maui          -> Shared
UnitTests        -> Domain, Application
IntegrationTests -> Infrastructure
```

La dirección importa: `Domain` no referencia a nadie, y nada de `src/1. Ui` entra en `Domain`. Es lo que permite el refactor a Vertical Slice de la semana 11 sin tocar las UIs.

### Paquetes de partida

Se instalan sin versión fija, resolviendo la última estable compatible con el framework de destino.

| Proyecto | Paquetes |
| --- | --- |
| Infrastructure | `Microsoft.EntityFrameworkCore`, `.SqlServer`, `.Tools`, `Microsoft.Data.SqlClient`, `Dapper` |
| WebApi, Ui.Web.Mvc | `NLog.Web.AspNetCore` |
| Ui.Maui | `CommunityToolkit.Mvvm` |
| UnitTests | `Moq`, `coverlet.collector` |
| IntegrationTests | `Microsoft.AspNetCore.Mvc.Testing`, `coverlet.collector` |

## Cosas que conviene saber

**El formato de solución es `.slnx`.** Desde el SDK 10, `dotnet new sln` genera XML en lugar del `.sln` clásico. Visual Studio 2022 17.14 en adelante lo abre. Si necesitas un `.sln`, conviértelo con `dotnet sln migrate`.

**`CommunityToolkit.Maui` está fuera por defecto.** El toolkit sigue a la última versión del runtime de MAUI y suele ir por delante del workload instalado. Con el workload `maui-windows 10.0.20` y `CommunityToolkit.Maui 15.0.1` el build falla con:

```text
error NU1605: Degradación del paquete detectada: Microsoft.Maui.Controls de 10.0.90 a 10.0.20
```

Si lo necesitas para la semana 12, ejecuta antes `dotnet workload update` y luego usa `-IncludeMauiToolkit`.

**El proyecto MAUI multiplataforma condiciona sus TFM al sistema operativo:** `net10.0-android` siempre, más `ios`/`maccatalyst` fuera de Linux y `windows10.0.19041.0` en Windows. Construirlo entero requiere los workloads correspondientes (`dotnet workload list`).

**Genera la solución en una ruta corta.** El compilador de recursos de Android (`aapt2`) choca con el límite de 260 caracteres de Windows y falla con un error poco descriptivo:

```text
error APT2098: xml_microsoft_maui_essentials_fileprovider_file_paths.xml.flat: error: failed to open file.
error APT2261: file failed to compile.
```

Los intermedios de Android anidan mucho (`obj\Debug\net10.0-android\lp\166\jl\res\xml\...`), así que algo como `D:\git\CourtConnect` va bien y `C:\Users\<usuario>\...\carpeta\muy\profunda` no. Si no puedes acortar la ruta, habilita las rutas largas en Windows (`LongPathsEnabled`).

**Las versiones de paquete no están ancladas.** Para un repositorio de formación interesa arrancar siempre con lo último. Si en algún momento se quiere reproducibilidad, el sitio para fijarlas es `Directory.Packages.props` con *Central Package Management*, no el script.

## Historia

La versión anterior de este scaffold eran tres ficheros en la raíz del repositorio (`create-sln.bat`, `addfiles_to_sln.ps1`, `fix-mauiprogram.ps1`) que dejaron de funcionar:

- Pedían `-f net9.0`, que las plantillas del SDK 10 ya no aceptan.
- Esperaban un `CourtConnect.sln` que `dotnet new sln` ya no genera, así que ningún proyecto llegaba a la solución.
- `addfiles_to_sln.ps1` reescribía el `.sln` como texto generando GUIDs a mano, algo que `dotnet sln add` ya hace bien y que el formato `.slnx` ni siquiera necesita.

Se sustituyeron por este script, que se verificó generando y compilando la solución completa.
