# 📝 Quiz — Masterclass .NET Technologies
**Instrucciones:** selecciona la opción correcta (A / B / C / D).
Tiempo recomendado: **20–30 minutos**.
Puntuación: **1 punto** por respuesta correcta. Aprobado: **≥ 14/20 (70%)**.

1. ¿Cuál es la diferencia principal entre **.NET Framework** y **.NET Core**?
A) .NET Framework es multiplataforma; .NET Core solo Windows.
B) .NET Framework fue diseñado para web; .NET Core solo para escritorio.
C) .NET Framework es Windows-only; .NET Core es multiplataforma y modular.
D) No hay diferencias significativas; son lo mismo.

2. ¿Cuál de las siguientes tecnologías está pensada para construir **interfaces web con C#** que se ejecutan en el navegador (WASM) o en servidor?
A) Entity Framework Core
B) Blazor
C) WebForms
D) WCF

3. ¿Para qué se utiliza **Entity Framework Core** (EF Core)?
A) Para el enrutamiento de API REST.
B) Para compilar código C# a bytecode.
C) Para mapear objetos .NET a tablas en bases de datos (ORM) y gestionar migraciones.
D) Para crear interfaces gráficas de usuario nativas.

4. ¿Qué es una **Minimal API** en ASP.NET Core?
A) Un API implementada únicamente con SOAP.
B) Un estilo ligero de crear endpoints HTTP con mínimo boilerplate (sin controllers).
C) Una librería para serializar objetos JSON.
D) Un servicio de Azure para publicar APIs.

5. ¿Para qué sirve **gRPC** ?
A) Es una librería para generar interfaces de usuario.
B) Es un protocolo RPC que usa Protobuf para comunicación eficiente entre servicios.
C) Es una alternativa a SQL Server para almacenar datos.
D) Es una herramienta de CI/CD.

6. ¿Qué herramienta usarías **principalmente** para conectar y gestionar una base de datos SQL Server desde tu equipo?
A) Visual Studio Code sin extensiones.
B) SonarCloud.
C) SQL Server Management Studio (SSMS).
D) Docker Desktop.

6. ¿Qué herramienta usarías **principalmente** para conectar y gestionar una base de datos SQL Server desde tu equipo?
A) Visual Studio Code sin extensiones.
B) SonarCloud.
C) SQL Server Management Studio (SSMS).
D) Docker Desktop.

7. ¿Qué hace **SonarCloud** en un pipeline de CI?
A) Compila el proyecto y lo despliega automáticamente.
B) Ejecuta pruebas end-to-end exclusivamente.
C) Realiza análisis estático de código para detectar bugs, code smells y vulnerabilidades; aplica quality gates.
D) Genera documentación técnica automática.

8. ¿Cuál es el propósito de **SonarLint** en el IDE (Visual Studio / VSCode)?
A) Ejecutar la aplicación localmente.
B) Detectar y sugerir correcciones de problemas de calidad de código en tiempo real mientras se escribe.
C) Hacer deploy a Azure App Service.
D) Crear issues en Azure DevOps automáticamente.

9. En un pipeline CI típico (build → test → sonar → deploy), ¿qué paso se ejecuta **antes** de SonarCloud?
A) Deploy a producción.
B) Ejecución de los tests (unit / integration).
C) Limpieza de la base de datos.
D) Creación de un contenedor Docker.

10. ¿Cuál es la diferencia principal entre desplegar en **Azure App Service (PaaS)** y desplegar en una **VM con IIS (IaaS)**?
A) App Service requiere más configuración de SO; VM es totalmente gestionado por Azure.
B) App Service es PaaS (menos gestión infra, auto-scaling); VM con IIS te da control total del servidor pero más mantenimiento.
C) No existe diferencia: ambos son exactamente iguales técnicamente.
D) App Service solo sirve aplicaciones Node.js; IIS solo sirve aplicaciones PHP.

11. ¿Qué librería de las siguientes se suele instalar vía **NuGet** para manejar logging (registrar eventos y mensajes) en aplicaciones .NET?
A) jQuery
B) NLog
C) Bootstrap
D) React

12. En el flujo de trabajo Git recomendado, ¿qué branch suele usarse para integrar las características terminadas antes del merge a `main`?
A) feature/*
B) hotfix/*
C) develop (o una rama de integración como `drissbego/integration`)
D) temp/*

13. ¿Qué rol en SCRUM es quien prioriza el backlog y decide qué funcionalidades son más importantes?
A) Scrum Master
B) Product Owner
C) Dev Team
D) Stakeholder externo

14. ¿Qué significa **CI/CD** en términos generales?
A) Series de pasos manuales para desplegar en producción sin automatización.
B) Un pipeline que automatiza la integración (Continuous Integration) y desplegues/entregas continuas (Continuous Delivery/Deployment).
C) Un tipo de base de datos especializada para logs.
D) Un formato de documentación técnica.

15. En la arquitectura por capas (Domain, Application, Infrastructure), ¿qué componente correspondería a la **Infrastructure**?
A) Clases de dominio puras (entidades, value objects).
B) Handlers de casos de uso (use cases).
C) Implementaciones concretas de acceso a datos (EF Core DbContext, repositorios).
D) Vistas Razor y componentes Blazor.

16. ¿Cuál es la ventaja de usar **Docker** para desplegar servicios .NET?
A) Elimina la necesidad de tests.
B) Proporciona portabilidad y consistencia entre entornos (imagen = mismo runtime/config).
C) Sustituye la necesidad de usar bases de datos.
D) Aumenta automáticamente la cobertura de tests.

17. ¿Cuál de estos elementos forma parte de un **Quality Gate** en SonarCloud?
A) Número de commits por desarrollador.
B) Porcentaje mínimo de cobertura de tests unitarios en el nuevo código.
C) Peso del repositorio en MB.
D) Número de líneas de comentarios.

18. ¿Qué entendemos por **Clean Code** (de forma sencilla)?
A) Código que pasa todos los tests automáticamente.
B) Código escrito centrándose en legibilidad, simplicidad y mantenibilidad (nombres claros, funciones pequeñas, principio KISS).
C) Código minificado para producción.
D) Código generado automáticamente por herramientas.

19. ¿Cuál de estas sería una **buena tarea** a asignar tras la masterclass para comprobar el dominio de los flujos vistos?
A) Reescribir todo el código en Java.
B) Corregir issues de Sonar en un repositorio de ejemplo siguiendo el flujo: issue → branch → PR → pipeline.
C) Borrar ramas antiguas en el repositorio sin revisar.
D) Crear una base de datos sin migraciones.

20. ¿Qué es un **ORM** (Object-Relational Mapping)?
A) Una librería para construir interfaces gráficas.
B) Un mecanismo que mapea objetos/entidades de tu código a tablas relacionales en la base de datos.
C) Un framework exclusivo para definir entidades de negocio.
D) Una herramienta de logging.
