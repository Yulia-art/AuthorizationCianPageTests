using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace AuthorizationCianPageTests
{
    public class EnviromentConstantsProvider
    {
        private const string _nameJsonFile = "EnviromentConstants.json";

        public void Provide(out EnviromentConstants enviromentConstantsObject)
        {
            string objectJsonFile = File.ReadAllText(_nameJsonFile);
            enviromentConstantsObject = JsonSerializer.Deserialize<EnviromentConstants>(objectJsonFile);
        }
    }
}
