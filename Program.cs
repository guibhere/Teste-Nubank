using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using Teste_Nubank.Model;
using Teste_Nubank.Utils;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Threading.Tasks;
using Teste_Nubank.Business.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Teste_Nubank.Business;

namespace Teste_Nubank
{
    class Program
    {

        public static void Main(string[] args)
        {
            IniciarServicos(args);
        }

        private static  void IniciarServicos(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                .AddLogging()
                .AddSingleton<IJsonHelper, JsonHelper>()
                .AddSingleton<ILeitorArquivoHelper,LeitorArquivoHelper>()
                .AddSingleton<ITaxBusiness,TaxBusiness>()
                .AddSingleton<ITeste, Teste>()
                .BuildServiceProvider();
            serviceProvider.GetRequiredService<ITeste>().Testar();

        }




    }
}
