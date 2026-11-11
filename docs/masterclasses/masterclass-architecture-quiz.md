# Quiz de la masterclass de arquitectura

## Instrucciones

- Responde **al día siguiente** de la [masterclass](masterclass-architecture.md), sin mirar las soluciones.
- Tiempo orientativo: **20 minutos**, fuera de los 110 minutos de la sesión.
- Hay **20 preguntas**, con una única respuesta correcta y un punto por acierto.
- Referencia de autoevaluación: **15/20**. Revisa cada error con un ejemplo propio, aunque superes esa cifra.
- No se pide implementar reglas ni resolver los ejercicios abiertos de CourtConnect.

## Límites y organización

### 1. La web, la API (entrada para otras aplicaciones) y el worker (trabajo en segundo plano) son programas separados. ¿Qué podemos concluir?

- A) Son microservicios si cada programa tiene su propio archivo de proyecto.
- B) Son módulos independientes si sus contenedores escuchan en puertos distintos.
- C) Pueden ser un monolito modular si comparten modelo y evolucionan juntos.
- D) Son servicios autónomos si cada programa dispone de su propio Dockerfile.

### 2. Una dependencia es algo que una clase necesita para trabajar. ¿Cuál respeta las capas del reto?

- A) Infrastructure implementa un contrato de guardado definido en Application.
- B) Application referencia Api para reutilizar sus respuestas HTTP tipadas.
- C) Domain referencia Infrastructure para validar reglas con el contexto SQL.
- D) La web referencia Infrastructure para compartir el repositorio de la API.

### 3. Un slice reúne código de una tarea, como cancelar. ¿Cómo encaja con las capas?

- A) Cada slice sustituye las capas por una colección de clases sin límites.
- B) Cada slice requiere su propio contexto y una base de datos independiente.
- C) Los slices obligan a introducir un mediador para poder invocar sus clases.
- D) Las capas separan responsabilidades y los slices agrupan casos de uso.

### 4. SOLID son cinco consejos de diseño. ¿Qué consejo aplica la segregación de interfaces?

- A) Compartir una interfaz CRUD completa entre lectores y modificadores.
- B) Añadir métodos vacíos cuando una implementación no necesite una operación.
- C) Reunir las operaciones del módulo en un contrato común para sus consumidores.
- D) Separar contratos para que cada consumidor dependa de lo que necesita.

### 5. Un dominio rico tiene objetos que protegen reglas. ¿Cuándo merece la pena?

- A) Cuando queremos que cada columna tenga su propia clase de dominio.
- B) Cuando varias operaciones deben preservar reglas como el límite de plazas.
- C) Cuando queremos mover las validaciones de formulario a las entidades.
- D) Cuando las consultas de lectura necesitan devolver muchos campos distintos.

### 6. Un partido es una entidad: conserva su identidad al cambiar de hora. Un importe es un objeto de valor. ¿Cómo se compara este último?

- A) Por la misma referencia, aunque representen idéntica cantidad y moneda.
- B) Por un identificador persistido que distinga cada instancia del importe.
- C) Por cantidad y moneda: dos importes de 10 EUR representan igual valor.
- D) Por la cantidad numérica, dejando la moneda fuera de la comparación.

### 7. ¿Qué busca un agregado, un grupo de objetos cuyos cambios pasan por una entrada común?

- A) Proteger reglas mediante cambios controlados desde su objeto raíz.
- B) Cargar las entidades relacionadas para cada consulta sobre el objeto raíz.
- C) Agrupar las tablas del módulo bajo un contexto de EF compartido.
- D) Resolver los conflictos entre peticiones gracias a compartir una clase.

## Persistencia y dependencias

### 8. DbContext es el objeto de EF Core que coordina los cambios de datos. ¿Cómo debemos usarlo?

