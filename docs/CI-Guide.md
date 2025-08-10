# Guía: Añadir CI básica (.NET build & test) — Semana 2

**Objetivo:** Añadir un workflow de GitHub Actions que ejecute `dotnet restore`, `dotnet build` y `dotnet test` en cada PR contra `main`.
**Branch de trabajo sugerida:** `ci/dotnet-test`

---

## 1. Crear la rama y el archivo del workflow

Desde tu entorno local:

```bash
# partir de main actualizado
git checkout main
git pull origin main

# crear rama para la CI
git checkout -b ci/dotnet-test
```

Crear la carpeta y el archivo:

```bash
mkdir -p .github/workflows
```

Crea el fichero `.github/workflows/dotnet.yml` con el contenido (ver "Contenido del workflow" abajo). Luego:

```bash
git add .github/workflows/dotnet.yml
git commit -m "ci: add GitHub Actions workflow for build & test"
git push -u origin ci/dotnet-test
```

---

## 2. Abrir el Pull Request (PR)

En GitHub: crea PR de `ci/dotnet-test` → `main`.
En la descripción del PR pega la **Plantilla de PR** (ver sección "Plantilla PR" abajo).

---

## 3. Verificar ejecución del workflow

- Abre la pestaña **Checks** o **Actions** de la PR.
- Espera a que los jobs terminen; si fallan, abre los logs para ver el error (clic en el job → View logs).
- Si el workflow pasa (checks verdes), mergea la PR **antes** de mergear otros PRs de código.

---

## 4. Ejecutar localmente (recomendado antes de abrir PR)

En tu máquina con el SDK instalado:

```bash
dotnet restore
dotnet build --configuration Release
dotnet test --configuration Release
```

Copia la salida del `dotnet test` (texto o captura) y pégala en la descripción del PR si todo pasa.

---

## Contenido del workflow (pegar en `.github/workflows/dotnet.yml`)

```yaml
name: .NET CI

on:
  push:
    branches: [ main ]
  pull_request:
    branches: [ main ]

jobs:
  build-and-test:
    runs-on: ubuntu-latest
    steps:
      - name: Checkout repository
        uses: actions/checkout@v4

      - name: Setup .NET SDK
        uses: actions/setup-dotnet@v3
        with:
          dotnet-version: '8.0.x' # Cambiar a '9.0.x' si queréis usar .NET 9

      - name: Restore dependencies
        run: dotnet restore

      - name: Build
        run: dotnet build --no-restore --configuration Release

      - name: Run tests
        run: dotnet test --no-build --configuration Release --verbosity normal
```

---

## Plantilla PR (copiar en la descripción del PR)

```
## Objetivo del PR
Añadir workflow CI: build y tests automáticos.

## Cambios
- Añadido `.github/workflows/dotnet.yml`

## Comprobaciones locales realizadas
- [ ] `dotnet restore` OK
- [ ] `dotnet build` OK
- [ ] `dotnet test` OK (adjuntar salida o captura)

## Notas
- SDK usado en CI: .NET 8 (actions/setup-dotnet@v3 con '8.0.x').
- Si los proyectos apuntan a otra versión (net9.0), actualizar `dotnet-version`.
```
