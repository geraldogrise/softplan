using JurosApi.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using Xunit;

namespace Test
{
    public class ControllerTest
    {
        [Fact(DisplayName = "Obtendo taxas de juros")]
        [Trait("Controller", "Juros")]
        public void ObterJuros()
        {
            JurosController controller = new JurosController();
            var result = controller.ObterJuros() as ObjectResult;
            Assert.NotNull(result);
            Assert.Equal(Convert.ToDouble(result.Value), 0.01);
            Assert.Equal(200, result.StatusCode);
        }
    }
}
