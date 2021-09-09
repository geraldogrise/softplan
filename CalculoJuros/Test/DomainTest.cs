using Domain;
using Microsoft.AspNetCore.Mvc;
using System;
using Xunit;
namespace Test
{
    public class DomainTest
    {
        [InlineData(100, 5, 105.10)]
        [InlineData(300, 7, 321.64)]
        [InlineData(400, 9, 437.47)]
        [InlineData(500, 12, 563.41)]
        [Theory(DisplayName = "Calcular taxas de juros")]
        [Trait("Service", "CalculoJuros")]
        public void CalculandoJuros(double valorInicial, int tempo, double resultado)
        {
            JurosService service = new JurosService();
            double result = service.CalcularJuros(valorInicial, tempo);
            Assert.NotNull(result);
            Assert.Equal(result.ToString("N2"), resultado.ToString("N2"));
        }
    }
}