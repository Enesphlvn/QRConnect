using App.Application.Features.Tickets.Create;
using App.Application.Features.Tickets.Dto;
using App.Application.Features.Tickets.Update;

namespace App.Application.Features.Tickets
{
    public interface ITicketService
    {
        Task<ServiceResult<List<TicketDto>>> GetAllListAsync();
        Task<ServiceResult<List<TicketDto>>> GetPagedAllListAsync(int pageNumber, int pageSize);
        Task<ServiceResult<TicketDto>> GetByIdAsync(int id);
        Task<ServiceResult<int>> CreateAsync(CreateTicketRequest request);
        Task<ServiceResult> UpdateAsync(int id, UpdateTicketRequest request);
        Task<ServiceResult> DeleteAsync(int id);
        Task<ServiceResult<byte[]>> QrCodeToUserAndEventAsync(int customerId, int eventId);
    }
}
