using Microsoft.Extensions.DependencyInjection;
using Sys.Medical.Aplicacao._Medicos.Comandos;
using Sys.Medical.Aplicacao._Medicos.Consultas;
using Sys.Medical.Aplicacao._Paciente.Comandos;
using Sys.Medical.Aplicacao._Paciente.Consultas;
using Sys.Medical.Repositorio.Context;
using Sys.Medical.Repositorio.Repositorios.AgendamentoRepositorio.Comandos;
using Sys.Medical.Repositorio.Repositorios.AgendamentoRepositorio.Consultas;
using Sys.Medical.Repositorio.Repositorios.MedicosRepositorio.Comandos;
using Sys.Medical.Repositorio.Repositorios.MedicosRepositorio.Consultas;
using Sys.Medical.Repositorio.Repositorios.PacienteRepositorio.Comandos;
using Sys.Medical.Repositorio.Repositorios.PacienteRepositorio.Consultas;

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

            services.AddScoped<IPacienteComandosRepositorio, PacienteComandosRepositorio>();
            services.AddScoped<IPacienteConsultasRepositorio, PacienteConsultasRepositorio>();
            services.AddScoped<IPacienteComandos, PacienteComandos>();
            services.AddScoped<IPacienteConsultas, PacienteConsultas>();

        }
    }
}
