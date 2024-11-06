using FluentValidation;

namespace App.Application.Features.Events.Update
{
    public class UpdateEventRequestValidator : AbstractValidator<UpdateEventRequest>
    {
        public UpdateEventRequestValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Etkinlik adı zorunludur.")
                .Length(3, 50).WithMessage("Etkinlik adı 3 ile 50 karakter arasında olmalıdır.");

            RuleFor(x => x.Date)
                .NotNull()
                .GreaterThan(DateTime.Now).WithMessage("Etkinlik tarihi bugünden sonra olmalıdır.");

            RuleFor(x => x.City)
                .NotEmpty().WithMessage("Şehir zorunludur.")
                .MaximumLength(50).WithMessage("Adres en fazla 50 karakter olabilir.");

            RuleFor(x => x.District)
                .NotEmpty().WithMessage("İlçe zorunludur.")
                .MaximumLength(50).WithMessage("Adres en fazla 50 karakter olabilir.");

            RuleFor(x => x.Price)
                .GreaterThan(0).WithMessage("Fiyat sıfırdan büyük olmalıdır.")
                .LessThanOrEqualTo(10000).WithMessage("Fiyat 10000'den fazla olamaz.");

            RuleFor(x => x.Description)
                .MaximumLength(200).WithMessage("Açıklama en fazla 200 karakter olabilir.")
                .When(x => !string.IsNullOrEmpty(x.Description));
        }
    }
}
