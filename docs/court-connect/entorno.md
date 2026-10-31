# Entorno de desarrollo del reto

Lo que tienes que instalar en tu ordenador (Windows) para el reto CourtConnect, en orden. Calcula entre 1 y 2 horas, sobre todo por las descargas. Si algo falla, se resuelve **antes del Día 1**: el Día 1 es para el repo y el dominio, no para pelearse con el entorno.

## Requisitos

- Windows 10 22H2 o Windows 11 23H2 o superior, de 64 bits.
- **Virtualización activada** en la BIOS/UEFI. Sin ella, WSL 2 y Docker no arrancan. Se comprueba en el Administrador de tareas → Rendimiento → CPU → «Virtualización: habilitada».
- 8 GB de RAM como mínimo (16 GB van mucho mejor con Docker) y unos 30 GB libres en disco.

## Resumen

| Herramienta | Para qué | Cuándo | Obligatoria |
| --- | --- | --- | --- |
| Git y GitHub CLI (`gh`) | Control de versiones, issues y PR | Día 1 | Sí |
| WSL 2 | Linux dentro de Windows; Docker lo usa por debajo | Antes de Docker | Sí |
| Docker Desktop | Contenedores: SQL Server, Testcontainers, Compose y, más adelante, Aspire | Parte I (Ej. 2) | Sí |
| SDK de .NET 10 | Compilar y ejecutar | Día 1 | Sí |
| VS Code y extensiones recomendadas | Editor principal del reto | Día 1 | Sí |
| Imagen de SQL Server | Base de datos en contenedor | Parte I (Ej. 2) | Sí |
| SSMS 22 | Cliente gráfico de SQL Server | Cuando quieras | No (la extensión mssql de VS Code cubre lo básico) |
| Visual Studio 2026 Community | IDE completo; se compara con VS Code al depurar Blazor | Parte II (extra del Ej. 1) | No |
| SDK de .NET 11 | La migración de la Parte III | Parte III (Ej. 1) | Más adelante |

Algunas herramientas se pueden instalar con `winget` (el gestor de paquetes de Windows) desde una terminal. Donde no se indica, usa el instalador oficial.

## 1. Git y GitHub CLI

