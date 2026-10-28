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

| Tecnología | Demo 1 (Día 8) | Demo 2 (Día 16) | Demo final (Día 23) | Comentarios |
|---|---|---|---|---|
| Git, PR y revisión | | | | |
| Modelo de dominio y xUnit | | | | |
| EF Core y migraciones | | | | |
| SQL Server | | | | |
| ASP.NET Core (API) e inyección de dependencias | | | | |
| Tests de integración | | | | |
| GitHub Actions | | | | |
| SonarCloud | | | | |
| Blazor (modos de render) | — | | | |
| Identity, autenticación y autorización | — | | | |
| Docker y Compose | — | | | |
| SDD con Spec Kit y revisión de código generado | — | — | | |
| *Slices* verticales y `BackgroundService` | — | — | | |
| Azure Container Apps y Azure SQL | — | — | | |
| Vocabulario profesional (usa los términos del glosario al explicar) | | | | |

## 2. Comprobaciones objetivas

| Comprobación | Parte I | Parte II | Parte III |
|---|---|---|---|
| CI en verde en `main` y obligatoria para fusionar | ☐ | ☐ | ☐ |
| Quality gate superado y bloqueante: job de CI y `SonarCloud Code Analysis` obligatorios (umbrales en `calidad.md`) | ☐ | ☐ | ☐ |
| Cada regla de negocio con al menos un test | ☐ | ☐ | ☐ |
| Todos los PR con «Uso de IA» y «Comparación con IA» (o «Hallazgos de la revisión» en SDD) | ☐ | ☐ | ☐ |
| Arranca desde un clon limpio siguiendo el README | ☐ | ☐ | ☐ |
| Ningún secreto ni dato real en el repo | ☐ | ☐ | ☐ |
| Horas reales apuntadas en las issues | ☐ | ☐ | ☐ |
| `docs/discovery.md` con lo que dijo su grupo | ☐ | — | — |
| R7 y R8 probadas con tests de integración | — | ☐ | ☐ |
| Métricas del piloto SDD registradas (las dos funcionalidades) | — | — | ☐ |
| MVP desplegado en Azure, sin costes inesperados | — | — | ☐ |
| PR trampa: al menos 4 de 7 defectos encontrados y explicados | — | — | ☐ |

## 3. PR trampa (Día 23)

Yamel prepara, con ayuda de la IA, un PR sobre `court-connect` con unos **7 defectos sembrados**, de tipos como estos (alineados con los riesgos del proyecto real):

- **Inyección de dependencias:** un servicio registrado como Singleton que usa el `DbContext` (dependencia cautiva).
- **Autorización (IDOR):** un endpoint que devuelve o modifica la inscripción de otro jugador sin comprobar el dueño.
- **Datos personales:** un log que escribe el correo o la fecha de nacimiento del jugador.
- **Secretos:** una cadena de conexión con contraseña en `appsettings.json`.
- **Datos:** una consulta N+1 en el listado de partidos.
- **Regla de negocio:** una confirmación de pago que no es idempotente.
- **Tests:** un test sin aserciones que solo infla la cobertura.

Driss lo revisa en GitHub como revisor, sin saber cuántos defectos hay. Cuenta como encontrado si señala la línea **y** explica el riesgo.

## 4. Valoración final

Se comenta en la retro final del Día 23, con estas tres preguntas:

1. ¿En qué tecnologías está listo para supervisar código en el proyecto real?
2. ¿Cuáles necesitan refuerzo, y cómo se reforzarán dentro del proyecto?
3. ¿Qué conclusiones del piloto SDD se llevan a la decisión PD-11?
