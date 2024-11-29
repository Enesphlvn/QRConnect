using App.API.Filters;
using App.Application.Features.UserOperationClaims;
using App.Application.Features.UserOperationClaims.Create;
using App.Application.Features.UserOperationClaims.Update;
using App.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace App.API.Controllers
{
    public class UserOperationClaimsController(IUserOperationClaimService userOperationClaimService) : CustomBaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetUserOperationClaims()
        {
            return CreateActionResult(await userOperationClaimService.GetAllListAsync());
        }

        [HttpGet("{pageNumber:int}/{pageSize:int}")]
        public async Task<IActionResult> GetPagedUserOperationClaims(int pageNumber, int pageSize)
        {
            return CreateActionResult(await userOperationClaimService.GetPagedAllListAsync(pageNumber, pageSize));
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetUserOperationClaim(int id)
        {
            return CreateActionResult(await userOperationClaimService.GetByIdAsync(id));
        }

        [HttpGet("detail")]
        public async Task<IActionResult> GetUserOperationClaimWithDetail()
        {
            return CreateActionResult(await userOperationClaimService.GetUserOperationClaimWithDetailAsync());
        }

        [HttpPost]
        public async Task<IActionResult> CreateUserOperationClaim(CreateUserOperationClaimRequest request)
        {
            return CreateActionResult(await userOperationClaimService.CreateAsync(request));
        }

        [ServiceFilter(typeof(NotFoundFilter<City, int>))]
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateCity(int id, UpdateUserOperationClaimRequest request)
        {
            return CreateActionResult(await userOperationClaimService.UpdateAsync(id, request));
        }

        [ServiceFilter(typeof(NotFoundFilter<UserOperationClaim, int>))]
        [HttpPatch("passive/{id:int}")]
        public async Task<IActionResult> Passive(int id)
        {
            return CreateActionResult(await userOperationClaimService.PassiveAsync(id));
        }

        [ServiceFilter(typeof(NotFoundFilter<UserOperationClaim, int>))]
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteUserOperationClaim(int id)
        {
            return CreateActionResult(await userOperationClaimService.DeleteAsync(id));
        }
    }
}
