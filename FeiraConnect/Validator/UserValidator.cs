using FeiraConnect.Model;
using FluentValidation;

namespace FeiraConnect.Validator
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(u => u.Nome)
                .NotEmpty()
                .MaximumLength(255);

            RuleFor(u => u.Email)
                .NotEmpty()
                .EmailAddress();

            RuleFor(u => u.Senha)
                .NotEmpty()
                .MinimumLength(8);

            RuleFor(u => u.Telefone)
                .MaximumLength(15);

        }
    }
}
