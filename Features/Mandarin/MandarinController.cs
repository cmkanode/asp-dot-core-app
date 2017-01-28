using Microsoft.AspNetCore.Mvc;
using cmkService.Models;
using cmkService.DAL;

namespace cmkService.Features.Mandarin
{
    public class MandarinController : Controller
    {
        private IMandarinZiRepository dictionary { get; set; }
        public MandarinController(IMandarinZiRepository _dictionary)
        {
            dictionary = _dictionary;
        }

        public IActionResult Index()
        {
            MandarinZi zi = dictionary.GetRandomWord();
            return View(zi);
        }
    }
}