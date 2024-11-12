using FluentValidation;

namespace App.Application.Features.OperationClaims.Update
{
    public class UpdateOperationClaimRequestValidator : AbstractValidator<UpdateOperationClaimRequest>
    {
        public UpdateOperationClaimRequestValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Rol adı zorunludur.")
                .Length(3, 30).WithMessage("Rol adı 3 ile 30 karakter arasında olmalıdır.");
        }
    }
}
