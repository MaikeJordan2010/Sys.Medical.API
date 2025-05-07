using FluentValidation;
using Sys.Medical.Dominio.ViewModel;

namespace Sys.Medical.Aplicacao._Agenda.Validadores
{
    public class ValidarAgendarConsultaPaciente : AbstractValidator<AgendarConsultaPaciente>
    {
        public ValidarAgendarConsultaPaciente()
        {
            RuleFor(x => x.CodAgenda).NotNull().NotEmpty();
            RuleFor(x => x.CodPaciente).NotNull().NotEmpty();
        }
    }
}
