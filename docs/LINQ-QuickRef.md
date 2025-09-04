# LINQ Quick Reference

- **Where**: filtra  
  `var q = items.Where(x => x.Prop > 0);`

- **Select**: proyecta  
  `var names = items.Select(x => x.Name);`

- **OrderBy / ThenBy**  
  `var sorted = items.OrderBy(x => x.Name).ThenByDescending(x => x.Score);`

- **GroupBy**  
  `var groups = items.GroupBy(x => x.Category);`

- **Join**  
  `var j = from a in A join b in B on a.Id equals b.AId select new { a, b };`

- **Sum / Average / Min / Max**  
  `var total = items.Sum(x => x.Value);`

- **Deferred execution**: las consultas LINQ devuelven `IEnumerable` y se evalúan al iterar. Usa `ToList()` para materializar.

**PLINQ**  
- `items.AsParallel().Select(...).Sum()`  
- `WithDegreeOfParallelism` para afinar.

**Consejos**  
- Evita efectos colaterales dentro de `Select`.  
- Para datasets grandes decide entre procesar en streaming (deferred) o materializar.
