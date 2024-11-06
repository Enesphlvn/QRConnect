using FluentValidation;

namespace App.Application.Features.Customers.Update
{
    public class UpdateCustomerRequestValidator : AbstractValidator<UpdateCustomerRequest>
    {
        public UpdateCustomerRequestValidator()
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
