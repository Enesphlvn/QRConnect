﻿using App.API.Filters;
using App.Application.Features.EventTypes;
using App.Application.Features.EventTypes.Create;
using App.Application.Features.EventTypes.Update;
using App.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace App.API.Controllers
{
    public class EventTypesController(IEventTypeService eventTypeService) : CustomBaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetEventTypes()
        {
            return CreateActionResult(await eventTypeService.GetAllListAsync());
        }

        [HttpGet("{pageNumber:int}/{pageSize:int}")]
        public async Task<IActionResult> GetPagedEventTypes(int pageNumber, int pageSize)
        {
            return CreateActionResult(await eventTypeService.GetPagedAllListAsync(pageNumber, pageSize));
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetEventType(int id)
        {
            return CreateActionResult(await eventTypeService.GetByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> CreateEventType(CreateEventTypeRequest request)
        {
            return CreateActionResult(await eventTypeService.CreateAsync(request));
        }

        [ServiceFilter(typeof(NotFoundFilter<EventType, int>))]
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateEventType(int id, UpdateEventTypeRequest request)
        {
            return CreateActionResult(await eventTypeService.UpdateAsync(id, request));
        }

        [ServiceFilter(typeof(NotFoundFilter<EventType, int>))]
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteEventType(int id)
        {
            return CreateActionResult(await eventTypeService.DeleteAsync(id));
        }
    }
}