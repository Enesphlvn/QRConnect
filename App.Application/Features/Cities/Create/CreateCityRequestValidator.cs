using FluentValidation;

namespace App.Application.Features.Cities.Create
{
    public class CreateCityRequestValidator : AbstractValidator<CreateCityRequest>
    {
        public CreateCityRequestValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Şehir adı zorunludur.")
                .Length(3, 15).WithMessage("Şehir adı 3 ile 15 karakter arasında olmalıdır.");
        }
    }
}
