using App.Application.Features.Customers.Create;
using App.Application.Features.Customers.Dto;
using App.Application.Features.Customers.Update;
using App.Application.Features.Customers.UpdateEmail;

namespace App.Application.Features.Customers
{
    public interface ICustomerService
    {
        Task<ServiceResult<List<CustomerDto>>> GetAllListAsync();
        Task<ServiceResult<List<CustomerDto>>> GetPagedAllListAsync(int pageNumber, int pageSize);
        Task<ServiceResult<CustomerDto>> GetByIdAsync(int id);
        Task<ServiceResult<int>> CreateAsync(CreateCustomerRequest request);
        Task<ServiceResult> UpdateAsync(int id, UpdateCustomerRequest request);
        Task<ServiceResult> UpdateEmailAsync(int id, UpdateEmailCustomerRequest request);
        Task<ServiceResult> DeleteAsync(int id);
        Task<ServiceResult<byte[]>> QrCodeToUserAsync(int userId);
    }
}
