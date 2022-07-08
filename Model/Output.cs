using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teste_Nubank.Model
{
    public class Output
    {
        public Output(double _tax)
        {

            this.tax = String.Format("{0:0.00}", _tax);
        }
        public string tax { get; set; }
    }
}
