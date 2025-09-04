# Delegados, Lambdas y Expression Trees (breve)

**Delegados**  
- `Func<T,bool>` representa un método que recibe `T` y devuelve `bool`.  
- `Action<T>` representa un método que recibe `T` y no devuelve valor.

**Lambdas**  
- `x => x.Length > 3` es una lambda compatible con `Func<string,bool>`.  
- Ejemplo: `Func<int,int> sq = x => x*x;`

**Multicast delegates (Action)**  
```csharp
Action a = () => Console.WriteLine("A"); 
a += () => Console.WriteLine("B"); 
a(); // imprime A y B
```

**Expression Trees** (intro)  
- `Expression<Func<T,bool>>` puede compilarse o inspeccionarse.  
- Útil para construir filtros dinámicos en ORMs (EF) — solo introducción.
