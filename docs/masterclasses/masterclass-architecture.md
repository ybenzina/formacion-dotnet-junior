# Masterclass Arquitectura

**Martes 17/11/2026, de 12:30 a 14:20.** Estaba prevista para el domingo siguiente al Día 5, a mitad del ejercicio 3, pero Driss terminó la Parte I antes de poder hacerla. Ahora repasa lo que ha construido y prepara la demo 1. Fechas en el [calendario](../court-connect/calendario.md).

**Duración:** 110 minutos, incluidos 10 de descanso, 25 de patrones y 20 de taller. **Formato:** diapositivas con puntos visibles y notas para Yamel. El [quiz](masterclass-architecture-quiz.md), de 20 preguntas, es tarea del día siguiente: 20 minutos, no al final de la sesión.

**Nota sobre los ejemplos:** las referencias a Àmbit son ilustrativas. Sirven para pensar sobre abonos, becas, tarifas, aforo e integraciones; no son requisitos confirmados del cliente. Todos los datos son ficticios.

## Objetivos

- Seguir una petición desde la web hasta la base de datos.
- Explicar qué hace cada parte y qué necesita de las demás.
- Reconocer seis patrones: formas conocidas de resolver problemas que se repiten.
- Elegir una mejora pequeña para el servicio propio y explicar cómo comprobarla.

## Preparación y alcance

La **arquitectura** es cómo repartimos el trabajo entre las piezas del programa. Como en un equipo, cada pieza debe saber qué hace y a quién puede pedir ayuda. El reparto de CourtConnect está en su [guía](../court-connect/architecture/README.md).

Driss trae el `RegistrationService` que hizo en la Parte I, con sus pruebas. Es un **servicio de aplicación**: coordina una tarea, como inscribir a alguien, pidiendo ayuda al dominio y a la base de datos. Repasará las reglas R1 a R6 del [enunciado](../court-connect/enunciado-dominio.md). Lo que aún no exista se dibujará en papel.

Yamel prepara una pizarra y abre el código y las pruebas de Driss. Los fragmentos de esta guía son ejemplos independientes para leer, no un proyecto ni la solución de los ejercicios. Usan C# habitual y .NET 10. La Parte III prevé pasar a .NET 11; esta sesión no necesita esa versión.

## Agenda

La columna «Guion» usa la numeración de este documento; «pptx», la de la presentación, que además tiene portada, objetivos y agenda (1 a 3) y un glosario al final (32 a 37). Algunas diapositivas del guion ocupan dos en el pptx (la de código va aparte).

| Bloque | Minutos | Guion | pptx |
| --- | --- | --- | --- |
| Problema y límites | 5 | 1 a 2 | 4 a 5 |
| Organizar el código y sus reglas | 10 | 3 a 6 | 6 a 9 |
| Agrupar tareas y guardar datos | 15 | 7 a 11 | 10 a 14 |
| Crear objetos y controlar el reloj | 15 | 12 a 16 | 15 a 20 |
| Descanso | 10 | — | — |
| Conceptos que conviene conocer | 5 | 17 | 21 |
| Seis patrones con ejemplos | 25 | 18 a 23 | 22 a 28 |
| Taller CourtConnect | 20 | 24 a 25 | 29 a 30 |
| Recapitulación y plan antes de la demo 1 | 5 | 26 | 31 |
| **Total** | **110** | **26** | **37** |

## Guion de diapositivas

### Diapositiva 01. Arquitectura: hacer explícito qué puede cambiar

**Puntos clave:**

- Una **regla de negocio** dice qué permite la aplicación: por ejemplo, no superar las plazas de un partido.
- **HTTP** es el protocolo con el que web y servidor se envían peticiones y respuestas.
- **SQL** es un lenguaje para consultar y modificar bases de datos.
- Cambiar la forma de guardar datos no debería cambiar la regla de plazas.

**Notas del ponente:**

**Qué decir:** «Si cambia una tarifa, ¿dónde buscarías el código? ¿Y si cambiamos de proveedor de facturación? Separar responsabilidades nos ayuda a tocar menos cosas. También cuesta: hay más archivos que entender. Buscamos una separación útil, no el mayor número de proyectos».

**Contexto para Yamel:** Dibuja los dos cambios y pide localizar qué piezas deberían modificarse en cada caso.

### Diapositiva 02. Un criterio de éxito observable

**Puntos clave:**

- CourtConnect tiene reglas sobre plazas, edad, estado, fechas y precio.
- **Refactorizar** es cambiar la organización del código sin cambiar lo que hace: ordenar la cocina sin cambiar la receta.
- Una prueba debe avisar si la mejora rompe una regla que ya funcionaba.

**Notas del ponente:**

**Qué decir:** «La edad se calcula para la fecha del partido. ¿Qué prueba demostraría que seguimos haciendo eso después de mover código?».

**Contexto para Yamel:** Si la regla aún no está programada, apuntadla como pendiente. Añadir una regla que falta es trabajo nuevo, no una refactorización.

### Diapositiva 03. Monolito modular no significa una clase enorme

**Puntos clave:**

