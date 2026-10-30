# Glosario técnico del reto

Términos profesionales que aparecen en los enunciados, explicados en lenguaje sencillo. Entre paréntesis, el término en inglés tal como lo vas a encontrar en la documentación y en las entrevistas.

**Cómo se usa:** el día 1 copias este fichero a `docs/learning/glosario.md` en `court-connect`. Cada día añades los términos nuevos que te encuentres y reescribes los que uses **con tus palabras**, con un ejemplo de tu propio código. Escribirlo tú es lo que hace que se quede. Si un término no está o no lo entiendes, pregúntalo (a Yamel o a la IA tutora) y añádelo.

No confundir con el glosario del **dominio** (`Game` = partido, `Registration` = inscripción…), que va en `docs/domain.md`.

## Arquitectura y diseño

| Término | Qué es |
| --- | --- |
| **Dominio** (*domain*) | El problema de negocio que resuelve la aplicación y sus reglas: aquí, canchas, partidos, jugadores e inscripciones. También el proyecto de código donde viven esas reglas |
| **Entidad** (*entity*) | Objeto del dominio con **identidad** propia (un `Id`) que cambia con el tiempo. Dos partidos con los mismos datos siguen siendo partidos distintos |
| **Objeto de valor** (*value object*) | Objeto que se define solo por sus valores y no cambia. Dos rangos de edad 8–12 son el mismo rango. Ejemplo: `AgeRange` |
| **Regla de negocio** (*business rule*) | Condición que impone el negocio, no la tecnología: «no se puede superar el número de plazas» |
| **Capa** (*layer*) | Grupo de código con una responsabilidad: dominio, aplicación, infraestructura, presentación. En .NET cada capa suele ser un proyecto |
| **Dependencia entre proyectos** (*project reference*) | Cuando un proyecto usa código de otro (`<ProjectReference>` en el `.csproj`). Las dependencias van en una sola dirección: hacia el dominio, nunca desde él |
| **Acoplamiento** (*coupling*) | Lo mucho que una pieza depende de otra. Poco acoplamiento = puedes cambiar una sin romper la otra |
| **Caso de uso** (*use case*) | Una acción completa que pide el usuario: «apuntar a un jugador a un partido» |
| **Servicio de aplicación** (*application service*) | Clase que implementa un caso de uso: coordina el dominio, los repositorios y el resto |
| **Repositorio** (*repository*) | Clase que oculta cómo se guardan y leen las entidades. El servicio pide «dame el partido 5» sin saber si hay SQL Server detrás |
| **Interfaz** (*interface*) | Contrato sin implementación (`IGameRepository`). Permite cambiar la implementación, por ejemplo por un doble en los tests |
| **Inyección de dependencias** (*dependency injection*, DI) | En vez de que una clase cree lo que necesita (`new SqlGameRepository()`), lo recibe en el constructor. ASP.NET Core trae un **contenedor** que hace esas entregas |
| **DTO** (*data transfer object*) | Objeto solo con datos para entrar o salir por la API. Evita exponer las entidades del dominio tal cual |

## C# y .NET

