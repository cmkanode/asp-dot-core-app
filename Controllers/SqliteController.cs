using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace cmkService.Controllers
{
    [Route("api/[controller]")]
    public class SqliteController : Controller
    {
        [HttpGet("[action]")]
        public IEnumerable<string> Tables()
        {
            //SELECT name FROM my_db.sqlite_master WHERE type='table';
            var results = new List<string>();
            results.Add("none");
            return results;
        }
    }
}