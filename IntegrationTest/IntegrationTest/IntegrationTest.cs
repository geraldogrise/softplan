using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace IntegrationTest
{
    public class IntegrationTest
    {
        [Fact(DisplayName = "Obtendo taxa de juros")]
        [Trait("Api", "ObtencaoJuros")]
        public void JurosApiIntegrationTest()
        {
            double juros = 0;
            using (var client = new HttpClient())
            {
                string endpoint = "http://localhost:22104/taxaJuros";
                var response = Task.Run(() => client.GetAsync(endpoint));
                response.Wait();
                if (response.Result.IsSuccessStatusCode)
                {
                    juros = JsonConvert.DeserializeObject<double>(response.Result.Content.ReadAsStringAsync().Result);
                }
                Assert.True(response.Result.IsSuccessStatusCode);
                Assert.Equal(juros, 0.01);
            }
        }

        [InlineData(100, 5, 105.10)]
        [InlineData(300, 7, 321.64)]
        [InlineData(400, 9, 437.47)]
        [InlineData(500, 12, 563.41)]
        [Theory(DisplayName = "Calcular taxas de juros")]
        [Trait("Api", "CalculoJuros")]
        public void CalculoJurosApiIntegrationTest(double valorInicial, int tempo, double resultado)
        {
            string  valorCalculado = string.Empty;
            using (var client = new HttpClient())
            {
                string endpoint = $"http://localhost:44303/calculaJuros/{valorInicial}/{tempo}";
                var response = Task.Run(() => client.GetAsync(endpoint));
                response.Wait();
                if (response.Result.IsSuccessStatusCode)
                {
                    valorCalculado = response.Result.Content.ReadAsStringAsync().Result;
                }
                Assert.True(response.Result.IsSuccessStatusCode);
                Assert.Equal(valorCalculado, resultado.ToString("N2"));
            }
        }
    }
}
