# Mejoras sugeridas — Semana 2 (tareas adicionales)

Estas son mejoras y tareas opcionales para pulir el trabajo de la Semana 2. Pueden abordarse como **issues** o PRs separados.

## 1. Robustecer ServicioSaludo
- Validar `null` y cadenas vacías.
- Trim del nombre.
- Añadir tests para casos límite.

**Ejemplo de implementación:**
```csharp
public string Saludar(string? nombre)
{
    if (string.IsNullOrWhiteSpace(nombre))
        return "¡Hola!";
    return $"¡Hola, {nombre.Trim()}!";
}
```

## 2. Tests adicionales
- Test para `null`:
```csharp
[Fact]
public void Saludar_Null_DeberiaRetornarHola()
{
    var svc = new ServicioSaludo();
    Assert.Equal("¡Hola!", svc.Saludar(null));
}
```
- Test para trim:
```csharp
[Fact]
public void Saludar_DeberiaTrimearNombre()
{
    var svc = new ServicioSaludo();
    Assert.Equal("¡Hola, Maria!", svc.Saludar("  Maria  "));
}
```

## 3. README por proyecto
Añadir en:
- `src/MyApp.Core/README.md`
- `src/MyApp.Console/README.md`

Contenido mínimo:
```
# MyApp.Core
Cómo compilar: `dotnet build`
Cómo testear: `dotnet test`

# MyApp.Console
Cómo ejecutar: `dotnet run --project src/MyApp.Console`
```

## 4. Añadir CI (si no está): `.github/workflows/dotnet.yml`
(Ver `docs/CI-Guide.md`)

## 5. Checklist para PRs (añadir en la descripción)
- [ ] `dotnet build` OK
- [ ] `dotnet test` OK
- [ ] `.gitignore` actualizado
- [ ] README con instrucciones básicas
- [ ] Tests para casos límite (null/empty/trim)

---

> Sugerencia de workflow: crear issues para cada mejora (por ejemplo `Mejora: validar ServicioSaludo`, `Mejora: añadir README por proyecto`) y asignarlos como tareas de aprendizaje.
