using Atividade01.Dominio.Sistemicas;
using Sys.Medical.Aplicacao._Agenda.Validadores;
using Sys.Medical.Dominio.DTOs;
using Sys.Medical.Dominio.Sistemicas;
using Sys.Medical.Repositorio.Repositorios.AgendamentoRepositorio.Comandos;
using Sys.Medical.Repositorio.Repositorios.AgendamentoRepositorio.Consultas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sys.Medical.Aplicacao._Agenda.Comandos
{
    public class AgendamentoComandos : IAgendamentoComandos
    {
        private readonly IAgendamentoComandosRepositorio _agendamentoComandosRepositorio;
        private readonly IAgendamentoConsultasRepositorio _agendamentoConsultasRepositorio;
        public AgendamentoComandos(IAgendamentoComandosRepositorio agendamentoComandosRepositorio,
                                    IAgendamentoConsultasRepositorio agendamentoConsultasRepositorio)
        {
            _agendamentoComandosRepositorio = agendamentoComandosRepositorio;
            _agendamentoConsultasRepositorio = agendamentoConsultasRepositorio; 
        }
        public ResultadoGenericoComandos AprovarAgenda(string codAgenda)
        {
            if (string.IsNullOrEmpty(codAgenda))
                return ResultadoGenericoComandos.Erro();

            var agenda = _agendamentoConsultasRepositorio.ObterAgenda(codAgenda);

            if(agenda != null)
            {
                agenda.TipoConsulta = (int)EnumTipoAgenda.Agendada;
                _agendamentoComandosRepositorio.Inserir(agenda);
                return ResultadoGenericoComandos.Ok();
            }
            return ResultadoGenericoComandos.Erro();
        }

        public ResultadoGenericoComandos CancelarAgenda(string codAgenda)
        {
            if (string.IsNullOrEmpty(codAgenda))
                return ResultadoGenericoComandos.Erro();

            var agenda = _agendamentoConsultasRepositorio.ObterAgenda(codAgenda);

            if (agenda != null)
            {
                agenda.TipoConsulta = (int)EnumTipoAgenda.Cancelada;
                _agendamentoComandosRepositorio.Inserir(agenda);
                return ResultadoGenericoComandos.Ok();
            }
            return ResultadoGenericoComandos.Erro();
        }

        public ResultadoGenericoComandos Criar(Agenda agenda)
        {
            var validador = new ValidarCriarAgenda().Validate(agenda);

            if (validador.IsValid) 
            {
                agenda.CodAgenda = Guid.NewGuid().ToString();
                agenda.TipoConsulta = (int)EnumTipoAgenda.Aguardando;

                _agendamentoComandosRepositorio.Inserir(agenda);

                return ResultadoGenericoComandos.Ok();
            }

            return ResultadoGenericoComandos.Erro(validador.Errors);
        }
    }
}
