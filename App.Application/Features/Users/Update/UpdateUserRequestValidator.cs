using FluentValidation;

namespace App.Application.Features.Users.Update
{
    public class UpdateUserRequestValidator : AbstractValidator<UpdateUserRequest>
    {
        public UpdateUserRequestValidator()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("İsim zorunludur.")
                .Length(3, 50).WithMessage("İsim 3 ile 50 karakter arasında olmalıdır.");

            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("Soyisim zorunludur.")
                .Length(3, 50).WithMessage("Soyisim 3 ile 50 karakter arasında olmalıdır.");
        }
    }
}