- A) Compartirlo entre consultas paralelas si utilizan métodos `async`.
- B) Coordinar cambios de una tarea, sin compartir el contexto entre operaciones paralelas.
- C) Conservarlo entre peticiones para aprovechar las entidades ya cargadas.
- D) Incluir en su transacción SQL las llamadas HTTP del mismo método.

### 9. Un repositorio ofrece operaciones para cargar y guardar objetos. ¿Qué opción encaja con el curso?

- A) Un repositorio genérico obligatorio aunque solo copie métodos de EF Core.
- B) Un contrato que exponga `IQueryable` para construir consultas desde la web.
- C) Un repositorio por tabla aunque ninguna operación necesite ese contrato.
- D) Un contrato específico que cubra operaciones necesarias del caso de uso.

### 10. Dos peticiones leen a la vez que queda una plaza. ¿Qué debemos comprobar?

- A) La protección al guardar y la respuesta al conflicto, probándolas con SQL.
- B) La validación previa, usando una prueba que ejecute las peticiones en serie.
- C) El registro scoped, para asegurar que ambas peticiones comparten contexto.
- D) El contador singleton, para sincronizar las plazas entre réplicas desplegadas.

### 11. Un scope es un periodo de uso compartido, como una petición web. Pedimos un servicio scoped dos veces en uno y después en otro. ¿Qué ocurre?

- A) Las tres comparten instancia mientras el contenedor siga abierto.
- B) Las tres crean instancias diferentes aunque coincidan en scope.
- C) Las dos primeras comparten instancia; el segundo scope crea otra.
- D) Las dos primeras crean instancias; el segundo scope reutiliza la última.

### 12. DI entrega a cada objeto lo que necesita. ¿Qué significa registrar un Singleton con AddSingleton?

- A) Compartir una instancia del registro entre las réplicas desplegadas.
- B) Compartir una instancia del registro dentro de ese contenedor de DI.
- C) Compartir una instancia del registro solo durante cada petición HTTP.
- D) Compartir una instancia del registro y serializar automáticamente su acceso.

### 13. Un BackgroundService vive toda la ejecución y trabaja en segundo plano. Si conserva un DbContext scoped desde el constructor, ¿qué ocurre?

- A) DI renueva la dependencia automáticamente al empezar cada iteración.
- B) Retiene una dependencia corta; necesita crear y liberar un scope por tarea o lote.
- C) La vida del contexto pasa a singleton y EF serializa sus consultas.
- D) Un constructor primario evita retener el contexto entre iteraciones.

### 14. TimeProvider representa el reloj. ¿Para qué lo recibimos por DI?

- A) Para convertir las fechas guardadas a la zona horaria del usuario.
- B) Para definir automáticamente el plazo de caducidad de cada inscripción.
- C) Para mantener sincronizados los relojes de las réplicas desplegadas.
- D) Para controlar el tiempo en pruebas sin depender de esperas reales.

## Patrones y aplicación

### 15. Factory significa fábrica de objetos. ¿Qué problema resuelve Game.Create en el ejemplo?

- A) Seleccionar la estrategia de precio que corresponde a cada inscripción.
- B) Reutilizar la misma instancia entre las peticiones del partido.
- C) Concentrar las comprobaciones necesarias para crear un objeto válido.
- D) Proteger también las reglas de los cambios posteriores del objeto.

### 16. Strategy significa estrategia intercambiable. Hay dos cálculos de tarifa por tipo de partido. ¿Qué diseño encaja?

- A) Dos cálculos con un contrato común y un consumidor que reciba el elegido.
- B) Dos servicios de inscripción completos que repitan los demás pasos.
- C) Dos clases registradas sin definir qué implementación recibirá el consumidor.
- D) Dos importes globales que el consumidor cambie antes de cada petición.

### 17. Adapter significa adaptador. Cambia el formato de un proveedor externo de facturación. ¿Dónde debería concentrarse la traducción?

- A) En los DTO públicos de la API, adoptando el formato del proveedor.
- B) En los métodos del dominio, para que conozcan el contrato externo.
- C) En cada consumidor, para que pueda adaptar su petición particular.
- D) En un adaptador de Infrastructure que implemente nuestro contrato.

