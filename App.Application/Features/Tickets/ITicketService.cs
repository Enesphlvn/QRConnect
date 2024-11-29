using App.Application.Features.Tickets.Create;
using App.Application.Features.Tickets.Dto;
using App.Application.Features.Tickets.Update;

namespace App.Application.Features.Tickets
{
    public interface ITicketService
    {
        Task<ServiceResult<List<TicketResponse>>> GetAllListAsync();
        Task<ServiceResult<List<TicketResponse>>> GetPagedAllListAsync(int pageNumber, int pageSize);
        Task<ServiceResult<List<TicketWithDetailResponse>>> GetTicketsWithDetailAsync();
        Task<ServiceResult<List<TicketsByEventResponse>>> GetTicketsByEventAsync(int eventId);
        Task<ServiceResult<List<TicketsByUserResponse>>> GetTicketsByUserAsync(int userId);
        Task<ServiceResult<List<TicketWithDetailResponse>>> GetTicketsByDateRangeAsync(DateTimeOffset startDate, DateTimeOffset endDate);
        Task<ServiceResult<bool>> HasUserTicketForEventAsync(int userId, int eventId);
        Task<ServiceResult<int>> GetTicketCountByEventAsync(int id);
        Task<ServiceResult<TicketResponse>> GetByIdAsync(int id);
        Task<ServiceResult<int>> CreateAsync(CreateTicketRequest request);
        Task<ServiceResult> UpdateAsync(int id, UpdateTicketRequest request);
        Task<ServiceResult> DeleteAsync(int id);
        Task<ServiceResult<byte[]>> QrCodeToUserAndEventAsync(int userId, int eventId);
        Task<ServiceResult> PassiveAsync(int id);
    }
}
