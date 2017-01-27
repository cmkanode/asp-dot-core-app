using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using cmkService.Models;
using cmkService.DAL;

namespace cmkService.Controllers
{
    [Route("api/[controller]")]
    public class MandarinZiController : Controller
    {
        public MandarinZiController(IMandarinZiRepository _characters){
            MandarinDictionary = _characters;
        }
        public IMandarinZiRepository MandarinDictionary { get; set; }


        [HttpGet("Get/{id}")]
        [HttpGet("{id}", Name = "Get")] // The name is not being recognized.
        public IActionResult GetById(int id)
        {
            var zi = MandarinDictionary.Find(id);
            if(zi == null){
                Console.WriteLine("Character not found.");
                return NotFound();
            }
            return new ObjectResult(zi);
        }

        // searchtype: definition, character, radical, stroke
        [HttpGet("Search/{searchtype}/{searchterm}")]
        public IActionResult GetByDefinition(string searchtype, string searchterm){
            IEnumerable<MandarinZi> results;
            switch(searchtype.ToLower()){
                case "definition":
                    results = MandarinDictionary.FindByDefinition(searchterm);
                    break;
                case "character":
                    results = MandarinDictionary.FindByCharacter(searchterm);
                    break;
                case "radical":
                    results = MandarinDictionary.FindByRadical(searchterm);
                    break;
                case "stroke":
                    int strokeCount = 0;
                    int.TryParse(searchterm, out strokeCount);
                    results = MandarinDictionary.FindByStroke(strokeCount);
                    break;
                default:
                    results = null;
                    break;
            }
            
            if(results == null){
                return NotFound();
            }
            return new ObjectResult(results);
        }
    }
}