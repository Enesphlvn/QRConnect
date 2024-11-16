using FluentValidation;

namespace App.Application.Features.Venues.Update
{
    public class UpdateVenueRequestValidator : AbstractValidator<UpdateVenueRequest>
    {
        public UpdateVenueRequestValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("İsim zorunludur.")
                .Length(3, 100).WithMessage("İsim 3 ile 50 karakter arasında olmalıdır.");

            RuleFor(x => x.CityId)
                .GreaterThan(0).WithMessage("UserId 0'dan büyük olmalıdır.");

            RuleFor(x => x.DistrictId)
                .GreaterThan(0).WithMessage("UserId 0'dan büyük olmalıdır.");

            RuleFor(x => x.Capacity)
                .GreaterThan(0).WithMessage("UserId 0'dan büyük olmalıdır.");
        }
    }
}
