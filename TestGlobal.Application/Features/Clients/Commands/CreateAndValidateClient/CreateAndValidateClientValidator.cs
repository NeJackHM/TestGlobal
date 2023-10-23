using FluentValidation;
using TestGlobal.Application.Features.Clients.Commands.CreateAndValidateClient.Message;

namespace TestGlobal.Application.Features.Clients.Commands.CreateAndValidateClient
{
    public class CreateAndValidateClientValidator : AbstractValidator<CreateAndValidateClientRequest>
    {
        public CreateAndValidateClientValidator()
        {
            RuleFor(p => p.Cpf)
                .NotEmpty().WithMessage("Cpf cannot be empty")
                .NotNull().WithMessage("Cpf cannot be null")
                .MaximumLength(11).WithMessage("Cpf diigits cannot be higer than 11");

            RuleFor(p => p.Name)
                  .NotEmpty().WithMessage("Name cannot be empty")
                  .NotNull().WithMessage("Name cannot be null");   

            RuleFor(p => p.Birthdate)
                .NotNull().WithMessage("Birthdate cannot be null");
        }
    }
}
