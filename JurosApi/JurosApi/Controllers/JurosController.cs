using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JurosApi.Controllers
{
    [ApiController]
    [Route("taxaJuros")]
    public class JurosController : ControllerBase
    {
        private static readonly double JUROS = 0.01;
        
        public JurosController()
        {
        }

        [HttpGet]
        public ActionResult ObterJuros()
        {
            return Ok(JUROS);
        }
    }
}
