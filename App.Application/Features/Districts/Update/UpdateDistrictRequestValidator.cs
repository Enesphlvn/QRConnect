using FluentValidation;

namespace App.Application.Features.Districts.Update
{
    public class UpdateDistrictRequestValidator : AbstractValidator<UpdateDistrictRequest>
    {
        public UpdateDistrictRequestValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Şehir adı zorunludur.")
                .Length(3, 15).WithMessage("Şehir adı 3 ile 15 karakter arasında olmalıdır.");

            RuleFor(x => x.CityId)
                .GreaterThan(0).WithMessage("CityId 0'dan büyük olmalıdır.");
        }
    }
}
