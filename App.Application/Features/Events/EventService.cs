using App.Application.Contracts.Persistence;
using App.Application.Features.Events.Create;
using App.Application.Features.Events.Dto;
using App.Application.Features.Events.Update;
using App.Application.Features.QRCodes;
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
            var isSameEvent = await eventRepository.AnyAsync(x => x.Date == request.Date && x.VenueId == request.VenueId);

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

        public async Task<ServiceResult<List<EventResponse>>> GetAllListAsync()
        {
            var events = await eventRepository.GetAllAsync();

            var eventsAsDto = mapper.Map<List<EventResponse>>(events);

            return ServiceResult<List<EventResponse>>.Success(eventsAsDto);
        }

        public async Task<ServiceResult<EventResponse>> GetByIdAsync(int id)
        {
            var @event = await eventRepository.GetByIdAsync(id);

            if (@event is null)
            {
                return ServiceResult<EventResponse>.Fail("Event bulunamadı", HttpStatusCode.NotFound);
            }

            var eventAsDto = mapper.Map<EventResponse>(@event);

            return ServiceResult<EventResponse>.Success(eventAsDto);
        }

        public async Task<ServiceResult<List<EventResponse>>> GetEventsByDateRangeAsync(DateTimeOffset startDate, DateTimeOffset endDate)
        {
            var events = await eventRepository.GetEventsByDateRangeAsync(startDate, endDate);

            if (events.Count == 0)
            {
                return ServiceResult<List<EventResponse>>.Fail("Bu tarih aralığında etkinlik bulunamadı.");
            }

            var eventsAsDto = mapper.Map<List<EventResponse>>(events);

            return ServiceResult<List<EventResponse>>.Success(eventsAsDto);
        }

        public async Task<ServiceResult<List<EventsByEventTypeResponse>>> GetEventsByEventTypeAsync(int eventTypeId)
        {
            var eventsByEventType = await eventRepository.GetEventsByEventTypeAsync(eventTypeId);

            if (eventsByEventType.Count == 0)
            {
                return ServiceResult<List<EventsByEventTypeResponse>>.Fail("EventType ile eşleşen event bulunamadı");
            }

            var eventsByEventTypeAsDto = mapper.Map<List<EventsByEventTypeResponse>>(eventsByEventType);

            return ServiceResult<List<EventsByEventTypeResponse>>.Success(eventsByEventTypeAsDto);
        }

        public async Task<ServiceResult<List<EventResponse>>> GetEventsByPriceRangeAsync(decimal minPrice, decimal maxPrice)
        {
            var events = await eventRepository.GetEventsByPriceRangeAsync(minPrice, maxPrice);

            if (events.Count == 0)
            {
                return ServiceResult<List<EventResponse>>.Fail("Bu fiyat aralığında etkinlik bulunamadı.");
            }

            var eventsAsDto = mapper.Map<List<EventResponse>>(events);

            return ServiceResult<List<EventResponse>>.Success(eventsAsDto);
        }

        public async Task<ServiceResult<List<EventsByUserTicketsResponse>>> GetEventsByUserTicketsAsync(int userId)
        {
            var eventsByUserTicket = await eventRepository.GetEventsByUserTicketsAsync(userId);

            if (eventsByUserTicket.Count == 0)
            {
                return ServiceResult<List<EventsByUserTicketsResponse>>.Fail("Kullanıcı veya kullanıcıya ait bilet bulunamadı.");
            }

            var eventsByUserTicketAsDto = mapper.Map<List<EventsByUserTicketsResponse>>(eventsByUserTicket);

            return ServiceResult<List<EventsByUserTicketsResponse>>.Success(eventsByUserTicketAsDto);
        }

        public async Task<ServiceResult<List<EventsByVenueResponse>>> GetEventsByVenueAsync(int venueId)
        {
            var eventsByVenue = await eventRepository.GetEventsByVenueAsync(venueId);

            if (eventsByVenue.Count == 0)
            {
                return ServiceResult<List<EventsByVenueResponse>>.Fail("Venue ile eşleşen etkinlik bulunamadı", HttpStatusCode.NotFound);
            }

            var eventsByVenueAsDto = mapper.Map<List<EventsByVenueResponse>>(eventsByVenue);

            return ServiceResult<List<EventsByVenueResponse>>.Success(eventsByVenueAsDto);
        }

        public async Task<ServiceResult<List<EventsWithHighestSalesResponse>>> GetEventsWithHighestSalesAsync(int numberOffEvents)
        {
            var eventsWithHighestSales = await eventRepository.GetEventsWithHighestSalesAsync(numberOffEvents);

            var eventsWithHighestSalesAsDto = mapper.Map<List<EventsWithHighestSalesResponse>>(eventsWithHighestSales);

            return ServiceResult<List<EventsWithHighestSalesResponse>>.Success(eventsWithHighestSalesAsDto);
        }

        public async Task<ServiceResult<List<EventWithDetailResponse>>> GetEventsWithDetailAsync()
        {
            var events = await eventRepository.GetEventsWithDetailAsync();

            var eventsAsDto = mapper.Map<List<EventWithDetailResponse>>(events);

            return ServiceResult<List<EventWithDetailResponse>>.Success(eventsAsDto);
        }

        public async Task<ServiceResult<List<EventResponse>>> GetPagedAllListAsync(int pageNumber, int pageSize)
        {
            if (pageNumber <= 0 || pageSize <= 0)
            {
                return ServiceResult<List<EventResponse>>.Fail("Geçersiz sayı", HttpStatusCode.BadRequest);
            }

            var events = await eventRepository.GetAllPagedAsync(pageNumber, pageSize);

            var eventAsDto = mapper.Map<List<EventResponse>>(events);

            return ServiceResult<List<EventResponse>>.Success(eventAsDto);
        }

        public async Task<ServiceResult> PassiveAsync(int id)
        {
            await eventRepository.PassiveAsync(id);

            return ServiceResult.Success(HttpStatusCode.NoContent);
        }

        public async Task<ServiceResult<byte[]>> QrCodeToEventAsync(int eventId)
        {
            var eventEntityExists = await eventRepository.GetEventWithDetailAsync(eventId);

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
                eventEntityExists.Description,
                EventTypeName = eventEntityExists.EventType.Name,
                VenueCityName = eventEntityExists.Venue.City.Name,
                VenueDistrictName = eventEntityExists.Venue.District.Name,
                VenueName = eventEntityExists.Venue.Name,
            };

            string plainText = JsonSerializer.Serialize(plainObject);

            return ServiceResult<byte[]>.Success(qRCodeService.GenerateQRCode(plainText));
        }

        public async Task<ServiceResult> UpdateAsync(int id, UpdateEventRequest request)
        {
            var isDuplicateEvent = await eventRepository.AnyAsync(x => x.Date == request.Date && x.VenueId == request.VenueId && x.Id != id);

            if (isDuplicateEvent)
            {
                return ServiceResult.Fail("Aynı tarih ve adreste başka bir etkinlik mevcut.", HttpStatusCode.BadRequest);
            }

            var existingEvent = await eventRepository.GetByIdAsync(id);

            if (existingEvent is null)
            {
                return ServiceResult.Fail("Etkinlik bulunamadı.", HttpStatusCode.NotFound);
            }

            mapper.Map(request, existingEvent);

            eventRepository.Update(existingEvent);
            await unitOfWork.SaveChangesAsync();

            return ServiceResult.Success(HttpStatusCode.NoContent);
        }
    }
}
