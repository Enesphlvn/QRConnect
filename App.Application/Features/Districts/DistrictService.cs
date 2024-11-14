using App.Application.Contracts.Persistence;
using App.Application.Features.Districts.Create;
using App.Application.Features.Districts.Dto;
using App.Application.Features.Districts.Update;
using App.Domain.Entities;
using AutoMapper;
using System.Net;

namespace App.Application.Features.Districts
{
    public class DistrictService(IDistrictRepository districtRepository, IUnitOfWork unitOfWork, IMapper mapper) : IDistrictService
    {
        public async Task<ServiceResult<int>> CreateAsync(CreateDistrictRequest request)
        {
            var isSameDistrict = await districtRepository.AnyAsync(x => x.Name == request.Name);

            if (isSameDistrict)
            {
                return ServiceResult<int>.Fail("Aynı isimde başka bir ilçe mevcut.", HttpStatusCode.BadRequest);
            }

            var newDistrict = mapper.Map<District>(request);

            await districtRepository.AddAsync(newDistrict);
            await unitOfWork.SaveChangesAsync();

            return ServiceResult<int>.SuccessAsCreated(newDistrict.Id, $"api/districts/{newDistrict.Id}");
        }

        public async Task<ServiceResult> DeleteAsync(int id)
        {
            var district = await districtRepository.GetByIdAsync(id);

            districtRepository.Delete(district!);
            await unitOfWork.SaveChangesAsync();

            return ServiceResult.Success(HttpStatusCode.NoContent);
        }

        public async Task<ServiceResult<List<DistrictDto>>> GetAllListAsync()
        {
            var districts = await districtRepository.GetAllAsync();

            var districtsAsDto = mapper.Map<List<DistrictDto>>(districts);

            return ServiceResult<List<DistrictDto>>.Success(districtsAsDto);
        }

        public async Task<ServiceResult<DistrictDto>> GetByIdAsync(int id)
        {
            var district = await districtRepository.GetByIdAsync(id);

            if (district is null)
            {
                return ServiceResult<DistrictDto>.Fail("District bulunamadı", HttpStatusCode.NotFound);
            }

            var districtAsDto = mapper.Map<DistrictDto>(district);

            return ServiceResult<DistrictDto>.Success(districtAsDto);
        }

        public async Task<ServiceResult<List<DistrictDto>>> GetPagedAllListAsync(int pageNumber, int pageSize)
        {
            if (pageNumber <= 0 || pageSize <= 0)
            {
                return ServiceResult<List<DistrictDto>>.Fail("Geçersiz sayı", HttpStatusCode.BadRequest);
            }

            var districts = await districtRepository.GetAllPagedAsync(pageNumber, pageSize);

            var districtAsDto = mapper.Map<List<DistrictDto>>(districts);

            return ServiceResult<List<DistrictDto>>.Success(districtAsDto);
        }

        public async Task<ServiceResult> PassiveAsync(int id)
        {
            await districtRepository.GetByIdAsync(id);

            await districtRepository.PassiveAsync(id);

            return ServiceResult.Success(HttpStatusCode.NoContent);
        }

        public async Task<ServiceResult> UpdateAsync(int id, UpdateDistrictRequest request)
        {
            var isDuplicateDistrict = await districtRepository.AnyAsync(x => x.Name == request.Name && x.Id != id);

            if (isDuplicateDistrict)
            {
                return ServiceResult.Fail("Aynı isimde başka bir ilçe mevcut.", HttpStatusCode.BadRequest);
            }

            var existingDistrict = await districtRepository.GetByIdAsync(id);

            if (existingDistrict is null)
            {
                return ServiceResult.Fail("ilçe bulunamadı.", HttpStatusCode.NotFound);
            }

            mapper.Map(request, existingDistrict);

            districtRepository.Update(existingDistrict);
            await unitOfWork.SaveChangesAsync();

            return ServiceResult.Success(HttpStatusCode.NoContent);
        }
    }
}
