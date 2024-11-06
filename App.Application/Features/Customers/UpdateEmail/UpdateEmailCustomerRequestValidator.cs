using FluentValidation;

namespace App.Application.Features.Customers.UpdateEmail
{
    public class UpdateEmailCustomerRequestValidator : AbstractValidator<UpdateEmailCustomerRequest>
    {
        public UpdateEmailCustomerRequestValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email zorunludur.")
                .EmailAddress().WithMessage("Geçerli bir email adresi girin.");
        }
    }
}
