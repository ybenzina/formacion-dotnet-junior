# Plantilla y checklist del repositorio `court-connect`

Ficheros para copiar al repo nuevo y pasos para crearlo. Es la primera tarea del reto (Parte I, Ejercicio 1, parte A).

## Ficheros que se copian tal cual

| Fichero | Para qué |
|---|---|
| `AGENTS.md` | Instrucciones para cualquier asistente de IA: contexto del reto y **modo tutor** |
| `CLAUDE.md` | Hace que Claude lea `AGENTS.md` |
| `.github/copilot-instructions.md` | Hace que Copilot lea `AGENTS.md` |
| `.github/pull_request_template.md` | Plantilla de PR con «Uso de IA» |
| `.github/ISSUE_TEMPLATE/tarea.md` | Plantilla de issue de tarea |

Además, copia el `.editorconfig` de la raíz de `formacion-dotnet-junior`.

## Checklist de creación

### En GitHub

- [ ] Crear el repo **`court-connect`** en la organización **DeemSoft**, **público**, con README y `.gitignore` de **VisualStudio**.
- [ ] *Settings → General → Pull Requests*:
  - [ ] Permitir solo **merge commits** (desmarcar squash y rebase). En la Parte III se activará también *squash*, para los PR hacia `develop`.
  - [ ] Activar **Automatically delete head branches**.
- [ ] *Settings → Rules → Rulesets*: crear un ruleset para `main` con:
  - [ ] **Require a pull request before merging**, con 1 aprobación.
  - [ ] **Block force pushes**.
  - [ ] (En el ejercicio 4, cuando la CI funcione) **Require status checks to pass** con el job de la CI.
  - [ ] (En el ejercicio 5, con SonarQube Cloud) añadir también el check **`SonarCloud Code Analysis`**, que es el que dicta el quality gate. Quedan dos checks obligatorios. Ver `docs/court-connect/calidad.md`.
  - Pregunta para tu README: ¿por qué en `ambit-escola` esto no se puede activar y aquí sí?
- [ ] Añadir a Yamel como revisor (si no tiene acceso por la organización).
- [ ] Crear las etiquetas `reto`, `parte-1`, `parte-2`, `parte-3`, `sdd` y `extra`.
- [ ] Crear los milestones **Reto · Parte I**, **Reto · Parte II** y **Reto · Parte III**, con la fecha de vencimiento de los días 8, 16 y 23 según el calendario del reto (`docs/court-connect/calendario.md` en `formacion-dotnet-junior`).

### En local

- [ ] Clonar el repo en una ruta corta (por ejemplo, `E:\git\court-connect`).
- [ ] Rama `chore/estructura-inicial` desde `main`.
- [ ] Copiar los ficheros de esta plantilla y el `.editorconfig`.
- [ ] Completar el `README.md`: qué es, cómo se ejecuta (de momento, «pendiente») y enlace a `docs/domain.md`.
- [ ] Crear `docs/learning/` con un `retro.md` vacío (lo irás completando) y `docs/discovery.md` para las conclusiones de hablar con tu grupo.
- [ ] Copiar `docs/court-connect/glosario.md` de `formacion-dotnet-junior` a `docs/learning/glosario.md` (tu glosario personal).
- [ ] PR hacia `main` con la plantilla. Yamel revisa y fusiona.

## Estructura objetivo del repo al final del reto

```text
court-connect/
├── AGENTS.md  CLAUDE.md  README.md  .editorconfig  .gitignore
├── CourtConnect.slnx  Directory.Build.props  global.json
├── docker-compose.yml
├── .github/  (workflows/, ISSUE_TEMPLATE/, copilot-instructions.md, pull_request_template.md)
├── docs/     (domain.md, discovery.md, learning/, sdd/)
├── specs/    (especificaciones de Spec Kit, Parte III)
├── src/
│   ├── CourtConnect.Domain
│   ├── CourtConnect.Application
│   ├── CourtConnect.Infrastructure
│   ├── CourtConnect.Api
│   ├── CourtConnect.Ui.Components
│   └── CourtConnect.Ui.Web
└── tests/
    ├── CourtConnect.UnitTests
    └── CourtConnect.IntegrationTests
```
