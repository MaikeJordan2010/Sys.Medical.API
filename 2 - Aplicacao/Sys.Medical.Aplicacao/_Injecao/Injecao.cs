using Microsoft.Extensions.DependencyInjection;
using Sys.Medical.Aplicacao._Medicos.Comandos;
using Sys.Medical.Aplicacao._Medicos.Consultas;
using Sys.Medical.Repositorio.Context;
using Sys.Medical.Repositorio.Repositorios.AgendamentoRepositorio.Comandos;
using Sys.Medical.Repositorio.Repositorios.AgendamentoRepositorio.Consultas;
using Sys.Medical.Repositorio.Repositorios.MedicosRepositorio.Comandos;
using Sys.Medical.Repositorio.Repositorios.MedicosRepositorio.Consultas;

namespace Sys.Medical.Aplicacao._Injecao
{
    public static class Injecao
    {
        public static void AddInfraestrutura(this IServiceCollection services)
        {
            services.AddScoped<IDbContext, DbContext>();

            services.AddScoped<IMedicoComandosRepositorio, MedicoComandosRepositorio>();
            services.AddScoped<IMedicoConsultasRepositorio, MedicoConsultasRepositorio>();
            services.AddScoped<IMedicoComandos, MedicoComandos>();
            services.AddScoped<IMedicoConsultas, MedicoConsultas>();

            services.AddScoped<IAgendamentoComandosRepositorio, AgendamentoComandosRepositorio>();
            services.AddScoped<IAgendamentoConsultasRepositorio, AgendamentoConsultasRepositorio>();

        }
    }
}
