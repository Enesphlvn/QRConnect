using FluentValidation;

namespace App.Application.Features.OperationClaims.Create
{
    public class CreateOperationClaimRequestValidator : AbstractValidator<CreateOperationClaimRequest>
    {
        public CreateOperationClaimRequestValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Rol adı zorunludur.")
                .Length(3, 30).WithMessage("Rol adı 3 ile 30 karakter arasında olmalıdır.");
        }
    }
}
