# Ejercicio 1 — Web con Blazor *(esbozo)*

**Lunes 26 de octubre · unas 4 h**

## Objetivo

Interfaz web que consume la API: aprender el modelo de componentes de Blazor, la sintaxis Razor y qué significa el *render mode*.

## Entregable

- `src/CourtConnect.Ui.Components` (Razor Class Library) con los componentes: lista de campus, ficha de campus y formulario de inscripción.
- `src/CourtConnect.Ui.Web` (Blazor Web App, render interactivo **Server**) que aloja esos componentes.
- Un cliente HTTP tipado detrás de una interfaz para llamar a la API. La web no accede a la base de datos.
- Mensajes de error comprensibles cuando la API devuelve ProblemDetails.
- Tests de componentes con **bUnit** y tests del cliente HTTP con un `HttpMessageHandler` falso, para llegar al 80 % de cobertura del código nuevo que exige el quality gate.

## Preguntas que tendrás que saber responder

- ¿Dónde se ejecuta el código de un componente en modo Server? ¿Y en WebAssembly?
- ¿Por qué los componentes están en una biblioteca aparte?

*Pasos, criterios de aceptación y recursos: pendientes de detallar.*
