using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teste_Nubank.Model;

namespace Teste_Nubank.Business.Interfaces
{
    public interface ITaxBusiness
    {
        public string CalcularImposto(List<Input> input);
        public double CalculaMedia(double MediaPonderada, int TotalAcoes, double CustoAcoesNovas, int QuantidadeAcoesNovas);
    }
}
