# Ejercicio 3 — Panel del organizador

**Días 13 y 14 · estimación: 6 h** · Issue: «P2 · Ej3 · Panel del organizador»

## Objetivo

Dar al organizador sus pantallas de gestión, ahora **interactivas**: crear canchas y partidos, abrirlos y cerrarlos, y ver quién se ha apuntado. Es el equivalente al backoffice de Àmbit.

## Antes de empezar (≈ 30 min)

Conceptos nuevos (añádelos al glosario): **circuito** de Blazor Server, **estado de autenticación** en Blazor (`AuthenticationStateProvider`, `AuthorizeView`) y **QuickGrid**.

## Pasos

Rama `feature/panel-organizador`.

### 1. Páginas interactivas (≈ 3 h)

| Página | Qué hace | Modo de render |
|---|---|---|
| Mis partidos | Partidos que organizo, con estado y plazas ocupadas (QuickGrid con ordenación) | Interactive Server |
| Nuevo partido | Formulario: cancha, fecha y hora, duración, plazas, edad mínima y precio | Interactive Server |
| Detalle | Abrir o cerrar el partido y ver la lista de apuntados (solo apodo y nombre) | Interactive Server |
| Canchas | Alta y listado de canchas | Interactive Server |

- Solo las ve quien tiene el rol `Organizer`. Quien no lo tiene, no ve ni el enlace del menú.
- El token tiene que llegar a las llamadas que hacen estas páginas: aplica lo que leíste ayer sobre pasar tokens al circuito.

### 2. Validación en el formulario (≈ 1 h)

- Validación de la entrada en el formulario, para dar respuesta inmediata (campos obligatorios, plazas ≥ 2…).
- Las reglas de negocio las sigue decidiendo la API: si rechaza algo, el formulario muestra su ProblemDetails.

### 3. Tests (≈ 1 h 30 min)

- bUnit: el menú no muestra el panel a un jugador; el formulario muestra los errores de validación y el error de la API.
- Integración: el flujo crear, abrir y cerrar con un organizador, y R7 con otro organizador.

## Criterios de aceptación

- [ ] El organizador crea canchas y partidos, los abre y los cierra desde la web.
- [ ] Un jugador no puede usar el panel ni llamando directamente a la API.
- [ ] La lista de apuntados muestra solo los datos necesarios.
- [ ] **Calidad:** gate superado.

## Extra

- Editar un partido en borrador.
- Que la lista de plazas libres se actualice sin recargar cuando alguien se apunta.

## Preguntas para la demo

- ¿Por qué el panel va en Interactive Server y el listado público en Static SSR?
- Ocultar el enlace del menú a quien no es organizador, ¿es seguridad? ¿Qué es lo que de verdad protege el panel?
- ¿Cómo llega el token a una llamada que hace una página interactiva?
- ¿Qué datos de los apuntados enseñas y por qué no enseñas más?

## Comparación con IA

Pide a la IA la página «Nuevo partido» completa y compárala con la tuya: validación, manejo de errores y comprobación del rol.

## Recursos

- [QuickGrid](https://learn.microsoft.com/es-es/aspnet/core/blazor/components/quickgrid)
- [Autorización en Blazor](https://learn.microsoft.com/es-es/aspnet/core/blazor/security/)
- [Escenarios de seguridad adicionales de Blazor del lado del servidor](https://learn.microsoft.com/es-es/aspnet/core/blazor/security/additional-scenarios)
