using FluentValidation;
using TestGlobal.Application.Features.Clients.Queries.GetClient.Messages;

namespace TestGlobal.Application.Features.Clients.Queries.GetClient
{
    public class GetClientValidator : AbstractValidator<GetClientRequest>
    {
        public GetClientValidator()
        {
            RuleFor(p => p.Cpf)
             .NotEmpty().WithMessage("Cpf cannot be empty")
             .NotNull().WithMessage("Cpf cannot be null")
             .MaximumLength(11).WithMessage("Cpf diigits cannot be higer than 11");
        }
    }
}
