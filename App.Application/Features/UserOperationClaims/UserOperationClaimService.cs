using App.Application.Contracts.Persistence;
using App.Application.Features.UserOperationClaims.Create;
using App.Application.Features.UserOperationClaims.Dto;
using App.Application.Features.UserOperationClaims.Update;
using App.Domain.Entities;
using AutoMapper;
using System.Net;

namespace App.Application.Features.UserOperationClaims
{
    public class UserOperationClaimService(IUserOperationClaimRepository userOperationClaimRepository, IUserRepository userRepository, IOperationClaimRepository operationClaimRepository, IUnitOfWork unitOfWork, IMapper mapper) : IUserOperationClaimService
    {
        public async Task<ServiceResult<int>> CreateAsync(CreateUserOperationClaimRequest request)
        {
            var userEntityExists = await userRepository.GetByIdAsync(request.UserId);
            var operationClaimEntityExists = await operationClaimRepository.GetByIdAsync(request.OperationClaimId);

            if (userEntityExists is null || operationClaimEntityExists is null)
            {
                return ServiceResult<int>.Fail("Kullanıcı veya rol bulunamadı", HttpStatusCode.NotFound);
            }

            var newUserOperationClaim = mapper.Map<UserOperationClaim>(request);

            await userOperationClaimRepository.AddAsync(newUserOperationClaim);
            await unitOfWork.SaveChangesAsync();

            return ServiceResult<int>.SuccessAsCreated(newUserOperationClaim.Id, $"api/useroperationclaims/{newUserOperationClaim.Id}");
        }

        public async Task<ServiceResult> DeleteAsync(int id)
        {
            var userOperationClaim = await userOperationClaimRepository.GetByIdAsync(id);

            userOperationClaimRepository.Delete(userOperationClaim!);
            await unitOfWork.SaveChangesAsync();

            return ServiceResult.Success(HttpStatusCode.NoContent);
        }

        public async Task<ServiceResult<List<UserOperationClaimDto>>> GetAllListAsync()
        {
            var userOperationClaims = await userOperationClaimRepository.GetAllAsync();

            var userOperationClaimsAsDto = mapper.Map<List<UserOperationClaimDto>>(userOperationClaims);

            return ServiceResult<List<UserOperationClaimDto>>.Success(userOperationClaimsAsDto);
        }

        public async Task<ServiceResult<UserOperationClaimDto>> GetByIdAsync(int id)
        {
            var userOperationClaim = await userOperationClaimRepository.GetByIdAsync(id);

            if (userOperationClaim is null)
            {
                return ServiceResult<UserOperationClaimDto>.Fail("UserOperationClaim bulunamadı", HttpStatusCode.NotFound);
            }

            var userOperationClaimAsDto = mapper.Map<UserOperationClaimDto>(userOperationClaim);

            return ServiceResult<UserOperationClaimDto>.Success(userOperationClaimAsDto);
        }

        public async Task<ServiceResult<List<UserOperationClaimDto>>> GetPagedAllListAsync(int pageNumber, int pageSize)
        {
            if (pageNumber <= 0 || pageSize <= 0)
            {
                return ServiceResult<List<UserOperationClaimDto>>.Fail("Geçersiz sayı", HttpStatusCode.BadRequest);
            }

            var userOperationClaims = await userOperationClaimRepository.GetAllPagedAsync(pageNumber, pageSize);

            var userOperationClaimsAsDto = mapper.Map<List<UserOperationClaimDto>>(userOperationClaims);

            return ServiceResult<List<UserOperationClaimDto>>.Success(userOperationClaimsAsDto);
        }

        public async Task<ServiceResult> PassiveAsync(int id)
        {
            await userOperationClaimRepository.PassiveAsync(id);

            return ServiceResult.Success(HttpStatusCode.NoContent);
        }

        public async Task<ServiceResult> UpdateAsync(int id, UpdateUserOperationClaimRequest request)
        {
            var userOperationClaim = await userOperationClaimRepository.GetByIdAsync(id);

            var userEntityExists = await userRepository.GetByIdAsync(request.UserId);
            var operationClaimEntityExists = await operationClaimRepository.GetByIdAsync(request.OperationClaimId);


            if (userEntityExists == null || operationClaimEntityExists == null)
            {
                return ServiceResult.Fail("Kullanıcı veya rol bulunamadı", HttpStatusCode.NotFound);
            }

            mapper.Map(request, userOperationClaim);

            userOperationClaimRepository.Update(userOperationClaim!);
            await unitOfWork.SaveChangesAsync();

            return ServiceResult.Success(HttpStatusCode.NoContent);
        }
    }
}
