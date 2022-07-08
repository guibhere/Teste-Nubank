using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teste_Nubank.Business.Interfaces;
using Teste_Nubank.Helpers;
using Teste_Nubank.Model;

namespace Teste_Nubank.Business
{
    public class TaxBusiness : ITaxBusiness
    {
        private readonly IJsonHelper _jsonHelper;
        private List<Output> output;
        private int TotalAcoes;
        private double MediaPonderada;
        private double PrejuizoAcumulado;

        public TaxBusiness(IJsonHelper jsonhelper)
        {
            _jsonHelper = jsonhelper;
        }
        public string CalcularImposto(List<Input> input) 
        {
            output = new List<Output>();
            TotalAcoes = input[0].quantity;
            MediaPonderada = input[0].UnitCost;
            PrejuizoAcumulado = 0;
            output.Add(new Output(0));

            for (int i = 1; i < input.Count(); i++)
            {
                switch (input[i].operation)
                {
                    case Constantes.OperacaoCompra:
                        output.Add(ComprarAcoes(input[i]));
                        break;
                    case Constantes.OperacaoVenda:
                        output.Add(VenderAcoes(input[i]));
                        break;
                }
            }
            return(_jsonHelper.JsonSerialize(output));
        }
        public double CalculaMedia(double MediaPonderada, int TotalAcoes, double CustoAcoesNovas, int QuantidadeAcoesNovas)
        {
            return ((MediaPonderada * TotalAcoes) + (CustoAcoesNovas * QuantidadeAcoesNovas)) / (TotalAcoes + QuantidadeAcoesNovas);
        }

        public Output ComprarAcoes(Input input)
        {
            this.MediaPonderada = CalculaMedia(MediaPonderada, TotalAcoes, input.UnitCost, input.quantity);
            this.TotalAcoes += input.quantity;
            return new Output(0);
        }

        public Output VenderAcoes(Input input)
        {
            this.TotalAcoes -= input.quantity;
            double BalancoOperacao = (input.UnitCost - MediaPonderada) * input.quantity;
            if (BalancoOperacao >= 0)
            {
                double Lucro = BalancoOperacao + PrejuizoAcumulado;
                if (Lucro < 0)
                    Lucro = 0;
                double ValorTransacao = input.UnitCost * input.quantity;
                this.PrejuizoAcumulado += BalancoOperacao;
                if (PrejuizoAcumulado > 0)
                    this.PrejuizoAcumulado = 0;
                if (ValorTransacao > 20000)
                    return(new Output(Lucro * 0.2));
                else
                    return(new Output(0));
            }
            else
            {
                this.PrejuizoAcumulado += BalancoOperacao;
                return(new Output(0));
            }
        }
    }
}
