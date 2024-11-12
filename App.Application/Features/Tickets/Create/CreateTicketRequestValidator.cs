using FluentValidation;

namespace App.Application.Features.Tickets.Create
{
    public class CreateTicketRequestValidator : AbstractValidator<CreateTicketRequest>
    {
        public CreateTicketRequestValidator()
        {
            RuleFor(x => x.EventId)
                .GreaterThan(0).WithMessage("EventId 0'dan büyük olmalıdır.");

            RuleFor(x => x.UserId)
                .GreaterThan(0).WithMessage("UserId 0'dan büyük olmalıdır.");
        }
    }
}
