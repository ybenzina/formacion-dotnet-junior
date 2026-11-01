# Ejercicio 1 — Web con Blazor

**Días 9 y 10 · estimación: 6 h** · Issue: «P2 · Ej1 · Web con Blazor»

## Objetivo

Una web que consume la API: aprender el modelo de componentes de Blazor, la sintaxis Razor y qué significa elegir el **modo de render** de cada página.

## Antes de empezar (≈ 1 h)

De la ruta de Microsoft Learn [Compilación de aplicaciones web con Blazor](https://learn.microsoft.com/es-es/training/paths/build-web-apps-with-blazor/), los módulos «Introducción al desarrollo web con Blazor», «Compilación de su primera aplicación web con Blazor» y «Creación de componentes reutilizables con Blazor».

Conceptos nuevos (añádelos al glosario): **componente Razor**, **render mode** (Static SSR, Interactive Server, WebAssembly), **formulario mejorado**, **Razor Class Library** y **cliente HTTP tipado**.

Lectura corta: [Modos de representación de ASP.NET Core Blazor](https://learn.microsoft.com/es-es/aspnet/core/blazor/components/render-modes). Quédate con esta idea: en **Static SSR** el servidor genera el HTML y no queda ninguna conexión abierta; en **Interactive Server** cada usuario mantiene una conexión (SignalR) con el servidor mientras tiene la página abierta.

## Pasos

Rama `feature/web`.

### 1. Proyectos (≈ 30 min)

- `src/CourtConnect.Ui.Components` (Razor Class Library): aquí van los componentes.
- `src/CourtConnect.Ui.Web` (Blazor Web App): aloja los componentes y llama a la API.
- La web **no** accede a la base de datos: solo habla con la API.

### 2. Cliente HTTP tipado (≈ 1 h)

- Una interfaz (`ICourtConnectApiClient` o una por recurso) y su implementación con `HttpClient`, registrada con `AddHttpClient`.
- La URL de la API sale de la configuración, no está escrita en el código.
- Cuando la API devuelve **ProblemDetails**, el cliente lo convierte en un mensaje comprensible para la persona que usa la web.

### 3. Páginas (≈ 2 h 30 min)

| Página | Qué muestra | Modo de render |
|---|---|---|
| Partidos | Partidos abiertos con fecha, cancha y plazas libres | **Static SSR** |
| Ficha del partido | Detalle y botón para apuntarse | **Static SSR** |
| Apuntarse | Formulario (de momento, eligiendo el jugador de una lista: el login llega en el ejercicio 2) | **Static SSR** con formulario mejorado |

Las páginas públicas van en Static SSR a propósito: son las que abre la gente desde el móvil, a veces con mala cobertura, y no necesitan una conexión abierta. El panel del organizador (ejercicio 3) sí será interactivo.

### 4. Tests (≈ 1 h)

- Tests de componentes con **bUnit**: el listado pinta los partidos, la ficha muestra «completo» cuando no quedan plazas, el formulario muestra el error de la API.
- Tests del cliente HTTP con un `HttpMessageHandler` falso: respuesta correcta, 404 y 409 con ProblemDetails.

## Criterios de aceptación

- [ ] Listado, ficha y formulario funcionan contra la API.
- [ ] Cada página declara su modo de render y sabes explicar por qué.
- [ ] La web no tiene ninguna referencia a Infrastructure ni a EF Core.
- [ ] La URL de la API sale de la configuración.
- [ ] Errores de la API mostrados de forma comprensible.
- [ ] **Calidad:** cobertura ≥ 80 % del código nuevo con bUnit y los tests del cliente.

## Extra

- **PWA instalable:** manifiesto, iconos y una página de «sin conexión». Solo eso: no hay modo sin conexión de verdad (ver la decisión en `ambit-escola`, documento de arquitectura).
- Que la web se vea bien en el móvil (es donde la usarán los jugadores).
- **La misma página en Visual Studio 2026 (≈ 45 min).** Compara los dos IDE depurando Blazor:
  1. Instala Visual Studio 2026 Community con la carga «Desarrollo de ASP.NET y web» (ver [`entorno.md`](../../../docs/court-connect/entorno.md#8-visual-studio-2026-community-opcional-parte-ii)).
  2. Abre `CourtConnect.slnx` y pon puntos de interrupción en una página Static SSR y en un componente Interactive Server.
  3. Compara con VS Code: depuración de `.razor`, Hot Reload, inspección de variables, explorador de tests y ventana de contenedores.
  4. Anota en el PR o en la retro qué aporta cada IDE y con cuál seguirás depurando Blazor.

  Copilot en Visual Studio lee `.github/copilot-instructions.md` (que apunta a `AGENTS.md`); Claude Code no se integra en Visual Studio y va en la terminal. La carpeta `.vs/` no se sube al repo: el `.gitignore` ya la excluye.

## Preguntas para la demo

- ¿Dónde se ejecuta el código de un componente en Static SSR? ¿Y en Interactive Server? ¿Y en WebAssembly?
- ¿Por qué el listado de partidos va en Static SSR y no en Interactive Server? ¿Qué pasaría con 500 jugadores mirando el listado a la vez en cada caso?
- ¿Por qué los componentes están en una biblioteca aparte? ¿Qué podrías hacer con ellos mañana?
- ¿Por qué la web no puede leer directamente la base de datos, si sería más rápido de programar?

## Comparación con IA

Con el PR abierto, pide a la IA la página de la ficha del partido con el formulario y compárala: modo de render, manejo de errores y dónde pone la lógica.

## Recursos

- [Modos de representación de Blazor](https://learn.microsoft.com/es-es/aspnet/core/blazor/components/render-modes)
- [Formularios de Blazor](https://learn.microsoft.com/es-es/aspnet/core/blazor/forms/)
- [`IHttpClientFactory` y clientes tipados](https://learn.microsoft.com/es-es/dotnet/core/extensions/httpclient-factory)
- [bUnit](https://bunit.dev/)
