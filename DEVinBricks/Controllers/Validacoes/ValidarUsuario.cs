using DEVinBricks.Repositories.Models;
using FluentValidation;

namespace DEVinBricks.Controllers.Validacoes
{
    public class ValidarUsuario : AbstractValidator<Usuario>
    {
        public ValidarUsuario()
        {
            RuleFor(x => x.Nome)
                .NotNull()
                .MinimumLength(3)
                .MaximumLength(150)
                .WithMessage("É necessário informar um nome para o usuário, com no mínimo 3 e máximo 150 caracteres");

            RuleFor(x => x.Senha)
                .NotNull()
                .MinimumLength(4)
                .WithMessage("É necessário informar uma senha com tamanho mínimo de 3 caracteres");

            RuleFor(x => x.Admin.Equals(true))
                .NotNull()
                .WithMessage("É necessário que o usuário seja um Admin");
        }
    }
}
