using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teste_Nubank.Business.Interfaces
{
    public interface ILeitorArquivoHelper
    {
        public dynamic CarregarArquivo(string caminhoArquivo);
    }
}
