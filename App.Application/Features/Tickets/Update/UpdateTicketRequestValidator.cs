using FluentValidation;

namespace App.Application.Features.Tickets.Update
{
    public class UpdateTicketRequestValidator : AbstractValidator<UpdateTicketRequest>
    {
        public UpdateTicketRequestValidator()
        {
            RuleFor(request => request.EventId)
                .GreaterThan(0).WithMessage("EventId 0'dan büyük olmalıdır.");

            RuleFor(request => request.UserId)
                .GreaterThan(0).WithMessage("UserId 0'dan büyük olmalıdır.");
        }
    }
}
