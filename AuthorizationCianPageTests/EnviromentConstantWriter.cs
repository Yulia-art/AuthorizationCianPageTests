using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace AuthorizationCianPageTests
{
    public class EnviromentConstantWriter
    {
        public void WriteDown()
        {
            var enviromentConstants = new EnviromentConstants();

            string objectSerialized = JsonSerializer.Serialize(enviromentConstants);
            File.WriteAllText("EnviromentConstants.json", objectSerialized);
        }
    }
}
