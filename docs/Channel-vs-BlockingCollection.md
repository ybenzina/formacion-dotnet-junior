# Channel vs BlockingCollection (comparativa)

**BlockingCollection<T>**  
- API sencilla basada en `IProducerConsumerCollection<T>`.  
- Uso típico con `GetConsumingEnumerable()` y `CompleteAdding()`.  
- Más fácil de entender en demos sincrónicas.

**Channel<T> (System.Threading.Channels)**  
- API asíncrona nativa (`WriteAsync` / `ReadAsync` / `ReadAllAsync`).  
- Bounded channels ofrecen *backpressure* natural.  
- Mejor integración con `async/await` end-to-end.

**Recomendación práctica**  
- Para pipelines **async** preferir `Channel<T>`.  
- Para demos simples o compatibilidad con código sincrónico, `BlockingCollection` es suficiente.
