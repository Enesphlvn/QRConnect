﻿using App.API.Filters;
using App.Application.Features.Districts;
using App.Application.Features.Districts.Create;
using App.Application.Features.Districts.Update;
using App.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace App.API.Controllers
{
    public class DistrictsController(IDistrictService districtService) : CustomBaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetDistricts()
        {
            return CreateActionResult(await districtService.GetAllListAsync());
        }

        [HttpGet("{pageNumber:int}/{pageSize:int}")]
        public async Task<IActionResult> GetPagedDistricts(int pageNumber, int pageSize)
        {
            return CreateActionResult(await districtService.GetPagedAllListAsync(pageNumber, pageSize));
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetDistrict(int id)
        {
            return CreateActionResult(await districtService.GetByIdAsync(id));
        }

        [HttpGet("bycity/{cityId:int}")]
        public async Task<IActionResult> GetDistrictsByCity(int cityId)
        {
            return CreateActionResult(await districtService.GetDistrictsByCityAsync(cityId));
        }

        [HttpGet("{id:int}/venues")]
        public async Task<IActionResult> GetDistrictWithVenues(int id)
        {
            return CreateActionResult(await districtService.GetDistrictWithVenuesAsync(id));
        }

        [HttpGet("venues")]
        public async Task<IActionResult> GetDistrictWithVenues()
        {
            return CreateActionResult(await districtService.GetDistrictWithVenuesAsync());
        }

        [HttpPost]
        public async Task<IActionResult> CreateDistrict(CreateDistrictRequest request)
        {
            return CreateActionResult(await districtService.CreateAsync(request));
        }

        [ServiceFilter(typeof(NotFoundFilter<District, int>))]
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateDistrict(int id, UpdateDistrictRequest request)
        {
            return CreateActionResult(await districtService.UpdateAsync(id, request));
        }

        [ServiceFilter(typeof(NotFoundFilter<District, int>))]
        [HttpPatch("passive/{id:int}")]
        public async Task<IActionResult> Passive(int id)
        {
            return CreateActionResult(await districtService.PassiveAsync(id));
        }

        [ServiceFilter(typeof(NotFoundFilter<District, int>))]
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteDistrict(int id)
        {
            return CreateActionResult(await districtService.DeleteAsync(id));
        }
    }
}
