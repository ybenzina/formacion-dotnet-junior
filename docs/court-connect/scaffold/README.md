# Scaffold de la solución CourtConnect

`New-CourtConnectSolution.ps1` genera la solución base sobre la que se trabajan los ejercicios.

## Uso

```powershell
.\New-CourtConnectSolution.ps1 -Path D:\git\CourtConnect
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
| `-Profile` | `Reto` | Qué solución generar: `Reto` o `Completo`. |
| `-TargetFramework` | `net10.0` | Framework de destino. |
| `-SkipPackages` | desactivado | No instala paquetes NuGet. Útil sin conexión. |
| `-IncludeMauiToolkit` | desactivado | Solo con `-Profile Completo`. Añade `CommunityToolkit.Maui`. Ver la nota más abajo. |

El script se detiene en el primer error, comprobando `$LASTEXITCODE` después de cada llamada a `dotnet`.

> El parámetro se declara internamente como `$ProfileName` con alias `Profile`, porque `$Profile` es una variable automática de PowerShell y no conviene pisarla. En la línea de comandos se usa `-Profile` con normalidad.

## Perfil `Reto` (por defecto)

Materializa la arquitectura de [`../architecture/README.md`](../architecture/README.md). Es deliberadamente simple: ocho proyectos, sin MAUI, sin MVC y sin WebAssembly.

```text
CourtConnect.slnx
Directory.Build.props
├── src
│   ├── 1. Ui
│   │   ├── CourtConnect.Ui.Components   (Razor Class Library)
│   │   └── CourtConnect.Ui.Web          (Blazor Web App, interactividad Server)
│   ├── 2. Domain
│   │   ├── CourtConnect.Domain          (entidades y reglas de negocio)
│   │   └── CourtConnect.Application     (casos de uso, DTOs, interfaces)
│   ├── 3. Api
│   │   └── CourtConnect.Api             (API REST con OpenAPI)
│   └── 4. Infrastructure
│       └── CourtConnect.Infrastructure  (EF Core, repositorios, adaptadores)
└── tests
    ├── CourtConnect.UnitTests
    └── CourtConnect.IntegrationTests
