using App.API.Filters;
using App.Application.Features.Tickets;
using App.Application.Features.Tickets.Create;
using App.Application.Features.Tickets.Update;
using App.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace App.API.Controllers
{
    public class TicketsController(ITicketService ticketService) : CustomBaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetTickets()
        {
            return CreateActionResult(await ticketService.GetAllListAsync());
        }

        [HttpGet("{pageNumber:int}/{pageSize:int}")]
        public async Task<IActionResult> GetPagedTickets(int pageNumber, int pageSize)
        {
            return CreateActionResult(await ticketService.GetPagedAllListAsync(pageNumber, pageSize));
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetTicket(int id)
        {
            return CreateActionResult(await ticketService.GetByIdAsync(id));
        }

        [HttpGet("qrcode/{eventId:int}/{customerId:int}")]
        public async Task<IActionResult> GetQRCode(int eventId, int customerId)
        {
            var result = await ticketService.QrCodeToUserAndEventAsync(customerId, eventId);

            if (result.IsSuccess)
            {
                return File(result.Data!, "image/png");
            }

            return CreateActionResult(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTicket(CreateTicketRequest request)
        {
            return CreateActionResult(await ticketService.CreateAsync(request));
        }

        [ServiceFilter(typeof(NotFoundFilter<Ticket, int>))]
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateTicket(int id, UpdateTicketRequest request)
        {
            return CreateActionResult(await ticketService.UpdateAsync(id, request));
        }

        [ServiceFilter(typeof(NotFoundFilter<Ticket, int>))]
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteTicket(int id)
        {
            return CreateActionResult(await ticketService.DeleteAsync(id));
        }
    }
}
