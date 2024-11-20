using App.Application.Features.Events.Create;
using App.Application.Features.Events.Dto;
using App.Application.Features.Events.Update;

namespace App.Application.Features.Events
{
    public interface IEventService
    {
        Task<ServiceResult<List<EventDto>>> GetAllListAsync();
        Task<ServiceResult<List<EventDto>>> GetPagedAllListAsync(int pageNumber, int pageSize);
        Task<ServiceResult<List<EventsByEventTypeDto>>> GetEventsByEventTypeAsync(int eventTypeId);
        Task<ServiceResult<List<EventsByVenueDto>>> GetEventsByVenueAsync(int venueId);
        Task<ServiceResult<List<EventsWithHighestSalesDto>>> GetEventsWithHighestSalesAsync(int numberOffEvents);
        Task<ServiceResult<List<EventDto>>> GetEventsByDateRangeAsync(DateTimeOffset startDate, DateTimeOffset endDate);
        Task<ServiceResult<List<EventDto>>> GetEventsByPriceRangeAsync(decimal minPrice, decimal maxPrice);
        Task<ServiceResult<List<EventsByUserTicketsDto>>> GetEventsByUserTicketsAsync(int userId);
        Task<ServiceResult<EventDto>> GetByIdAsync(int id);
        Task<ServiceResult<int>> CreateAsync(CreateEventRequest request);
        Task<ServiceResult> UpdateAsync(int id, UpdateEventRequest request);
        Task<ServiceResult> DeleteAsync(int id);
        Task<ServiceResult<byte[]>> QrCodeToEventAsync(int eventId);
        Task<ServiceResult> PassiveAsync(int id);
    }
}