| Término | Qué es |
| --- | --- |
| **Clase** (*class*) | El tipo habitual. Se compara por **referencia**: dos objetos son iguales solo si son el mismo objeto |
| **Record** (*record*) | Tipo pensado para guardar datos. Se compara por **valor**, es inmutable por defecto y se escribe en menos líneas. Bueno para DTOs y objetos de valor; **no** para entidades de EF Core |
| **Igualdad por referencia / por valor** | Por referencia: ¿es el mismo objeto en memoria? Por valor: ¿tienen los mismos datos? |
| **Inmutable** (*immutable*) | Que no cambia después de crearse. Para «cambiarlo» se crea otro (en records, con `with`) |
| **Propiedad** (*property*) | `public string Name { get; private set; }`. Con `private set` solo la propia clase puede cambiarla |
| **Constructor principal** (*primary constructor*) | Parámetros declarados junto al nombre de la clase: `class RegistrationService(IGameRepository games)`. Cómodo para inyección de dependencias; los parámetros no son de solo lectura |
| **Atributo** (*attribute*) | Metadatos entre corchetes sobre una clase o propiedad: `[Required]`, `[Fact]`. En Java se llaman anotaciones |
| **Enum** | Lista cerrada de valores con nombre: `RegistrationStatus.Confirmed` |
| **Excepción de dominio** (*domain exception*) | Excepción propia que indica que se ha incumplido una regla de negocio |
| **Objeto resultado** (*result object*) | Alternativa a las excepciones: el método devuelve «bien» o «mal y por qué» |
| **Tipos que aceptan null** (*nullable reference types*) | `string?` puede ser `null`; `string`, no. El compilador avisa si te olvidas de comprobarlo |
| **Lambda** | Función corta sin nombre: `p => p.Age >= 8` |
| **LINQ, sintaxis de métodos** (*method syntax*) | `players.Where(p => p.Age >= 8).Select(p => p.Name)`. Es la que usamos. Existe otra tipo SQL (`from p in players where …`) que no usamos |
| **`TimeProvider`** | Clase de .NET que da la fecha y la hora actuales. Inyectarla permite fijar «hoy» en los tests |
| **SDK / runtime** | El SDK sirve para compilar; el runtime, para ejecutar |
| **`TargetFramework`** | Versión de .NET para la que se compila un proyecto: `net10.0` |
| **`global.json`** | Fija qué versión del SDK usa el repo, en local y en la CI |
| **LTS / STS** (*long-term / standard-term support*) | Tipos de versión de .NET. Sale una cada noviembre: las pares son LTS (3 años de soporte) y las impares STS (ahora 2 años). El reto empieza en .NET 10 (LTS) y migra a .NET 11 (STS) en la Parte III |
| **Cambio incompatible** (*breaking change*) | Cambio de una versión nueva que obliga a tocar tu código o tu configuración. Se revisan antes de migrar |
| **Solución** (*solution*, `.slnx`) | Agrupa varios proyectos (`.csproj`) para compilarlos juntos |
| **Biblioteca de clases** (*class library*) | Proyecto que no se ejecuta solo; otros proyectos lo usan |
| **Paquete NuGet** | Biblioteca de terceros que se añade al proyecto (`dotnet add package`) |

## Datos

| Término | Qué es |
| --- | --- |
| **ORM** (*object-relational mapper*) | Herramienta que traduce entre objetos de C# y tablas SQL. EF Core es el ORM de .NET |
| **`DbContext`** | Clase de EF Core que representa la sesión con la base de datos |
| **`DbSet<T>`** | Propiedad del `DbContext` que representa una tabla: `DbSet<Game> Games` |
| **API fluida** (*Fluent API*) | Configurar EF Core con código (`builder.Property(c => c.Name).HasMaxLength(100)`) en lugar de atributos |
| **Migración** (*migration*) | Fichero generado por EF Core con los cambios del esquema de la base de datos, para aplicarlos de forma ordenada |
| **Datos de prueba iniciales** (*seeding*) | Datos que se cargan al crear la base de datos |
| **Índice único** (*unique index*) | Restricción de la base de datos que impide filas repetidas en ciertas columnas |
| **Token de concurrencia** (*concurrency token*) | Columna que detecta si dos personas modificaron el mismo registro a la vez |
| **Cadena de conexión** (*connection string*) | Texto con servidor, base de datos y credenciales. Es un secreto |
| **Secretos de usuario** (*user secrets*) | Sitio fuera del repo donde guardar secretos en desarrollo (`dotnet user-secrets`) |

## API web

| Término | Qué es |
| --- | --- |
| **API REST** | API sobre HTTP donde cada URL representa un recurso (`/games/5`) y el verbo indica la acción (`GET`, `POST`…) |
| **Endpoint** | Una URL con un verbo que la API atiende: `POST /games/{id}/registrations` |
| **Minimal API** | Forma de definir endpoints en ASP.NET Core sin controladores: `app.MapGet(...)` |
| **Código de estado HTTP** (*status code*) | 200 OK, 201 creado, 204 sin contenido, 400 petición incorrecta, 404 no encontrado, 409 conflicto con el estado actual |
| **ProblemDetails** | Formato estándar de los errores de una API (RFC 9457) |
| **OpenAPI** | Descripción estándar de una API, de la que salen documentación y clientes |
| **Fichero `.http`** | Fichero con peticiones HTTP que se ejecutan desde el editor |
| **PRG** (*Post/Redirect/Get*) | Patrón de formularios: el servidor procesa el POST y redirige a un GET. Así, recargar la página no reenvía el formulario |
| **TempData** | Datos que sobreviven a una sola redirección y se borran al leerlos. Ideal para el aviso «Inscripción guardada» después de un PRG |
| **Estado de sesión** (*session state*) | Datos del usuario guardados en el servidor entre peticiones, asociados a una cookie. Sirve para un asistente de varios pasos. Ojo con varias réplicas: cada una tiene su memoria |

