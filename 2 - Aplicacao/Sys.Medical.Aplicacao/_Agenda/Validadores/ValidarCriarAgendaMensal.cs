using FluentValidation;
using Sys.Medical.Dominio.ViewModel;

namespace Sys.Medical.Aplicacao._Agenda.Validadores
{
    public class ValidarCriarAgendaMensal : AbstractValidator<AgendaMensal>
    {
        public ValidarCriarAgendaMensal()
        {
            RuleFor(x => x.DataInicial).NotNull().NotEmpty();
            RuleFor(x => x.DataFinal).NotNull().NotEmpty();
            RuleFor(x => x.HoraInicioTurno).NotNull().NotEmpty();
            RuleFor(x => x.HoraFimTurno).NotNull().NotEmpty();

        }
    }
}
