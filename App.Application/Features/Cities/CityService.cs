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
            var isSameCity = await cityRepository.AnyAsync(x => x.Name == request.Name);

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

        public async Task<ServiceResult<List<CityDto>>> GetAllListAsync()
        {
            var cities = await cityRepository.GetAllAsync();

            var cityAsDto = mapper.Map<List<CityDto>>(cities);

            return ServiceResult<List<CityDto>>.Success(cityAsDto);
        }

        public async Task<ServiceResult<CityDto>> GetByIdAsync(int id)
        {
            var city = await cityRepository.GetByIdAsync(id);

            if (city is null)
            {
                return ServiceResult<CityDto>.Fail("City bulunamadı", HttpStatusCode.NotFound);
            }

            var cityAsDto = mapper.Map<CityDto>(city);

            return ServiceResult<CityDto>.Success(cityAsDto);
        }

        public async Task<ServiceResult<List<CityDto>>> GetPagedAllListAsync(int pageNumber, int pageSize)
        {
            if (pageNumber <= 0 || pageSize <= 0)
            {
                return ServiceResult<List<CityDto>>.Fail("Geçersiz sayı", HttpStatusCode.BadRequest);
            }

            var cities = await cityRepository.GetAllPagedAsync(pageNumber, pageSize);

            var citiesAsDto = mapper.Map<List<CityDto>>(cities);

            return ServiceResult<List<CityDto>>.Success(citiesAsDto);
        }

        public async Task<ServiceResult> PassiveAsync(int id)
        {
            await cityRepository.GetByIdAsync(id);

            await cityRepository.PassiveAsync(id);

            return ServiceResult.Success(HttpStatusCode.NoContent);
        }

        public async Task<ServiceResult> UpdateAsync(int id, UpdateCityRequest request)
        {
            var isDuplicateCity = await cityRepository.AnyAsync(x => x.Name == request.Name && x.Id != id);

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