```

### Nombres cortos en disco, prefijados en el código

Las carpetas y los `.csproj` no llevan el prefijo de organización; los namespaces y los ensamblados sí. El prefijo se declara una sola vez, en el `Directory.Build.props` que genera el script:

```xml
<RootNamespace>DeemSoft.$(MSBuildProjectName)</RootNamespace>
<AssemblyName>DeemSoft.$(MSBuildProjectName)</AssemblyName>
```

Es el valor por defecto del SDK con `DeemSoft.` delante, así que `CourtConnect.Domain.csproj` compila a `DeemSoft.CourtConnect.Domain.dll`. Se ahorran 9 caracteres por segmento de ruta, dos veces (carpeta y fichero) más los intermedios de `obj\`, que en Windows no es poco.

Para que esto funcione, el script **crea cada proyecto con el nombre completo y luego renombra el `.csproj`**. No es un rodeo caprichoso: las plantillas escriben el namespace dentro de los ficheros que generan, y la Razor Class Library además incrusta el nombre del ensamblado en la ruta de sus recursos estáticos:

```csharp
"import", "./_content/DeemSoft.CourtConnect.Ui.Components/exampleJsInterop.js"
```

Si se generara directamente con el nombre corto, esa importación apuntaría a un `_content/` que no existe: **no rompe la compilación, rompe en ejecución**.

El perfil `Completo` no lleva prefijo ni `Directory.Build.props`. Si se retoma esa línea, habría que aplicarle la misma convención y volver a verificarla, que con MAUI de por medio no es inmediato.

### Referencias entre proyectos

```text
Application      -> Domain
Infrastructure   -> Domain, Application
Api              -> Application, Infrastructure
Ui.Web           -> Ui.Components
UnitTests        -> Domain, Application
IntegrationTests -> Api
```

La dirección importa. `Domain` no referencia a nadie. Y `Ui.Web` **no** referencia a `Infrastructure`: la web no toca la base de datos, solo habla con la API por HTTP. Si alguien añade esa referencia para "ir más rápido", se carga la decisión de arquitectura del reto.

Los componentes Razor viven en una librería aparte precisamente para que puedan reutilizarse más adelante en WebAssembly o en MAUI Blazor Hybrid sin reescribirlos.

### Paquetes de partida

| Proyecto | Paquetes |
| --- | --- |
| Infrastructure | `Microsoft.EntityFrameworkCore.SqlServer`, `Microsoft.EntityFrameworkCore.Tools` |
| UnitTests | `coverlet.collector` |
| IntegrationTests | `Microsoft.AspNetCore.Mvc.Testing`, `Testcontainers.MsSql`, `coverlet.collector` |

`Testcontainers.MsSql` se incluye porque la arquitectura pide tests de integración contra SQL Server en contenedor. Si prefieres levantar el contenedor con `docker compose` por fuera, quítalo.

No se añade MediatR: el reto usa servicios de aplicación simples. Tampoco hace falta paquete para el reloj inyectable, `TimeProvider` es parte del framework.

## Perfil `Completo`

La propuesta original de 14 semanas: añade MVC, Blazor WebAssembly, MAUI y un proyecto `Shared`. Se conserva por si se retoma esa línea, pero el reto no lo usa.

Usa los mismos nombres cortos en disco, pero **no genera `Directory.Build.props`**, así que sus namespaces y ensamblados se quedan en `CourtConnect.*`, sin el prefijo de organización. Es una inconsistencia conocida: aplicarle la convención obliga a volver a verificar un build con MAUI, que arrastra sus propias pegas de workloads y de longitud de ruta. Se haría si alguna vez se retoma el perfil.

```powershell
.\New-CourtConnectSolution.ps1 -Path D:\git\CourtConnectCompleto -Profile Completo
```

## Cosas que conviene saber

**El formato de solución es `.slnx`.** Desde el SDK 10, `dotnet new sln` genera XML en lugar del `.sln` clásico. Visual Studio 2022 17.14 en adelante lo abre. Si necesitas un `.sln`, conviértelo con `dotnet sln migrate`.

**Las versiones de paquete no están ancladas.** Para un repositorio de formación interesa arrancar siempre con lo último. Si en algún momento se quiere reproducibilidad, el sitio para fijarlas es `Directory.Packages.props` con *Central Package Management*, no el script.

**Si un paquete falla, reintenta.** `dotnet add package` depende de la red y una caída puntual aborta el script. No es un fallo del scaffold; vuelve a lanzarlo sobre una carpeta limpia.

### Solo afectan al perfil `Completo`

**`CommunityToolkit.Maui` está fuera por defecto.** El toolkit sigue a la última versión del runtime de MAUI y suele ir por delante del workload instalado. Con el workload `maui-windows 10.0.20` y `CommunityToolkit.Maui 15.0.1` el build falla con:

```text
error NU1605: Degradación del paquete detectada: Microsoft.Maui.Controls de 10.0.90 a 10.0.20
```

Ejecuta antes `dotnet workload update` y luego usa `-IncludeMauiToolkit`.

**El proyecto MAUI condiciona sus TFM al sistema operativo:** `net10.0-android` siempre, más `ios`/`maccatalyst` fuera de Linux y `windows10.0.19041.0` en Windows. Construirlo entero requiere los workloads correspondientes (`dotnet workload list`).

**Genera la solución en una ruta corta.** El compilador de recursos de Android (`aapt2`) choca con el límite de 260 caracteres de Windows y falla con un error poco descriptivo:

```text
error APT2098: xml_microsoft_maui_essentials_fileprovider_file_paths.xml.flat: error: failed to open file.
error APT2261: file failed to compile.
```

Los intermedios de Android anidan mucho (`obj\Debug\net10.0-android\lp\166\jl\res\xml\...`), así que algo como `D:\git\CourtConnect` va bien y `C:\Users\<usuario>\...\carpeta\muy\profunda` no. Si no puedes acortar la ruta, habilita las rutas largas en Windows (`LongPathsEnabled`).

## Historia

La versión anterior de este scaffold eran tres ficheros en la raíz del repositorio (`create-sln.bat`, `addfiles_to_sln.ps1`, `fix-mauiprogram.ps1`) que dejaron de funcionar:

- Pedían `-f net9.0`, que las plantillas del SDK 10 ya no aceptan.
- Esperaban un `CourtConnect.sln` que `dotnet new sln` ya no genera, así que ningún proyecto llegaba a la solución.
- `addfiles_to_sln.ps1` reescribía el `.sln` como texto generando GUIDs a mano, algo que `dotnet sln add` ya hace bien y que el formato `.slnx` ni siquiera necesita.

El perfil `Reto` se verifica generando, compilando y ejecutando los tests de la solución completa; es lo que se comprueba cuando se toca el script. El perfil `Completo` se verificó así en su momento, pero no después del cambio de nomenclatura.
