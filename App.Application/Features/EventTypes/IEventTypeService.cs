using App.Application.Features.EventTypes.Create;
using App.Application.Features.EventTypes.Dto;
using App.Application.Features.EventTypes.Update;

namespace App.Application.Features.EventTypes
{
    public interface IEventTypeService
    {
        Task<ServiceResult<List<EventTypeResponse>>> GetAllListAsync();
        Task<ServiceResult<List<EventTypeResponse>>> GetPagedAllListAsync(int pageNumber, int pageSize);
        Task<ServiceResult<EventTypeWithEventsResponse>> GetEventTypeWithEventsAsync(int id);
        Task<ServiceResult<List<EventTypeWithEventsResponse>>> GetEventTypeWithEventsAsync();
        Task<ServiceResult<EventTypeResponse>> GetByIdAsync(int id);
        Task<ServiceResult<int>> CreateAsync(CreateEventTypeRequest request);
        Task<ServiceResult> UpdateAsync(int id, UpdateEventTypeRequest request);
        Task<ServiceResult> DeleteAsync(int id);
        Task<ServiceResult> PassiveAsync(int id);
    }
}
