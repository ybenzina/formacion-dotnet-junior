# Masterclass Contenedores, Compose y Aspire

**Sesión 1, 90 minutos, el domingo siguiente al Día 15 por la mañana**, después del ejercicio de Docker. Por la tarde se celebra [IA y agentes](masterclass-ai-agents.md). La [sesión 2](masterclass-cloud-azure.md) aborda Azure el domingo siguiente al Día 20.

**Cloud**, o nube, significa usar recursos de un proveedor a través de internet, como alquilar un servidor en vez de comprarlo. La primera sesión trabaja en nuestro ordenador; la segunda estudia el paso a Azure.

**Nota sobre los ejemplos:** las menciones a Àmbit son ilustrativas, no decisiones del cliente. Las prácticas de esta guía usan solo CourtConnect con datos ficticios. La estimación no es un presupuesto de Àmbit.

Formato: 12 diapositivas con notas para Yamel, taller de 25 minutos y [quiz de 12 preguntas](masterclass-cloud-quiz.md#sesión-1-contenedores-compose-y-aspire) para el día siguiente, fuera de clase.

## Objetivos

- Explicar los archivos de contenedores que Driss ya ha escrito.
- Encontrar un fallo de conexión o arranque y comprobar una mejora.
- Entender qué aporta Aspire para ejecutar y observar varias partes juntas.

## Preparación y alcance

**Driss:** trae sus Dockerfile y su `docker-compose.yml` del [ejercicio 4 de la Parte II](../../reto/Parte2/Ejercicio4/README.md), ya trabajado el Día 15. Repasa el recorrido web → API → base de datos. Una **API** ofrece operaciones a otros programas, como inscribir a un jugador. Para los costes basta un navegador.

**Yamel:** prepara una demostración local aislada de Aspire, con datos ficticios y capturas de reserva. Comprueba las versiones antes de la clase. Los ejemplos usan .NET 10; la migración a .NET 11 corresponde a la Parte III. No se crean recursos de pago durante estas sesiones ni se muestran credenciales.

## Sesión 1: Contenedores, Compose y Aspire

**El domingo siguiente al Día 15, 90 minutos.** Repaso y ampliación después del ejercicio de Docker, no preparación para empezarlo. **Compose** describe servicios que arrancan juntos, como web, API y SQL. **Aspire** ayuda a ejecutar y observar las piezas de una aplicación durante el desarrollo, como un panel de control local.

### Agenda de la sesión 1

| Bloque | Minutos | Diapositivas |
| --- | --- | --- |
| Recuperar el recorrido de CourtConnect | 5 | 1 |
| Imágenes y revisión de Dockerfile | 20 | 2 a 4 |
| Compose: red, datos y arranque | 15 | 5 a 6 |
| Aspire: AppHost y configuración común | 8 | 7 a 8 |
| Señales, comparación y demo de diagnóstico | 12 | 9 a 11 |
| Taller sobre los archivos de Driss | 25 | 12 |
| Cierre y dudas | 5 | Repaso |
| **Total** | **90** | |

### Diapositiva 01. Del código a una aplicación que funciona

**Puntos clave:**

- **Compilar** transforma el código en un programa; **ejecutar** lo pone en marcha.
- **Desplegar** lleva una versión al entorno donde se usará; **operar** es mantenerla funcionando.
- Hoy seguimos una petición de CourtConnect: navegador, web, API y SQL.

**Notas del ponente:**

**Qué decir:** «El viernes levantaste la aplicación. Hoy quiero que me expliques por qué funciona y cómo sabrías qué parte falla».

**Contexto para Yamel:** Recupera el mapa de la [clase de arquitectura](masterclass-architecture.md). No hace falta añadir funcionalidades: trabajamos sobre las piezas que ya tiene.

### Diapositiva 02. Imagen, contenedor y registry

**Puntos clave:**

- **Imagen**: paquete con la aplicación y lo necesario para ejecutarla, como una plantilla preparada.
- **Contenedor**: una ejecución de esa imagen. Podemos arrancar varias copias.
- **Registry**, o registro: almacén desde el que se publican y descargan imágenes; no las ejecuta.
- **Tag**, o etiqueta: nombre de una versión que puede cambiar de destino. La identificación por huella, digest, queda en el glosario.

**Notas del ponente:**

**Qué decir:** «Señala qué es imagen y qué es contenedor en tu ejercicio. Una etiqueta como `latest` puede apuntar mañana a otro contenido; el digest identifica uno concreto».

**Contexto para Yamel:** Relaciónalo con el commit, la versión guardada en Git. Los archivos escritos dentro del contenedor pueden perderse al reemplazarlo. Un contenedor comparte el núcleo del sistema que lo ejecuta; no es una máquina virtual completa por aplicación.

### Diapositiva 03. Dockerfile multi-stage: construir no es ejecutar

**Puntos clave:**

- **Dockerfile**: receta para construir una imagen.
- **Multi-stage**: separar etapas, como cocinar con todo el equipo y llevar a la mesa solo el plato terminado.
- El **SDK** tiene herramientas para compilar; el **runtime** ejecuta lo ya compilado.

Ejemplo del mentor, **no Dockerfile de CourtConnect**. Presupone un proyecto aislado `src/Training.Api/Training.Api.csproj`, target .NET 10 y ensamblado `DeemSoft.Training.Api`, configurado en su `Directory.Build.props` raíz:

```dockerfile
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /source
COPY . .
RUN dotnet publish src/Training.Api/Training.Api.csproj -c Release -o /app/publish --self-contained false -p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS final
WORKDIR /app
COPY --from=build /app/publish .
ENV ASPNETCORE_HTTP_PORTS=8080
EXPOSE 8080
USER $APP_UID
ENTRYPOINT ["dotnet", "DeemSoft.Training.Api.dll"]
```

**Notas del ponente:**

**Qué decir:** «¿Qué se queda fuera de la imagen final? El código fuente y las herramientas de compilación».

**Contexto para Yamel:** `publish` prepara los archivos de ejecución y restaura dependencias si hace falta. `APP_UID` es el identificador de usuario incluido en estas imágenes Linux de .NET. `ENTRYPOINT` indica el comando al arrancar. Separar copias y restauración puede reutilizar trabajo previo, la **caché** de construcción; hay que incluir también los archivos compartidos del proyecto. El fragmento prioriza entender las dos etapas, no optimizarlo todo.

### Diapositiva 04. Puertos, configuración y archivos que sobran

**Puntos clave:**

- Un **puerto** es una entrada de red de un programa, como una puerta numerada.
- `EXPOSE` documenta un puerto; no lo publica en el **host**, el equipo que ejecuta los contenedores.
- `localhost` significa «este mismo equipo o contenedor», no el contenedor de SQL de al lado.
- **`.dockerignore`** excluye archivos del contexto de construcción, la carpeta que Docker recibe para crear la imagen.
- Excluye secretos, `.git`, `bin` y `obj`. `.gitignore` no los excluye de Docker.
- **Root** es el administrador de Linux. Ejecutar la aplicación con un usuario no root limita sus permisos.

**Notas del ponente:**

**Qué decir:** «¿Qué diferencia hay entre el puerto donde escucha la API y el que abres en tu ordenador? Las variables de entorno son valores de configuración que recibe el proceso».

**Contexto para Yamel:** No copies contraseñas en `ENV`, `ARG` ni archivos de la imagen: sus capas pueden inspeccionarse. Un `.env` ignorado por Git sigue siendo texto legible. Revisa nombres de variables sin mostrar sus valores secretos.

### Diapositiva 05. Compose: describir un conjunto local

**Puntos clave:**

- El archivo usa **YAML**, un formato de texto cuya sangría organiza los datos.
- Declara servicios, redes, puertos, configuración y volúmenes.
- Los servicios se encuentran por su nombre: la API puede llamar al servicio `sql`.
- Un **volumen** guarda datos fuera de la parte desechable del contenedor, como un disco que conservas al cambiar de ordenador.

**Notas del ponente:**

**Qué decir:** «¿Qué nombre usa la API para llegar a SQL? ¿Hace falta publicar SQL a internet para eso?».

**Contexto para Yamel:** Abre el Compose de Driss. En la misma red de Compose pueden comunicarse sin publicarlo. Conservar un volumen no es tener una copia de seguridad: también puede borrarse o dañarse. No borres volúmenes durante la demostración.

### Diapositiva 06. Arrancado no significa preparado

**Puntos clave:**

- SQL puede estar arrancado y seguir preparando la base de datos.
- Un **healthcheck** comprueba si un servicio responde como esperamos.
- **Liveness** comprueba si el proceso sigue vivo; **readiness**, si está listo para recibir trabajo.
- Una **migración** cambia la estructura de la base de datos. Hay que decidir quién la aplica y cuándo.

**Notas del ponente:**

**Qué decir:** «La tienda puede tener la persiana levantada y aún no poder atender. Una dependencia saludable ayuda a ordenar el arranque, pero SQL también puede fallar después».

**Contexto para Yamel:** Reintentar una lectura puede ayudar; repetir un pago puede cobrar dos veces. La **idempotencia** evita duplicar el efecto cuando se repite una operación. No reinicies sin fin una API solo porque SQL esté caído ni dejes varias copias aplicando migraciones a la vez.

### Diapositiva 07. Aspire AppHost: coordinar las piezas

**Puntos clave:**

- **AppHost** describe qué piezas arrancan y cuáles necesitan a otras.
- **Orquestar** es coordinar esas piezas, como organizar el orden de un trabajo en equipo.
- El **dashboard** es un panel donde ver su estado y actividad.
- Ejecutar AppHost en local no equivale a desplegar en Azure.

**Notas del ponente:**

**Qué decir:** «Compose nos ayudó a entender contenedores y red. Aspire añade una vista del conjunto orientada al desarrollo».

**Contexto para Yamel:** Señala dónde la API declara que necesita SQL. Puede ejecutar proyectos directamente y usar contenedores para otras piezas. Hay herramientas para publicar a partir de ese modelo, pero requieren un flujo de despliegue configurado aparte.

### Diapositiva 08. ServiceDefaults: configuración común

**Puntos clave:**

- **ServiceDefaults** reúne salud, telemetría, descubrimiento de servicios y resiliencia; no reglas de plazas o precios.
- **Descubrimiento de servicios** resuelve nombres de servicios a sus direcciones; **resiliencia** limita el impacto de fallos transitorios mediante tiempos límite y reintentos controlados.
- **Telemetría** son datos sobre cómo funciona el programa, como el tiempo que tarda una petición.

**Notas del ponente:**

**Qué decir:** «Compartimos cómo observar y conectar los servicios, no las reglas de las plazas o los precios».

**Contexto para Yamel:** AppHost ocupa 3 minutos y esta diapositiva 5. Revisar las extensiones generadas de salud, descubrimiento y HTTP. Un reintento predeterminado no demuestra que repetir un pago sea seguro. No explicar aquí las tres clases de señales: vienen en la siguiente diapositiva.

### Diapositiva 09. OpenTelemetry: tres señales

**Puntos clave:**

- **Log:** registro de un hecho, como una consulta fallida.
- **Métrica:** medida, como el número de errores por minuto.
- **Traza:** recorrido de una operación por web, API y SQL.
- **OpenTelemetry:** herramientas y formato común para recoger y enviar señales; no es su almacén.

Instrumentación, exportador y OTLP quedan definidos en el glosario, para consultar al configurar el destino.

**Notas del ponente:**

**Qué decir:** «Un mensaje cuenta qué pasó, una medida cuánto pasa y una traza por dónde pasó la petición».

**Contexto para Yamel:** Cinco minutos para relacionar las señales con una única petición. Evitar datos personales y contraseñas. El destino necesita configuración y una recepción comprobada; la demostración sigue pendiente de ejecución antes de clase.

### Diapositiva 10. Compose y Aspire: comparar sin duplicar

**Puntos clave:**

| Aspecto | Compose | Aspire en el recorrido local |
| --- | --- | --- |
| Modelo | Servicios y contenedores en YAML | Piezas de la aplicación y sus relaciones |
| Ejecución | Principalmente contenedores | Proyectos y contenedores, entre otros |
| Diagnóstico | Logs y herramientas que configuremos | Panel integrado con la telemetría configurada |
| Uso didáctico | Entender cómo empaquetamos y conectamos | Entender el conjunto y localizar fallos |

**Notas del ponente:**

**Qué decir:** «No necesitamos dos herramientas intentando arrancar SQL en el mismo puerto. Elegimos una responsable de cada recurso».

**Contexto para Yamel:** Aspire es el siguiente paso de aprendizaje; no exige tirar el Compose que Driss acaba de hacer. Lo que funciona en local aún debe probarse con la configuración del entorno publicado.

### Diapositiva 11. Demo: localizar un fallo, no adivinarlo

**Puntos clave:**

- Encontrar web, API y SQL en el panel de la demostración.
- Hacer una lectura y seguir su traza.
- Detener solo SQL de la demostración y localizar dónde falla.
- Arrancarlo y comprobar que la lectura vuelve a funcionar.

**Notas del ponente:**

**Qué decir:** «¿Es un fallo de conexión, una contraseña incorrecta o una regla de negocio? ¿Qué evidencia lo muestra?».

**Contexto para Yamel:** Reserva 5 minutos dentro del bloque Aspire. Usa solo la demostración aislada del mentor. Si no puede ejecutarse, usa capturas verificadas y dilo. Buscamos explicar el fallo, no acertar por intuición.

### Diapositiva 12. Taller: revisar tus archivos

**Puntos clave:**

- Abrir los Dockerfile y `docker-compose.yml` de Driss en `court-connect`.
- Explicar construcción, usuario, puertos, dependencias y volumen SQL.
- Elegir una mejora y comprobarla sin cambiar reglas de negocio.
- Anotar qué observaríamos en Aspire para diagnosticar el mismo sistema.

**Notas del ponente:**

**Qué decir:** «Tú explicas la receta y yo hago preguntas».

**Contexto para Yamel:** El taller siguiente dura 25 minutos. Si algo del ejercicio sigue fallando, ese fallo es el punto de partida; no lo sustituimos por una solución completa del mentor.

### Taller de la sesión 1

1. **Recorrido, 5 minutos:** Driss muestra qué construye cada Dockerfile y qué servicio usa cada imagen en Compose.
2. **Revisión, 8 minutos:** comprobar etapas de construcción, runtime final, usuario no root, `.dockerignore`, nombres de red, puertos y secretos fuera de la imagen. Yamel pregunta qué sobra y qué falta.
3. **Prueba, 8 minutos:** elegir una mejora pequeña, reconstruir la imagen afectada y arrancar desde el Compose propio. Revisar estado y logs, probar una lectura y comprobar que SQL conserva datos tras un reinicio sin borrar su volumen.
4. **Cierre del taller, 4 minutos:** registrar cambio, resultado y una duda. Dibujar qué relación declararía AppHost y qué traza buscaríamos en su panel.

**Criterios de aceptación:**

- [ ] Driss distingue imagen, contenedor y registro usando sus propios archivos.
- [ ] Explica las dos etapas, el usuario no root y qué excluye `.dockerignore`.
- [ ] Distingue puerto interno, publicado y nombre de servicio; SQL tiene almacenamiento persistente.
- [ ] Identifica una espera de arranque y cómo sabría si la dependencia está preparada.
- [ ] La mejora tiene una comprobación con resultado registrado. Si algo bloquea la ejecución, se anota el error y la siguiente prueba.
- [ ] No se muestran secretos ni se borran volúmenes para hacer la demostración.

**Cierre de la sesión, 5 minutos:** Driss explica un error encontrado y una diferencia entre Compose y Aspire. Al día siguiente hace el [quiz de la sesión 1](masterclass-cloud-quiz.md#sesión-1-contenedores-compose-y-aspire), fuera de los 90 minutos. Las mejoras útiles se conservan para la demo del Día 16.

## Recursos de apoyo

Fuentes oficiales para preparar y actualizar la sesión; revisar versiones antes de impartirla. Los ejemplos son material de lectura, no una demostración ejecutada.

- [Contenedores .NET, Microsoft Learn](https://learn.microsoft.com/en-us/dotnet/core/docker/introduction) y [Docker Compose](https://docs.docker.com/compose/).
- [Aspire ServiceDefaults](https://aspire.dev/get-started/csharp-service-defaults/) y [documentación de Aspire](https://aspire.dev/).
- [Escalado de Container Apps](https://learn.microsoft.com/en-us/azure/container-apps/scale-app) e [identidades gestionadas](https://learn.microsoft.com/en-us/azure/container-apps/managed-identity).
- [OpenTelemetry en Application Insights](https://learn.microsoft.com/en-us/azure/azure-monitor/app/opentelemetry-enable).
- [Oferta gratuita de Azure SQL y condiciones](https://learn.microsoft.com/en-us/azure/azure-sql/database/free-offer?view=azuresql).
- [Calculadora de Azure](https://azure.microsoft.com/en-us/pricing/calculator/).
- [Resource groups con Bicep, Microsoft Learn](https://learn.microsoft.com/en-us/azure/templates/microsoft.resources/resourcegroups).
- [Referencia AzureRM resource_group](https://registry.terraform.io/providers/hashicorp/azurerm/latest/docs/resources/resource_group) y [su fuente oficial](https://github.com/hashicorp/terraform-provider-azurerm/blob/main/website/docs/r/resource_group.html.markdown).
- [Estilo y versionado en Terraform](https://developer.hashicorp.com/terraform/language/style) y [protección de datos sensibles y state](https://developer.hashicorp.com/terraform/language/manage-sensitive-data).
- [ECS sobre Fargate, AWS](https://docs.aws.amazon.com/AmazonECS/latest/developerguide/AWS_Fargate.html) y [Cloud Run, Google Cloud](https://docs.cloud.google.com/run/docs/overview/what-is-cloud-run), para contrastar límites antes de elegir.

## Glosario

**Imprescindibles (15):** imagen, contenedor, registry, Dockerfile, multi-stage, runtime, puerto, localhost, Compose, volumen, healthcheck, AppHost, ServiceDefaults, telemetría y traza.

**Que te suene:** los demás términos de consulta de la tabla. No se pide memorizar todo el catálogo.

### Vocabulario de consulta

| Término | Explicación sencilla | Ejemplo |
| --- | --- | --- |
| Cloud | Recursos de un proveedor usados por internet | Ejecutar CourtConnect en Azure |
| API | Operaciones que ofrece un programa a otro | La web pide inscribir a un jugador |
| Compilar / ejecutar | Convertir código en programa y ponerlo en marcha | Publicar la API y arrancarla |
| Desplegar / operar | Llevar una versión a un entorno y mantenerla funcionando | Publicar y revisar sus errores |
| Imagen / contenedor | Paquete preparado y una ejecución de él | Una imagen de API y dos copias en marcha |
| Registry / tag / digest | Almacén de imágenes, etiqueta y huella de contenido | Descargar una versión identificada |
| Dockerfile / multi-stage | Receta de imagen y separación en etapas | Compilar primero, ejecutar después |
| SDK / runtime | Herramientas de construcción y entorno de ejecución | SDK en la primera etapa, runtime en la final |
| Root / no root | Usuario administrador y usuario con permisos limitados | Ejecutar la API sin privilegios de administrador |
| Puerto / host / localhost | Entrada de red, equipo que aloja y referencia a uno mismo | Puerto de la API publicado en el ordenador |
| Contexto de construcción / .dockerignore | Archivos que recibe Docker y lista de exclusiones | Excluir `.env`, `bin` y `obj` |
| Variable de entorno | Valor de configuración entregado al proceso | Puerto donde escucha la aplicación |
| Caché de construcción | Trabajo previo que se reutiliza | No restaurar paquetes si no cambiaron |
| Compose / YAML | Descripción de servicios conjuntos y formato del archivo | Web, API y SQL en un archivo |
| Volumen | Almacenamiento que puede sobrevivir al contenedor | Datos de SQL tras reemplazarlo |
| Healthcheck / liveness / readiness | Comprobar salud, que vive y que está listo | SQL arrancado pero aún no preparado |
| Migración | Cambio de estructura de la base de datos | Añadir una tabla |
| Idempotencia | Repetir sin duplicar el efecto | No cobrar dos veces una inscripción |
| Aspire / AppHost | Herramientas de desarrollo y modelo de las piezas | Arrancar proyectos y SQL juntos |
| Orquestación / dashboard | Coordinación y panel para observarla | Ver qué recurso ha fallado |
| ServiceDefaults | Configuración técnica compartida | Salud, telemetría, descubrimiento y resiliencia |
| Descubrimiento / resiliencia | Resolver servicios y tolerar fallos transitorios | Encontrar la API y limitar tiempos de espera |
| Telemetría / log / métrica / traza | Datos de funcionamiento: hecho, medida y recorrido | Error, número de errores y petición afectada |
| OpenTelemetry / OTLP | Herramientas y protocolo para recoger y enviar señales | Enviar una traza al panel |
| Instrumentación / exportador | Recoger señales y enviarlas | Medir una petición y mandarla a un destino |
