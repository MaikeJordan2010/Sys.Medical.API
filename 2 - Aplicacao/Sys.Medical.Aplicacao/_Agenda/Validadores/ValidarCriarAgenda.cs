using FluentValidation;
using Sys.Medical.Dominio.DTOs;

namespace Sys.Medical.Aplicacao._Agenda.Validadores
{
    internal class ValidarCriarAgenda : AbstractValidator<Agenda>
    {
        public ValidarCriarAgenda()
        {
            RuleFor(x => x.CodMedico).NotNull().NotEmpty();
            RuleFor(x => x.CodPaciente).NotNull().NotEmpty();
            RuleFor(x => x.DataInicioConsulta).NotNull().NotEmpty();
        }
    }
}
