using App.API.Filters;
using App.Application.Features.Cities.Create;
using App.Application.Features.Cities.Update;
using App.Application.Features.OperationClaims;
using App.Application.Features.OperationClaims.Create;
using App.Application.Features.OperationClaims.Update;
using App.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace App.API.Controllers
{
    public class OperationClaimsController(IOperationClaimService operationClaimService) : CustomBaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetOperationClaims()
        {
            return CreateActionResult(await operationClaimService.GetAllListAsync());
        }

        [HttpGet("{pageNumber:int}/{pageSize:int}")]
        public async Task<IActionResult> GetPagedOperationClaims(int pageNumber, int pageSize)
        {
            return CreateActionResult(await operationClaimService.GetPagedAllListAsync(pageNumber, pageSize));
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetOperationClaim(int id)
        {
            return CreateActionResult(await operationClaimService.GetByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> CreateOperationClaim(CreateOperationClaimRequest request)
        {
            return CreateActionResult(await operationClaimService.CreateAsync(request));
        }

        [ServiceFilter(typeof(NotFoundFilter<OperationClaim, int>))]
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateOperationClaim(int id, UpdateOperationClaimRequest request)
        {
            return CreateActionResult(await operationClaimService.UpdateAsync(id, request));
        }

        [ServiceFilter(typeof(NotFoundFilter<OperationClaim, int>))]
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteOperationClaim(int id)
        {
            return CreateActionResult(await operationClaimService.DeleteAsync(id));
        }
    }
}
