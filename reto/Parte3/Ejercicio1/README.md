# Ejercicio 1 — SDD (1/2): especificar torneos y pago

**Días 17 y 18 · estimación: 6 h 30 min** · Issue: «P3 · Ej1 · SDD (1/2): especificación»

## Objetivo

Especificar con GitHub Spec Kit la funcionalidad **torneos con pago simulado y caducidad** (ver el [enunciado del dominio](../../../docs/court-connect/enunciado-dominio.md#parte-iii--torneos-y-pago-con-sdd)), hasta que la especificación sea tan clara que la IA no tenga que inventarse nada.

## Antes de empezar (≈ 30 min)

Conceptos nuevos (añádelos al glosario): **constitución**, **especificación**, **plan técnico**, **slice vertical**, **`BackgroundService`** e **idempotencia**. Repasa lo que viste en la masterclass de arquitectura sobre *slices*.

## Pasos

### 0. Rama de integración (≈ 30 min)

Desde hoy se trabaja con el flujo de la Parte III (ver el [README de la parte](../README.md#flujo-de-ramas-desde-la-parte-iii)):

- Etiqueta el estado actual de `main` como **`v0.1.0`** (el MVP de las partes I y II) y crea **`develop`** a partir de esa etiqueta.
- Ruleset para `develop`: PR obligatorio con 1 aprobación, los dos checks obligatorios (CI y `SonarCloud Code Analysis`) y sin *force push*. En `main` se mantiene el que ya tienes; a `main` solo llegan PR desde `develop` o `hotfix/*` (por convención: GitHub no lo restringe).
- Permite también *squash merge* en los ajustes del repo.
- La CI se ejecuta también en los PR y push a `develop`.

Rama `feature/sdd-torneos`, **creada desde `develop`**.

### 1. Inicializar Spec Kit (≈ 30 min)

- Spec Kit inicializado en `court-connect` con la herramienta elegida en la Parte II.
- Comprueba que respeta `AGENTS.md` como fuente única de instrucciones.

### 2. Constitución (≈ 1 h 30 min)

La constitución son las reglas que la IA tiene que seguir siempre. Tiene que ser coherente con `AGENTS.md` y con [`calidad.md`](../../../docs/court-connect/calidad.md). Como mínimo:

- El código nuevo se organiza en **slices verticales**: una carpeta por caso de uso (por ejemplo, `Features/Tournaments/RegisterTeam/`) con su petición, su *handler*, su validación y sus tests. Los *handlers* son clases normales que se inyectan: **sin MediatR** ni otro mediador.
- Las reglas de negocio van en el dominio, con tests.
- Tests suficientes para el quality gate (cobertura ≥ 80 % del código nuevo).
- Seguridad: las reglas R7 y R8 aplican también a torneos (solo el capitán inscribe y paga por su equipo).
- Datos mínimos y siempre ficticios.

### 3. Especificación (≈ 3 h)

- Especificación de la funcionalidad en `specs/`, con las aclaraciones resueltas. Tiene que responder, entre otras:
  - ¿Cuánto tiempo retiene la plaza una inscripción pendiente, y de dónde sale ese valor?
  - ¿Quién o qué hace caducar las inscripciones vencidas? (Pista: un **`BackgroundService`** que se ejecuta cada cierto tiempo, con `TimeProvider` para poder probarlo.)
  - ¿Qué pasa si el pago se confirma justo cuando la inscripción caduca?
  - ¿Qué significa exactamente que confirmar dos veces el mismo pago «no tenga efectos»?
  - ¿Qué equipos cuentan para el número máximo: los confirmados o también los pendientes?
- **Yamel revisa y aprueba la especificación antes de pasar al plan.**

### 4. Métricas (≈ 15 min)

- Primera parte de `docs/sdd/sdd-piloto.md`: horas y consumo de IA de esta fase.

## Criterios de aceptación

- [ ] `v0.1.0` etiquetada; `develop` creada, protegida y con la CI activa.
- [ ] Spec Kit inicializado y coherente con `AGENTS.md`.
- [ ] Constitución con slices, tests, seguridad y datos mínimos.
- [ ] Especificación aprobada por Yamel, sin aclaraciones pendientes.
- [ ] Métricas de la fase registradas.

## Preguntas para la demo

- ¿Qué hay ahora en `main` y qué en `develop`? ¿Por qué una rama de funcionalidad ya no va directa a `main`?
- ¿Qué diferencia hay entre la constitución y la especificación?
- ¿Qué pregunta de la especificación te hizo cambiar de idea al responderla?
- ¿Por qué la caducidad necesita un proceso en segundo plano? ¿Había otra forma?
