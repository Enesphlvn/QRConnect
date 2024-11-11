using App.Application.Contracts.Persistence;
using App.Application.Features.Events.Create;
using App.Application.Features.Events.Dto;
using App.Application.Features.Events.Update;
using App.Domain.Entities;
using AutoMapper;
using System.Net;
using System.Text.Json;

namespace App.Application.Features.Events
{
    public class EventService(IEventRepository eventRepository, IUnitOfWork unitOfWork, IMapper mapper, IQRCodeService qRCodeService) : IEventService
    {
        public async Task<ServiceResult<int>> CreateAsync(CreateEventRequest request)
        {
            var isSameEvent = await eventRepository.AnyAsync(x => x.Date == request.Date && x.City == request.City && x.District == request.District);

            if (isSameEvent)
            {
                return ServiceResult<int>.Fail("Aynı tarih ve adreste başka bir etkinlik mevcut.", HttpStatusCode.BadRequest);
            }

            var newEvent = mapper.Map<Event>(request);

            await eventRepository.AddAsync(newEvent);
            await unitOfWork.SaveChangesAsync();

            return ServiceResult<int>.SuccessAsCreated(newEvent.Id, $"api/events/{newEvent.Id}");
        }

        public async Task<ServiceResult> DeleteAsync(int id)
        {
            var @event = await eventRepository.GetByIdAsync(id);

            eventRepository.Delete(@event!);
            await unitOfWork.SaveChangesAsync();

            return ServiceResult.Success(HttpStatusCode.NoContent);
        }

        public async Task<ServiceResult<List<EventDto>>> GetAllListAsync()
        {
            var events = await eventRepository.GetAllAsync();

            var eventsAsDto = mapper.Map<List<EventDto>>(events);

            return ServiceResult<List<EventDto>>.Success(eventsAsDto);
        }

        public async Task<ServiceResult<EventDto>> GetByIdAsync(int id)
        {
            var @event = await eventRepository.GetByIdAsync(id);

            if (@event is null)
            {
                return ServiceResult<EventDto>.Fail("Event bulunamadı", HttpStatusCode.NotFound);
            }

            var eventAsDto = mapper.Map<EventDto>(@event);

            return ServiceResult<EventDto>.Success(eventAsDto);
        }

        public async Task<ServiceResult<List<EventDto>>> GetPagedAllListAsync(int pageNumber, int pageSize)
        {
            if (pageNumber <= 0 || pageSize <= 0)
            {
                return ServiceResult<List<EventDto>>.Fail("Geçersiz sayı", HttpStatusCode.BadRequest);
            }

            var events = await eventRepository.GetAllPagedAsync(pageNumber, pageSize);

            var eventAsDto = mapper.Map<List<EventDto>>(events);

            return ServiceResult<List<EventDto>>.Success(eventAsDto);
        }

        public async Task<ServiceResult<byte[]>> QrCodeToEventAsync(int eventId)
        {
            var eventEntityExists = await eventRepository.GetByIdAsync(eventId);

            if (eventEntityExists is null)
            {
                return ServiceResult<byte[]>.Fail("Etkinlik bulunamadı", HttpStatusCode.NotFound);
            }

            var plainObject = new
            {
                eventEntityExists.Id,
                eventEntityExists.Name,
                eventEntityExists.Date,
                eventEntityExists.Price,
                eventEntityExists.City,
                eventEntityExists.District,
                eventEntityExists.Description
            };

            string plainText = JsonSerializer.Serialize(plainObject);

            return ServiceResult<byte[]>.Success(qRCodeService.GenerateQRCode(plainText));
        }

        public async Task<ServiceResult> UpdateAsync(int id, UpdateEventRequest request)
        {
            var isDuplicateEvent = await eventRepository.AnyAsync(x => x.Date == request.Date && x.City == request.City && x.District == request.District && x.Id != id);

            if (isDuplicateEvent)
            {
                return ServiceResult.Fail("Aynı tarih ve adreste başka bir etkinlik mevcut.", HttpStatusCode.BadRequest);
            }

            var @event = mapper.Map<Event>(request);
            @event.Id = id;

            eventRepository.Update(@event);
            await unitOfWork.SaveChangesAsync();

            return ServiceResult.Success(HttpStatusCode.NoContent);
        }
    }
}
