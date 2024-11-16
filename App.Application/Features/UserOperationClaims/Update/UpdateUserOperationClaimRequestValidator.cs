using FluentValidation;

namespace App.Application.Features.UserOperationClaims.Update
{
    public class UpdateUserOperationClaimRequestValidator : AbstractValidator<UpdateUserOperationClaimRequest>
    {
        public UpdateUserOperationClaimRequestValidator()
        {
            RuleFor(x => x.UserId)
                .GreaterThan(0).WithMessage("userId 0'dan büyük olmalıdır.");

            RuleFor(x => x.OperationClaimId)
                .GreaterThan(0).WithMessage("OperationClaimId 0'dan büyük olmalıdır.");
        }
    }
}
