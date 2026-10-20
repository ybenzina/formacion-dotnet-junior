# Parte II · Web, identidad y contenedores — Reto CourtConnect

**Del lunes 2 al miércoles 11 de noviembre de 2026.** Unas 4 horas al día. El proyecto real tiene prioridad: si un día te quita horas, aplica el orden de recorte (más abajo) y avisa en Discord.

## Objetivos de la Parte II

- Construir una web con Blazor que consume la API, eligiendo el **modo de render** de cada página.
- Añadir **cuentas, login y roles**: quién eres lo dice la sesión, no la petición.
- Dar al organizador su **panel** para crear y gestionar partidos.
- Empaquetar la aplicación en contenedores y levantarla entera con Docker Compose.

Es el mismo reparto que tendrá Àmbit: una parte pública y ligera para los usuarios (aquí, los jugadores) y un panel de gestión (aquí, el del organizador).

## Calendario

| Días | Ejercicio | Entregable |
|---|---|---|
| L 2 – M 3 | [Ejercicio 1 — Web con Blazor](Ejercicio1/README.md) | Listado, ficha y formulario de apuntarse desde la web |
| X 4 – J 5 | [Ejercicio 2 — Cuentas, login y roles](Ejercicio2/README.md) | Registro, login, roles y reglas R7 y R8 |
| V 6 – L 9 | [Ejercicio 3 — Panel del organizador](Ejercicio3/README.md) | Crear canchas y partidos, abrir, cerrar y ver apuntados |
| M 10 | [Ejercicio 4 — Docker y Docker Compose](Ejercicio4/README.md) | `docker compose up` levanta todo |
| X 11 | [Ejercicio 5 — Demo 2 y preparación del SDD](Ejercicio5/README.md) | Demo, retro y herramienta de IA del piloto elegida |

Viernes 6: reunión semanal de seguimiento. **Domingo 8:** masterclass de contenedores, Aspire y Azure.

## Reglas

Las mismas de la Parte I ([`Parte1/README.md`](../Parte1/README.md#reglas)): primero tú y después la IA, datos ficticios, horas reales en cada issue y glosario al día.

## Calidad

El quality gate de SonarQube Cloud sigue siendo **bloqueante** en todos los PR. Ver [`docs/court-connect/calidad.md`](../docs/court-connect/calidad.md).

## Orden de recorte

1. Los apartados marcados como **Extra**.
2. Tests de componentes más allá del mínimo.
3. Edición de partidos en el panel (basta con crear, abrir y cerrar).

Lo que **no** se recorta: login y roles con las reglas R7 y R8 probadas, el `HttpClient` tipado con el token, `docker compose up` y el quality gate.

## Demo 2

**Miércoles 11 de noviembre**, unos 30 minutos, desde un clon limpio con `docker compose up`:

1. Registrarse como jugador, entrar y apuntarse a un partido.
2. Intentar cancelar la inscripción de otro jugador o abrir un partido ajeno: la API lo rechaza.
3. Entrar como organizador: crear una cancha y un partido, abrirlo y ver quién se ha apuntado.
4. Enseñar tests, CI y Sonar.
5. Responder 3 a 5 preguntas de «explícame esta pieza».

Criterios: [`docs/court-connect/evaluacion.md`](../docs/court-connect/evaluacion.md).
