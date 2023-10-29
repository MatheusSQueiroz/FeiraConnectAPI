using FeiraConnect.Model;
using FluentValidation;

namespace FeiraConnect.Validator
{
    public class FeiraValidator : AbstractValidator<Feira>
    {
        public FeiraValidator()
        {

            RuleFor(f => f.Nome)
                .NotEmpty();

            RuleFor(f => f.Local)
                .NotEmpty();

            RuleFor(f => f.Data)
                .NotEmpty();

        }

    }
}
