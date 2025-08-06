namespace MyApp.Core.Tests;

using Xunit;

public class SaludoTests
{
    [Fact]
    public void Saludar_DeberiaRetornarHolaNombre()
    {
        var svc = new ServicioSaludo();
        Assert.Equal("¡Hola, Maria!", svc.Saludar("Maria"));
    }
}

