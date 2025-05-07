using FluentValidation;
using Sys.Medical.Dominio.DTOs;

namespace Sys.Medical.Aplicacao._Agenda.Validadores
{
    public class ValidarAtualizarAgenda : AbstractValidator<Agenda>
    {
        public ValidarAtualizarAgenda()
        {
            RuleFor(x => x.CodAgenda).NotNull();
            RuleFor(x => x.CodMedico).NotNull();
        }
    }
}