- **Backend**: la parte que ejecuta reglas y guarda datos en el servidor.
- **Monolito modular**: un backend organizado por tareas, por ejemplo partidos e inscripciones, que evoluciona como una unidad.
- Un **worker** hace trabajo en segundo plano, sin esperar una petición del navegador. En la Parte III vive en su propio programa, `CourtConnect.Worker`.
- **Microservicios**: servicios con límites propios que pueden evolucionar y desplegarse por separado. Tener varios procesos no basta.

**Notas del ponente:**

**Qué decir:** «Piensa en departamentos de una misma empresa. Repartir tareas no obliga a convertir cada departamento en otra empresa».

**Contexto para Yamel:** `CourtConnect.Worker` será un host separado de la API y la web, pero compartirá Application e Infrastructure con la API. Se crea en la Parte III con la plantilla Worker Service, sin HTTP ni ingress. Tener programas separados no convierte el sistema en microservicios; añadir esas fronteras introduce llamadas por red y fallos que CourtConnect no necesita para aprender estas reglas.

### Diapositiva 04. Cuatro responsabilidades, no cuatro escalones obligatorios

**Puntos clave:**

Una **capa** agrupa una responsabilidad. Una **API** ofrece operaciones a otros programas; por ejemplo, la web pide a la API que inscriba a un jugador. Un **endpoint** es una entrada concreta, como `POST /games/{id}/registrations`.

| Capa | Decide o hace | No debe conocer |
| --- | --- | --- |
| Domain | Reglas del negocio: cuándo se puede inscribir | HTTP o la base de datos |
| Application | Pasos de una tarea: cargar, pedir la operación y guardar | Detalles de cómo se guarda |
| Infrastructure | Guardar datos y llamar a servicios externos | Cómo se muestra una pantalla |
| Api | Recibir peticiones, comprobar identidad y formato, devolver respuestas | Copias de las reglas en cada endpoint |

**Notas del ponente:**

**Qué decir:** «Un caso de uso es una tarea que tiene sentido para una persona: inscribirse o cancelar».

**Contexto para Yamel:** Dibuja las referencias: Application conoce Domain; Infrastructure conoce Application y Domain; Api conoce Application y registra las clases de Infrastructure. Las flechas muestran qué código puede conocer a qué otro código, no todos los pasos de una petición. Domain no referencia Infrastructure.

### Diapositiva 05. SOLID como preguntas de revisión

**Puntos clave:**

**SOLID** son cinco consejos para facilitar cambios, no cinco clases obligatorias.

| Principio | Pregunta útil en CourtConnect |
| --- | --- |
| S: responsabilidad única | Un motivo principal de cambio |
| O: abierto/cerrado | Añadir variantes sin romper las existentes |
| L: sustitución | Respetar el contrato al cambiar implementación |
| I: interfaces pequeñas | Pedir solo las operaciones necesarias |
| D: inversión de dependencias | Depender del contrato, no del proveedor |

**Notas del ponente:**

**Qué decir:** «Una dependencia es algo que una clase necesita para trabajar. Tu servicio necesita un repositorio: esa es una dependencia».

**Contexto para Yamel:** Pide un ejemplo por principio, sin exigir memorizar las siglas. Si un método siempre lanza `NotSupportedException`, esa clase quizá no pueda cumplir la interfaz. No hace falta convertir cada `if` en varias clases.

### Diapositiva 06. DDD táctico donde haya reglas

**Puntos clave:**

- **DDD**, diseño guiado por el dominio, parte de las reglas y palabras del negocio para representarlas en código.
- **Entidad**: conserva su identidad aunque cambien sus datos. Un partido sigue siendo el mismo si cambia la hora.
- **Objeto de valor**: importa su contenido, no un identificador. Dos importes de 10 EUR representan el mismo valor.
- **Agregado**: objetos que se modifican a través de una entrada común, su raíz, para proteger sus reglas.
- Los objetos protegen reglas; no son solo bolsas de datos. «Invariante» y «dominio rico» quedan definidos en el glosario de consulta.

**Notas del ponente:**

**Qué decir:** «Si cualquiera cambia directamente las plazas, ¿quién protege la regla? Un agregado se parece a una recepción que controla las entradas».

**Contexto para Yamel:** Abonos, becas, tarifas y aforo sirven para buscar reglas que merezcan este cuidado. Para una lista sencilla puede bastar **CRUD**: crear, leer, actualizar y borrar. Un agregado no es toda la base de datos ni resuelve por sí solo dos inscripciones simultáneas.

### Diapositiva 07. Capas y slices responden a preguntas diferentes

**Puntos clave:**

- Capas: qué responsabilidad tiene cada pieza.
- **Vertical slice**, o corte por funcionalidad: reunir el código de una tarea. Es como guardar juntos los documentos de un trámite.
- Dentro de Application: `Features/Registrations/Register/` y `Features/Registrations/Cancel/`.
- Un **handler** es la clase que atiende esa tarea; por ejemplo, cancelar una inscripción.

**Notas del ponente:**

**Qué decir:** «Las capas dicen qué hace cada pieza. Las carpetas por tarea ayudan a encontrar lo que cambia junto».

**Contexto para Yamel:** No repitas las cuatro capas dentro de cada carpeta ni copies las reglas. En las partes I y II basta el servicio sencillo; usaremos esta organización para el código nuevo de la Parte III.

### Diapositiva 08. Handler normal, dependencias visibles

**Puntos clave:**

