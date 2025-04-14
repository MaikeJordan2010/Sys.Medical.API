using FluentValidation;
using Sys.Medical.Dominio.ViewModel;

namespace Sys.Medical.Aplicacao._Medicos.Validadores
{
    internal class ValidarLoginUsuarioMedico : AbstractValidator<LoginUsuario>
    {
        public ValidarLoginUsuarioMedico()
        {
            RuleFor(x => x.Usuario).NotNull().NotEmpty();
            RuleFor(x => x.Senha).NotNull().NotEmpty();
        }
    }
}
