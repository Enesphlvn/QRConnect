using FluentValidation;

namespace App.Application.Features.Users.UpdatePassword
{
    public class UpdatePasswordUserRequestValidator : AbstractValidator<UpdatePasswordUserRequest>
    {
        public UpdatePasswordUserRequestValidator()
        {
            RuleFor(x => x.OldPassword)
                .NotEmpty().WithMessage("Şifre boş bırakılamaz.")
                .MinimumLength(8).WithMessage("Şifre en az 8 karakter uzunluğunda olmalı.")
                .Matches("[A-Z]").WithMessage("Şifre en az bir büyük harf içermeli.")
                .Matches("[a-z]").WithMessage("Şifre en az bir küçük harf içermeli.")
                .Matches("[0-9]").WithMessage("Şifre en az bir rakam içermeli.")
                .Matches(@"[\W]").WithMessage("Şifre en az bir özel karakter içermeli.");

            RuleFor(x => x.NewPassword)
                .NotEmpty().WithMessage("Şifre boş bırakılamaz.")
                .MinimumLength(8).WithMessage("Şifre en az 8 karakter uzunluğunda olmalı.")
                .Matches("[A-Z]").WithMessage("Şifre en az bir büyük harf içermeli.")
                .Matches("[a-z]").WithMessage("Şifre en az bir küçük harf içermeli.")
                .Matches("[0-9]").WithMessage("Şifre en az bir rakam içermeli.")
                .Matches(@"[\W]").WithMessage("Şifre en az bir özel karakter içermeli.");

            RuleFor(x => x.ConfirmPassword)
                .NotEmpty().WithMessage("Şifre boş bırakılamaz.")
                .MinimumLength(8).WithMessage("Şifre en az 8 karakter uzunluğunda olmalı.")
                .Matches("[A-Z]").WithMessage("Şifre en az bir büyük harf içermeli.")
                .Matches("[a-z]").WithMessage("Şifre en az bir küçük harf içermeli.")
                .Matches("[0-9]").WithMessage("Şifre en az bir rakam içermeli.")
                .Matches(@"[\W]").WithMessage("Şifre en az bir özel karakter içermeli.");
        }
    }
}
