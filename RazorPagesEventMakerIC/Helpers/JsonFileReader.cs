using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RazorPagesEventMakerIC.Models;

namespace RazorPagesEventMakerIC.Helpers
{
    public class JsonFileReader
    {
        public static List<Event> ReadJson(string filePath)
        {
            string jsonString = File.ReadAllText(filePath);
            List<Event> returnListe = JsonConvert.DeserializeObject<List<Event>>(jsonString);
            return returnListe;
        }

    }
}
