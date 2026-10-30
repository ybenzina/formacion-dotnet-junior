# Issues del reto — para crear en `court-connect`

- **Driss** crea a mano la issue del **Ejercicio 1 de la Parte I** nada más crear el repo (es parte de la práctica).
- **Claude Code** crea el resto con `gh` cuando el primer PR esté fusionado: etiquetas, milestones e issues de esta lista.
- Todas usan la plantilla «Tarea». Enunciado completo en `formacion-dotnet-junior`.

## Etiquetas

| Nombre | Color | Descripción |
|---|---|---|
| `reto` | `#1f6feb` | Reto de formación CourtConnect |
| `parte-1` | `#8250df` | Parte I · Fundamentos |
| `parte-2` | `#bf3989` | Parte II · Web, identidad y contenedores |
| `parte-3` | `#0969da` | Parte III · MVP con SDD |
| `sdd` | `#d29922` | Funcionalidad con Spec-Driven Development |
| `extra` | `#6e7781` | Opcional, solo si sobra tiempo |

## Milestones

| Título | Vence | Descripción |
|---|---|---|
| Reto · Parte I | 2026-10-30 | Fundamentos: del dominio a la API con CI |
| Reto · Parte II | 2026-11-11 | Web, identidad y contenedores |
| Reto · Parte III | 2026-11-20 | MVP con SDD y despliegue en Azure |

## Issues

| # | Título | Etiquetas | Milestone | Estimación | Enunciado |
|---|---|---|---|---|---|
| 1 | `[Tarea] P1 · Ej1 · Repositorio y dominio` | reto, parte-1 | Parte I | 4 h | `reto/Parte1/Ejercicio1` |
| 2 | `[Tarea] P1 · Ej2 · EF Core y SQL Server en Docker` | reto, parte-1 | Parte I | 4 h | `reto/Parte1/Ejercicio2` |
| 3 | `[Tarea] P1 · Ej3 · API con ASP.NET Core` | reto, parte-1 | Parte I | 4 h | `reto/Parte1/Ejercicio3` |
| 4 | `[Tarea] P1 · Ej4 · Tests de integración y CI` | reto, parte-1 | Parte I | 4 h | `reto/Parte1/Ejercicio4` |
| 5 | `[Tarea] P1 · Ej5 · SonarCloud y demo 1` | reto, parte-1 | Parte I | 4 h | `reto/Parte1/Ejercicio5` |
| 6 | `[Tarea] P2 · Ej1 · Web con Blazor` | reto, parte-2 | Parte II | 6 h | `reto/Parte2/Ejercicio1` |
| 7 | `[Tarea] P2 · Ej2 · Cuentas, login y roles` | reto, parte-2 | Parte II | 7 h | `reto/Parte2/Ejercicio2` |
| 8 | `[Tarea] P2 · Ej3 · Panel del organizador` | reto, parte-2 | Parte II | 6 h | `reto/Parte2/Ejercicio3` |
| 9 | `[Tarea] P2 · Ej4 · Docker y Docker Compose` | reto, parte-2 | Parte II | 4 h | `reto/Parte2/Ejercicio4` |
| 10 | `[Tarea] P2 · Ej5 · Demo 2 y preparación del SDD` | reto, parte-2 | Parte II | 5 h | `reto/Parte2/Ejercicio5` |
| 11 | `[Tarea] P3 · Ej1 · .NET 11 y SDD (1/2): especificación` | reto, parte-3, sdd | Parte III | 8 h | `reto/Parte3/Ejercicio1` |
| 12 | `[Tarea] P3 · Ej2 · SDD (2/2): implementación y revisión` | reto, parte-3, sdd | Parte III | 7 h | `reto/Parte3/Ejercicio2` |
| 13 | `[Tarea] P3 · Ej3 · Segunda funcionalidad SDD` | reto, parte-3, sdd | Parte III | 4 h | `reto/Parte3/Ejercicio3` |
| 14 | `[Tarea] P3 · Ej4 · Despliegue en Azure` | reto, parte-3 | Parte III | 5 h | `reto/Parte3/Ejercicio4` |
| 15 | `[Tarea] P3 · Ej5 · PR trampa y demo final` | reto, parte-3 | Parte III | 4 h | `reto/Parte3/Ejercicio5` |

Las issues de las partes II y III se crean al empezar cada parte, por si cambian los enunciados.

## Cuerpo de cada issue

Mismo esquema para todas, rellenando con los datos del enunciado:

```markdown
## Objetivo
<Objetivo del enunciado, en una o dos frases>

Enunciado completo: `formacion-dotnet-junior` → `<ParteN/EjercicioM>/README.md`

## Entregable
<Lista «Criterios de aceptación» del enunciado, como casillas>

## Checklist
- [ ] Rama creada desde `main` actualizado
- [ ] Hecho primero sin IA; comparado después (sección «Comparación con IA» del PR)
- [ ] Tests incluidos con los casos del enunciado (si hay código)
- [ ] Quality gate superado (desde P1 · Ej5)
- [ ] PR con «Qué / Por qué / Cómo se ha comprobado / Uso de IA» y `Closes #N`

## Estimación
Horas estimadas: <según la tabla> · Horas reales:
```