- El endpoint recibe el handler mediante **DI**, inyección de dependencias: entregarle a un objeto lo que necesita, como preparar sus herramientas.
- El constructor muestra qué necesita: por ejemplo, un repositorio y un reloj.
- El handler coordina los pasos; el dominio protege sus reglas.
- Es una clase normal. No necesita otra biblioteca para recibir una llamada.

**Notas del ponente:**

**Qué decir:** «Sigue la petición con el dedo: endpoint, handler, dominio, guardado y respuesta. Puedes probar el handler llamando a su método sin arrancar la web».

**Contexto para Yamel:** Usamos llamadas directas; en la diapositiva 17 veremos qué es un mediador y por qué no hace falta aquí.

### Diapositiva 09. EF Core ya coordina una unidad de trabajo

**Puntos clave:**

- **EF Core** permite guardar y consultar objetos C# en una base de datos.
- Su **`DbContext`** recuerda los cambios y los guarda con `SaveChangesAsync`.
- **Unidad de trabajo**: reunir cambios que se confirman juntos, como una cesta antes de pagar.
- Una **transacción** hace que esos cambios se guarden todos o ninguno. En SQL, un `SaveChanges` usa una por defecto.
- No uses el mismo contexto en operaciones paralelas.

**Notas del ponente:**

**Qué decir:** «Tener el mismo contexto no convierte dos guardados separados en una única transacción. Tampoco incluye una llamada HTTP en la transacción SQL».

**Contexto para Yamel:** El contexto vive en Infrastructure. Evitamos crear otra unidad de trabajo que solo copie los métodos de EF Core.

### Diapositiva 10. Repositorios: justificar el contrato antes de crearlo

**Puntos clave:**

- **Repositorio**: un contrato para cargar y guardar objetos del dominio, como un archivo al que pides un expediente.
- Puede tener sentido un contrato concreto para un agregado con reglas.
- No creamos un repositorio genérico obligatorio para cada tabla.
- Un **DTO** transporta solo los datos que necesitamos; por ejemplo, nombre y plazas libres para una lista.
- **IQueryable** representa una consulta pendiente de ejecutar; no es una lista de resultados.

**Notas del ponente:**

**Qué decir:** «No queremos copiar EF Core método por método. Queremos pedir lo que necesita esta tarea».

**Contexto para Yamel:** Una consulta de lectura puede devolver un DTO desde Infrastructure a través de un contrato de Application. No entregamos `IQueryable`, una consulta aún por ejecutar, a la web. Las pruebas contra SQL comprueban cosas que un sustituto en memoria no puede verificar, como la traducción real de consultas.

### Diapositiva 11. Dos peticiones para la última plaza

**Puntos clave:**

- **Concurrencia**: varias operaciones avanzan a la vez, como dos personas comprando la última entrada.
- Las dos peticiones pueden leer que queda una plaza antes de guardar.
- Hay que proteger también el guardado y decidir qué respuesta recibe quien llega tarde.
- Se prueba con la base de datos real, no solo con una lista en memoria.

**Notas del ponente:**

**Qué decir:** «¿En qué momento se enteraría la segunda petición de que la primera ya ocupó la plaza?».

**Contexto para Yamel:** Dibuja dos columnas: leer, comprobar y guardar. Una restricción de unicidad puede evitar duplicar una inscripción, pero no basta para limitar un aforo variable. Deja la elección y la implementación como razonamiento de Driss.

### Diapositiva 12. DI: crear fuera, usar dentro

**Puntos clave:**

- Un **contenedor de DI** crea objetos y entrega sus dependencias. Se parece a alguien que prepara las herramientas de un taller.
- El constructor dice qué necesita cada clase.
- En Api registramos qué implementación debe entregar el contenedor.
- La clase usa la herramienta recibida, en vez de buscarla en un lugar global.
- **Grafo de dependencias:** red de objetos que necesitan otros objetos.
- **Constructor principal:** dependencias declaradas junto al nombre de la clase; no reasignes sus parámetros.

Comparación única con código antiguo. Constructor clásico y campo privado `_camelCase`:

```csharp
public sealed class GameTimeReader
{
    private readonly TimeProvider _clock;
    public GameTimeReader(TimeProvider clock)
    {
        _clock = clock;
    }
    public DateTimeOffset ReadNow() => _clock.GetUtcNow();
}
```

La misma dependencia con constructor principal, que usaremos en los servicios:

```csharp
public sealed class GameTimeReader(TimeProvider clock)
{
    public DateTimeOffset ReadNow() => clock.GetUtcNow();
}
```

**Notas del ponente:**

**Qué decir:** «Si recibes un reloj, en una prueba puedo darte otro que siempre marque la misma hora. La red de objetos y dependencias se llama grafo».

**Contexto para Yamel:** Registra las clases en el arranque; evita `BuildServiceProvider` dentro del registro y que cada servicio busque dependencias por su cuenta. Eso oculta lo que necesita y puede crear contenedores duplicados.

### Diapositiva 13. Transient, Scoped y Singleton

**Puntos clave:**

**Lifetime**, o ciclo de vida, indica cuánto se reutiliza un objeto creado por DI. **Resolver** un servicio significa pedirle una instancia al contenedor. Un **scope** es un periodo en el que se comparten ciertos objetos, como una petición web.

