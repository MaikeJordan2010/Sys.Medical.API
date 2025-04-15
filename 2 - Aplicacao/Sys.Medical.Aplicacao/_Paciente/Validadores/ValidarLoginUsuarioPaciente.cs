using FluentValidation;
using Sys.Medical.Dominio.ViewModel;

namespace Sys.Medical.Aplicacao._Paciente.Validadores
{
    internal class ValidarLoginUsuarioPaciente : AbstractValidator<LoginUsuario>
    {
        public ValidarLoginUsuarioPaciente()
        {
            RuleFor(x => x.Usuario).NotNull().NotEmpty();
            RuleFor(x => x.Senha).NotNull().NotEmpty();
        }
    }
}
