﻿using App.API.Filters;
using App.Application.Features.Cities;
using App.Application.Features.Cities.Create;
using App.Application.Features.Cities.Update;
using App.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace App.API.Controllers
{
    public class CitiesController(ICityService cityService) : CustomBaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetCities()
        {
            return CreateActionResult(await cityService.GetAllListAsync());
        }

        [HttpGet("{pageNumber:int}/{pageSize:int}")]
        public async Task<IActionResult> GetPagedCities(int pageNumber, int pageSize)
        {
            return CreateActionResult(await cityService.GetPagedAllListAsync(pageNumber, pageSize));
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetCity(int id)
        {
            return CreateActionResult(await cityService.GetByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> CreateCity(CreateCityRequest request)
        {
            return CreateActionResult(await cityService.CreateAsync(request));
        }

        [ServiceFilter(typeof(NotFoundFilter<City, int>))]
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateCity(int id, UpdateCityRequest request)
        {
            return CreateActionResult(await cityService.UpdateAsync(id, request));
        }

        [ServiceFilter(typeof(NotFoundFilter<City, int>))]
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteCity(int id)
        {
            return CreateActionResult(await cityService.DeleteAsync(id));
        }
    }
}