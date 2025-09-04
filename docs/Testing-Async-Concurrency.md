# Testing async y concurrencia (guía rápida)

- Usa xUnit con tests `async Task`:
```csharp
[Fact]
public async Task MyAsyncTest()
{
    var result = await SomeAsync();
    Assert.Equal(expected, result);
}
```

- Para tests de concurrencia, aumenta carga (p.ej. 1000 tasks) y repite para reducir flakiness.  
- Usa `Assert.ThrowsAsync` para excepciones:
  `await Assert.ThrowsAsync<TaskCanceledException>(() => SomeOperation(ct));`  
- Evitar asserts basados en tiempo; preferir aserciones sobre estados (contadores, elementos procesados).  
