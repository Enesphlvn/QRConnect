using App.Application.Contracts.Persistence;
using App.Application.Features.Cities.Create;
using App.Application.Features.Cities.Dto;
using App.Application.Features.Cities.Update;
using App.Domain.Entities;
using AutoMapper;
using System.Net;

namespace App.Application.Features.Cities
{
    public class CityService(ICityRepository cityRepository, IUnitOfWork unitOfWork, IMapper mapper) : ICityService
    {
        public async Task<ServiceResult<int>> CreateAsync(CreateCityRequest request)
        {
            var ss = request.Name;

            var isSameCity = await cityRepository.AnyAsync(x => x.Name.ToLower() == request.Name.ToLower());

            if (isSameCity)
            {
                return ServiceResult<int>.Fail("Aynı isimde başka bir şehir mevcut.", HttpStatusCode.BadRequest);
            }

            var newCity = mapper.Map<City>(request);

            await cityRepository.AddAsync(newCity);
            await unitOfWork.SaveChangesAsync();

            return ServiceResult<int>.SuccessAsCreated(newCity.Id, $"api/cities/{newCity.Id}");
        }

        public async Task<ServiceResult> DeleteAsync(int id)
        {
            var city = await cityRepository.GetByIdAsync(id);

            cityRepository.Delete(city!);
            await unitOfWork.SaveChangesAsync();

            return ServiceResult.Success(HttpStatusCode.NoContent);
        }

        public async Task<ServiceResult<List<CityResponse>>> GetAllListAsync()
        {
            var cities = await cityRepository.GetAllAsync();

            var citiesAsDto = mapper.Map<List<CityResponse>>(cities);

            return ServiceResult<List<CityResponse>>.Success(citiesAsDto);
        }

        public async Task<ServiceResult<CityResponse>> GetByIdAsync(int id)
        {
            var city = await cityRepository.GetByIdAsync(id);

            if (city is null)
            {
                return ServiceResult<CityResponse>.Fail("City bulunamadı", HttpStatusCode.NotFound);
            }

            var cityAsDto = mapper.Map<CityResponse>(city);

            return ServiceResult<CityResponse>.Success(cityAsDto);
        }

        public async Task<ServiceResult<CityWithDistrictsAndVenuesResponse>> GetCityWithDistrictsAndVenuesAsync(int id)
        {
            var city = await cityRepository.GetCityWithDistrictsAndVenuesAsync(id);

            if (city is null)
            {
                return ServiceResult<CityWithDistrictsAndVenuesResponse>.Fail("Şehir bulunamadı", HttpStatusCode.NotFound);
            }

            var cityAsDto = mapper.Map<CityWithDistrictsAndVenuesResponse>(city);

            return ServiceResult<CityWithDistrictsAndVenuesResponse>.Success(cityAsDto);
        }

        public async Task<ServiceResult<CityWithDistrictsResponse>> GetCityWithDistrictsAsync(int cityId)
        {
            var city = await cityRepository.GetCityWithDistrictsAsync(cityId);

            if (city is null)
            {
                return ServiceResult<CityWithDistrictsResponse>.Fail("Şehir bulunamadı", HttpStatusCode.NotFound);
            }

            var cityAsDto = mapper.Map<CityWithDistrictsResponse>(city);

            return ServiceResult<CityWithDistrictsResponse>.Success(cityAsDto);
        }

        public async Task<ServiceResult<List<CityWithDistrictsResponse>>> GetCityWithDistrictsAsync()
        {
            var city = await cityRepository.GetCityWithDistrictsAsync();

            var cityAsDto = mapper.Map<List<CityWithDistrictsResponse>>(city);

            return ServiceResult<List<CityWithDistrictsResponse>>.Success(cityAsDto);
        }

        public async Task<ServiceResult<CityWithVenuesResponse>> GetCityWithVenuesAsync(int cityId)
        {
            var city = await cityRepository.GetCityWithVenuesAsync(cityId);

            if (city is null)
            {
                return ServiceResult<CityWithVenuesResponse>.Fail("Şehir bulunamadı", HttpStatusCode.NotFound);
            }

            var cityAsDto = mapper.Map<CityWithVenuesResponse>(city);

            return ServiceResult<CityWithVenuesResponse>.Success(cityAsDto);
        }

        public async Task<ServiceResult<List<CityWithVenuesResponse>>> GetCityWithVenuesAsync()
        {
            var city = await cityRepository.GetCityWithVenuesAsync();

            var cityAsDto = mapper.Map<List<CityWithVenuesResponse>>(city);

            return ServiceResult<List<CityWithVenuesResponse>>.Success(cityAsDto);
        }

        public async Task<ServiceResult<List<CityResponse>>> GetPagedAllListAsync(int pageNumber, int pageSize)
        {
            if (pageNumber <= 0 || pageSize <= 0)
            {
                return ServiceResult<List<CityResponse>>.Fail("Geçersiz sayı", HttpStatusCode.BadRequest);
            }

            var cities = await cityRepository.GetAllPagedAsync(pageNumber, pageSize);

            var citiesAsDto = mapper.Map<List<CityResponse>>(cities);

            return ServiceResult<List<CityResponse>>.Success(citiesAsDto);
        }

        public async Task<ServiceResult> PassiveAsync(int id)
        {
            await cityRepository.PassiveAsync(id);

            return ServiceResult.Success(HttpStatusCode.NoContent);
        }

        public async Task<ServiceResult> UpdateAsync(int id, UpdateCityRequest request)
        {
            var isDuplicateCity = await cityRepository.AnyAsync(x => x.Name.ToLower() == request.Name.ToLower() && x.Id != id);

            if (isDuplicateCity)
            {
                return ServiceResult.Fail("Aynı isimde başka bir şehir mevcut.", HttpStatusCode.BadRequest);
            }

            var existingCity = await cityRepository.GetByIdAsync(id);

            if (existingCity is null)
            {
                return ServiceResult.Fail("Şehir bulunamadı.", HttpStatusCode.NotFound);
            }

            mapper.Map(request, existingCity);

            cityRepository.Update(existingCity);
            await unitOfWork.SaveChangesAsync();

            return ServiceResult.Success(HttpStatusCode.NoContent);
        }
    }
}
