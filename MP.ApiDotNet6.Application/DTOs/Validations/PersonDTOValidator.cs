// Pacote de validação dos valores recebidos pela aplicação
using FluentValidation;

namespace MP.ApiDotNet6.Application.DTOs.Validations
{
    public class PersonDTOValidator : AbstractValidator<PersonDTO>
    {
        public PersonDTOValidator()
        {
            RuleFor(x => x.Document)
                .NotEmpty()
                .NotNull()
                .WithMessage("Documento deve ser informado");

            RuleFor(x => x.Name)
                .NotEmpty()
                .NotNull()
                .WithMessage("Nome deve ser informado");

            RuleFor(x => x.PhoneCel)
                .NotEmpty()
                .NotNull()
                .WithMessage("Nome deve ser informado");
        }
    }
}