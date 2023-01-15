using Business;
using Domain.Interface;
using Microsoft.Extensions.DependencyInjection;
using Repository;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CrossCuting.InjecaoDependencia
{

    public static class ConfiguracaoServices
    {
        public static void ConfiguracaoDependenciasServices(IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IDados, Dados>();
            serviceCollection.AddTransient<IManipulacaoArquivoDeDados, ManipulacaoArquivoDeDados>();
            serviceCollection.AddTransient<IRegrasSorteio, RegrasSorteio>();

        }
    }
}
