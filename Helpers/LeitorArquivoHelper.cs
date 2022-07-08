using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teste_Nubank.Business.Interfaces;
using Teste_Nubank.Model;

namespace Teste_Nubank.Business
{
    public class LeitorArquivoHelper : ILeitorArquivoHelper
    {
        private readonly IJsonHelper _jsonHelper;
        public LeitorArquivoHelper(IJsonHelper jsonhelper)
        {
            _jsonHelper = jsonhelper;
        }

        public dynamic CarregarArquivo(string caminhoArquivo)
        {
            using (StreamReader reader = new StreamReader(caminhoArquivo))
            {
                string inputstring = reader.ReadToEnd();
                List<String> inputlistString = new List<string>();
                List<List<Input>> inputList = new List<List<Input>>();
                inputlistString = inputstring.Split('[').Skip(0).Where(x => x.Contains(']')).Select(x => x.Split(']').First()).ToList();

                foreach (String jsonstring in inputlistString)
                {
                    inputList.Add(_jsonHelper.JsonDeserialize('[' + jsonstring + ']'));
                }

                return inputList;
            }
        } 
    }
}

