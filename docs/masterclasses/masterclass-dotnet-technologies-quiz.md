# 📝 Quiz — Masterclass .NET Technologies

**Instrucciones:** elige la opción correcta (A / B / C / D).
Tiempo recomendado: **25–30 minutos**.
Puntuación: **1 punto** por respuesta correcta. Aprobado: **≥ 18/25 (72 %)**.
Las soluciones, con una línea de explicación, están al final: no las mires antes de terminar.

## Parte 1 — Ecosistema .NET

1. ¿Cuál es la diferencia principal entre **.NET Framework** y **.NET Core** (hoy, simplemente .NET)?
A) .NET Framework es multiplataforma; .NET Core solo funciona en Windows.
B) .NET Framework se diseñó para web; .NET Core solo para escritorio.
C) .NET Framework solo funciona en Windows; .NET es multiplataforma y modular.
D) No hay diferencias importantes.

2. ¿Qué versión de .NET usa el reto y de qué tipo es?
A) .NET 8, STS.
B) .NET 10, LTS.
C) .NET 9, LTS.
D) .NET Framework 4.8.

3. ¿Cuánto soporte gratuito tiene una versión **STS** de .NET?
A) 6 meses.
B) 1 año.
C) 2 años.
D) 3 años.

4. ¿Qué tecnología permite construir **interfaces web con C#** que se ejecutan en el servidor o en el navegador (WebAssembly)?
A) Entity Framework Core
B) WebForms
C) Blazor
D) WCF

5. ¿Para qué se usa **Entity Framework Core**?
A) Para definir las rutas de una API REST.
B) Para mapear objetos de C# a tablas de una base de datos (ORM) y gestionar migraciones.
C) Para compilar C# a código nativo.
D) Para crear interfaces gráficas de escritorio.

6. ¿Qué es una **Minimal API** en ASP.NET Core?
A) Una API que solo usa SOAP.
B) Una forma ligera de definir endpoints HTTP sin controladores (`app.MapGet(...)`).
C) Una librería para serializar JSON.
D) Un servicio de Azure para publicar APIs.

7. ¿Para qué sirve **gRPC**?
A) Para generar interfaces de usuario.
B) Es una alternativa a SQL Server.
C) Es una herramienta de CI/CD.
D) Es un protocolo de llamadas remotas que usa Protobuf para comunicar servicios de forma eficiente.

8. ¿Qué servicio de Azure usará el reto para desplegar los contenedores?
A) Azure Container Apps.
B) Una máquina virtual con IIS.
C) Azure Kubernetes Service (AKS).
D) Azure Functions.

## Parte 2 — Metodologías y herramientas

9. Cuando ya hay código en producción, ¿cómo llega un cambio nuevo hasta `main`?
A) Con un commit directo a `main`.
B) Con un *push* forzado desde la rama de la funcionalidad.
C) Rama corta → PR revisado y con la CI en verde hacia `develop` (integración) → cuando la iteración está validada, de `develop` a `main`.
D) Enviando un zip al revisor.

10. ¿Qué rol de Scrum prioriza el backlog y decide qué es más importante?
A) Scrum Master
B) Product Owner
C) Equipo de desarrollo
D) Un cliente externo cualquiera

11. ¿Qué hace **SonarQube Cloud** en la CI?
A) Compila y despliega la aplicación.
B) Ejecuta solo pruebas end-to-end.
C) Analiza el código para encontrar bugs, code smells y vulnerabilidades, y aplica el quality gate.
D) Genera la documentación técnica.

12. ¿Para qué sirve **SonarQube for IDE** (antes SonarLint) en VS Code?
A) Para ejecutar la aplicación.
B) Para señalar problemas de calidad mientras escribes el código.
C) Para desplegar en Azure.
D) Para crear issues en GitHub automáticamente.

13. En un PR del reto, el job de la CI sale en **verde** pero `SonarCloud Code Analysis` sale en **rojo**. ¿Qué significa?
A) Que el PR se puede fusionar.
B) Que el código no compila.
C) Que el código compila y pasa los tests, pero no supera el quality gate.
D) Que GitHub está caído.

14. El quality gate «Sonar way» del reto exige una cobertura mínima de…
A) 50 % de todo el código del repositorio.
B) 80 % del código nuevo del PR.
C) 100 % del código nuevo.
D) No mide la cobertura.

15. ¿Dónde se guarda el `SONAR_TOKEN` que usa la CI?
A) En el fichero YAML del workflow.
B) En `appsettings.json`.
C) Como secreto del repositorio en GitHub.
D) En el README.

