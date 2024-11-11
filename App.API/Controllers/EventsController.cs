using App.API.Filters;
using App.Application.Features.Events;
using App.Application.Features.Events.Create;
using App.Application.Features.Events.Update;
using App.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace App.API.Controllers
{
    public class EventsController(IEventService eventService) : CustomBaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetEvents()
        {
            return CreateActionResult(await eventService.GetAllListAsync());
        }

        [HttpGet("{pageNumber:int}/{pageSize:int}")]
        public async Task<IActionResult> GetPagedEvents(int pageNumber, int pageSize)
        {
            return CreateActionResult(await eventService.GetPagedAllListAsync(pageNumber, pageSize));
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetEvent(int id)
        {
            return CreateActionResult(await eventService.GetByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> CreateEvent(CreateEventRequest request)
        {
            return CreateActionResult(await eventService.CreateAsync(request));
        }

        [ServiceFilter(typeof(NotFoundFilter<Event, int>))]
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateEvent(int id, UpdateEventRequest request)
        {
            return CreateActionResult(await eventService.UpdateAsync(id, request));
        }

        [ServiceFilter(typeof(NotFoundFilter<Event, int>))]
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteEvent(int id)
        {
            return CreateActionResult(await eventService.DeleteAsync(id));
        }
    }
}
