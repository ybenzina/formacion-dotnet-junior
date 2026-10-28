using Xunit;
using System;
using GestorTareas;

namespace GestorTareas.Tests
{
    public class GestorTareasValidationTests
    {
        [Theory]
        [InlineData("")]
        [InlineData("   ")]
        [InlineData(null)]
        public void Agregar_TituloInvalido_LanzaArgumentException(string? tituloInvalido)
        {
            var gestor = new GestorTareas();
#pragma warning disable CS8604 // Possible null reference argument. // Testing null input
			Assert.Throws<ArgumentException>(() => gestor.Agregar(tituloInvalido, "Descripción"));
#pragma warning restore CS8604 // Possible null reference argument.
		}
    }
}
