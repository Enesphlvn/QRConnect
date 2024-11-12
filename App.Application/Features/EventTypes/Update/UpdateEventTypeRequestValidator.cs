﻿using FluentValidation;

namespace App.Application.Features.EventTypes.Update
{
    public class UpdateEventTypeRequestValidator : AbstractValidator<UpdateEventTypeRequest>
    {
        public UpdateEventTypeRequestValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Etkinlik türü zorunludur.")
                .Length(2, 50).WithMessage("Etkinlik türü 2 ile 50 karakter arasında olmalıdır.");
        }
    }
}