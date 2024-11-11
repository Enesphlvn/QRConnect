using App.Application.Features.Events.Create;
using App.Application.Features.Events.Dto;
using App.Application.Features.Events.Update;

namespace App.Application.Features.Events
{
    public interface IEventService
    {
        Task<ServiceResult<List<EventDto>>> GetAllListAsync();
        Task<ServiceResult<List<EventDto>>> GetPagedAllListAsync(int pageNumber, int pageSize);
        Task<ServiceResult<EventDto>> GetByIdAsync(int id);
        Task<ServiceResult<int>> CreateAsync(CreateEventRequest request);
        Task<ServiceResult> UpdateAsync(int id, UpdateEventRequest request);
        Task<ServiceResult> DeleteAsync(int id);
        Task<ServiceResult<byte[]>> QrCodeToEventAsync(int eventId);
    }
}
