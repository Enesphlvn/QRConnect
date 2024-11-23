using App.Application.Features.Events.Create;
using App.Application.Features.Events.Dto;
using App.Application.Features.Events.Update;

namespace App.Application.Features.Events
{
    public interface IEventService
    {
        Task<ServiceResult<List<EventResponse>>> GetAllListAsync();
        Task<ServiceResult<List<EventResponse>>> GetPagedAllListAsync(int pageNumber, int pageSize);
        Task<ServiceResult<List<EventWithDetailResponse>>> GetEventsWithDetailAsync();
        Task<ServiceResult<List<EventsByEventTypeResponse>>> GetEventsByEventTypeAsync(int eventTypeId);
        Task<ServiceResult<List<EventsByVenueResponse>>> GetEventsByVenueAsync(int venueId);
        Task<ServiceResult<List<EventsWithHighestSalesResponse>>> GetEventsWithHighestSalesAsync(int numberOffEvents);
        Task<ServiceResult<List<EventResponse>>> GetEventsByDateRangeAsync(DateTimeOffset startDate, DateTimeOffset endDate);
        Task<ServiceResult<List<EventResponse>>> GetEventsByPriceRangeAsync(decimal minPrice, decimal maxPrice);
        Task<ServiceResult<List<EventsByUserTicketsResponse>>> GetEventsByUserTicketsAsync(int userId);
        Task<ServiceResult<EventResponse>> GetByIdAsync(int id);
        Task<ServiceResult<int>> CreateAsync(CreateEventRequest request);
        Task<ServiceResult> UpdateAsync(int id, UpdateEventRequest request);
        Task<ServiceResult> DeleteAsync(int id);
        Task<ServiceResult<byte[]>> QrCodeToEventAsync(int eventId);
        Task<ServiceResult> PassiveAsync(int id);
    }
}
