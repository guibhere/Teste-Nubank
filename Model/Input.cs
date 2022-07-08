using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Teste_Nubank.Model
{
    public class Input
    {
        public string operation { get; set; }
        [JsonPropertyName("unit-cost")]
        public double UnitCost { get; set; }
        public int quantity { get; set; }
    }
}
