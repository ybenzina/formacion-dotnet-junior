---
name: Añadir workflow CI (.NET build & test)
about: Crear un GitHub Actions workflow que ejecute dotnet restore/build/test para PRs contra main
title: 'CI: Añadir workflow .NET (build & test)'
labels: ['Semana2','CI','Infra']
---

**Objetivo**: Añadir un workflow de GitHub Actions que valide automáticamente `dotnet restore`, `dotnet build` y `dotnet test` en cada PR hacia `main`.

## Pasos propuestos
1. Crear rama a partir de `main`: `ci/dotnet-test`
2. Añadir fichero `.github/workflows/dotnet.yml` con el workflow (ver `docs/Guia-CI.md`)
3. Commit & push de la rama
4. Abrir PR: `ci/dotnet-test` → `main`
5. Esperar checks verdes y, si pasan, mergear la PR

## Checklist
- [ ] Rama `ci/dotnet-test` creada
- [ ] `.github/workflows/dotnet.yml` añadido
- [ ] PR abierto con la plantilla de PR (incluir salida de `dotnet test` local)
- [ ] Logs de workflow revisados (checks verificados)

## Notas
- Usa en `actions/setup-dotnet` la misma versión del SDK que el `TargetFramework` de los proyectos. Si el repo tiene un `global.json`, mejor que el workflow lo lea (`global-json-file: global.json`) en lugar de repetir la versión.
- Si el workflow falla por binarios comiteados, elimina `bin/` y `obj/` con `git rm --cached` y vuelve a commitear.