| Lifetime | Cuándo se reutiliza | Ejemplo o precaución |
| --- | --- | --- |
| Transient | Una instancia nueva cada vez que se pide | Una herramienta nueva para cada encargo |
| Scoped | La misma dentro de un scope | En la API, normalmente un `DbContext` por petición |
| Singleton | Una por registro y contenedor principal | Un reloj compartido por la aplicación |

**Notas del ponente:**

**Qué decir:** «¿Cuántos objetos tendríamos en cada caso?».

**Contexto para Yamel:** Dibuja dos peticiones y pide el mismo servicio dos veces dentro de cada una. Scoped no significa siempre petición: depende del entorno. En Blazor con interactividad en servidor puede durar la conexión de interacción del usuario. La web del reto llama a la API; no conserva su propio `DbContext`.

### Diapositiva 14. Singleton no es una clase estática

**Puntos clave:**

- Un singleton de DI es un objeto normal que el contenedor comparte.
- Puede recibir dependencias e implementar una interfaz para sustituirlo en pruebas.
- Una clase `static` ofrece acceso global sin crear un objeto; es otra forma de trabajar.
- No guardes en ninguno el usuario actual ni datos de una petición.

**Notas del ponente:**

**Qué decir:** «Compartir no significa que se pueda modificar sin cuidado. Dos peticiones pueden usar el singleton a la vez».

**Contexto para Yamel:** Dos copias de la aplicación en servidores distintos tienen objetos distintos. Volveremos a esta diapositiva al comparar el patrón clásico con `AddSingleton`.

### Diapositiva 15. Dependencia cautiva: una vida corta atrapada en una larga

**Puntos clave:**

- **Dependencia cautiva**: un objeto duradero conserva otro que debería durar menos.
- Ejemplo: un singleton guarda un `DbContext` pensado para una sola petición.
- El contexto se sigue usando después de su tarea y puede mezclar trabajo de varias peticiones.
- La validación de scopes detecta este error; está activa por defecto en **Development**, el entorno de desarrollo.
- En **Production**, producción, no se activa por defecto: la dependencia cautiva puede pasar sin error de validación.

**Notas del ponente:**

**Qué decir:** «Es como guardar para siempre una herramienta prestada solo para un turno. Cambiar todo a singleton no lo arregla».

**Contexto para Yamel:** Dibuja `Worker (singleton) → Handler (scoped) → DbContext (scoped)` recibido en el constructor. Con el host y contenedor predeterminados, Development habilita la validación; una configuración explícita puede cambiarlo también en producción. No afirmar que una dependencia cautiva siempre provocará una excepción. La validación no demuestra seguridad ante uso simultáneo.

### Diapositiva 16. BackgroundService y TimeProvider

**Puntos clave:**

- **`BackgroundService`** es la base de .NET para trabajo en segundo plano, como revisar inscripciones pendientes.
- En el reto se registra con `AddHostedService` en `CourtConnect.Worker`, no en la API; dura toda la ejecución de ese host.
- Abre un scope por tarea o lote, pide allí sus servicios y cierra el scope al terminar.
- **`TimeProvider`** representa el reloj. En una prueba permite avanzar el tiempo sin esperar de verdad.

**Notas del ponente:**

**Qué decir:** «Si la inscripción caduca en diez minutos, ¿quieres esperar diez minutos en cada prueba? El reloj inyectado lo evita».

**Contexto para Yamel:** `CourtConnect.Worker` es el programa que aloja el servicio y consulta SQL mediante Infrastructure; no aplica migraciones. Separarlo evita que la caducidad dependa de las réplicas de la API. `IServiceScopeFactory` crea scopes para el worker. Usar un scope no impide que dos workers hagan la misma tarea; la coordinación y la respuesta a un reinicio son otros problemas. El reloj tampoco elige la zona horaria ni la regla de caducidad.

### Diapositiva 17. Conceptos que conviene conocer

**Puntos clave:**

- **Multisociedad**: varias empresas usan el sistema con datos separados, como carpetas con permisos distintos.
- **CQRS**: separar acciones que cambian datos de consultas que los leen, como inscribirse frente a listar partidos.
- **Mediator**: un intermediario dirige cada petición a quien la atiende, como una centralita.
- **Domain event**, o evento de dominio: un hecho del negocio, como «inscripción creada».
- Outbox e idempotencia quedan en el glosario y se trabajan en la [clase de integraciones](masterclass-integrations.md); no añadimos otras dos técnicas a este bloque.

**Notas del ponente:**

**Qué decir:** «Hoy basta con reconocer estos nombres. No vamos a implementarlos ni a examinarnos de sus detalles».

**Contexto para Yamel:** Un filtro por sociedad no sustituye permisos; separar consultas no exige otra base de datos; una outbox puede reenviar un mensaje. Eso exige **idempotencia**: repetir una operación sin duplicar su efecto, como no cobrar dos veces el mismo pago. MediatR es una biblioteca que implementa Mediator; seguimos con llamadas directas por simplicidad.

### Diapositiva 18. Singleton: compartir una instancia con cuidado

**Puntos clave:**

- **Problema:** varias clases necesitan el mismo servicio, por ejemplo un reloj.
- **Singleton clásico:** la clase controla su única instancia y ofrece acceso global con `Instance`.
- Una clase estática también ofrece acceso global, pero no es el Singleton clásico: no tiene una instancia.
- **En .NET:** preferimos `AddSingleton` para un objeto compartido gestionado por DI.
- **Cuándo no:** para el jugador actual, datos de una petición o `DbContext`.

