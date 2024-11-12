using FluentValidation;

namespace App.Application.Features.Cities.Update
{
    public class UpdateCityRequestValidator : AbstractValidator<UpdateCityRequest>
    {
        public UpdateCityRequestValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Şehir adı zorunludur.")
                .Length(3, 15).WithMessage("Şehir adı 3 ile 15 karakter arasında olmalıdır.");
        }
    }
}
