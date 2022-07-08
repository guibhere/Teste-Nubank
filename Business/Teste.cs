using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teste_Nubank.Business.Interfaces;
using Teste_Nubank.Model;
using Teste_Nubank.Utils;

namespace Teste_Nubank
{
    public class Teste : ITeste
    {
        private readonly IJsonHelper _jsonHelper;
        private readonly ILeitorArquivoHelper _leitorArquivo;
        private readonly ITaxBusiness _taxBusiness;
        public Teste(IJsonHelper jsonHelper,ILeitorArquivoHelper leitorArquivo,ITaxBusiness taxBusiness)
        {
            _jsonHelper = jsonHelper;
            _leitorArquivo = leitorArquivo;
            _taxBusiness = taxBusiness;
        }
        public void Testar()
        {
            var inputlist = _leitorArquivo.CarregarArquivo("E:\\teste.json");
            foreach (List<Input> input in inputlist)
            {
                Console.WriteLine(_taxBusiness.CalcularImposto(input));
            }
            Console.ReadLine();
        }


    }
}