El registro comparte el reloj; el consumidor lo recibe por constructor principal:

```csharp
services.AddSingleton<TimeProvider>(TimeProvider.System);
public sealed class GameTimeReader(TimeProvider clock)
{
    public DateTimeOffset ReadNow() => clock.GetUtcNow();
}
```

**Notas del ponente:**

**Qué decir:** «La clase recibe el reloj; en las pruebas podemos cambiarlo. ¿Por qué sería peligroso guardar aquí el identificador del jugador?».

**Contexto para Yamel:** Recupera DI y sus ciclos de vida. El Singleton clásico controla su instancia mediante un acceso global `Instance`; una clase estática no tiene instancia. Con DI, el contenedor controla la creación y la vida; cuando crea un servicio desechable, también lo libera. No comparte la instancia entre servidores ni protege automáticamente datos modificables. La comparación de constructores ya se mostró en DI, no se repite aquí. Tiempo: 5 minutos.

### Diapositiva 19. Factory: crear un objeto válido

**Puntos clave:**

- **Factory**, o fábrica: concentra cómo se crea un objeto, como un punto de revisión antes de entregarlo.
- **Problema:** evitar repetir comprobaciones y crear objetos que nacen incompletos.
- **En .NET:** `IHttpClientFactory` crea clientes y reutiliza sus piezas de transporte; el detalle de handlers y conexiones está en el glosario.
- **Cuándo no:** si un constructor sencillo ya expresa bien la creación.

Fragmento dentro de un `Game` didáctico con título y capacidad. Su constructor es privado y asigna esos campos; el modelo completo del reto tiene más reglas:

```csharp
public static Game Create(string title, int capacity)
{
    if (string.IsNullOrWhiteSpace(title))
        throw new ArgumentException("A title is required.", nameof(title));
    if (capacity <= 0)
        throw new ArgumentOutOfRangeException(nameof(capacity));
    return new Game(title.Trim(), capacity);
}
```

**Notas del ponente:**

**Qué decir:** «¿Puede otro código saltarse estas comprobaciones usando `new Game`?».

**Contexto para Yamel:** No: el constructor es privado. Es un método fábrica estático, no la jerarquía Factory Method clásica. `IHttpClientFactory` cachea handlers y gestiona su rotación: `HandlerLifetime` es de dos minutos por defecto; no significa cerrar cada conexión exactamente cada dos minutos. Los clientes existentes pueden seguir usando su handler. Las conexiones pertenecen a los pools de esos handlers. No convertir cada constructor en fábrica. Tiempo: 4 minutos.

### Diapositiva 20. Strategy: cambiar una forma de calcular

**Puntos clave:**

- **Strategy**, o estrategia: distintas formas de hacer una tarea bajo el mismo contrato.
- **Problema:** elegir una tarifa sin llenar el servicio de condiciones sobre todos los tipos de partido.
- **En .NET:** interfaces con implementaciones elegidas mediante DI; `IComparer<T>`, que permite cambiar cómo se comparan objetos, es otro ejemplo.
- **Cuándo no:** si solo hay una regla sencilla y no existe una variación real.

Tarifas ficticias, no reglas nuevas del reto. El contrato `IPricingStrategy` declara `decimal Calculate(decimal basePrice)`. El consumidor recibe la estrategia por DI:

```csharp
public sealed class FriendlyPricing : IPricingStrategy
{
    public decimal Calculate(decimal basePrice) => basePrice;
}
public sealed class TournamentPricing : IPricingStrategy
{
    public decimal Calculate(decimal basePrice) => basePrice * 1.20m;
}
public sealed class GamePriceReader(IPricingStrategy strategy)
{
    public decimal Read(decimal basePrice) => strategy.Calculate(basePrice);
}
```

**Notas del ponente:**

**Qué decir:** «La llamada es la misma; cambia el objeto que calcula».

**Contexto para Yamel:** Para el ejemplo, registrar `AddScoped<IPricingStrategy, TournamentPricing>()` y `AddScoped<GamePriceReader>()` elige una implementación para ese consumidor. No es un selector dinámico por partido: si hace falta esa variación, se diseña explícitamente. DI no adivina reglas. Relaciónalo con tarifas distintas y recuerda que R6 conserva el precio al inscribirse. Tiempo: 4 minutos.

### Diapositiva 21. Adapter, Clean y Hexagonal: proteger un límite

**Puntos clave:**

- **Adapter**, o adaptador: traduce nuestro contrato al de otro sistema, como un conector de enchufes.
- **Puerto:** contrato de lo que necesita la aplicación; **Hexagonal** organiza sus conexiones mediante puertos y adaptadores.
- **Clean Architecture:** mantiene las reglas independientes de detalles como HTTP o SQL. Comparte este objetivo con Hexagonal, aunque no son nombres idénticos.
- **Problema:** que el servicio de aplicación no conozca rutas y formatos de un proveedor.
- **En .NET:** una clase de Infrastructure puede implementar nuestro puerto usando `HttpClient`, el cliente HTTP de .NET.
- **Cuándo no:** para envolver otra clase sin cambiar nada ni proteger un límite útil.

