using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JurosApi.Controllers
{
    [ApiController]
    public class GithubController : ControllerBase
    {
        private static string GITHUBREPOSITORY = "https://github.com/geraldogrise/softplan";
        public GithubController()
        {

        }

        [HttpGet("showmethecode")]
        public ActionResult ShowMeTheCode()
        {
            return Ok(GITHUBREPOSITORY);
        }
    }
}
