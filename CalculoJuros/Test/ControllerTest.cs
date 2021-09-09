using CalculoJuros.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using Xunit;

namespace Test
{
    public class ControllerTest
    {
        [InlineData(100, 5, 105.10)]
        [InlineData(300, 7, 321.64)]
        [InlineData(400, 9, 437.47)]
        [InlineData(500, 12, 563.41)]
        [Theory(DisplayName = "Calcular taxas de juros")]
        [Trait("Controller", "CalculoJuros")]
        public void CalculandoJuros(double valorInicial, int tempo, double resultado)
        {
            CalculaJurosController controller = new CalculaJurosController();
            var result = controller.CalcularJuros(valorInicial, tempo) as ObjectResult;
            Assert.NotNull(result);
            Assert.Equal(Convert.ToDouble(result.Value), resultado);
            Assert.Equal(200, result.StatusCode);
        }
    }
}
