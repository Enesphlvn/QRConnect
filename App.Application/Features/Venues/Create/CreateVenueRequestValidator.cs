using FluentValidation;

namespace App.Application.Features.Venues.Create
{
    public class CreateVenueRequestValidator : AbstractValidator<CreateVenueRequest>
    {
        public CreateVenueRequestValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("İsim zorunludur.")
                .Length(3, 100).WithMessage("İsim 3 ile 50 karakter arasında olmalıdır.");

            RuleFor(x => x.CityId)
                .GreaterThan(0).WithMessage("CityId 0'dan büyük olmalıdır.");

            RuleFor(x => x.DistrictId)
                .GreaterThan(0).WithMessage("DistrictId 0'dan büyük olmalıdır.");

            RuleFor(x => x.Capacity)
                .GreaterThan(0).WithMessage("Capacity 0'dan büyük olmalıdır.");
        }
    }
}
