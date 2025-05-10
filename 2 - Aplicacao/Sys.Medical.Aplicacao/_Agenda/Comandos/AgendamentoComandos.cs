using Atividade01.Dominio.Sistemicas;
using Sys.Medical.Aplicacao._Agenda.Validadores;
using Sys.Medical.Dominio.DTOs;
using Sys.Medical.Dominio.Sistemicas;
using Sys.Medical.Dominio.TratarDados;
using Sys.Medical.Dominio.ViewModel;
using Sys.Medical.Repositorio.Repositorios.AgendamentoRepositorio.Comandos;
using Sys.Medical.Repositorio.Repositorios.AgendamentoRepositorio.Consultas;

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
        public ResultadoGenericoComandos Atualizar(Agenda agenda)
        {
            var validador = new ValidarAtualizarAgenda().Validate(agenda);
            if (validador.IsValid)
            {
                var agendaAtual = _agendamentoConsultasRepositorio.ObterAgenda(agenda.CodAgenda!);

                if(agenda != null)
                {
                    _agendamentoComandosRepositorio.Atualizar(agenda);
                    return ResultadoGenericoComandos.Ok();
                }
            }
            return ResultadoGenericoComandos.Erro();
        }


        public ResultadoGenericoComandos AgendarConsultaPaciente(AgendarConsultaPaciente agenda)
        {
            var validador = new ValidarAgendarConsultaPaciente().Validate(agenda);
            if (validador.IsValid)
            {
                var agendaAtual = _agendamentoConsultasRepositorio.ObterAgenda(agenda.CodAgenda!);

                if (agendaAtual != null)
                {
                    agendaAtual.StatusConsulta = (int)EnumTipoAgenda.AguardandoAprovacao;
                    agendaAtual.CodPaciente = agenda.CodPaciente;

                    _agendamentoComandosRepositorio.Atualizar(agendaAtual);
                    return ResultadoGenericoComandos.Ok();
                }
            }
            return ResultadoGenericoComandos.Erro();
        }

        public ResultadoGenericoComandos CriarAgendaMensal(AgendaMensal agendaMensal)
        {
            var validador = new ValidarCriarAgendaMensal().Validate(agendaMensal);

            if (validador.IsValid)
            {
                Agenda agenda;

                var dataInicial = agendaMensal.DataInicial;
                while(dataInicial <= agendaMensal?.DataFinal)
                {
                    if (agendaMensal!.DiaValido(dataInicial))
                    {
                        if(agendaMensal.DesconsiderarFeriados == true || VerificaFeriados.IsFeriado(dataInicial) == false)
                        {

                            TimeOnly horaInicio = new TimeOnly(Convert.ToInt32(agendaMensal?.HoraInicioTurno?.Split(":")[0]), Convert.ToInt32(agendaMensal?.HoraInicioTurno?.Split(":")[1]));
                            TimeOnly horaFim = new TimeOnly(Convert.ToInt32(agendaMensal?.HoraFimTurno?.Split(":")[0]), Convert.ToInt32(agendaMensal?.HoraFimTurno?.Split(":")[1]));

                            while (horaInicio <= horaFim)
                            {
                                int tempoAtendimento = agendaMensal?.TempoMedioAtendimento ?? 60;
                                DateTime dataInicioConsulta = new DateTime(dataInicial.Year, dataInicial.Month, dataInicial.Day, horaInicio.Hour, horaInicio.Minute, 00);
                                DateTime dataFinalConsulta = dataInicioConsulta.AddMinutes(tempoAtendimento);

                                agenda = new Agenda()
                                {
                                    CodAgenda = Guid.NewGuid().ToString(),
                                    CodMedico = agendaMensal.CodMedico,
                                    DataInicioConsulta = dataInicioConsulta,
                                    DataFinalConsulta = dataFinalConsulta,
                                    StatusConsulta = (int)EnumTipoAgenda.SemAgenda,
                                    Valor = agendaMensal.Valor ?? 0,
                                    TempoConsulta = agendaMensal.TempoMedioAtendimento,
                                };

                                _agendamentoComandosRepositorio.Inserir(agenda);
                                horaInicio = horaInicio.AddMinutes(tempoAtendimento);
                            }
                        }
                    }

                    dataInicial = dataInicial.AddDays(1);
                }
            }

            return ResultadoGenericoComandos.Erro(validador.Errors);
        }

    }
}
