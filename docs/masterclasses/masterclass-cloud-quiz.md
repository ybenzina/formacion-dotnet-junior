# Quiz de la masterclass de contenedores, Aspire y cloud

## Instrucciones

- Hay dos quizzes de **12 preguntas**, como tarea al día siguiente de cada sesión de la [masterclass](masterclass-cloud.md).
- **12–15 minutos por quiz**, fuera de los 90 minutos de clase. Una respuesta correcta por pregunta y un punto por acierto.
- Referencia de autoevaluación: **9/12 en cada sesión**. Explica cada error con un ejemplo propio.
- Las soluciones están al final, separadas por sesión. No hace falta contratar recursos ni memorizar precios.

## Sesión 1: Contenedores, Compose y Aspire

**Tras la sesión del domingo siguiente al Día 15. Preguntas 1–12.** Repasa tus archivos de Docker si una respuesta te genera dudas.

### 1. ¿Qué diferencia una imagen de un contenedor?

- A) La imagen contiene código fuente; el contenedor se ocupa de compilarlo.
- B) La imagen es una ejecución; el contenedor es la receta para construirla.
- C) La imagen conserva datos cambiantes; el contenedor conserva sus versiones.
- D) La imagen es un paquete; el contenedor es una ejecución de ese paquete.

### 2. Un Dockerfile es la receta de una imagen. Multi-stage separa la construcción en etapas. ¿Para qué lo usamos?

- A) Separar web y SQL en etapas que se ejecuten juntas al arrancar.
- B) Compilar con SDK y llevar el resultado a una imagen de ejecución.
- C) Copiar todas las etapas a producción para reutilizar la caché local.
- D) Publicar cada etapa como una réplica distinta del mismo servicio.

### 3. La receta contiene `EXPOSE 8080`. ¿Qué hace esa línea?

- A) Publica el puerto en el host sin otra configuración de red.
- B) Documenta un puerto, sin configurar su escucha ni publicarlo.
- C) Configura la escucha HTTP de ASP.NET Core dentro del contenedor.
- D) Reserva ese puerto para impedir que otro contenedor lo utilice.

### 4. Compose coordina varios servicios. Arranca SQL antes que la API, pero la primera petición falla. ¿Qué puede ocurrir?

- A) SQL sigue preparándose; el orden de arranque no implica disponibilidad.
- B) La API necesita que SQL publique su puerto al exterior del host.
- C) Compose necesita que API y SQL compartan el mismo Dockerfile.
- D) SQL necesita eliminar su volumen para aceptar la primera conexión.

### 5. Un volumen guarda datos fuera de la parte desechable del contenedor. ¿Qué permite en SQL local?

- A) Recuperar una tabla borrada sin disponer de una copia de seguridad.
- B) Replicar los datos entre las máquinas del equipo al usar el mismo volumen.
- C) Conservar los datos al sustituir el contenedor si mantenemos el volumen.
- D) Cifrar los datos automáticamente al separarlos de la imagen de SQL.

### 6. AppHost describe las piezas que Aspire arranca durante el desarrollo. ¿Qué hace en esta sesión?

- A) Publica en Azure los recursos declarados al abrir el panel local.
- B) Cambia las capas para que cada proyecto tenga su propia base SQL.
- C) Sustituye la configuración de producción por las direcciones de desarrollo.
- D) Coordina piezas locales; desplegarlas requiere otro flujo configurado.

### 7. ServiceDefaults es un lugar para configuración técnica común. ¿Qué debería contener?

- A) Salud, telemetría, descubrimiento de servicios y resiliencia HTTP.
- B) Salud, telemetría, reglas de plazas y políticas de precio comunes.
- C) Descubrimiento, entidades de EF y consultas de los módulos del dominio.
- D) Resiliencia, migraciones automáticas y secretos compartidos en código.

### 8. OpenTelemetry recoge señales de funcionamiento. Una traza sigue una operación. ¿Qué nos ayuda a ver?

- A) El promedio mensual de errores, sin relacionarlos con una petición.
- B) La configuración deseada de cada contenedor antes de arrancarlo.
- C) El recorrido de una operación y dónde consume tiempo o falla.
- D) El historial de versiones que produjo una imagen del registro.

### 9. ¿Para qué sirve `.dockerignore`, la lista de archivos que Docker excluye de la construcción?

- A) Para eliminar secretos que ya se publicaron en capas de una imagen.
- B) Para excluir archivos del conjunto enviado al construir una imagen.
- C) Para impedir que Git incluya los archivos de compilación al confirmar.
- D) Para negar al proceso el acceso a archivos del contenedor en ejecución.

### 10. Root es el usuario administrador de Linux. ¿Por qué ejecutar la aplicación con un usuario no root?

- A) Para cifrar las variables de entorno que recibe el proceso al arrancar.
- B) Para impedir que una consulta SQL defectuosa lea datos de otro usuario.
- C) Para limitar los permisos del proceso y reducir el impacto de un fallo.
- D) Para aislar la aplicación con un núcleo Linux exclusivo del contenedor.

