using FluentValidation;

namespace App.Application.Features.Users.UpdateEmail
{
    public class UpdateEmailUserRequestValidator : AbstractValidator<UpdateEmailUserRequest>
    {
        public UpdateEmailUserRequestValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email zorunludur.")
                .EmailAddress().WithMessage("Geçerli bir email adresi girin.");
        }
    }
}
