using App.Application.Features.Venues.Create;
using App.Application.Features.Venues.Dto;
using App.Application.Features.Venues.Update;
using App.Domain.Entities;
using AutoMapper;

namespace App.Application.Features.Venues
{
    public class VenueProfileMapping : Profile
    {
        public VenueProfileMapping()
        {
            CreateMap<VenueDto, Venue>().ReverseMap();

            CreateMap<VenueWithDetailDto, Venue>().ReverseMap();

            CreateMap<CreateVenueRequest, Venue>();

            CreateMap<UpdateVenueRequest, Venue>();
        }
    }
}
