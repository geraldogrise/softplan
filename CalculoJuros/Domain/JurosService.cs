using Newtonsoft.Json;
using System;
using System.Configuration;
using System.Net.Http;
using System.Threading.Tasks;

namespace Domain
{
    public class JurosService
    {
        private string endpoint { get; set; }
        public JurosService()
        {
            endpoint = AppSettings.GetConfig().GetSection("TaxaJurosEndpoint").Value;
        }
        public double CalcularJuros(double valorInicial, int tempo)
        {
            double valor = 1 + ObterTaxaJuros();
            return valorInicial * Math.Pow(valor, tempo);
        }

        public double ObterTaxaJuros()
        {
            double juros = 0;
            using (var client = new HttpClient())
            {
                endpoint += "taxaJuros";
                var response = Task.Run(() => client.GetAsync(endpoint));
                response.Wait();
                if (response.Result.IsSuccessStatusCode)
                {
                   juros = JsonConvert.DeserializeObject<double>(response.Result.Content.ReadAsStringAsync().Result);
                }
                else
                {
                    new Exception(response.Result.StatusCode + " - " + response.Result.Content.ReadAsStringAsync().Result);
                }

                return juros;
            }
        }
    }
}
