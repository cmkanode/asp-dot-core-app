using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace cmkService.Controllers
{
    [Route("api/[controller]")]
    public class LiteDbController : Controller
    {
        [HttpGet("[action]")]
        public IEnumerable<string> Tables()
        {
            var results = new List<string>();
            results.Add("none");
            return results;
        }
    }
}