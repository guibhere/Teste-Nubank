using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teste_Nubank.Model;

namespace Teste_Nubank.Business.Interfaces
{
    public interface IJsonHelper
    {
        public string JsonSerialize(List<Output> output);
        public List<Input> JsonDeserialize(string jsonstring);
    }
}