El puerto `IGameBilling` declara `Task SendAsync(Guid gameId)`. Servicio ficticio, no la API de Holded; `PostAsJsonAsync` envía texto estructurado, definido como JSON en el glosario:

```csharp
services.AddHttpClient<IGameBilling, GameBillingAdapter>(client =>
    client.BaseAddress = new Uri("https://billing.example.invalid/"));
public sealed class GameBillingAdapter(HttpClient client) : IGameBilling
{
    public async Task SendAsync(Guid gameId)
    {
        using HttpResponseMessage response = await client.PostAsJsonAsync(
            "demo/game-charges", new { GameId = gameId });
        response.EnsureSuccessStatusCode();
    }
}
```

**Notas del ponente:**

**Qué decir:** «Application conoce `IGameBilling`; Infrastructure conoce HTTP».

**Contexto para Yamel:** Puertos y adaptadores se explican aquí una sola vez. La interfaz permite sustituir el proveedor en pruebas, no elimina fallos de red. `AddHttpClient` registra el cliente tipado y su dirección base; la extensión JSON requiere `System.Net.Http.Json`. El dominio `.invalid` no representa un servicio real. El fragmento omite autenticación, cancelación y tratamiento completo de errores. Holded es facturación: crear un documento no confirma un cobro. Reintentar requiere idempotencia. Tiempo: 4 minutos.

### Diapositiva 22. Decorator: añadir comportamiento alrededor

**Puntos clave:**

- **Decorator**, o decorador: envuelve un servicio y mantiene su interfaz, como una funda que protege sin cambiar el teléfono.
- **Problema:** añadir un registro de actividad sin modificar el servicio original.
- **Logging** significa registrar hechos de ejecución; un log es uno de esos mensajes.
- **En .NET:** registramos la envoltura mediante DI. `DelegatingHandler` usa una idea parecida alrededor de llamadas HTTP.
- **Cuándo no:** para esconder reglas de negocio o añadir capas que no aportan nada.
- La variante con caché queda como vocabulario de consulta, no como otra técnica que implementar aquí.

`IGameSummary` declara `string Get(Guid gameId)` y `GameSummary` ya lo implementa. La envoltura mantiene ese contrato:

```csharp
public sealed class LoggedGameSummary(IGameSummary inner,
    ILogger<LoggedGameSummary> logger) : IGameSummary
{
    public string Get(Guid gameId)
    {
        logger.LogInformation("Reading game {GameId}", gameId);
        return inner.Get(gameId);
    }
}
```

**Notas del ponente:**

**Qué decir:** «El consumidor sigue pidiendo `IGameSummary`. Primero se registra el mensaje y después se llama al servicio original».

**Contexto para Yamel:** Registrar primero `GameSummary` como scoped y después `IGameSummary` con una factory que construya `LoggedGameSummary` recibiendo el concreto y su logger. Resolver el concreto evita pedir la misma interfaz y crear una dependencia circular. La caché puede ser otro decorador, con política explícita de invalidación. No registrar datos personales en logs. Tiempo: 4 minutos.

### Diapositiva 23. Options: configuración con nombres y tipos

**Puntos clave:**

- **Options pattern** agrupa configuración en una clase tipada, como una ficha con campos en vez de notas sueltas.
- **Problema:** evitar buscar cadenas de configuración por todo el programa.
- **En .NET:** `IOptions<T>` entrega esa configuración mediante DI.
- **Cuándo no:** para guardar estado de un jugador o reglas que cambian por partido en la base de datos.

Configuración ficticia del listado. El archivo de configuración tendría una sección `GameList` con `PageSize`:

```csharp
services.AddOptions<GameListOptions>().Bind(configuration.GetSection("GameList"))
    .Validate(options => options.PageSize > 0, "PageSize must be positive.")
    .ValidateOnStart();
public sealed class GameListOptions
{
    public int PageSize { get; set; } = 20;
}
public sealed class GameListSettings(IOptions<GameListOptions> options)
{
    public int PageSize => options.Value.PageSize;
}
```

**Notas del ponente:**

**Qué decir:** «La clase nos dice qué esperamos y la validación avisa si el tamaño no es válido».

**Contexto para Yamel:** `IOptions<T>` pertenece a `Microsoft.Extensions.Options`. El enlace de configuración usa las extensiones habituales del arranque de ASP.NET Core. No es una forma de cifrar secretos. `IOptions<T>` no ofrece recarga automática; `IOptionsSnapshot<T>` e `IOptionsMonitor<T>` cubren otros ciclos de actualización y quedan para otra sesión. Tiempo: 4 minutos.

### Diapositiva 24. Taller: tu servicio de la Parte I

**Puntos clave:**

- Abre el servicio de aplicación que hiciste en la Parte I.
- Sigue una inscripción: entrada, regla, guardado y respuesta.
- Marca lo que existe y dibuja en papel lo que falta.
- Elige una mejora pequeña que puedas explicar en la demo 1.

**Notas del ponente:**

**Qué decir:** «No buscamos más código: queremos entender bien lo que has hecho».

