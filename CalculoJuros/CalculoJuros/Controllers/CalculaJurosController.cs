using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalculoJuros.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculaJurosController : ControllerBase
    {
        public CalculaJurosController()
        {
            
        }

        [HttpGet("{valorInicial}/{tempo}")]
        public ActionResult CalcularJuros(double valorInicial, int tempo)
        {
           JurosService juros = new JurosService();
           double valorFinal = juros.CalcularJuros(valorInicial, tempo);
           return Ok(valorFinal.ToString("N2"));
        }
    }
}
