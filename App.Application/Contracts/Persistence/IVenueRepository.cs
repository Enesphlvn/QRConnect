﻿using App.Domain.Entities;

namespace App.Application.Contracts.Persistence
{
    public interface IVenueRepository : IGenericRepository<Venue, int>
    {
        Task<List<Venue>> GetVenueByCityAsync(int cityId);
        Task<List<Venue>> GetVenueByDistrictAsync(int districtId);
    }
}
