using App.Application.Contracts.Persistence;
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
            var isSameEventType = await eventTypeRepository.AnyAsync(x => x.Name.ToLower() == request.Name.ToLower());

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

        public async Task<ServiceResult<List<EventTypeResponse>>> GetAllListAsync()
        {
            var eventTypes = await eventTypeRepository.GetAllAsync();

            var eventTypesAsDto = mapper.Map<List<EventTypeResponse>>(eventTypes);

            return ServiceResult<List<EventTypeResponse>>.Success(eventTypesAsDto);
        }

        public async Task<ServiceResult<EventTypeResponse>> GetByIdAsync(int id)
        {
            var eventType = await eventTypeRepository.GetByIdAsync(id);

            if (eventType is null)
            {
                return ServiceResult<EventTypeResponse>.Fail("EventType bulunamadı", HttpStatusCode.NotFound);
            }

            var eventTypeAsDto = mapper.Map<EventTypeResponse>(eventType);

            return ServiceResult<EventTypeResponse>.Success(eventTypeAsDto);
        }

        public async Task<ServiceResult<EventTypeWithEventsResponse>> GetEventTypeWithEventsAsync(int id)
        {
            var eventType = await eventTypeRepository.GetEventTypeWithEventsAsync(id);

            if (eventType is null)
            {
                return ServiceResult<EventTypeWithEventsResponse>.Fail("EventType bulunamadı", HttpStatusCode.NotFound);
            }

            var eventTypeAsDto = mapper.Map<EventTypeWithEventsResponse>(eventType);

            return ServiceResult<EventTypeWithEventsResponse>.Success(eventTypeAsDto);
        }

        public async Task<ServiceResult<List<EventTypeWithEventsResponse>>> GetEventTypesWithEventsAsync()
        {
            var eventType = await eventTypeRepository.GetEventTypesWithEventsAsync();

            if (eventType is null)
            {
                return ServiceResult<List<EventTypeWithEventsResponse>>.Fail("EventType bulunamadı");
            }

            var eventTypeAsDto = mapper.Map<List<EventTypeWithEventsResponse>>(eventType);

            return ServiceResult<List<EventTypeWithEventsResponse>>.Success(eventTypeAsDto);
        }

        public async Task<ServiceResult<List<EventTypeResponse>>> GetPagedAllListAsync(int pageNumber, int pageSize)
        {
            if (pageNumber <= 0 || pageSize <= 0)
            {
                return ServiceResult<List<EventTypeResponse>>.Fail("Geçersiz sayı", HttpStatusCode.BadRequest);
            }

            var eventTypes = await eventTypeRepository.GetAllPagedAsync(pageNumber, pageSize);

            var eventTypeAsDto = mapper.Map<List<EventTypeResponse>>(eventTypes);

            return ServiceResult<List<EventTypeResponse>>.Success(eventTypeAsDto);
        }

        public async Task<ServiceResult> PassiveAsync(int id)
        {
            await eventTypeRepository.PassiveAsync(id);

            return ServiceResult.Success(HttpStatusCode.NoContent);
        }

        public async Task<ServiceResult> UpdateAsync(int id, UpdateEventTypeRequest request)
        {
            var isDuplicateEventType = await eventTypeRepository.AnyAsync(x => x.Name.ToLower() == request.Name.ToLower() && x.Id != id);

            if (isDuplicateEventType)
            {
                return ServiceResult.Fail("Aynı isimde başka bir etkinlik türü mevcut.", HttpStatusCode.BadRequest);
            }

            var existingEventType = await eventTypeRepository.GetByIdAsync(id);

            if (existingEventType is null)
            {
                return ServiceResult.Fail("Etkinlik türü bulunamadı.", HttpStatusCode.NotFound);
            }

            mapper.Map(request, existingEventType);

            eventTypeRepository.Update(existingEventType);
            await unitOfWork.SaveChangesAsync();

            return ServiceResult.Success(HttpStatusCode.NoContent);
        }
    }
}
