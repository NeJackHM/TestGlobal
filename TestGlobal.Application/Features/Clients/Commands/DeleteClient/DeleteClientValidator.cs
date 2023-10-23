using FluentValidation;
using TestGlobal.Application.Features.Clients.Commands.DeleteClient.Messages;

namespace TestGlobal.Application.Features.Clients.Commands.DeleteClient
{
    public class DeleteClientValidator : AbstractValidator<DeleteClientRequest>
    {
        public DeleteClientValidator()
        {
            RuleFor(p => p.Cpf)
               .NotEmpty().WithMessage("Cpf cannot be empty")
               .NotNull().WithMessage("Cpf cannot be null")
               .MaximumLength(11).WithMessage("Cpf diigits cannot be higer than 11");
        }

    }
}
