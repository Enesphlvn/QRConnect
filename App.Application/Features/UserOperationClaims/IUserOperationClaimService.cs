using App.Application.Features.UserOperationClaims.Create;
using App.Application.Features.UserOperationClaims.Dto;
using App.Application.Features.UserOperationClaims.Update;

namespace App.Application.Features.UserOperationClaims
{
    public interface IUserOperationClaimService
    {
        Task<ServiceResult<List<UserOperationClaimResponse>>> GetAllListAsync();
        Task<ServiceResult<List<UserOperationClaimWithDetailResponse>>> GetUserOperationClaimWithDetailAsync();
        Task<ServiceResult<List<UserOperationClaimResponse>>> GetPagedAllListAsync(int pageNumber, int pageSize);
        Task<ServiceResult<UserOperationClaimResponse>> GetByIdAsync(int id);
        Task<ServiceResult<List<UserOperationClaimByUserResponse>>> GetUserOperationClaimByUserAsync(int userId);
        Task<ServiceResult<List<UserOperationClaimByOperationClaimResponse>>> GetUserOperationClaimByOperationClaimAsync(int operationClaimId);
        Task<ServiceResult<int>> CreateAsync(CreateUserOperationClaimRequest request);
        Task<ServiceResult> UpdateAsync(int id, UpdateUserOperationClaimRequest request);
        Task<ServiceResult> DeleteAsync(int id);
        Task<ServiceResult> PassiveAsync(int id);
    }
}
