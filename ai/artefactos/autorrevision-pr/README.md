# Autorrevisión del PR · check-pr

**v1.0.0 · draft.** Para que Driss revise su PR antes de pedir la revisión de Yamel. Dice **qué falta, no cómo hacerlo**. Pruebas de ejecución pendientes.

## Cuándo usarla

Con el PR del ejercicio ya abierto y antes de pedir revisión. Comprueba los criterios de aceptación del enunciado, la plantilla del PR, la issue y sus horas reales, la rama base, los checks del último commit, el glosario, la retro y algunas señales de riesgo.

**No usar** para resolver el ejercicio ni para saber qué nota saca: no escribe código, no da niveles de la rúbrica y la decisión es de Yamel. No publica, comenta, aprueba ni edita nada en GitHub.

Necesita `gh` autenticado con acceso de lectura al repo del PR (normalmente `DeemSoft/court-connect`) y el enunciado en `formacion-dotnet-junior` (`reto/ParteN/EjercicioM/README.md`), en una carpeta hermana o en GitHub.

## Instalación e invocación

Copia el [skill](v1.0.0/claude/.claude/skills/check-pr/SKILL.md) con su cabecera:

| Motores | Ruta destino | Invocación |
| --- | --- | --- |
| Claude Code y VS Code Local | `.claude/skills/check-pr/SKILL.md` | `/check-pr` |

En `court-connect` llega con la [plantilla del repo](../../../docs/court-connect/plantilla-repo/README.md), junto con `AGENTS.md`, el Día 1. También se instala en `formacion-dotnet-junior`. Solo para el motor **Copilot**, añade el mismo fichero a `.github/skills/check-pr/SKILL.md`; Local lee ambas carpetas, así que no las dupliques para usar Local.

Instala por PR, comprueba [SHA-256](../../README.md#deriva-y-sha-256) y actualiza [el registro](../../REGISTRO.md).

## Cómo se usa

Indica el número o la URL del PR, o deja que use la rama actual: `/check-pr 12`. Si no localiza el enunciado, te pide la ruta o el enlace.

Devuelve la tabla de criterios, el resto de comprobaciones y una lista final **«Antes de pedir revisión»**, de bloqueante a recomendable. Termina con un resumen de una línea para pegar en el PR: «Autorrevisión hecha con `/check-pr` (versión): …».

Si le pides que lo arregle, lista lo que falta y te da pistas, sin código. Los checks pendientes o en rojo no se dan nunca por buenos.

## Pruebas y mejora

Ejecuta [la batería](v1.0.0/pruebas.md) y un caso propio con Claude Code y VS Code Local. Guarda resultados reales. Las mejoras vuelven a esta fuente mediante nueva versión y CHANGELOG.
