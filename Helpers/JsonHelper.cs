using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Teste_Nubank.Business.Interfaces;
using Teste_Nubank.Model;

namespace Teste_Nubank.Utils
{
    class JsonHelper : IJsonHelper
    {
        public string JsonSerialize(List<Output> output)
        {
            return JsonSerializer.Serialize(output);
        }

        public string ExtrairJson(string inputstring,int inicio,int fim){
            return inputstring.Substring(inicio, fim);
        }

        public List<Input> JsonDeserialize(string jsonstring) 
        {
           return JsonSerializer.Deserialize<List<Input>>(jsonstring);
        }
    }
}
