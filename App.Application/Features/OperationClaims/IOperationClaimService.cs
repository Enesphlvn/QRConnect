using App.Application.Features.OperationClaims.Create;
using App.Application.Features.OperationClaims.Dto;
using App.Application.Features.OperationClaims.Update;

namespace App.Application.Features.OperationClaims
{
    public interface IOperationClaimService
    {
        Task<ServiceResult<List<OperationClaimDto>>> GetAllListAsync();
        Task<ServiceResult<List<OperationClaimDto>>> GetPagedAllListAsync(int pageNumber, int pageSize);
        Task<ServiceResult<OperationClaimDto>> GetByIdAsync(int id);
        Task<ServiceResult<int>> CreateAsync(CreateOperationClaimRequest request);
        Task<ServiceResult> UpdateAsync(int id, UpdateOperationClaimRequest request);
        Task<ServiceResult> DeleteAsync(int id);
        Task<ServiceResult> PassiveAsync(int id);
    }
}
