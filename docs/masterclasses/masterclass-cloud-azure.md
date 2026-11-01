# Masterclass Azure, infraestructura como código y costes

**Sesión 2, 90 minutos, el domingo siguiente al Día 20**, antes del despliegue del Día 22. Requiere la [sesión local](masterclass-cloud-local.md), del domingo siguiente al Día 15.

**Cloud**, o nube, significa usar recursos de un proveedor a través de internet, como alquilar un servidor en vez de comprarlo. La primera sesión trabaja en nuestro ordenador; la segunda estudia el paso a Azure.

**Nota sobre los ejemplos:** las menciones a Àmbit son ilustrativas, no decisiones del cliente. Las prácticas de esta guía usan solo CourtConnect con datos ficticios. La estimación no es un presupuesto de Àmbit.

Formato: 20 diapositivas con notas para Yamel, taller de 30 minutos y [quiz de 12 preguntas](masterclass-cloud-quiz.md#sesión-2-azure-infraestructura-como-código-y-costes) para el día siguiente. El taller tiene una [hoja separada para Yamel](masterclass-cloud-costes-yamel.md).

## Objetivos

- Relacionar cada parte de CourtConnect con un servicio de Azure.
- Comparar dos formas de describir infraestructura mediante código.
- Estimar un mes normal y un pico pequeño de inscripciones, explicando los supuestos.

## Preparación y alcance

**Driss:** repasa el recorrido web → API → base de datos y el trabajo de caducidad de la Parte III. Una **API** ofrece operaciones a otros programas. Para los costes basta un navegador.

**Yamel:** prepara la calculadora con Container Apps Consumption y un nivel concreto de Azure SQL de laboratorio. Anota sus precios y condiciones al preparar la sesión; no hay importes verificados en esta guía. Los fragmentos son para leer: no se compilan ni despliegan aquí. No se muestran credenciales.

## Sesión 2: Azure, infraestructura como código y costes

**El domingo siguiente al Día 20, 90 minutos.** Antes del despliegue del Día 22. Hoy pasamos del ordenador local a los servicios del proveedor y practicamos cuánto podrían costar.

### Agenda de la sesión 2

| Bloque | Minutos | Diapositivas |
| --- | --- | --- |
| Modelos cloud y proveedores | 10 | 1 a 2 |
| Container Apps, Jobs, SQL e identidad; apoyos | 30 | 3 a 9 |
| Infraestructura como código: lectura comparada | 10 | 10 a 13 |
| Decisión y entrega de versiones | 5 | 14 a 15 |
| Taller: solo Container Apps y SQL en calculadora | 30 | 16 a 19 |
| Cierre y preparación del Día 22 | 5 | 20 |
| **Total** | **90** | |

### Diapositiva 01. IaaS, PaaS, SaaS y serverless

**Puntos clave:**

- **IaaS**, infraestructura como servicio: alquilar máquinas y ocuparse de su sistema y aplicación, como alquilar un local vacío.
- **PaaS**, plataforma como servicio: el proveedor mantiene la plataforma y nosotros la aplicación, como una cocina equipada.
- **SaaS**, software como servicio: usar una aplicación ya hecha, como un correo web.
- **Serverless**: el proveedor gestiona servidores y parte del escalado. No significa que no haya servidores ni que todo sea gratis.

**Notas del ponente:**

**Qué decir:** «La pregunta es cuánto trabajo gestionamos nosotros y cuánto el proveedor».

**Contexto para Yamel:** Azure Container Apps ejecuta contenedores con un enfoque serverless; no obliga a convertir la aplicación en funciones pequeñas. Aunque la base de datos sea gestionada, nosotros seguimos decidiendo permisos y comprobando que podemos recuperar nuestros datos.

### Diapositiva 02. Azure, AWS y Google Cloud

**Puntos clave:**

Son proveedores de nube. Esta tabla agrupa servicios por lo que permiten hacer; no afirma que tengan los mismos límites o precios.

| Necesidad | Azure | AWS | Google Cloud |
| --- | --- | --- | --- |
| Ejecutar contenedores | Container Apps | ECS sobre Fargate | Cloud Run |
| Guardar imágenes | Container Registry | ECR | Artifact Registry |
| Base de datos SQL gestionada | Azure SQL Database | RDS, con SQL Server entre sus motores | Cloud SQL, con SQL Server entre sus motores |
| Guardar archivos como objetos | Blob Storage | S3 | Cloud Storage |
| Proteger secretos | Key Vault | Secrets Manager | Secret Manager |
| Identificar aplicaciones sin contraseñas propias | Managed Identity y Entra ID | Roles IAM para tareas ECS | Cuentas de servicio e IAM |
| Consultar señales de funcionamiento | Azure Monitor y Application Insights | CloudWatch y X-Ray | Cloud Monitoring, Logging y Trace |

**Notas del ponente:**

**Qué decir:** «.NET no obliga a usar Azure. En este reto lo usamos para aprender un recorrido concreto».

**Contexto para Yamel:** Compara conocimientos del equipo, servicios necesarios, región donde se guardan datos, soporte y coste. **IAM** es gestión de identidades y accesos: decidir quién es cada actor y qué puede hacer. Azure SQL Database no es idéntico a una instancia SQL Server de otro proveedor. Una imagen portable no hace portables automáticamente sus datos, permisos y red.

### Diapositiva 03. CourtConnect en Container Apps

**Puntos clave:**

- **Azure Container Apps** ejecuta contenedores sin que administremos sus máquinas.
- Un **environment** es el espacio común de plataforma y red para las aplicaciones.
- Una **réplica** es una copia en ejecución.
- Para la práctica: web, API y `CourtConnect.Worker` como aplicaciones. Este host continuo de la Parte III revisa caducidades y consulta Azure SQL; la web solo llama a la API.
- **Ingress** es la entrada de tráfico: web pública y API interna para llamadas servidor a servidor dentro del mismo entorno.

**Notas del ponente:**

**Qué decir:** «La web atiende a la persona, la API recibe sus operaciones y el worker sigue ejecutándose para revisar caducidades».

**Contexto para Yamel:** Se despliega el proyecto `CourtConnect.Worker` que se construye en la Parte III: aloja el `BackgroundService`, no tiene HTTP ni ingress y no aplica migraciones. No se convierte en un proceso finito. Worker describe trabajo en segundo plano, no un producto Azure. El Job solo se estudia como alternativa de costes; adoptarlo requeriría otra decisión y cambios fuera del Día 22. Revisión y container app quedan definidos en el glosario. El worker consulta SQL mediante Infrastructure; la web no consulta SQL. Si el navegador llama directamente a la API, habría que revisar su ingress y contar esas entradas externas.

### Diapositiva 04. Escalar a cero: ¿quién vuelve a arrancar?

**Puntos clave:**

- **Escalar** es aumentar o reducir capacidad, por ejemplo pasar de una a dos réplicas.
- **Escalar a cero** apaga todas las réplicas cuando no hay trabajo.
- Una petición HTTP puede despertar una API configurada para ello. El **arranque en frío** es la espera mientras vuelve a arrancar.
- Un worker con un temporizador interno no puede despertarse si no queda ningún proceso ejecutándolo.
- Predeterminados: `minReplicas = 0`, `maxReplicas = 10`; 10 no es el máximo permitido. Sin ingress, mínimo positivo ni regla de activación, una app puede quedar a cero sin volver a arrancar.
- Nuestro worker usa `minReplicas = 1`, `maxReplicas = 1`: mantiene vivo el temporizador interno.
- Comparación: un **Job** arranca, termina una tarea y sale. Puede activarse cada cinco minutos con `*/5 * * * *` en UTC, sin un temporizador dentro de una app viva.

**Notas del ponente:**

**Qué decir:** «Un despertador dentro de un ordenador apagado no ejecuta nuestro programa».

**Contexto para Yamel:** El worker continuo es la base del reto. Sin ingress, mínimo positivo ni regla externa de activación, un temporizador interno no puede reactivar una app a cero. Un Job se factura activo durante sus ejecuciones, no mientras espera. `parallelism = 1` no impide solapamientos entre ejecuciones distintas. Cinco minutos es una hipótesis de costes de la alternativa, no una nueva regla de caducidad ni una implementación exigida. Antes de adoptarla habría que validar demora, reintentos y repetición sin duplicar efectos. Fuentes: [escalado](https://learn.microsoft.com/en-us/azure/container-apps/scale-app) y [Jobs](https://learn.microsoft.com/en-us/azure/container-apps/jobs).

### Diapositiva 05. Blazor: el estado también se despliega

**Puntos clave:**

- **Static SSR** genera la página en el servidor y envía HTML, el documento que muestra el navegador.
- **Interactive Server** mantiene una conexión con el servidor para responder a las acciones de la pantalla.
- Su **circuito** conserva el estado de esa interacción, como una conversación en curso.
- Cambiar de réplica o reiniciar puede perder estado que solo estaba en memoria.

**Notas del ponente:**

**Qué decir:** «Piensa en una inscripción a medio completar. ¿Qué debe sobrevivir si reiniciamos la web?».

**Contexto para Yamel:** La **afinidad de sesión** intenta devolver al usuario a la misma réplica; no recupera lo perdido si desaparece. **Data Protection** protege datos como cookies y necesita claves persistentes y coherentes entre copias. El cálculo usa web con mínimo cero para aprender sus costes, no como recomendación automática para Interactive Server. Una conexión persistente puede mantener actividad y cambiar las horas supuestas. Si se exige una réplica disponible, recalcular con mínimo uno y comprobar las condiciones idle. No prometer reconexión transparente ni añadir caché sin necesidad.

### Diapositiva 06. Azure SQL: datos, recuperación y permisos

**Puntos clave:**

- **Azure SQL Database** es una base de datos relacional que administra Azure; seguimos decidiendo tablas, consultas y permisos.
- El nivel elegido cambia capacidad, almacenamiento y precio.
- Una copia de seguridad solo resulta útil si sabemos restaurarla.
- Una oferta gratuita tiene límites: se comprueban antes de crear recursos.

**Notas del ponente:**

**Qué decir:** «¿Qué pasa cuando se acaba la cantidad gratuita: se pausa o empieza a cobrar? La retención indica cuánto tiempo conservamos copias».

**Contexto para Yamel:** Revisa la opción concreta del laboratorio. La recuperación debe responder cuánto podemos perder y cuánto podemos tardar en volver. Gestionar el recurso en Azure no concede automáticamente permiso para leer sus tablas.

### Diapositiva 07. Servicios de apoyo: reconocer su función

**Puntos clave:**

- **Container Registry** almacena imágenes; no las ejecuta.
- **Blob Storage** conserva archivos fuera del contenedor; no se añade al alcance del reto.
- **Application Insights** permite consultar telemetría; no corrige errores por sí solo.
- **Functions** ejecuta código ante activaciones; no se necesita para programar un Container Apps Job.

**Notas del ponente:**

**Qué decir:** «Reconocer un servicio no obliga a incorporarlo. Hoy profundizamos en Container Apps, SQL e identidad».

**Contexto para Yamel:** Mantén una línea por servicio. El registro sí entra en los costes de apoyo como tarea posterior; Blob, Functions y AKS no se añaden. La observabilidad siguiente es una lectura de configuración, no un recorrido por el portal.

### Diapositiva 08. Key Vault e identidad gestionada

**Puntos clave:**

- **Identidad gestionada**: una identidad que Azure mantiene para la aplicación, como una acreditación sin contraseña que debamos guardar.
- **Key Vault** guarda secretos con acceso controlado, como una caja fuerte para credenciales que aún necesitemos.
- **Autenticación** comprueba quién eres; **autorización**, qué puedes hacer. Tener identidad no concede todos los permisos.

**Notas del ponente:**

**Qué decir:** «La acreditación te identifica; otra regla decide qué puertas abre».

**Contexto para Yamel:** Para conectar la API con SQL hacen falta configuración del cliente, identidad aceptada, usuario y permisos en SQL, y una conexión de red permitida. Key Vault puede custodiar secretos de pruebas que sigan siendo necesarios. Cambiarlos periódicamente se llama **rotación**. En local se usa una identidad de desarrollo autorizada; no aparece automáticamente la identidad de Azure.

### Diapositiva 09. OpenTelemetry hacia Application Insights

**Puntos clave:**

- **Application Insights** permite consultar el funcionamiento de la aplicación dentro de Azure Monitor.
- **OpenTelemetry** recoge señales. Una **traza** relaciona los pasos de una operación; exportador queda como consulta en el glosario.
- Una misma traza ayuda a relacionar el paso por web, API y SQL.
- En aplicaciones nuevas, la guía recomienda **Microsoft OpenTelemetry Distro**, un paquete de instrumentación listo para configurar, no inicializar dos distribuciones a la vez.

Fragmento de lectura con el paquete `Microsoft.OpenTelemetry`; el destino se configura mediante `APPLICATIONINSIGHTS_CONNECTION_STRING` en el entorno:

```csharp
using Microsoft.OpenTelemetry;
builder.UseMicrosoftOpenTelemetry(options =>
{
  options.Exporters = ExportTarget.AzureMonitor;
});
```

**Notas del ponente:**

**Qué decir:** «El panel local de Aspire y Application Insights son destinos distintos; estar en Azure no cambia el destino por arte de magia».

**Contexto para Yamel:** El fragmento presupone un `WebApplicationBuilder`. La recomendación para nuevas aplicaciones es `Microsoft.OpenTelemetry`; las que ya usan Azure Monitor OpenTelemetry Distro no requieren una migración automática. Al partir de ServiceDefaults, revisar la configuración existente para no duplicar proveedores ni exportaciones. Comprobar recepción de una traza antes de darlo por instrumentado. No se ha ejecutado esa comprobación aquí. Referencia: [guía oficial](https://learn.microsoft.com/en-us/azure/azure-monitor/app/opentelemetry-enable?tabs=aspnetcore).

### Diapositiva 10. IaC: describir, revisar y repetir

**Puntos clave:**

- **IaC**, infraestructura como código: describir recursos en archivos, como una receta para preparar un entorno.
- El archivo puede revisarse en Git antes de crear o cambiar recursos.
- Una **vista previa** muestra qué se propone crear, modificar o borrar.
- Crear infraestructura y publicar una versión de la aplicación son pasos distintos.

**Notas del ponente:**

**Qué decir:** «Si mañana necesitamos otro entorno, ¿cómo recordamos cada opción que marcamos a mano? IaC deja una descripción revisable».

**Contexto para Yamel:** **Deriva** significa que lo creado a mano ya no coincide con esa descripción. Compararemos un grupo de recursos vacío, una carpeta lógica de Azure que reúne recursos para gestionarlos. Leemos los ejemplos; no los ejecutamos.

### Diapositiva 11. El mismo grupo de recursos con Bicep

**Puntos clave:**

- **Bicep** es un lenguaje de Azure para describir qué recursos queremos, no cada clic para crearlos.
- **ARM**, Azure Resource Manager, es el sistema de Azure que recibe y gestiona esos despliegues.
- `targetScope` indica el alcance; aquí, la **suscripción**, que agrupa recursos y facturación.
- `what-if` permite previsualizar cambios. No hace falta mantener un archivo de estado cliente como en Terraform.

```bicep
targetScope = 'subscription'

param resourceGroupName string = 'rg-training-demo'
param location string = 'westeurope'

resource training 'Microsoft.Resources/resourceGroups@2025-04-01' = {
  name: resourceGroupName
  location: location
  tags: {
    purpose: 'training'
  }
}
```

**Notas del ponente:**

**Qué decir:** «Leemos el nombre, la ubicación y la etiqueta `purpose`. Estamos describiendo una carpeta lógica, no desplegando CourtConnect».

**Contexto para Yamel:** La ubicación del grupo no fija la de todos sus recursos. [Microsoft Learn documenta la versión de API del ejemplo](https://learn.microsoft.com/en-us/azure/templates/microsoft.resources/2025-04-01/resourcegroups) y su alcance de suscripción. La fecha del identificador es una versión de API, no una fecha de clase. Azure conserva el estado real; borrar una línea no garantiza borrar un recurso. Dedicamos dos minutos a leerlo, no a desplegar.

### Diapositiva 12. El mismo grupo de recursos con Terraform

**Puntos clave:**

- **Terraform** describe infraestructura de distintos proveedores con un flujo común.
- Un **provider** es el complemento que sabe hablar con un proveedor; AzureRM gestiona estos recursos de Azure.
- **Plan** muestra los cambios propuestos antes de aplicarlos.
- Soportar varias nubes no convierte automáticamente un recurso de Azure en uno de AWS.

Fragmento equivalente para leer. Para ejecutarlo harían falta el provider `hashicorp/azurerm` con versión fijada, autenticación, suscripción y estado protegido:

```hcl
resource "azurerm_resource_group" "training" {
  name     = "rg-training-demo"
  location = "westeurope"
  tags     = { purpose = "training" }
}
```

**Notas del ponente:**

**Qué decir:** «Busca los mismos tres datos que en Bicep: nombre, ubicación y etiqueta. Validar comprueba la configuración; planificar permite revisar lo que cambiaría; aplicar hace el cambio».

**Contexto para Yamel:** Los ejemplos son alternativas: no gestionamos el mismo recurso con los dos a la vez. La adopción de un recurso existente requiere decidir quién lo gestiona e incorporarlo a su registro. Referencia: [AzureRM resource_group](https://registry.terraform.io/providers/hashicorp/azurerm/latest/docs/resources/resource_group).

### Diapositiva 13. Terraform state y criterios de elección

**Puntos clave:**

**State**, o estado de Terraform, es el registro que relaciona lo escrito en código con los recursos reales, como un inventario con sus identificadores.

| Aspecto | Bicep | Terraform |
| --- | --- | --- |
| Alcance | Azure | Varios proveedores, con recursos propios de cada uno |
| Estado | Azure guarda los recursos; no gestionamos un state cliente equivalente | Hay que guardar y proteger el state |
| Vista previa | `what-if` | `plan` |
| Ventaja principal | Integración directa con Azure | Flujo común para varias nubes |
| Trabajo adicional | Conocer el modelo de despliegue de Azure | Gestionar también el almacenamiento y protección del state |

**Notas del ponente:**

**Qué decir:** «Un inventario de infraestructura puede contener información sensible».

**Contexto para Yamel:** `sensitive` oculta valores en ciertas salidas, pero no los cifra ni garantiza que no estén en el state. Un **backend** de Terraform es el lugar donde lo guarda; en equipo debe ser remoto, protegido y con bloqueo para evitar escrituras simultáneas. El archivo de **lock** fija versiones de proveedores y sí se versiona; state y planes sensibles no. Para elegir, pesa la experiencia del equipo y los proveedores que realmente usará, no el número de logotipos soportados.

### Diapositiva 14. Elegir sin ampliar el reto

**Puntos clave:**

- Web y API atienden peticiones; `CourtConnect.Worker`, construido en la Parte III, revisa caducidades continuamente.
- Container Apps ejecuta las tres aplicaciones; SQL conserva los datos.
- Jobs queda como comparación de una tarea finita, no como requisito del Día 22.
- Elegir una sola herramienta IaC para gestionar cada recurso.
- Antes de añadir otro producto, explicar qué necesidad concreta queda sin cubrir.

**Notas del ponente:**

**Qué decir:** «Primero sabemos qué trabajo hay que hacer; después elegimos quién lo ejecuta».

**Contexto para Yamel:** Una tarea puede revisar periódicamente dentro de un proceso continuo. Lo que distingue al Job es que el proceso termina. No pedir esa adaptación en el reto ni usar dos gestores sobre el mismo recurso IaC.

### Diapositiva 15. Entrega: CI, OIDC y una revisión recuperable

**Puntos clave:**

- **CI**, integración continua: comprobar automáticamente cada cambio, como un control de calidad antes de entregar.
- **OIDC** permite que GitHub Actions se identifique ante Azure mediante una relación de confianza y credenciales temporales, sin una contraseña duradera guardada.
- Publicamos una imagen identificable, comprobamos la nueva revisión y observamos errores.
- **Rollback** significa volver a una versión anterior. Hay que comprobar que sigue siendo compatible con la base de datos.

**Notas del ponente:**

**Qué decir:** «La imagen que publicamos debe corresponder a una versión conocida del código».

**Contexto para Yamel:** La confianza de OIDC se limita a repositorio, rama o entorno autorizado. No damos permisos de despliegue a código de un PR no revisado. La identidad que despliega y la que usa la aplicación tienen trabajos distintos. Volver a la imagen anterior no deshace una migración de datos.

### Diapositiva 16. Coste: explicar de dónde sale cada cifra

**Puntos clave:**

- Anota fecha, región, moneda y **SKU**, el nivel o modalidad que se contrata.
- Separa coste fijo, tiempo de ejecución, datos guardados y datos enviados.
- **Active** significa consumo activo; **idle**, una réplica encendida sin trabajo activo, según las reglas de facturación del servicio.
- En Consumption, cero réplicas no consume cómputo facturable. Idle requiere mínimo positivo, estar en ese mínimo y cumplir umbrales de inactividad; no basta con que nadie abra la web.
- Se cuentan solo peticiones HTTP que entran **desde fuera del entorno**, no la llamada interna web → API. Otros servicios siguen teniendo sus propios costes.
- Un presupuesto con alertas avisa; no es un interruptor que corte todo el gasto.

**Notas del ponente:**

**Qué decir:** «La calculadora pone precio a los datos que le damos. No sabe si hemos elegido una máquina adecuada».

**Contexto para Yamel:** Consumption incluye por suscripción y mes natural 180.000 vCPU-s, 360.000 GiB-s y 2 millones de peticiones. No multiplicar por app ni descontar dos veces. Una réplica por encima del mínimo se factura activa; en el mínimo positivo, idle exige contenedores arrancados, ninguna petición HTTP, menos de 0,01 vCPU y menos de 1.000 bytes/s de red. Jobs solo tienen consumo activo mientras ejecutan. Fuente: [facturación oficial](https://learn.microsoft.com/en-us/azure/container-apps/billing). Crédito temporal y franquicia recurrente son distintos.

### Diapositiva 17. El mapa que vamos a presupuestar

**Puntos clave:**

- Web → API → Azure SQL; la web no consulta SQL directamente.
- `CourtConnect.Worker` (Parte III) → Azure SQL para revisar inscripciones pendientes, sin HTTP ni ingress.
- Web, API y worker son apps; el registro guarda las imágenes.
- Key Vault custodia secretos necesarios y la telemetría ayuda a diagnosticar fallos.

**Notas del ponente:**

**Qué decir:** «¿Qué consumo cambiaría si sustituyéramos el worker encendido por ejecuciones finitas?».

**Contexto para Yamel:** Parte de `CourtConnect.Worker`, construido en la Parte III, con mínimo y máximo uno; el Job es una alternativa no implementada. El worker y la API acceden a SQL; la web no. El worker no aplica migraciones. Las identidades y permisos se anotan en las flechas, no como contraseñas en una imagen. Las diapositivas 16 a 19 se explican dentro del taller, no como otro bloque adicional.

### Diapositiva 18. Pocos usuarios y un pico de inscripciones

**Puntos clave:**

- Mes normal: 30 días con poco uso.
- Mes con torneo: 29 días normales y un día de apertura, con 40 inscripciones en dos horas.
- Son datos ficticios de aprendizaje; no proceden de una aplicación medida.
- Más usuarios no indican por sí solos cuánta CPU o memoria necesitamos.
- **CPU:** ejecuta instrucciones; **vCPU:** unidad de procesador virtual; **memoria:** conserva datos de trabajo mientras el proceso vive.

**Notas del ponente:**

**Qué decir:** «No sumes 30 días normales y otro día entero de torneo: serían 31».

**Contexto para Yamel:** La **CPU** ejecuta instrucciones; la **memoria** conserva datos de trabajo mientras el proceso vive. Una **vCPU** es una unidad de capacidad de procesador virtual. La calculadora estima el precio; una prueba de carga, que simula varias peticiones, ayudaría después a comprobar capacidad y tiempos de respuesta.

### Diapositiva 19. Cambiar una variable y comparar

**Puntos clave:**

- Completa Container Apps y SQL con unidades y fuente del precio; los apoyos quedan como tarea.
- Compara normal y pico manteniendo la misma región y moneda.
- **Análisis de sensibilidad**: cambiar una variable para ver cuánto afecta, como sustituir el worker continuo por un Job.
- Si falta un precio o consumo, escribe «pendiente», no cero.

**Notas del ponente:**

**Qué decir:** «¿Qué pesa más: las dos horas de una réplica adicional o mantener el worker todo el mes?».

**Contexto para Yamel:** Primero comparar cantidades de cómputo; después consultar sus tarifas. Si faltan partidas, el resultado es un subtotal. Guardar la estimación sin datos de una cuenta real. La hoja de Yamel contiene cantidades de control, no una solución del ejercicio de programación.

### Diapositiva 20. Preparar el despliegue del Día 22

**Puntos clave:**

- Explicar qué servicio de Azure necesita cada pieza de CourtConnect.
- Revisar permisos, estado de la web y mínimos y máximos de web, API y worker.
- Conservar la estimación, los límites del laboratorio y el plan de limpieza.
- Hacer el despliegue en el ejercicio del Día 22, con la suscripción que indique Yamel.

**Notas del ponente:**

**Qué decir:** «Antes de crear nada, explícame qué vamos a pagar, qué puede quedar encendido y cómo lo retiraremos».

**Contexto para Yamel:** Para el cierre de 5 minutos, pide una diferencia entre proveedores, un riesgo de permisos y una variable de coste por medir. Al día siguiente se hace el [quiz de la sesión 2](masterclass-cloud-quiz.md#sesión-2-azure-infraestructura-como-código-y-costes), fuera de la clase.

### Taller de costes de CourtConnect

**Tiempo:** 30 minutos incluidos: mapa 4, supuestos 6, calculadora 15 y revisión 5. **Entrega:** mapa de CourtConnect, dos estimaciones comparables y una tabla de supuestos. Todos los datos son ficticios, a escala del reto. No se crean recursos.

Yamel deja preparada la calculadora. **En clase solo se calculan Container Apps (web, API y worker continuo) y Azure SQL**. Registro, Key Vault, telemetría y salida de datos se completan como tarea: el resultado de clase es un subtotal. El Job se compara sustituyendo al worker, sin implementarlo.

#### Mapa y supuestos de uso

Durante los primeros 4 minutos, dibuja web → API → SQL y `CourtConnect.Worker` → SQL. Son tres apps del mismo entorno: web pública, API interna y worker sin ingress. El worker se construye en la Parte III; la web no consulta SQL. Añade registro, Key Vault y telemetría como apoyos pendientes de precio. Marca identidades y datos que deben sobrevivir a un reinicio.

Durante los siguientes 6 minutos, lee los supuestos. Un mes normal tiene poco uso; el segundo sustituye un día normal por la apertura de inscripciones de un torneo.

| Entrada | Mes normal | Mes con torneo |
| --- | --- | --- |
| Periodo | 30 días normales | 29 normales y 1 de pico |
| Usuarios activos | 5 al día | 40 durante el día del pico |
| Inscripciones en la apertura del torneo | Sin apertura de torneo | 40 en dos horas |
| Peticiones HTTP desde fuera del entorno, a la web | 200 al día | 2.000 durante el día del pico |
| Llamadas internas web → API | No se suman al medidor HTTP externo | No se suman al medidor HTTP externo |
| Datos SQL guardados | 1 GB | 1 GB |
| Telemetría enviada | 10 MB al día | 50 MB durante el día del pico |
| Imágenes guardadas en el registro | 1 GB | 1 GB |
| Operaciones de Key Vault | 300 al mes | 330 al mes |
| Salida de datos hacia internet | 1 GB al mes | 1,2 GB al mes |

**Control de cálculo:** normal = 6.000 peticiones y 300 MB de telemetría. Mes con torneo = 7.800 peticiones y 340 MB. Para convertir estas cantidades usamos 1 GB = 1.000 MB. Son volúmenes pequeños deliberadamente; no son resultados medidos.

#### Supuestos de ejecución

Para practicar el cálculo en Container Apps, usamos **0,25 vCPU y 0,5 GiB de memoria por réplica**. GiB es una unidad de memoria basada en potencias de dos; no es exactamente lo mismo que GB. Es una entrada ficticia para calcular precios, no una recomendación de capacidad para Blazor o .NET.

| Recurso y activación | Límites explícitos | Mes normal | Mes con torneo |
| --- | --- | --- | --- |
| Web, HTTP público | `minReplicas = 0`, `maxReplicas = 1` | 30 h activas; 690 h a cero | 32 h activas; 688 h a cero |
| API, HTTP interno | `minReplicas = 0`, `maxReplicas = 2` | 30 h activas; 690 h a cero | Base: 32 h activas y 688 h a cero; extra: 2 h activas |
| Base: worker continuo, temporizador | `minReplicas = 1`, `maxReplicas = 1` | 720 h activas | 720 h activas |
| Alternativa: Job programado, cada 5 minutos UTC | Una réplica por ejecución; no usa `minReplicas` | 30 s por ejecución | 30 s por ejecución |

El Job se compara con el worker, **no se suman ambos**. Suponemos ejecuciones sin fallos, reintentos ni solapamientos, incluyendo arranque y apagado en los 30 s. Las horas activas de las apps incluyen arranques y espera de reducción de réplicas. Con mínimo cero, el resto es tiempo a cero, no idle. Para el worker la clasificación activa todo el mes es una hipótesis conservadora; medir sus umbrales antes de presupuestarlo realmente. No afirmamos que 40 personas necesiten otra réplica ni que este tamaño baste para Blazor.

**Control de unidades:** `vCPU-s = horas-réplica × 3.600 × vCPU`; `GiB-s = horas-réplica × 3.600 × GiB`. Calcula primero web, API y worker; después, las ejecuciones del Job alternativo por día y por mes. Contrasta los totales con 180.000 vCPU-s y 360.000 GiB-s gratuitos por suscripción y mes natural, suponiendo que ninguna otra carga los ha consumido. No son una franquicia por aplicación.

#### Pasos en la calculadora

1. **Fija el contexto:** fecha de la estimación, región de ejemplo `West Europe`, moneda EUR y mes de 30 días. Si una partida usa un mes normalizado de 730 horas, documenta la diferencia y usa el mismo criterio en las dos estimaciones.
2. **Container Apps:** selecciona Consumption e introduce web, API y worker continuo, con recursos y duraciones anteriores. Cuenta 6.000 o 7.800 peticiones externas, no llamadas internas. Comprueba qué franquicia descuenta la calculadora y no la restes otra vez.
3. **Azure SQL:** elige con Yamel un nivel de laboratorio disponible y mantenlo igual en los dos escenarios. Incluye capacidad, almacenamiento y copias. Un GB guardado no permite deducir cuánta capacidad de cálculo hace falta. Registra las condiciones de la oferta gratuita si se usa.
4. **Deja los apoyos para casa:** registro, Key Vault, telemetría con retención y salida de datos. No se confunde pendiente con gratis ni se duplica la ingesta, los datos recibidos por el servicio.
5. **Compara:** duplica la estimación y cambia solo los supuestos del torneo. Mantén región, moneda y nivel SQL. Guarda enlace o exportación sin datos de cuentas reales.
6. **Revisa:** durante los últimos 5 minutos, sustituye el worker por el Job. Compara cómputo antes y después de la franquicia, sin implementar esa alternativa. Explica qué hipótesis medirías y qué alerta pondrías. Presenta un subtotal hasta completar los apoyos.

#### Hoja de resultados

| Partida | Hipótesis y unidad | Normal | Pico | Fuente, fecha o pendiente |
| --- | --- | --- | --- | --- |
| Container Apps: web | Pendiente | Pendiente | Pendiente | Calculadora |
| Container Apps: API | Pendiente | Pendiente | Pendiente | Calculadora |
| Container Apps: worker continuo | 720 horas-réplica activas | Pendiente | Pendiente | Calculadora |
| Alternativa Job, no sumada al worker | Ejecuciones y segundos | Pendiente | Pendiente | Comparación separada |
| Azure SQL y copias | Pendiente | Pendiente | Pendiente | Calculadora y condiciones del nivel |
| Key Vault | Pendiente | Pendiente | Pendiente | Calculadora |
| Registro de contenedores | Nivel y GB | Pendiente | Pendiente | Calculadora |
| Telemetría y retención | MB o GB y días | Pendiente | Pendiente | Calculadora; sin duplicar ingesta |
| Salida de datos | GB al mes | Pendiente | Pendiente | Calculadora |
| Subtotal de partidas conocidas | Suma con pendientes visibles | Pendiente | Pendiente | No es total si faltan partidas |
| Cantidades gratuitas verificadas | Condiciones y alcance | Pendiente | Pendiente | Sin descontar dos veces |
| Créditos temporales | Separados del coste mensual | Pendiente | Pendiente | Fecha de caducidad |

#### Criterios de aceptación

- [ ] En clase se calculan Container Apps y SQL; los apoyos quedan identificados como tarea pendiente.
- [ ] Se explican normal y torneo sin añadir un día extra al mes.
- [ ] Se distinguen usuarios, peticiones y recursos de cómputo; la capacidad se marca como hipótesis.
- [ ] Hay mínimos y máximos explícitos de web, API y worker; la comparación Job tiene horario, duración y número de ejecuciones calculado, sin implementación.
- [ ] Se distinguen horas activas, tiempo a cero e idle; la comparación no suma Job y worker.
- [ ] Se comprueban vCPU-s y GiB-s frente a la franquicia y se cuentan solo peticiones externas.
- [ ] Cada importe tiene unidad, región, moneda, fecha y fuente; lo desconocido queda pendiente.
- [ ] Se revisan las condiciones gratuitas sin multiplicarlas por aplicación ni duplicar descuentos.
- [ ] Hay una comparación Job frente a worker y una alerta propuesta con su límite.
- [ ] Driss puede explicar qué necesita medir antes de fiarse de la estimación.

## Recursos de apoyo

Fuentes oficiales consultadas para las reglas de escalado, facturación, Jobs y OpenTelemetry. Revisar precios, ofertas y versiones antes de impartirla; las fechas de API son identificadores técnicos, no convocatorias.

- [Contenedores .NET, Microsoft Learn](https://learn.microsoft.com/en-us/dotnet/core/docker/introduction) y [Docker Compose](https://docs.docker.com/compose/).
- [Aspire ServiceDefaults](https://aspire.dev/get-started/csharp-service-defaults/) y [documentación de Aspire](https://aspire.dev/).
- [Escalado de Container Apps](https://learn.microsoft.com/en-us/azure/container-apps/scale-app) e [identidades gestionadas](https://learn.microsoft.com/en-us/azure/container-apps/managed-identity).
- [Facturación Consumption y franquicias](https://learn.microsoft.com/en-us/azure/container-apps/billing) y [Container Apps Jobs](https://learn.microsoft.com/en-us/azure/container-apps/jobs).
- [OpenTelemetry en Application Insights](https://learn.microsoft.com/en-us/azure/azure-monitor/app/opentelemetry-enable).
- [Oferta gratuita de Azure SQL y condiciones](https://learn.microsoft.com/en-us/azure/azure-sql/database/free-offer?view=azuresql).
- [Calculadora de Azure](https://azure.microsoft.com/en-us/pricing/calculator/).
- [Resource groups con Bicep, Microsoft Learn](https://learn.microsoft.com/en-us/azure/templates/microsoft.resources/resourcegroups).
- [Referencia AzureRM resource_group](https://registry.terraform.io/providers/hashicorp/azurerm/latest/docs/resources/resource_group) y [su fuente oficial](https://github.com/hashicorp/terraform-provider-azurerm/blob/main/website/docs/r/resource_group.html.markdown).
- [Estilo y versionado en Terraform](https://developer.hashicorp.com/terraform/language/style) y [protección de datos sensibles y state](https://developer.hashicorp.com/terraform/language/manage-sensitive-data).
- [ECS sobre Fargate, AWS](https://docs.aws.amazon.com/AmazonECS/latest/developerguide/AWS_Fargate.html) y [Cloud Run, Google Cloud](https://docs.cloud.google.com/run/docs/overview/what-is-cloud-run), para contrastar límites antes de elegir.

## Glosario

**Imprescindibles (15):** Container Apps, environment, réplica, ingress, escalado, Job, Azure SQL, identidad gestionada, Key Vault, autorización, IaC, vCPU-s, GiB-s, franquicia y SKU.

**Que te suene:** los demás términos de consulta. No se pide memorizar los catálogos de tres proveedores.

### Vocabulario de consulta

| Término | Explicación sencilla | Ejemplo |
| --- | --- | --- |
| IaaS / PaaS / SaaS | Alquilar infraestructura, plataforma o aplicación | Máquina virtual, plataforma de contenedores o correo web |
| Serverless | El proveedor gestiona servidores y parte del escalado | Container Apps |
| IAM / Entra ID | Gestión de identidades y accesos, y servicio de identidad de Microsoft | Comprobar quién llama |
| Container Apps / environment / container app | Ejecución gestionada, espacio común y definición de una aplicación | Web, API y worker en un entorno |
| Job / cron / UTC | Trabajo finito, expresión de horario y referencia temporal | Revisar caducidades cada cinco minutos |
| vCPU-s / GiB-s | Capacidad asignada multiplicada por segundos de ejecución | 0,25 vCPU durante 30 s son 7,5 vCPU-s |
| Franquicia | Cantidad gratuita con condiciones y ámbito definidos | Cómputo compartido por suscripción y mes |
| Revisión / réplica | Versión de configuración y copia ejecutándose | Dos copias de una API publicada |
| Worker | Programa que trabaja sin petición de usuario | Revisar inscripciones pendientes |
| Ingress | Entrada de tráfico a una aplicación | Acceso público a la web |
| Escalado / arranque en frío | Cambiar capacidad y esperar a que vuelva a arrancar | Pasar de cero a una réplica |
| Static SSR / Interactive Server | Página generada en servidor e interacción con conexión persistente | Listado público y gestión de partidos |
| Circuito / afinidad de sesión | Estado de interacción y envío a la misma réplica | Mantener una interacción con la web |
| Data Protection | Protección de datos de aplicación con claves | Proteger cookies de acceso |
| Azure SQL / retención | Base de datos gestionada y tiempo que se conservan copias | Restaurar una versión anterior |
| Blob Storage | Almacén de archivos como objetos | Una imagen fuera del disco del contenedor |
| Identidad gestionada | Identidad de aplicación mantenida por Azure | API identificándose ante SQL |
| Autenticación / autorización | Comprobar quién eres y qué puedes hacer | Identidad válida con permiso de lectura |
| Key Vault / rotación | Almacén protegido y cambio de secretos | Renovar una credencial de pruebas |
| Application Insights / muestreo | Consulta de telemetría y selección de parte de ella | Conservar una parte de las trazas |
| IaC / deriva | Infraestructura en archivos y diferencias respecto a lo creado | Un permiso cambiado a mano |
| Grupo de recursos / suscripción | Agrupación lógica de recursos y ámbito de gestión y facturación | Grupo del laboratorio en la suscripción indicada |
| Bicep / ARM / what-if | Lenguaje, gestor Azure y vista previa | Revisar un grupo antes de crearlo |
| Terraform / provider / módulo | Herramienta, complemento de proveedor y conjunto reutilizable | Módulo que usa AzureRM |
| Plan / state / backend / lock | Cambios propuestos, inventario, lugar donde se guarda y versiones fijadas | Revisar cambios sin subir el state a Git |
| Sensitive | Oculta un valor en ciertas salidas; no lo cifra | Un secreto que aún puede estar en el state |
| Kubernetes / clúster / AKS / Functions | Coordinador de contenedores, grupo de máquinas, Kubernetes gestionado en Azure y código activado por eventos | Productos que no se incorporan al reto |
| CI / OIDC / rollback | Comprobación automática, identidad temporal federada y vuelta a una versión anterior | Publicar una imagen revisada |
| SKU / active / idle | Modalidad, uso activo y réplica encendida sin trabajo activo | Dos tipos de tiempo facturable |
| CPU / vCPU / memoria / GiB | Procesador, capacidad virtual, datos de trabajo y unidad binaria de memoria | Recursos de cada réplica |
| Ingesta / sensibilidad | Datos recibidos y efecto de cambiar una variable | Duplicar la telemetría en la calculadora |
