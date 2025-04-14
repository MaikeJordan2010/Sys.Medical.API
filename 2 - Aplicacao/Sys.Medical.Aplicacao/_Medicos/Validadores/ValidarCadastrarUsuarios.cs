using FluentValidation;
using Sys.Medical.Dominio.Medico;

namespace Sys.Medical.Aplicacao._Medicos.Validadores
{
    public class ValidarCadastrarUsuarios : AbstractValidator<CadastroUsuario>
    {
        public ValidarCadastrarUsuarios()
        {
            RuleFor(x => x.CPF).NotEmpty();
            RuleFor(x => x.CRM).NotEmpty();
            RuleFor(x => x.Nome).NotEmpty();
            RuleFor(x => x.Especialidade).NotEmpty();
        }
    }
}
