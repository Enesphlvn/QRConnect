using App.Application.Contracts.Persistence;
using App.Application.Features.Cities.Dto;
using App.Application.Features.Venues.Create;
using App.Application.Features.Venues.Dto;
using App.Application.Features.Venues.Update;
using App.Domain.Entities;
using AutoMapper;
using System.Net;

namespace App.Application.Features.Venues
{
    public class VenueService(IVenueRepository venueRepository, IUnitOfWork unitOfWork, IMapper mapper) : IVenueService
    {
        public async Task<ServiceResult<int>> CreateAsync(CreateVenueRequest request)
        {
            var isSameVenue = await venueRepository.AnyAsync(x => x.Name.ToLower() == request.Name.ToLower());

            if (isSameVenue)
            {
                return ServiceResult<int>.Fail("Aynı isimde başka bir mekan mevcut.", HttpStatusCode.BadRequest);
            }

            var newVenue = mapper.Map<Venue>(request);

            await venueRepository.AddAsync(newVenue);
            await unitOfWork.SaveChangesAsync();

            return ServiceResult<int>.SuccessAsCreated(newVenue.Id, $"api/venues/{newVenue.Id}");
        }

        public async Task<ServiceResult> DeleteAsync(int id)
        {
            var venue = await venueRepository.GetByIdAsync(id);

            venueRepository.Delete(venue!);
            await unitOfWork.SaveChangesAsync();

            return ServiceResult.Success(HttpStatusCode.NoContent);
        }

        public async Task<ServiceResult<List<VenueDto>>> GetAllListAsync()
        {
            var venues = await venueRepository.GetAllAsync();

            var venuesAsDto = mapper.Map<List<VenueDto>>(venues);

            return ServiceResult<List<VenueDto>>.Success(venuesAsDto);
        }

        public async Task<ServiceResult<VenueDto>> GetByIdAsync(int id)
        {
            var venue = await venueRepository.GetByIdAsync(id);

            if (venue is null)
            {
                return ServiceResult<VenueDto>.Fail("Venue bulunamadı", HttpStatusCode.NotFound);
            }

            var venueAsDto = mapper.Map<VenueDto>(venue);

            return ServiceResult<VenueDto>.Success(venueAsDto);
        }

        public async Task<ServiceResult<List<VenueDto>>> GetPagedAllListAsync(int pageNumber, int pageSize)
        {
            if (pageNumber <= 0 || pageSize <= 0)
            {
                return ServiceResult<List<VenueDto>>.Fail("Geçersiz sayı", HttpStatusCode.BadRequest);
            }

            var venues = await venueRepository.GetAllPagedAsync(pageNumber, pageSize);

            var venuesAsDto = mapper.Map<List<VenueDto>>(venues);

            return ServiceResult<List<VenueDto>>.Success(venuesAsDto);
        }

        public async Task<ServiceResult> PassiveAsync(int id)
        {
            await venueRepository.PassiveAsync(id);

            return ServiceResult.Success(HttpStatusCode.NoContent);
        }

        public async Task<ServiceResult> UpdateAsync(int id, UpdateVenueRequest request)
        {
            var isDuplicateVenue = await venueRepository.AnyAsync(x => x.Name.ToLower() == request.Name.ToLower() && x.Id != id);

            if (isDuplicateVenue)
            {
                return ServiceResult.Fail("Aynı isimde başka bir mekan mevcut.", HttpStatusCode.BadRequest);
            }

            var existingVenue = await venueRepository.GetByIdAsync(id);

            if (existingVenue is null)
            {
                return ServiceResult.Fail("Mekan bulunamadı.", HttpStatusCode.NotFound);
            }

            mapper.Map(request, existingVenue);

            venueRepository.Update(existingVenue);
            await unitOfWork.SaveChangesAsync();

            return ServiceResult.Success(HttpStatusCode.NoContent);
        }
    }
}