16. ¿Qué ventaja tiene ejecutar SQL Server en **Docker** durante el desarrollo?
A) Elimina la necesidad de tests.
B) Todos trabajan con la misma versión y se puede crear y borrar sin instalar nada en el sistema.
C) Sustituye a la base de datos en producción.
D) Aumenta la cobertura de los tests.

17. ¿Con qué puedes conectarte a un SQL Server desde tu equipo para hacer consultas?
A) Con VS Code sin extensiones.
B) Con SonarQube Cloud.
C) Con la extensión mssql de VS Code o con SSMS.
D) Con Docker Desktop.

## Parte 3 — Desarrollo asistido por IA

18. ¿Qué es un **token** para un modelo de IA?
A) Una contraseña para usar la API.
B) Un trozo de texto (una palabra o parte de ella) con el que el modelo trabaja y por el que se paga.
C) Un fichero de configuración.
D) Una línea de código.

19. ¿Qué es la **ventana de contexto**?
A) La ventana del editor donde escribes.
B) Todo lo que el modelo tiene en cuenta en una petición: instrucciones, ficheros, historial y tu mensaje.
C) El historial de commits del repo.
D) La lista de extensiones instaladas.

20. ¿Cuál de estos prompts es más efectivo?
A) «Hazme los tests.»
B) «Arregla el código.»
C) «Escribe tests xUnit para `PriceCalculator` en `tests/`, usando `[Theory]` para los casos de borde (0, negativos, máximo); deben compilar y pasar con `dotnet test`. No modifiques el código de producción.»
D) «Haz lo que creas mejor.»

21. ¿Qué es **MCP** (Model Context Protocol)?
A) Un lenguaje de programación para IA.
B) Un estándar abierto para conectar aplicaciones de IA con herramientas y datos externos.
C) Un modelo de IA de Microsoft.
D) Un formato de base de datos.

22. ¿Qué hace un **agente** de IA, como Copilot en modo agente o Claude Code?
A) Solo responde preguntas de texto.
B) Planifica y ejecuta pasos usando herramientas: leer ficheros, ejecutar comandos, proponer cambios.
C) Sustituye la revisión de código.
D) Compila más rápido.

23. En los ejercicios de base del reto, ¿qué papel tiene la IA según `AGENTS.md`?
A) Escribe la solución para que la copies.
B) Tutor: explica, pregunta y da pistas, sin darte la solución hecha.
C) No se puede usar en absoluto.
D) Solo puede corregir faltas de ortografía.

24. En **Spec-Driven Development** con GitHub Spec Kit, ¿qué va primero?
A) La implementación.
B) Los tests de integración.
C) La especificación (después vienen el plan, las tareas y la implementación).
D) El despliegue.

## Parte 4 — Reto CourtConnect

25. En la arquitectura de CourtConnect, ¿qué proyecto contiene las implementaciones de acceso a datos (`DbContext`, repositorios)?
A) Domain
B) Application
C) Infrastructure
D) Ui.Components

---

## Soluciones

| Nº | Respuesta | Por qué |
|---|---|---|
| 1 | C | .NET Framework es solo Windows; .NET (antes Core) es multiplataforma |
| 2 | B | .NET 10 salió en noviembre de 2025 y es LTS |
| 3 | C | STS: 2 años; LTS: 3 años |
| 4 | C | Blazor: componentes con C# en servidor o WebAssembly |
| 5 | B | EF Core es el ORM de .NET |
| 6 | B | Endpoints con `MapGet`, `MapPost`… sin controladores |
| 7 | D | gRPC usa HTTP/2 y Protobuf |
| 8 | A | Container Apps: contenedores sin gestionar Kubernetes |
| 9 | C | `main` queda para producción; el desarrollo en curso se integra en `develop`. Sin producción, las ramas van directas a `main` |
| 10 | B | El Product Owner prioriza el backlog |
| 11 | C | Análisis estático y quality gate |
| 12 | B | Avisa mientras escribes |
| 13 | C | Son dos checks distintos: funcionar no es lo mismo que cumplir el listón de calidad |
| 14 | B | Solo se mide el código nuevo |
| 15 | C | Los secretos nunca van en el repo |
| 16 | B | Entorno igual para todos y desechable |
| 17 | C | mssql o SSMS |
| 18 | B | Se paga por tokens de entrada y de salida |
| 19 | B | Más contexto no siempre es mejor: hay que dar lo relevante |
| 20 | C | Tiene contexto, tarea, restricciones y criterio de terminado |
| 21 | B | «Un USB-C para la IA» |
| 22 | B | Un agente actúa con herramientas; por eso hay que revisar lo que hace |
| 23 | B | Modo tutor: primero tú, después la IA |
| 24 | C | Primero la especificación |
| 25 | C | Infrastructure implementa lo que Application necesita |