### 11. `localhost` significa «este mismo equipo o contenedor». La API llama a `localhost` para encontrar SQL en otro contenedor. ¿Qué revisarías?

- A) El nombre de servicio SQL y la red que comparte con la API.
- B) El puerto publicado de la API, usándolo también como puerto SQL.
- C) El nombre del volumen SQL, usándolo como dirección de conexión.
- D) La etiqueta de la imagen SQL, usándola como nombre de servidor.

### 12. Un registry almacena imágenes. Un tag es una etiqueta y un digest identifica el contenido. ¿Qué afirmación es correcta?

- A) Un tag identifica contenido inmutable y un digest indica la rama.
- B) Un digest acredita que la imagen pasó un análisis de vulnerabilidades.
- C) Un tag permite recuperar una imagen aunque el registro la borre.
- D) Un digest identifica contenido; una etiqueta puede cambiar de destino.

## Sesión 2: Azure, infraestructura como código y costes

**Tras la sesión del domingo siguiente al Día 20. Preguntas 13–24.** Se corrigen por separado de la sesión 1.

### 13. La base normal con worker continuo consume 702.000 vCPU-s y 1.404.000 GiB-s. Hay 180.000 y 360.000 de franquicia disponibles, respectivamente. ¿Qué queda?

- A) Cero cómputo facturable, porque cada aplicación recibe la franquicia completa.
- B) 522.000 vCPU-s y 1.044.000 GiB-s, con SQL incluido en esa misma partida.
- C) 522.000 vCPU-s y 1.044.000 GiB-s; SQL y otros servicios se calculan aparte.
- D) 118.800 vCPU-s y 237.600 GiB-s, porque el worker solo consume cuando procesa un lote.

### 14. Como alternativa de estudio al worker continuo, queremos arrancar un lote periódico y terminar. ¿Qué permite activarlo sin un proceso vivo?

- A) Un Container Apps Job con horario cron, duración y reintentos definidos.
- B) Una app sin ingress, mínimo cero y solo un temporizador dentro del proceso.
- C) Un hosted service singleton dentro de una app sin ninguna réplica activa.
- D) Una regla HTTP sin ingress que despierte al llegar la hora del temporizador.

### 15. Interactive Server mantiene la interacción de la web mediante una conexión. ¿Qué revisamos al añadir réplicas, copias de la aplicación?

- A) La afinidad basta para recuperar el circuito perdido al reiniciar una réplica.
- B) Hay que revisar estado, conexiones, claves y recuperación tras un reinicio.
- C) Un volumen SQL conserva automáticamente el estado del circuito de la web.
- D) Añadir réplicas traslada automáticamente los circuitos a la copia menos ocupada.

### 16. Una identidad gestionada es la acreditación que Azure mantiene para la aplicación. La API tiene una, pero SQL rechaza el acceso. ¿Qué comprobamos?

- A) Que el rol de gestión del recurso incluya también lectura de sus tablas.
- B) Que la identidad tenga una contraseña guardada como variable de entorno.
- C) Que el grupo de recursos comparta el nombre de la base de datos SQL.
- D) Que cliente, identidad, permisos de datos y red permitan esa conexión.

### 17. Una aplicación nueva adopta OpenTelemetry para enviar datos a Application Insights. ¿Qué encaja con la guía consultada?

- A) Inicializar dos distribuciones para asegurar que cada señal llega al destino.
- B) Usar Microsoft OpenTelemetry Distro y verificar una traza en el destino.
- C) Mantener solo el panel local de Aspire al publicar la imagen en Azure.
- D) Configurar el destino tras el arranque y confiar en recuperar las señales previas.

### 18. Key Vault es un almacén protegido de secretos. ¿Para qué sirve si ya usamos identidad gestionada?

- A) Para mantener manualmente la contraseña de la identidad gestionada.
- B) Para sustituir los permisos SQL por permisos de lectura del almacén.
- C) Para custodiar secretos externos que la identidad no hace desaparecer.
- D) Para resolver automáticamente los permisos de negocio de cada jugador.

### 19. Azure, AWS y Google Cloud ofrecen servicios de nube. ¿Cómo leemos su tabla comparativa?

- A) Una fila equivale a un contrato portable entre los proveedores comparados.
- B) Una imagen portable permite conservar permisos y red al cambiar de nube.
- C) El mismo motor SQL implica iguales límites de servicio y recuperación.
- D) Las funciones se parecen; sus capacidades y condiciones deben compararse.

### 20. Hay 200 peticiones externas a la web y esta hace 200 llamadas internas a la API del mismo entorno. ¿Cuántas entran en el medidor HTTP externo?

- A) 200; las llamadas internas siguen consumiendo cómputo, no ese medidor.
- B) 400; cada llamada a un proceso cuenta como entrada externa al entorno.
- C) 0; el mínimo cero excluye las peticiones del cómputo del medidor HTTP.
- D) 600; hay que sumar también una respuesta HTTP por cada petición externa.

