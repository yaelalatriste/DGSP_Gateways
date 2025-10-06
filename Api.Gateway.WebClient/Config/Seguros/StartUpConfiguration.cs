using Api.Gateway.Proxies.Seguros.Commands.Continuidades;
using Api.Gateway.Proxies.Seguros.Commands.Expedientes;
using Api.Gateway.Proxies.Seguros.Queries.Continuidades;
using Api.Gateway.Proxies.Seguros.Queries.Expedientes;
using Api.Gateway.Proxies.Seguros.Queries.Reportes;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Api.Gateway.WebClient.Config.Seguros
{
    public static class StartUpConfiguration
    {
        public static IServiceCollection AddProxiesSegurosQueries(this IServiceCollection service, IConfiguration configuration)
        {
            service.AddHttpClient<IQExpedienteSegurosProxy, QExpedienteSegurosProxy>();
            service.AddHttpClient<IRJubiladosProxy, RJubiladosProxy>();
            service.AddHttpClient<IQSContinuidadesProxy, QSContinuidadesProxy>();

            return service;
        }
        
        public static IServiceCollection AddProxiesSegurosCommands(this IServiceCollection service, IConfiguration configuration)
        {
            service.AddHttpClient<ICExpedienteSegurosProxy, CExpedienteSegurosProxy>();
            service.AddHttpClient<ICSContinuidadesProxy, CSContinuidadesProxy>();

            return service;
        }
    }
}
