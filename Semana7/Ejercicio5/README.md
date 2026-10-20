# Ejercicio 5 — SonarCloud y demo 1

**Viernes 23 de octubre · unas 4 h** · Issue: «S7 · Ej5 · SonarCloud y demo 1»

## Objetivo

Añadir análisis de calidad y cobertura a la CI, dejar el código limpio y presentar lo hecho en la semana.

## Antes de empezar (≈ 30 min)

Conceptos nuevos de hoy (en el [glosario](../../docs/court-connect/glosario.md)): **quality gate**, **cobertura**, **duplicación**, **code smell** y **security hotspot**.

Lectura: [`docs/court-connect/calidad.md`](../../docs/court-connect/calidad.md) entero, sobre todo «Son dos checks, no uno».

## Pasos

### 1. SonarCloud en la CI (≈ 1 h 30 min) — rama `chore/sonarcloud`

- En SonarCloud (SonarQube Cloud), dentro de la organización de DeemSoft, importa `court-connect` y elige el análisis **con GitHub Actions** (desactiva el análisis automático).
- Guarda el token como secreto `SONAR_TOKEN` del repo, y la organización y la clave del proyecto como **variables** (`SONAR_ORGANIZATION`, `SONAR_PROJECT_KEY`). Así, si el repo cambia de dueño, el workflow no se toca.
- Añade al workflow el escáner de SonarCloud para .NET y la cobertura con coverlet en formato OpenCover. Referencia: `.github/workflows/build.yml` de este repo. Fíjate en lo que tiene escrito a mano y no lo copies así.

- Excluye del análisis solo el código generado (`**/Migrations/**`) y justifica en el PR cualquier otra exclusión.
- Haz que el gate **bloquee**: añade al ruleset de `main` los **dos** checks obligatorios, el job de tu workflow y `SonarCloud Code Analysis` (lo publica la app de SonarQube Cloud). El job de la CI puede salir en verde aunque el gate falle: no espera al veredicto. Lee el apartado «Son dos checks, no uno» de `calidad.md`.
- Lee [`docs/court-connect/calidad.md`](../../docs/court-connect/calidad.md).

### 2. Limpiar issues (≈ 1 h)

- Revisa los issues del análisis. Corrige los de severidad alta y media. Los que decidas no corregir, justifícalos en el PR.
- Revisa los security hotspots y márcalos con una explicación.
- El **quality gate** tiene que quedar superado.
- **Antes de darlo por cerrado, pasa también la revisión de dependencias** que aprendiste el martes: `dotnet list package --vulnerable --include-transitive` sobre la solución entera, no solo sobre un proyecto. El gate no cubre esto (ver «Lo que el gate no mira» en `calidad.md`), así que un gate en verde con un paquete vulnerable dentro sigue siendo un problema. Si aparece algo nuevo, arréglalo o justifícalo en el PR.

### 3. Preparar la demo y la retro (≈ 1 h 30 min)

- Clona el repo en una carpeta nueva y sigue tu README desde cero. Si algo no funciona, el README está mal: corrígelo.
- Escribe en `docs/learning/retro.md`: qué ha ido bien, qué ha costado, qué has aprendido de cada tecnología y qué harías distinto.
- Demo con Yamel (30 min): ver [`Semana7/README.md`](../README.md#demo-del-viernes).

## Criterios de aceptación

- [ ] Análisis de SonarCloud en cada PR, con cobertura.
- [ ] Quality gate **Sonar way** superado: fiabilidad, seguridad y mantenibilidad A, cobertura del código nuevo ≥ 80 %, duplicación ≤ 3 %, hotspots revisados al 100 %.
- [ ] Los dos checks (job de la CI y `SonarCloud Code Analysis`) son obligatorios en el ruleset: un PR que no supera el gate no se puede fusionar (pruébalo con un PR de prueba y ciérralo).
- [ ] **Recuerda:** la Action en verde no basta. El ejercicio está aceptado cuando **también** `SonarCloud Code Analysis` está en verde.
- [ ] Sin la organización ni la clave del proyecto escritas a mano en el workflow.
- [ ] Revisión de dependencias de la solución pasada, con el resultado anotado en el PR.
- [ ] README que permite arrancar todo desde un clon limpio.
- [ ] Retro escrita.

## Preguntas para la demo

- El quality gate dice «cobertura del código nuevo ≥ 80 %». ¿Qué es «código nuevo» en un PR y qué significa exactamente ese 80 %? ¿Un 100 % de cobertura garantiza que no hay errores?
- Si en un PR falla el job de la CI, ¿qué buscas? ¿Y si falla `SonarCloud Code Analysis`?
- Elige un issue de Sonar que hayas corregido: ¿qué riesgo tenía?
- Con el quality gate en verde, ¿puedes afirmar que la aplicación no tiene vulnerabilidades conocidas? ¿Por qué?

## Comparación con IA

Pide a la IA que revise uno de los issues que decidiste no corregir. ¿Te convence su opinión?

## Recursos

- [SonarQube Cloud con GitHub Actions](https://docs.sonarsource.com/sonarqube-cloud/advanced-setup/ci-based-analysis/github-actions-for-sonarcloud/)
- [Cobertura de código en .NET](https://learn.microsoft.com/es-es/dotnet/core/testing/unit-testing-code-coverage)
