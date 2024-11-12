﻿using App.Application.Contracts.Persistence;
using App.Application.Features.EventTypes.Create;
using App.Application.Features.EventTypes.Dto;
using App.Application.Features.EventTypes.Update;
using App.Domain.Entities;
using AutoMapper;
using System.Net;

namespace App.Application.Features.EventTypes
{
    public class EventTypeService(IEventTypeRepository eventTypeRepository, IUnitOfWork unitOfWork, IMapper mapper) : IEventTypeService
    {
        public async Task<ServiceResult<int>> CreateAsync(CreateEventTypeRequest request)
        {
            var isSameEventType = await eventTypeRepository.AnyAsync(x => x.Name == request.Name);

            if (isSameEventType)
            {
                return ServiceResult<int>.Fail("Aynı isimde başka bir etkinlik türü mevcut.", HttpStatusCode.BadRequest);
            }

            var newEventType = mapper.Map<EventType>(request);
            await eventTypeRepository.AddAsync(newEventType);
            await unitOfWork.SaveChangesAsync();

            return ServiceResult<int>.SuccessAsCreated(newEventType.Id, $"api/eventtypes/{newEventType.Id}");
        }

        public async Task<ServiceResult> DeleteAsync(int id)
        {
            var eventType = await eventTypeRepository.GetByIdAsync(id);

            eventTypeRepository.Delete(eventType!);
            await unitOfWork.SaveChangesAsync();

            return ServiceResult.Success(HttpStatusCode.NoContent);
        }

        public async Task<ServiceResult<List<EventTypeDto>>> GetAllListAsync()
        {
            var eventTypes = await eventTypeRepository.GetAllAsync();

            var eventTypesAsDto = mapper.Map<List<EventTypeDto>>(eventTypes);

            return ServiceResult<List<EventTypeDto>>.Success(eventTypesAsDto);
        }

        public async Task<ServiceResult<EventTypeDto>> GetByIdAsync(int id)
        {
            var eventType = await eventTypeRepository.GetByIdAsync(id);

            if (eventType is null)
            {
                return ServiceResult<EventTypeDto>.Fail("EventType bulunamadı", HttpStatusCode.NotFound);
            }

            var eventTypeAsDto = mapper.Map<EventTypeDto>(eventType);

            return ServiceResult<EventTypeDto>.Success(eventTypeAsDto);
        }

        public async Task<ServiceResult<List<EventTypeDto>>> GetPagedAllListAsync(int pageNumber, int pageSize)
        {
            if (pageNumber <= 0 || pageSize <= 0)
            {
                return ServiceResult<List<EventTypeDto>>.Fail("Geçersiz sayı", HttpStatusCode.BadRequest);
            }

            var eventTypes = await eventTypeRepository.GetAllPagedAsync(pageNumber, pageSize);

            var eventTypeAsDto = mapper.Map<List<EventTypeDto>>(eventTypes);

            return ServiceResult<List<EventTypeDto>>.Success(eventTypeAsDto);
        }

        public async Task<ServiceResult> UpdateAsync(int id, UpdateEventTypeRequest request)
        {
            var isDuplicateEventType = await eventTypeRepository.AnyAsync(x => x.Name == request.Name && x.Id != id);

            if (isDuplicateEventType)
            {
                return ServiceResult.Fail("Aynı isimde başka bir etkinlik türü mevcut.", HttpStatusCode.BadRequest);
            }

            var eventType = mapper.Map<EventType>(request);
            eventType.Id = id;

            eventTypeRepository.Update(eventType);
            await unitOfWork.SaveChangesAsync();

            return ServiceResult.Success(HttpStatusCode.NoContent);
        }
    }
}