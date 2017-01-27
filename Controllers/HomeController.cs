using Microsoft.AspNetCore.Mvc;

namespace cmkService
{
    [Route("api/[Controller]")]
    public class HomeController : Controller{
        [HttpGet("[action]")]
        public string Index()
        {
            return "version 1.0";
        }
    }
}