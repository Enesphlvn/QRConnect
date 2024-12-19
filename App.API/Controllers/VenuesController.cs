using App.API.Filters;
using App.Application.Features.Venues;
using App.Application.Features.Venues.Create;
using App.Application.Features.Venues.Update;
using App.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace App.API.Controllers
{
    public class VenuesController(IVenueService venueService) : CustomBaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetVenues()
        {
            return CreateActionResult(await venueService.GetAllListAsync());
        }

        [HttpGet("{pageNumber:int}/{pageSize:int}")]
        public async Task<IActionResult> GetPagedVenues(int pageNumber, int pageSize)
        {
            return CreateActionResult(await venueService.GetPagedAllListAsync(pageNumber, pageSize));
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetVenue(int id)
        {
            return CreateActionResult(await venueService.GetByIdAsync(id));
        }

        [HttpGet("{venueId:int}/events")]
        public async Task<IActionResult> GetVenueWithEvents(int venueId)
        {
            return CreateActionResult(await venueService.GetVenueWithEventsAsync(venueId));
        }

        [HttpGet("events")]
        public async Task<IActionResult> GetVenuesWithEvents()
        {
            return CreateActionResult(await venueService.GetVenuesWithEventsAsync());
        }

        [HttpGet("bycity/{cityId:int}")]
        public async Task<IActionResult> GetVenueByCity(int cityId)
        {
            return CreateActionResult(await venueService.GetVenueByCityAsync(cityId));
        }

        [HttpGet("bydistrict/{districtId:int}")]
        public async Task<IActionResult> GetVenueByDistrict(int districtId)
        {
            return CreateActionResult(await venueService.GetVenueByDistrictAsync(districtId));
        }

        [HttpPost]
        public async Task<IActionResult> CreateVenue(CreateVenueRequest request)
        {
            return CreateActionResult(await venueService.CreateAsync(request));
        }

        [ServiceFilter(typeof(NotFoundFilter<Venue, int>))]
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateVenue(int id, UpdateVenueRequest request)
        {
            return CreateActionResult(await venueService.UpdateAsync(id, request));
        }

        [ServiceFilter(typeof(NotFoundFilter<Venue, int>))]
        [HttpPatch("passive/{id:int}")]
        public async Task<IActionResult> Passive(int id)
        {
            return CreateActionResult(await venueService.PassiveAsync(id));
        }

        [ServiceFilter(typeof(NotFoundFilter<Venue, int>))]
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteVenue(int id)
        {
            return CreateActionResult(await venueService.DeleteAsync(id));
        }
    }
}
