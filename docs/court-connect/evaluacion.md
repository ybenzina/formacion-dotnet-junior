# Evaluación del reto CourtConnect

La pregunta que responde la evaluación es una sola: **¿puede Driss supervisar código .NET generado por una IA en estas tecnologías?**

## 1. Rúbrica por tecnología

Yamel la completa en cada demo, a partir de las preguntas de «explícame esta pieza».

| Nivel | Significa |
|---|---|
| 1 | No la reconoce |
| 2 | La reconoce y sabe para qué sirve |
| 3 | Explica cómo funciona en su código y detecta errores evidentes |
| 4 | La modifica o la amplía sin ayuda |

**Objetivo del reto: nivel 3 o más en todas.**

| Tecnología | Demo 1 (23/10) | Demo 2 (30/10) | Comentarios |
|---|---|---|---|
| Git, PR y revisión | | | |
| Modelo de dominio y xUnit | | | |
| EF Core y migraciones | | | |
| SQL Server | | | |
| ASP.NET Core (API) | | | |
| Tests de integración | | | |
| GitHub Actions | | | |
| SonarCloud | | | |
| Blazor | — | | |
| Docker y Compose | — | | |
| SDD con Spec Kit | — | | |

## 2. Comprobaciones objetivas

| Comprobación | Semana 7 | Semana 8 |
|---|---|---|
| CI en verde en `main` y obligatoria para fusionar | ☐ | ☐ |
| Quality gate superado y bloqueante: job de CI y `SonarCloud Code Analysis` obligatorios (umbrales en `calidad.md`) | ☐ | ☐ |
| Cada regla de negocio con al menos un test | ☐ | ☐ |
| Todos los PR con «Uso de IA» y «Comparación con IA» | ☐ | ☐ |
| Arranca desde un clon limpio siguiendo el README | ☐ | ☐ |
| Ningún secreto ni dato real en el repo | ☐ | ☐ |
| Horas reales apuntadas en las issues | ☐ | ☐ |
| Métricas del piloto SDD registradas | — | ☐ |
| PR trampa: al menos 3 de 5 defectos encontrados y explicados | — | ☐ |

## 3. PR trampa (viernes 30)

Yamel prepara, con ayuda de la IA, un PR sobre `court-connect` con unos **5 defectos sembrados**, de tipos como:

- **Regla de negocio:** se puede sobrepasar el número de plazas en algún camino.
- **Seguridad:** un secreto en la configuración, o datos del jugador que salen por la API sin necesidad.
- **Datos:** una consulta que provoca N+1 o carga más de lo necesario.
- **Tests:** un test que siempre pasa o que no comprueba lo que dice.
- **Robustez:** una excepción no controlada o un código HTTP incorrecto.

Driss lo revisa en GitHub como revisor, sin saber cuántos defectos hay. Cuenta como encontrado si señala la línea **y** explica el riesgo.

## 4. Valoración final

Se comenta en la retro del viernes 30, con estas tres preguntas:

1. ¿En qué tecnologías está listo para supervisar código en el proyecto real?
2. ¿Cuáles necesitan refuerzo, y cómo se reforzarán dentro del proyecto?
3. ¿Qué conclusiones del piloto SDD se llevan a la decisión PD-11?
