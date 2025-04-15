using FluentValidation;
using Sys.Medical.Dominio.Paciente;

namespace Sys.Medical.Aplicacao._Paciente.Validadores
{
    public class ValidarAtualizarPaciente : AbstractValidator<Paciente>
    {
        public ValidarAtualizarPaciente()
        {
            RuleFor(x => x.CodPaciente).NotEmpty();
        }
    }
}