## Tests

| Término | Qué es |
| --- | --- |
| **Test unitario** (*unit test*) | Prueba una pieza aislada, sin base de datos ni red |
| **Test de integración** (*integration test*) | Prueba varias piezas juntas: API + base de datos real |
| **`[Fact]` / `[Theory]` + `[InlineData]`** | En xUnit: un caso fijo / un mismo test con varios juegos de datos |
| **Doble de prueba** (*test double*: *mock*, *fake*) | Sustituto de una dependencia en un test: un repositorio en memoria, por ejemplo |
| **Fixture** | Preparación compartida entre tests (arrancar la base de datos una vez) |
| **Cobertura** (*code coverage*) | Porcentaje del código que ejecutan los tests |
| **`WebApplicationFactory`** | Arranca la API en memoria para probarla desde los tests |
| **Testcontainers** | Biblioteca que arranca contenedores Docker (por ejemplo, SQL Server) desde los tests |

## Contenedores

| Término | Qué es |
| --- | --- |
| **Imagen** (*image*) | Plantilla de solo lectura con todo lo necesario para ejecutar algo: `mcr.microsoft.com/mssql/server` |
| **Contenedor** (*container*) | Una imagen en ejecución. Se crea, se para y se borra |
| **Volumen** (*volume*) | Almacenamiento que sobrevive al contenedor |
| **Puerto publicado** (*published port*) | Puerto de tu máquina conectado al del contenedor (`-p 1433:1433`) |
| **Docker Compose** | Fichero que levanta varios contenedores juntos |

## CI y calidad

| Término | Qué es |
| --- | --- |
| **Integración continua** (*continuous integration*, CI) | Compilar y probar automáticamente cada cambio |
| **Workflow / job / runner** | En GitHub Actions: el fichero YAML / cada bloque de trabajo / la máquina que lo ejecuta |
| **Status check** | Resultado (verde o rojo) que un workflow o una app publica en un PR |
| **Ruleset** | Reglas de GitHub para una rama: PR obligatorio, checks obligatorios… |
| **Quality gate** | Listón de calidad que tiene que superar el código nuevo (ver `calidad.md`) |
| **Code smell** | Código que funciona pero es difícil de mantener |
| **Security hotspot** | Punto sensible para la seguridad que una persona tiene que revisar |

## Herramientas de IA

| Término | Qué es |
| --- | --- |
| **Agente** (*agent*) | Un rol con instrucciones y herramientas para trabajar en una tarea. Un agente personalizado de chat no implica autonomía: puede ser solo un tutor seleccionado por la persona |
| **Skill** | Instrucciones y recursos empaquetados en una carpeta para un flujo concreto. Lo invoca la persona o el modelo según la configuración; no añade autonomía por sí solo |
| **Fichero de prompt** (*prompt file*) | Una tarea reutilizable en Markdown que la persona lanza como comando. En VS Code se usa en el motor Local; otros motores pueden necesitar un skill |
| **Frontmatter** | Bloque YAML al principio del fichero, entre líneas `---`, con metadatos como nombre, descripción o herramientas. No es el cuerpo de las instrucciones |
| **Versionado semántico** (*Semantic Versioning*, SemVer) | Versión `MAJOR.MINOR.PATCH`: cambio incompatible, capacidad compatible o corrección. Permite fijar qué referencia está instalada |
| **Deriva** (*drift*) | Diferencia entre una copia instalada y la versión fuente que declara. Se comprueba comparando SHA-256 de copia, fuente y registro; una versión antigua intacta no tiene deriva |
