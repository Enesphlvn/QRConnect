using FluentValidation;

namespace App.Application.Features.Users.Create
{
    public class CreateUserRequestValidator : AbstractValidator<CreateUserRequest>
    {
        public CreateUserRequestValidator()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("İsim zorunludur.")
                .Length(3, 50).WithMessage("İsim 3 ile 50 karakter arasında olmalıdır.");

            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("Soyisim zorunludur.")
                .Length(3, 50).WithMessage("Soyisim 3 ile 50 karakter arasında olmalıdır.");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email zorunludur.")
                .EmailAddress().WithMessage("Geçerli bir email adresi girin.");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Şifre boş bırakılamaz.")
                .MinimumLength(8).WithMessage("Şifre en az 8 karakter uzunluğunda olmalı.")
                .Matches(@"[A-ZĞÜÖŞÇİ]").WithMessage("Şifre en az bir büyük harf içermeli.")
                .Matches("[a-z]").WithMessage("Şifre en az bir küçük harf içermeli.")
                .Matches("[0-9]").WithMessage("Şifre en az bir rakam içermeli.")
                .Matches(@"[\W]").WithMessage("Şifre en az bir özel karakter içermeli.");
        }
    }
}
