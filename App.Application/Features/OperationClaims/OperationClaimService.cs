using App.Application.Contracts.Persistence;
using App.Application.Features.OperationClaims.Create;
using App.Application.Features.OperationClaims.Dto;
using App.Application.Features.OperationClaims.Update;
using App.Domain.Entities;
using AutoMapper;
using System.Net;

namespace App.Application.Features.OperationClaims
{
    public class OperationClaimService(IOperationClaimRepository operationClaimRepository, IMapper mapper, IUnitOfWork unitOfWork) : IOperationClaimService
    {
        public async Task<ServiceResult<int>> CreateAsync(CreateOperationClaimRequest request)
        {
            var isSameOperationClaim = await operationClaimRepository.AnyAsync(x => x.Name.ToLower() == request.Name.ToLower());

            if (isSameOperationClaim)
            {
                return ServiceResult<int>.Fail("Aynı isimde başka bir rol mevcut.", HttpStatusCode.BadRequest);
            }

            var newOperationClaim = mapper.Map<OperationClaim>(request);

            await operationClaimRepository.AddAsync(newOperationClaim);
            await unitOfWork.SaveChangesAsync();

            return ServiceResult<int>.SuccessAsCreated(newOperationClaim.Id, $"api/operationclaims/{newOperationClaim.Id}");
        }

        public async Task<ServiceResult> DeleteAsync(int id)
        {
            var operationClaim = await operationClaimRepository.GetByIdAsync(id);

            operationClaimRepository.Delete(operationClaim!);
            await unitOfWork.SaveChangesAsync();

            return ServiceResult.Success(HttpStatusCode.NoContent);
        }

        public async Task<ServiceResult<List<OperationClaimResponse>>> GetAllListAsync()
        {
            var operationClaims = await operationClaimRepository.GetAllAsync();

            var operationClaimsAsDto = mapper.Map<List<OperationClaimResponse>>(operationClaims);

            return ServiceResult<List<OperationClaimResponse>>.Success(operationClaimsAsDto);
        }

        public async Task<ServiceResult<OperationClaimResponse>> GetByIdAsync(int id)
        {
            var operationClaim = await operationClaimRepository.GetByIdAsync(id);

            if (operationClaim is null)
            {
                return ServiceResult<OperationClaimResponse>.Fail("Rol bulunamadı", HttpStatusCode.NotFound);
            }

            var operationClaimAsDto = mapper.Map<OperationClaimResponse>(operationClaim);

            return ServiceResult<OperationClaimResponse>.Success(operationClaimAsDto);
        }

        public async Task<ServiceResult<OperationClaimWithUserOperationClaimsResponse>> GetOperationClaimWithUserOperationClaimsAsync(int id)
        {
            var operationClaim = await operationClaimRepository.GetOperationCalimWithUserOperationClaimsAsync(id);

            if (operationClaim is null)
            {
                return ServiceResult<OperationClaimWithUserOperationClaimsResponse>.Fail("OperationClaim bulunamadı.", HttpStatusCode.NotFound);
            }

            var operationClaimAsDto = mapper.Map<OperationClaimWithUserOperationClaimsResponse>(operationClaim);

            return ServiceResult<OperationClaimWithUserOperationClaimsResponse>.Success(operationClaimAsDto);
        }

        public async Task<ServiceResult<List<OperationClaimWithUserOperationClaimsResponse>>> GetOperationClaimWithUserOperationClaimsAsync()
        {
            var operationClaims = await operationClaimRepository.GetOperationCalimWithUserOperationClaimsAsync();

            if (operationClaims.Count == 0)
            {
                return ServiceResult<List<OperationClaimWithUserOperationClaimsResponse>>.Fail("OperationClaim bulunamadı", HttpStatusCode.NotFound);
            }

            var operationClaimsAsDto = mapper.Map<List<OperationClaimWithUserOperationClaimsResponse>>(operationClaims);

            return ServiceResult<List<OperationClaimWithUserOperationClaimsResponse>>.Success(operationClaimsAsDto);
        }

        public async Task<ServiceResult<List<OperationClaimResponse>>> GetPagedAllListAsync(int pageNumber, int pageSize)
        {
            if (pageNumber <= 0 || pageSize <= 0)
            {
                return ServiceResult<List<OperationClaimResponse>>.Fail("Geçersiz sayı", HttpStatusCode.BadRequest);
            }

            var operationClaims = await operationClaimRepository.GetAllPagedAsync(pageNumber, pageSize);

            var operationClaimsAsDto = mapper.Map<List<OperationClaimResponse>>(operationClaims);

            return ServiceResult<List<OperationClaimResponse>>.Success(operationClaimsAsDto);
        }

        public async Task<ServiceResult> PassiveAsync(int id)
        {
            await operationClaimRepository.PassiveAsync(id);

            return ServiceResult.Success(HttpStatusCode.NoContent);
        }

        public async Task<ServiceResult> UpdateAsync(int id, UpdateOperationClaimRequest request)
        {
            var isDuplicateOperationClaim = await operationClaimRepository.AnyAsync(x => x.Name.ToLower() == request.Name.ToLower() && x.Id != id);

            if (isDuplicateOperationClaim)
            {
                return ServiceResult.Fail("Aynı isimde başka bir rol mevcut.", HttpStatusCode.BadRequest);
            }

            var existingOperationClaim = await operationClaimRepository.GetByIdAsync(id);
            if (existingOperationClaim is null)
            {
                return ServiceResult.Fail("Rol bulunamadı.", HttpStatusCode.NotFound);
            }

            mapper.Map(request, existingOperationClaim);

            operationClaimRepository.Update(existingOperationClaim);
            await unitOfWork.SaveChangesAsync();

            return ServiceResult.Success(HttpStatusCode.NoContent);
        }
    }
}