### 18. Decorator significa envoltura con la misma interfaz. ¿Cómo añade logs, mensajes de actividad, a un servicio?

- A) Heredando de la implementación y copiando su método para añadir mensajes.
- B) Añadiendo a cada consumidor las llamadas de log antes de invocar el servicio.
- C) Envolviendo el servicio con la misma interfaz y delegando la operación.
- D) Reemplazando el servicio por otro que registre sin ejecutar la operación.

### 19. Options agrupa configuración en clases. ¿Para qué usarías `IOptions<GameListOptions>`?

- A) Para conservar el filtro temporal elegido por cada usuario del listado.
- B) Para cifrar los secretos que se cargan desde archivos de configuración.
- C) Para recibir el tamaño de página configurado mediante propiedades tipadas.
- D) Para recargar automáticamente el tamaño cada vez que cambie el archivo.

### 20. Tu servicio de la Parte I ya funciona y se acerca la demo 1. ¿Qué resultado del taller te ayuda más?

- A) Reorganizar las carpetas antes de comprobar qué comportamiento falta.
- B) Elegir una mejora verificable y dejar sus pasos y una prueba para aplicarla antes de la demo 1.
- C) Añadir los seis patrones antes de volver a ejecutar las pruebas existentes.
- D) Sustituir el servicio por slices antes de terminar sus reglas pendientes.

---

## Soluciones

| Nº | Respuesta | Por qué |
| --- | --- | --- |
| 1 | C | Varios programas pueden compartir modelo y evolución; contar procesos no demuestra autonomía. |
| 2 | A | El contrato está en Application y la implementación en Infrastructure; Domain no conoce infraestructura. |
| 3 | D | Capa y slice organizan aspectos distintos; una carpeta no exige mediador ni otra base de datos. |
| 4 | D | El consumidor no debe depender de métodos que no usa; métodos vacíos no arreglan el contrato. |
| 5 | B | Las reglas justifican el modelo, no el número de columnas. |
| 6 | C | Cantidad y moneda determinan el valor; la referencia o un identificador no lo hacen. |
| 7 | A | La raíz controla cambios; guardar con peticiones simultáneas requiere protección adicional. |
| 8 | B | El contexto no admite uso paralelo ni incluye servicios HTTP en su transacción SQL. |
| 9 | D | El contrato debe aportar algo al caso de uso, no copiar EF ni filtrar consultas hacia la web. |
| 10 | A | La comprobación previa puede quedar obsoleta; necesitamos una prueba concurrente contra SQL. |
| 11 | C | Se comparte dentro de un scope; el siguiente tiene su propia instancia. |
| 12 | B | Singleton es por registro y contenedor, no por despliegue; tampoco sincroniza el acceso. |
| 13 | B | El scope limita la duración y permite liberar el contexto. Cambiar la sintaxis del constructor no cambia esa vida. |
| 14 | D | La prueba controla el reloj; zona horaria y caducidad siguen siendo reglas explícitas. |
| 15 | C | La fábrica concentra la creación; no protege por sí sola todas las mutaciones posteriores. |
| 16 | A | El consumidor recibe una estrategia elegida explícitamente; DI no deduce el tipo de partido. |
| 17 | D | El adaptador traduce el contrato sin llevar detalles externos al dominio ni a cada consumidor. |
| 18 | C | El decorador conserva la interfaz y delega; copiar lógica o repartir logs no es esa envoltura. |
| 19 | C | Options da configuración tipada. `IOptions<T>` no ofrece recarga automática ni cifrado. |
| 20 | B | El taller parte del trabajo propio y deja una mejora con prueba y pasos concretos. |

**Revisión con Yamel:** elige dos errores o dudas y explica qué fallo concreto podrían causar. Una respuesta acertada sin poder justificarla merece repaso.