1. Instala **Git**: `winget install --id Git.Git -e` o desde [git-scm.com](https://git-scm.com/downloads/win). Con las opciones por defecto del instalador vale.
2. Configúralo:

   ```powershell
   git config --global user.name "Tu nombre"
   git config --global user.email "tu-correo@ejemplo.com"
   git config --global init.defaultBranch main
   git config --global core.autocrlf true
   ```

   `core.autocrlf true` hace que en tu disco los ficheros tengan finales de línea de Windows (CRLF) y en el repo, de Linux (LF). Es como trabajan los repos del reto.
3. Instala **GitHub CLI**: `winget install --id GitHub.cli -e`. Después, `gh auth login` y elige GitHub.com, HTTPS y entrar con el navegador.

Comprueba: `git --version` y `gh auth status`.

## 2. WSL 2

1. Abre una terminal **como administrador** y ejecuta `wsl --install`. Instala WSL 2 y una distribución de Ubuntu.
2. **Reinicia** el ordenador. Al volver, se abre Ubuntu y te pide un usuario y una contraseña de Linux (pueden ser distintos de los de Windows).
3. Actualízalo: `wsl --update`.

Comprueba: `wsl --version` (versión 2.1.5 o superior) y `wsl --list --verbose` (la distribución con `VERSION 2`).

## 3. Docker Desktop

1. Descarga el instalador desde la [página oficial](https://docs.docker.com/desktop/setup/install/windows-install/).
2. Instálalo **para tu usuario** (es la opción por defecto y no pide permisos de administrador), con el motor **WSL 2**, que también es la opción por defecto.
3. Ábrelo y acepta las condiciones. Para uso personal y para empresas pequeñas es gratis (hace falta licencia de pago a partir de 250 empleados o 10 millones de dólares de facturación).
4. Si se cierra al arrancar o dice que no puede iniciar el motor, revisa que la virtualización esté activada y que WSL 2 funcione.

Comprueba:

```powershell
docker version
docker run --rm hello-world
```

### Memoria

Docker usa la memoria de WSL, que por defecto puede llegar a la mitad de la RAM del ordenador. Para que no acapare el equipo, limítala con un fichero `.wslconfig` en tu carpeta de usuario (`%USERPROFILE%\.wslconfig`):

```ini
[wsl2]
# Límite de RAM para la VM de WSL (Docker Desktop incluido)
memory=6GB
# Swap dentro de la VM
swap=4GB
```

Con 6 GB hay de sobra para SQL Server, que necesita al menos 2 GB. Para aplicar el cambio, cierra Docker Desktop, ejecuta `wsl --shutdown` y vuelve a abrirlo. Comprueba la memoria que ve WSL con:

```powershell
wsl -d docker-desktop -u root -e sh -c "free -h"
```

### Si Docker Desktop se cae con el error `0xc00000fd`

**Síntoma:** al descargar una imagen grande (por ejemplo, la de SQL Server), Docker Desktop muestra *«An error occurred while running a WSL command»* con `exit status 0xc00000fd`, el motor se para y `docker` responde *«Docker Desktop is unable to start»*. Con `hello-world` puede funcionar, porque apenas descarga nada.

**Causa:** el archivo de paginación de Windows es demasiado pequeño y el sistema se queda sin memoria virtual. Cuando WSL no puede reservar más, Windows cierra su servicio (`wslservice.exe`) con ese código, que significa *stack overflow*. No es un fallo de Docker ni de la imagen.

**Cómo comprobarlo:**

```powershell
Get-CimInstance Win32_PageFileUsage | Select-Object Name, AllocatedBaseSize
$os = Get-CimInstance Win32_OperatingSystem
"Memoria virtual libre: {0:N1} GB" -f ($os.FreeVirtualMemory/1MB)
```

Si el archivo de paginación es de menos de unos pocos GB o la memoria virtual libre está por debajo de 1 o 2 GB, es esto. En el Visor de eventos (Registros de Windows → Aplicación) verás errores de `wslservice.exe` con el código `0xc00000fd`.

**Solución:**

1. `Win + R` → `sysdm.cpl` → Opciones avanzadas → Rendimiento → Configuración → Opciones avanzadas → Memoria virtual → Cambiar.
2. Marca **Administrar automáticamente el tamaño del archivo de paginación**, o elige un disco interno con espacio y pon **Tamaño personalizado** de 16384 MB inicial y 32768 MB máximo. Pulsa **Establecer** y **Aceptar**.
3. Reinicia si Windows lo pide.
4. Configura también el `.wslconfig` del apartado anterior, cierra Docker Desktop, ejecuta `wsl --shutdown`, ábrelo de nuevo y repite la descarga.

No hace falta reinstalar ni restablecer Docker Desktop: borrarías tus imágenes y volúmenes y el error volvería.

## 4. SDK de .NET 10

1. `winget install --id Microsoft.DotNet.SDK.10 -e`, o el instalador del SDK (no solo el *runtime*) desde [dotnet.microsoft.com](https://dotnet.microsoft.com/download/dotnet/10.0).
2. Cierra y abre la terminal.

Comprueba: `dotnet --list-sdks` muestra una versión `10.0.x`. Si tienes varias, no pasa nada: el `global.json` de cada repo decide cuál se usa.

## 5. VS Code y extensiones

1. Instala **VS Code**: `winget install --id Microsoft.VisualStudioCode -e` o desde [code.visualstudio.com](https://code.visualstudio.com/). Durante la instalación, marca «Agregar a PATH» y «Abrir con Code» en el menú contextual.
2. Abre la carpeta del repo. VS Code propone instalar las **extensiones recomendadas** del repo (`.vscode/extensions.json`): acepta. Si no aparece el aviso, en la vista de extensiones busca `@recommended`.
3. Entra con tu cuenta de GitHub (icono de cuenta, abajo a la izquierda) para usar GitHub Copilot.

Comprueba: abre un fichero `.cs` y mira que C# Dev Kit carga sin errores.

## 6. Imagen de SQL Server

Con Docker Desktop abierto, descárgala ya, porque ocupa más de 1 GB:

```powershell
docker pull mcr.microsoft.com/mssql/server:2022-latest
```

Si durante la descarga Docker Desktop muestra un error de WSL con `0xc00000fd`, mira [«Si Docker Desktop se cae con el error `0xc00000fd`»](#si-docker-desktop-se-cae-con-el-error-0xc00000fd).

Las imágenes de Microsoft están en su propio registro (MCR). Por eso se descargan desde la terminal y no desde el buscador de Docker Desktop. Una vez descargada, aparece en la pestaña «Images».

**No arranques todavía el contenedor:** cómo hacerlo (contraseña de `sa`, puerto y volumen) es parte del ejercicio 2 de la Parte I.

## 7. SSMS 22 (opcional)

SQL Server Management Studio es el cliente gráfico clásico de SQL Server. La extensión mssql de VS Code basta para el reto, pero en las empresas verás SSMS a menudo.

1. Descarga el instalador desde la [página oficial de SSMS](https://learn.microsoft.com/es-es/ssms/install/install). Se instala con el instalador de Visual Studio y pide permisos de administrador.
2. Deja la selección por defecto.

Te conectarás a tu SQL Server en Docker en el ejercicio 2 (servidor `localhost,1433`, autenticación de SQL Server).

## 8. Visual Studio 2026 Community (opcional, Parte II)

El editor del reto es VS Code. Visual Studio es el IDE completo de Microsoft y es habitual en las empresas que trabajan con .NET. En el extra del [ejercicio 1 de la Parte II](../../reto/Parte2/Ejercicio1/README.md) se compara con VS Code al depurar Blazor.

1. Descarga **Visual Studio 2026 Community** desde la [página de descargas](https://visualstudio.microsoft.com/es/downloads/).
2. En el instalador, marca estas **cargas de trabajo**:
   - **Desarrollo de ASP.NET y web.** Es la principal: API, Blazor, herramientas de contenedores y SQL Server Data Tools. En los componentes opcionales de la derecha, marca también **Aspire** si aparece.
   - **Desarrollo de Azure**, para la Parte III (despliegue en Azure). Si no tienes espacio, puede esperar.
   - No hacen falta las de escritorio, móvil, juegos ni C++.
3. Entra con tu cuenta de GitHub para usar GitHub Copilot dentro de Visual Studio. Copilot lee las instrucciones del repo (`.github/copilot-instructions.md`, que apunta a `AGENTS.md`).
4. Claude Code no se integra en Visual Studio: si lo usas, va en la terminal.

Visual Studio instala su propio SDK de .NET. Es normal tener varios: lo decide el `global.json`. No subas al repo la carpeta `.vs/`; el `.gitignore` de la plantilla ya la excluye.

**Licencia:** Community es gratuita para uso individual y para organizaciones pequeñas.

## 9. Más adelante

- **SDK de .NET 11:** se instala al empezar la Parte III, en la migración (ver el [ejercicio 1](../../reto/Parte3/Ejercicio1/README.md)).
- **Herramientas de IA del piloto SDD** (Spec Kit y Claude Code o Copilot): en el ejercicio 5 de la Parte II.
- **CLI de Azure** (`az`): en el ejercicio 4 de la Parte III.

## Comprobación final

Todo esto debería responder sin errores:

```powershell
git --version
gh auth status
wsl --version
docker version
docker run --rm hello-world
dotnet --list-sdks
code --version
docker image ls mcr.microsoft.com/mssql/server
```

Si algo falla, pregunta en Discord con el comando y el mensaje de error completo.
