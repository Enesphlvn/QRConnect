using App.Application.Features.UserOperationClaims.Create;
using App.Application.Features.UserOperationClaims.Dto;
using App.Application.Features.UserOperationClaims.Update;

namespace App.Application.Features.UserOperationClaims
{
    public interface IUserOperationClaimService
    {
        Task<ServiceResult<List<UserOperationClaimDto>>> GetAllListAsync();
        Task<ServiceResult<List<UserOperationClaimDto>>> GetPagedAllListAsync(int pageNumber, int pageSize);
        Task<ServiceResult<UserOperationClaimDto>> GetByIdAsync(int id);
        Task<ServiceResult<int>> CreateAsync(CreateUserOperationClaimRequest request);
        Task<ServiceResult> UpdateAsync(int id, UpdateUserOperationClaimRequest request);
        Task<ServiceResult> DeleteAsync(int id);
        Task<ServiceResult> PassiveAsync(int id);
    }
}