### 21. Bicep describe recursos Azure. Terraform mantiene un state, un inventario que relaciona código y recursos. ¿Qué significa que Bicep no necesite un archivo cliente equivalente?

- A) Azure reconstruye los recursos declarados desde cero en cada despliegue.
- B) Quitar un recurso del archivo ordena su borrado en el siguiente despliegue.
- C) No gestionamos ese state cliente; seguimos revisando los cambios.
- D) La vista previa sustituye los permisos necesarios para aplicar cambios.

### 22. En Terraform, `sensitive` oculta valores en ciertas salidas. ¿Hace seguro subir el state a Git?

- A) No; ocultarlo en pantalla no lo elimina del state ni del plan.
- B) Sí; `sensitive` cifra el valor con la identidad del proveedor AzureRM.
- C) Sí; `sensitive` reemplaza el valor por una referencia a Key Vault.
- D) No; solo basta renombrar el state antes de incorporarlo a Git.

### 23. Terraform usa providers, complementos para hablar con cada nube. ¿Qué implica compararlo con Bicep?

- A) Cambiar el provider transforma los recursos Azure en equivalentes AWS.
- B) El flujo puede ser común, pero los recursos siguen siendo específicos.
- C) Usar ambas herramientas sobre un recurso evita la deriva por duplicación.
- D) Tener varios providers elimina la necesidad de proteger el state compartido.

### 24. CourtConnect tiene un mes normal y otro con un día de torneo. ¿Qué estimación está bien planteada?

- A) Treinta días normales más uno de pico, conservando el rótulo de 30 días.
- B) Veintinueve días normales y uno de pico, sumando Job y worker alternativo.
- C) Veintinueve días normales y uno de pico, con worker base y costes pendientes visibles.
- D) Veintinueve días normales y uno de pico, asignando cero a precios pendientes.

---

## Soluciones de la sesión 1

| Nº | Respuesta | Por qué |
| --- | --- | --- |
| 1 | D | Una imagen permite crear varias ejecuciones; no es una máquina en marcha. |
| 2 | B | La imagen final necesita ejecutar, no conservar el SDK ni todas las etapas. |
| 3 | B | Documentar un puerto no publica la aplicación ni configura su escucha. |
| 4 | A | Arrancado no significa listo; también puede fallar después. |
| 5 | C | El volumen puede sobrevivir al contenedor, pero no es backup ni réplica automática. |
| 6 | D | Arrancar en local y desplegar en Azure son flujos distintos. |
| 7 | A | ServiceDefaults aporta esos cuatro aspectos técnicos; no contiene reglas de negocio. |
| 8 | C | La traza conecta pasos de una operación; no es un agregado mensual ni un inventario. |
| 9 | B | `.gitignore` no sustituye a `.dockerignore`; Docker recibe su propio conjunto de archivos. |
| 10 | C | Menos permisos reducen riesgos; no eliminan todas las vulnerabilidades. |
| 11 | A | `localhost` apunta al contenedor de la API, no al de SQL. |
| 12 | D | Una etiqueta puede cambiar; el digest identifica contenido concreto. |

## Soluciones de la sesión 2

| Nº | Respuesta | Por qué |
| --- | --- | --- |
| 13 | C | Se resta la franquicia una sola vez al total; el worker base se estima activo 720 h. El Job es otro escenario, no se suma. |
| 14 | A | El horario externo activa el Job. En el reto se mantiene el worker continuo con mínimo y máximo uno; no se implementa esta alternativa. |
| 15 | B | Afinidad no recupera memoria perdida; revisar también claves de Data Protection y conexiones. |
| 16 | D | Identidad, permisos SQL y conectividad son requisitos distintos. |
| 17 | B | La guía recomienda Microsoft OpenTelemetry Distro para nuevas aplicaciones; verificar llegada y evitar duplicación. |
| 18 | C | La identidad gestionada no elimina necesariamente todos los secretos externos. |
| 19 | D | Funciones parecidas no garantizan idénticos límites o precio. |
| 20 | A | Solo las 200 entradas desde fuera del entorno cuentan en ese medidor; se descuentan franquicias después. |
| 21 | C | Bicep usa el modelo de Azure; sigue habiendo cambios y riesgos que revisar. |
| 22 | A | Ocultar una salida no cifra ni elimina el secreto guardado; renombrar tampoco lo protege. |
| 23 | B | Un flujo común no hace intercambiables los recursos ni elimina la responsabilidad sobre el state. |
| 24 | C | Son 30 días en ambos casos; Job y worker son alternativas y los precios desconocidos quedan pendientes. |

**Revisión con Yamel:** explica un incidente que sabrías diagnosticar y una hipótesis de coste que todavía necesitarías medir. No hace falta contratar ni desplegar nada para justificar ambas respuestas.
