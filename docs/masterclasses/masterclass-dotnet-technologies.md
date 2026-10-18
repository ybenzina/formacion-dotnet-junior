# Masterclass .NET Technologies - Historia .NET, flujos de trabajo y proyecto CourtConnect

## 🎯 Objetivos
- Comprender la evolución del ecosistema .NET y su estado actual.
- Familiarizarse con las herramientas del entorno de desarrollo profesional (Visual Studio, VS Code, SSMS, Azure).
- Conocer los flujos de trabajo con GitHub y SonarQube.
- Definir los requerimientos del proyecto final **CourtConnect**.

## 🧩 Contenidos
### 1. Historia .NET y visión general
- Evolución: **.NET Framework → .NET Core → .NET 5/6/7/8**
- Ecosistema .NET:
  - ASP.NET Core MVC / Razor Pages
  - WebForms (legacy)
  - Web API REST y gRPC
  - Entity Framework Core
  - Blazor (Server / WebAssembly)
  - .NET MAUI (multiplataforma)
- Lenguaje: **C# specs y versiones**
- Estrategias de despliegue de aplicaciones .NET:
  - On-Premise: IIS, Windows Services
  - Cloud: App Services, Containers (Docker + ACI/AKS)

### 2. Metodologías, herramientas y entornos
- Ciclo de vida del desarrollo de software
- Metodologías de trabajo ágiles: **SCRUM overview**
- Estrategia de ramas con Git flow (main, develop, feature/*, release, hotfix)
- Análisis estático de código con SonarCloud y políticas de calidad de código (QGates) Clean Code.
	- Demo: Identificación de issues en Sonarcloud y revisión de QGate
- CI/CD con GitHub Actions
	- Demo: Ejecución de pipeline con build, test y code analysis on push changes
- **Herramientas** de soporte al desarrollo:
  - Visual Studio Community / Professional
  - VSCode (para front no .NET y scripts)
  - Plugins: SonarLint, Azure Dev Tools, NuGet Package Manager
	- Demo: Creación de proyecto con VS Professional, instalación de extensiones y uso de Nugets para la integración de librerías (ejemplco con Nlog).
  - Azure Portal / CLI
	- Demo: Acceso a azure y creación de VM Windows con Sql Server y acceso por RDP.
  - SSMS para SQL Server
	- Demo3: SSMS para el acceso a las BBDDs Sql Server.

### 3. Proyecto CourtConnect
- Definición de alcance y requerimientos.
- Organización, entornos y herramientas
	- Demo: Creación de repositorio en AzureDevOps, definición de epics, sprints y features identificados.

#### 🧪 Demos
- Demo1: Identificación de issues en Sonarcloud, revisión de estado de la calidad y reglas de clean code.
- Demo2: ejecutar pipeline de build + tests + code analysis.
- Demo3: Creación de proyecto con VS Professional, instalación de extensiones y uso de Nugets para la integración de librerías (ejemplco con Nlog).
- Demo4: Acceso a azure y exploración de recursos
- Demo5: Acceso a SQL Server con SSMS
- Demo6: Creación de repositorio en AzureDevOps para CoutConnect

## 🧭 Actividades
| Nº | Actividad | Descripción |
|----|------------|-------------|
| 1 | **Quiz Fase 1** | Evaluación de conocimientos base .NET |
| 2 | **Corregir issues Sonar** | Aplicar flujo de trabajo Git + PR |
| 3 | **Requisitos CourtConnect** | Definir objetivos funcionales y técnicos |
| 4 | **Setup de repositorio en AzureDevOps** | Creación y configuración del repositorio en AzureDevOps. Documentación de requisitos, user stories y definición de backlog  |


## ❓ Quiz Interactivo de la Masterclass .NET Technologies

### Parte 1 - Ecosistema .NET
1. ¿Qué diferencia principal existe entre .NET Framework y .NET Core?
2. ¿Qué tecnología de .NET permite crear aplicaciones multiplataforma?
3. Menciona 3 tecnologías incluidas en el ecosistema .NET moderno.
4. ¿Qué ventajas ofrece el despliegue en Azure App Services frente a IIS?

### Parte 2 - Metodologías y herramientas
5. Define brevemente las actividades a realizar en las diferentes fases del desarrollo de software.
6. Define brevemente qué es SCRUM y en qué casos es práctico utilizar esta metodología.
7. ¿Qué es GitFlow? Describe brevemente el flujo de trabajo con ramas y PRs Git.
8. ¿Qué es Sonarqube y para qué sirve? ¿Cómo se puede usar dentro del entorno de desarrollo?
9. Explica el propósito de un pipeline CI/CD en GitHub Actions.

### Parte 3 - Proyecto CourtConnect
10. ¿Cuál es el objetivo del proyecto CourtConnect?
11. Identifica los principales componentes / subsistemas requeridos para la solución.
12. ¿Qué tecnologías principales te plantearías utilizar en su implementación?


## 📘 Recursos de apoyo

### 📖 Documentación oficial
- [Historia y evolución de .NET](https://learn.microsoft.com/dotnet/fundamentals/)
- [C# Language Specification](https://learn.microsoft.com/dotnet/csharp/)
- [Entity Framework Core Overview](https://learn.microsoft.com/ef/core/)
- [ASP.NET Core fundamentals](https://learn.microsoft.com/aspnet/core/)
- [Blazor Introduction](https://learn.microsoft.com/aspnet/core/blazor/)
- [Deploy to Azure App Service](https://learn.microsoft.com/azure/app-service/)

---

### 🎥 Vídeos formativos
- 📺 [What is .NET? – Microsoft Developer](https://www.youtube.com/watch?v=QbkbT9zv-cY)
- 📺 [Intro to ASP.NET Core](https://www.youtube.com/watch?v=C5cnZ-gZy2I)
- 📺 [Build and deploy .NET apps to Azure](https://www.youtube.com/watch?v=3D3a6cSn1fY)
- 📺 [Using EF Core with SQL Server](https://www.youtube.com/watch?v=pY0xZxP2Yb4)
- 📺 [Blazor in Action – Introduction](https://www.youtube.com/watch?v=cM4YwoyyVSY)

---

### 🧰 Herramientas
- [Visual Studio Community](https://visualstudio.microsoft.com/)
- [VS Code](https://code.visualstudio.com/)
- [Azure for Students (sandbox gratuita)](https://azure.microsoft.com/free/students/)
- [SonarCloud](https://sonarcloud.io/)
- [GitHub Actions documentation](https://docs.github.com/en/actions)
