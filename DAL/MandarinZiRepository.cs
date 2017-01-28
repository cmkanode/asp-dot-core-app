using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using cmkService.Models;
using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json;
using Microsoft.Extensions.PlatformAbstractions;


namespace cmkService.DAL
{
    public class MandarinZiRepository : IMandarinZiRepository
    {
        private static List<MandarinZi> _dictionary = new List<MandarinZi>();
        private Random rnd = new Random();
        
        public MandarinZiRepository(){
            ApplicationEnvironment env = PlatformServices.Default.Application;
            string basePath = env.ApplicationBasePath;
            StreamReader reader = File.OpenText(basePath + "/Data/sanqianzi.json"); // resolving to C:/Data/sanqianzi.json
            string data = reader.ReadToEnd();
            _dictionary = JsonConvert.DeserializeObject<List<MandarinZi>>(data);
        }
        public MandarinZi Find(int id)
        {
            var result = _dictionary.Where(z => z.id == id).First();
            return result;
        }

        public IEnumerable<MandarinZi> FindByDefinition(string searchterm){
            var results = from m in _dictionary
                where m.definitions.Any(d => d.ToLower().Contains(searchterm.ToLower()))
                select m;
            return results;
        }
        public IEnumerable<MandarinZi> FindByCharacter(string searchterm){
            var results = from m in _dictionary
                where m.character.Contains(searchterm)
                select m;
            return results;
        }
        public IEnumerable<MandarinZi> FindByRadical(string searchterm){
            var results = from m in _dictionary
                where m.radical == searchterm
                select m;
            return results;
        }
        public IEnumerable<MandarinZi> FindByStroke(int strokeCount){
            var results = from m in _dictionary
                where m.totalStrokes == strokeCount
                select m;
            return results;
        }

        public MandarinZi GetRandomWord()
        {
            return _dictionary[rnd.Next(_dictionary.Count)];
        }
    }
}