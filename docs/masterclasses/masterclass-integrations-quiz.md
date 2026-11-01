# Quiz de integraciones y tareas en segundo plano

Al día siguiente de la [masterclass](masterclass-integrations.md): 12 preguntas, una respuesta por pregunta, 15 minutos fuera de clase. Referencia: 9/12 y explicación de las dudas. No hace falta memorizar valores del paquete ni implementar el taller.

## Preguntas

### 1. El proveedor aceptó un pago, pero perdimos la respuesta. ¿Qué sabemos?

- A) Que el timeout canceló el cobro remoto antes de guardar su resultado.
- B) Que una clave nueva permitirá recuperar el resultado del mismo cobro.
- C) Que hay incertidumbre local y debemos resolverla sin pedir otro pago.
- D) Que revertir el estado local anulará también la operación del proveedor.

### 2. ¿Qué aporta un typed HttpClient?

- A) Encapsula llamadas y detalles de un proveedor detrás de operaciones de una clase.
- B) Comparte una transacción de base de datos entre cliente y proveedor remoto.
- C) Reintenta automáticamente cada operación hasta recibir una respuesta válida.
- D) Convierte los errores HTTP en resultados de negocio sin configuración propia.

### 3. ¿Por qué evitar `new HttpClient()` y su destrucción en cada llamada?

- A) Porque dos objetos cliente no pueden usar al mismo tiempo una URL.
- B) Porque cada nuevo cliente elimina la caché DNS de toda la aplicación.
- C) Porque destruir el cliente impide cancelar las operaciones ya terminadas.
- D) Porque recrear handlers puede agotar conexiones de transporte.

### 4. ¿Qué hace un circuit breaker?

- A) Conserva cada mensaje fallido para reenviarlo tras reiniciar el proceso.
- B) Pausa llamadas ante fallos repetidos y permite probar recuperación.
- C) Reduce la duración de cada llamada para compensar reintentos previos.
- D) Consulta al proveedor si una operación incierta produjo algún efecto.

### 5. ¿Cuándo es peligroso reintentar un envío de pago?

- A) Cuando la espera entre intentos supera la duración de la primera llamada.
- B) Cuando usa POST con deduplicación acordada y vigente para esa operación.
- C) Cuando desconocemos el resultado y no hay protección frente a duplicados.
- D) Cuando se consulta el estado sin crear otra operación en el proveedor.

### 6. ¿Qué clave usamos tras perder la respuesta de una misma intención de pago?

- A) Una clave nueva para distinguir el reintento de la petición que falló.
- B) La clave persistida de esa intención, respetando el contrato del proveedor.
- C) La clave del jugador para agrupar pagos distintos bajo el mismo valor.
- D) La hora actual para impedir que el proveedor reutilice un resultado previo.

### 7. ¿Qué debe ocurrir si llega la misma clave con otro importe?

- A) Rechazar el conflicto entre la clave guardada y el nuevo importe.
- B) Actualizar el importe de la intención original conservando su resultado.
- C) Generar otra clave dentro del servidor y aceptar automáticamente el cobro.
- D) Devolver el resultado anterior sin comprobar que el importe haya cambiado.

### 8. ¿Qué cambia transactional outbox?

- A) Incluye al proveedor HTTP en la misma transacción que la base local.
- B) Marca el mensaje antes del envío para evitar pérdida ante un cierre del proceso.
- C) Resuelve los duplicados externos cuando dos workers leen el mismo pendiente.
- D) Guarda cambio y encargo en una transacción local; el envío posterior puede repetirse.

### 9. ¿Cómo obtiene un worker sus servicios scoped?

- A) Resolviéndolos una vez desde el contenedor raíz al iniciar el proceso.
- B) Creando y liberando un scope por unidad o lote antes de esperar.
- C) Inyectándolos en el constructor singleton para renovarlos en cada vuelta.
- D) Compartiendo un scope durante toda la vida de las tareas paralelas.

### 10. ¿Qué aporta TimeProvider?

- A) Sincronizar las ejecuciones de varias réplicas mediante un reloj compartido.
- B) Recuperar el instante pendiente de reintento tras reiniciar el proceso.
- C) Controlar el reloj de las pruebas sin esperar los plazos reales.
- D) Evitar que dos réplicas procesen un mensaje al mismo tiempo.

### 11. Holded no ha confirmado soporte de deduplicación. ¿Qué hacemos?

- A) Verificar consulta y conciliación; detener reenvíos inciertos sin protección acordada.
- B) Añadir una cabecera habitual y dar por protegida la operación remota.
- C) Usar outbox local y asumir que el proveedor descartará cada duplicado.
- D) Reintentar con otra referencia para evitar conflictos con la factura previa.

### 12. ¿Qué desplegamos para la caducidad en el Día 22 del reto?

- A) Un Job adicional al worker, para duplicar las comprobaciones de caducidad.
- B) El worker con mínimo cero, despertado por su propio temporizador interno.
- C) Un Job que sustituye obligatoriamente el worker, con implementación y nuevas pruebas.
- D) El host `CourtConnect.Worker`, continuo con mínimo y máximo uno; el Job solo se compara.

## Soluciones razonadas

| Nº | Respuesta | Por qué |
| --- | --- | --- |
| 1 | C | La ausencia de respuesta no revela si hubo efecto remoto; el rollback local no deshace HTTP. |
| 2 | A | Encapsula detalles del proveedor; no añade por sí solo transacción remota ni resiliencia. |
| 3 | D | La factory cachea y rota handlers con sus pools; un cliente duradero bien configurado también es válido. |
| 4 | B | Limita presión sobre un servicio que falla; no conserva ni deduplica operaciones. |
| 5 | C | Incluso un error de servidor puede llegar después del efecto; HTTP POST no decide por sí solo la idempotencia. |
| 6 | B | La clave identifica una intención persistida, no al usuario ni cada intento; el receptor debe reconocerla. |
| 7 | A | Mismo identificador y distinto contenido no representan la misma operación. |
| 8 | D | Evita perder el encargo entre escrituras locales; no garantiza exactamente un envío externo. |
| 9 | B | Respeta lifetimes y liberación; un scope no coordina automáticamente dos workers. |
| 10 | C | Un reloj controlable prueba el tiempo, no la persistencia ni el bloqueo entre réplicas. |
| 11 | A | No se pueden inventar garantías del proveedor; la incertidumbre puede requerir intervención. |
| 12 | D | La caducidad corre en `CourtConnect.Worker`, no en la API. El temporizador no despierta un proceso escalado a cero. El Job se valora como sustitución, sin implementarlo. |