**Contexto para Yamel:** Usa los primeros 15 minutos del [taller](#taller-courtconnect). Yamel pregunta y da pistas; Driss propone el cambio y la prueba. No se entrega un servicio resuelto ni se exige usar todos los patrones.

### Diapositiva 25. Explicar la decisión antes de seguir

**Puntos clave:**

- ¿Qué problema resuelve tu cambio?
- ¿Qué comportamiento debe seguir igual?
- ¿Qué prueba lo comprobaría?
- ¿Qué patrón has descartado y por qué?
- **Prueba de regresión:** detecta que algo que funcionaba dejó de hacerlo.

**Notas del ponente:**

**Qué decir:** «No hay premio por crear más carpetas. Quiero entender por qué tu servicio queda más claro. Una prueba de regresión detecta que algo que funcionaba dejó de hacerlo».

**Contexto para Yamel:** Reserva los últimos 5 minutos del taller. Si falta una regla, se apunta como tarea pendiente y no como fallo causado por el cambio.

### Diapositiva 26. Plan antes de la demo 1

**Puntos clave:**

- Aplica la mejora antes de la demo 1, con una decisión explicada y pruebas.
- Mantén servicios sencillos; dibujar slices no obliga a migrarlo todo.
- Usa un patrón cuando resuelva un problema concreto.
- Repasa el quiz y explica cada error con un ejemplo propio.

**Notas del ponente:**

**Qué decir:** «¿Qué vas a cambiar antes de la demo 1 y qué vas a dejar como está?».

**Contexto para Yamel:** Recupera las preguntas iniciales de tarifa y proveedor. Cierra con una acción concreta y una duda para revisar, no con una lista de tecnologías que instalar.

## Taller CourtConnect

**Tiempo:** 20 minutos incluidos. **Entrega:** un mapa del servicio actual, una mejora propuesta y un plan para aplicarla antes de la demo 1. Se trabaja sobre el servicio de Driss; las partes que falten se dibujan en papel.

### Enunciado

1. **Leer, 4 minutos:** Driss explica una operación de su servicio. Marca las reglas R1 a R6 que ya ha implementado y las que faltan.
2. **Separar, 5 minutos:** señala entrada, coordinación, reglas y guardado. Dibuja cómo se separarían `Register` y `Cancel` si crecieran; no hace falta crear las carpetas.
3. **Mejorar, 6 minutos:** propone un cambio pequeño. Puede ser aclarar una dependencia, corregir su lifetime o extraer una responsabilidad. Si cabe, modifica solo código ya escrito y ejecuta sus pruebas; si no, diseña el cambio y la prueba en papel.
4. **Revisar, 5 minutos:** explica el beneficio y el coste. Anota qué aplicarás antes de la demo 1 y una pregunta para Yamel.

### Pistas

- Empieza por una responsabilidad y una prueba, no por mover todos los archivos.
- ¿La fecha que necesita la regla es la del partido o la del reloj actual?
- ¿Qué dependencia solo necesita uno de los dos casos de uso?
- ¿La comprobación pertenece al transporte, a la orquestación o al dominio?
- ¿Dos llamadas simultáneas podrían invalidar una comprobación correcta por separado?
- ¿Tu nuevo puerto expresa una necesidad o vuelve a escribir la API de EF Core?

### Criterios de aceptación

- [ ] Se distingue código existente, mejora propuesta y trabajo pendiente.
- [ ] Se explica qué hace cada capa en la operación elegida.
- [ ] Las reglas y respuestas que ya funcionaban se conservan; una prueba lo comprueba o queda diseñada.
- [ ] Hay una prueba de éxito, una de rechazo y una pregunta sobre dos peticiones simultáneas.
- [ ] Se justifica la duración de las dependencias; ningún singleton retiene un `DbContext`.
- [ ] Se elige o descarta un patrón por su utilidad, no por aparecer en la clase.
- [ ] El plan permite aplicar la mejora antes de la demo 1 sin imponer otra arquitectura ni añadir funcionalidades.

## Actividades posteriores

- Al día siguiente, completar el [quiz de arquitectura](masterclass-architecture-quiz.md): 20 minutos de tarea, no al terminar la sesión.
- Aplicar la mejora en un PR antes de la demo 1 y explicar en él qué se aplicó; incluir la sección «Uso de IA».
- Añadir al glosario cinco conceptos y un ejemplo propio de cada uno.
- Conservar dos preguntas para Yamel: una sobre una frontera del diseño y otra sobre una prueba que falta.

## Recursos de apoyo

Revisar versiones y condiciones antes de impartir la sesión; los artículos avanzados no amplían por sí solos el alcance del reto.

- [DI y validación de scopes, Microsoft Learn](https://learn.microsoft.com/en-us/dotnet/core/extensions/dependency-injection).
- [Vida de DbContext y unidad de trabajo, Microsoft Learn](https://learn.microsoft.com/en-us/ef/core/dbcontext-configuration/).
- [IHttpClientFactory](https://learn.microsoft.com/en-us/dotnet/core/extensions/httpclient-factory) y [Options](https://learn.microsoft.com/en-us/dotnet/core/extensions/options).
- [Arquitectura de CourtConnect](../court-connect/architecture/README.md) y [reglas de dominio](../court-connect/enunciado-dominio.md).
- [Masterclass de contenedores y cloud](masterclass-cloud.md), para conectar límites lógicos con despliegue y operación.

## Glosario

**Imprescindibles (15):** arquitectura, regla de negocio, capa, caso de uso, entidad, agregado, DI, scope, lifetime, Singleton, DbContext, transacción, Strategy, Adapter y DTO.

**Que te suene:** el resto del vocabulario de la tabla. Basta reconocer para qué sirve y dónde consultarlo; no memorizar definiciones.

| Término | Explicación sencilla | Ejemplo |
| --- | --- | --- |
| Arquitectura | Reparto de responsabilidades y dependencias | Reglas en Domain, guardado en Infrastructure |
| Regla de negocio | Condición que debe respetar una operación | No superar las plazas |
| HTTP / API / endpoint | Protocolo web, operaciones ofrecidas y una entrada concreta | Pedir una inscripción al endpoint de la API |
| SQL | Lenguaje para trabajar con bases de datos | Consultar partidos |
| Refactorización | Reorganizar sin cambiar el resultado | Extraer una responsabilidad del servicio |
| Backend | Programa que ejecuta reglas en el servidor | API de CourtConnect |
| Monolito modular | Backend dividido por responsabilidades que evoluciona como una unidad | Partidos e inscripciones en el mismo sistema |
| Microservicio | Servicio con límites propios y evolución independiente | Un servicio externo de pagos |
| Capa | Grupo de código con una responsabilidad | Infrastructure guarda datos |
| Caso de uso / servicio de aplicación | Tarea del usuario y clase que coordina sus pasos | Cancelar una inscripción |
| Clean Architecture | Organización que protege las reglas de los detalles externos | Domain no conoce SQL |
| Hexagonal / puerto / adaptador | Conectar el interior con el exterior mediante contratos | Interfaz de facturación e implementación HTTP |
| SOLID | Cinco consejos para diseñar clases que se puedan cambiar | Una interfaz con solo los métodos necesarios |
| DDD táctico | Piezas de diseño basadas en reglas del negocio | Entidades y objetos de valor |
| Entidad | Objeto que conserva su identidad | Partido cuya hora cambia |
| Objeto de valor | Dato que se compara por su contenido | Importe y moneda |
| Agregado / raíz | Grupo que controla sus cambios desde una entrada común | Partido que protege cambios relacionados con sus reglas |
| Invariante | Regla que debe mantenerse siempre | Capacidad positiva |
| Dominio rico | Objetos que protegen reglas, no solo guardan datos | Una operación que rechaza un cambio inválido |
| CRUD | Crear, leer, actualizar y borrar | Mantener una lista de canchas |
| Vertical slice | Agrupar código de una tarea | Carpeta de cancelación |
| Handler | Clase que atiende una tarea | Clase que coordina la cancelación |
| EF Core / DbContext | Herramienta de acceso a datos y objeto que coordina cambios | Guardar una inscripción |
| Unidad de trabajo / transacción | Cambios agrupados y guardado de todos o ninguno | Un `SaveChanges` en SQL |
| Repositorio | Contrato para cargar y guardar objetos | Buscar un partido por identificador |
| DTO | Datos preparados para viajar entre partes | Nombre y plazas libres |
| Concurrencia | Operaciones que avanzan a la vez | Dos peticiones para la última plaza |
| Dependencia / DI | Algo que una clase necesita y la forma de recibirlo | Recibir un reloj por constructor |
| Contenedor / resolución / grafo | Gestor de objetos, pedir uno y su red de dependencias | Resolver un servicio con su repositorio |
| Lifetime / scope | Duración de un objeto y periodo de uso compartido | Una petición HTTP |
| Transient / Scoped / Singleton | Nuevo por resolución, uno por scope o uno compartido | Herramienta nueva, contexto de petición o reloj |
| Dependencia cautiva | Retener un objeto más tiempo del debido | Singleton que conserva un contexto scoped |
| Worker / BackgroundService | Trabajo en segundo plano y base de .NET para hacerlo | Revisar inscripciones pendientes |
| TimeProvider | Reloj sustituible | Avanzar el tiempo en una prueba |
| Multisociedad | Separar datos de varias empresas | Empresa A no ve los de B |
| CQRS | Separar cambios de consultas | Inscribirse frente a listar |
| Mediator / MediatR | Intermediario de peticiones y una biblioteca que lo implementa | Enviar una petición a su handler |
| Domain event | Hecho del negocio | Inscripción creada |
| Outbox / idempotencia | Mensaje pendiente guardado y protección frente a efectos duplicados | Reenviar sin cobrar dos veces |
| Factory | Centralizar la creación de objetos | `Game.Create` comprueba capacidad |
| Handler HTTP / pool | Pieza de transporte / grupo de conexiones que reutiliza | La factory cachea y rota handlers; no son handlers de casos de uso |
| Strategy | Cambiar cómo se hace una tarea con el mismo contrato | Dos cálculos de tarifa |
| Adapter / HttpClient | Traductor a otro sistema y cliente HTTP de .NET | Adaptador de facturación |
| JSON | Texto estructurado para intercambiar datos | Objeto con `GameId` |
| Decorator | Envolver un servicio manteniendo su interfaz | Registrar una lectura antes de delegarla |
| Logging / log / caché | Registrar hechos, cada mensaje y guardar resultados reutilizables | Mensaje de lectura de un partido |
| Options / IOptions | Configuración agrupada en clases y acceso mediante DI | Tamaño de página del listado |
| Prueba de regresión | Comprobación de algo que ya funcionaba | La cancelación sigue liberando plaza |
