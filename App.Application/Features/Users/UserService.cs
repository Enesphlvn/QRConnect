using App.Application.Contracts.Persistence;
using App.Application.Features.Passwords;
using App.Application.Features.QRCodes;
using App.Application.Features.Users.Create;
using App.Application.Features.Users.Dto;
using App.Application.Features.Users.Update;
using App.Application.Features.Users.UpdateEmail;
using App.Domain.Entities;
using AutoMapper;
using System.Net;
using System.Text.Json;

namespace App.Application.Features.Users
{
    public class UserService(IUserRepository userRepository, IUnitOfWork unitOfWork, IMapper mapper, IQRCodeService qRCodeService, IPasswordHashingService passwordHashingService) : IUserService
    {
        public async Task<ServiceResult<int>> CreateAsync(CreateUserRequest request)
        {
            var anyUserEmail = await userRepository.AnyAsync(x => x.Email == request.Email);

            if (anyUserEmail)
            {
                return ServiceResult<int>.Fail("Müşteri email veritabanında bulunmaktadır", HttpStatusCode.NotFound);
            }

            passwordHashingService.GeneratePasswordhash(request.Password, out byte[] passwordhash, out byte[] passwordSalt);

            var newUser = mapper.Map<User>(request);
            newUser.PasswordHash = passwordhash;
            newUser.PasswordSalt = passwordSalt;

            await userRepository.AddAsync(newUser);
            await unitOfWork.SaveChangesAsync();

            return ServiceResult<int>.SuccessAsCreated(newUser.Id, $"api/users/{newUser.Id}");
        }

        public async Task<ServiceResult> DeleteAsync(int id)
        {
            var user = await userRepository.GetByIdAsync(id);

            userRepository.Delete(user!);
            await unitOfWork.SaveChangesAsync();

            return ServiceResult.Success(HttpStatusCode.NoContent);
        }

        public async Task<ServiceResult<List<UserDto>>> GetAllListAsync()
        {
            var users = await userRepository.GetAllAsync();

            var usersAsDto = mapper.Map<List<UserDto>>(users);

            return ServiceResult<List<UserDto>>.Success(usersAsDto);
        }

        public async Task<ServiceResult<UserDto>> GetByIdAsync(int id)
        {
            var user = await userRepository.GetByIdAsync(id);

            if (user is null)
            {
                return ServiceResult<UserDto>.Fail("Müşteri bulunamadı", HttpStatusCode.NotFound);
            }

            var userAsDto = mapper.Map<UserDto>(user);

            return ServiceResult<UserDto>.Success(userAsDto);
        }

        public async Task<ServiceResult<List<UserDto>>> GetPagedAllListAsync(int pageNumber, int pageSize)
        {
            if (pageNumber <= 0 || pageSize <= 0)
            {
                return ServiceResult<List<UserDto>>.Fail("Geçersiz sayı", HttpStatusCode.BadRequest);
            }

            var users = await userRepository.GetAllPagedAsync(pageNumber, pageSize);

            var usersAsDto = mapper.Map<List<UserDto>>(users);

            return ServiceResult<List<UserDto>>.Success(usersAsDto);
        }

        public async Task<ServiceResult<byte[]>> QrCodeToUserAsync(int userId)
        {
            var userEntityExists = await userRepository.GetByIdAsync(userId);

            if (userEntityExists is null)
            {
                return ServiceResult<byte[]>.Fail("Kullanıcı bulunamadı", HttpStatusCode.NotFound);
            }

            var plainObject = new
            {
                userEntityExists.Id,
                userEntityExists.FirstName,
                userEntityExists.LastName,
                userEntityExists.Email
            };
            string plainText = JsonSerializer.Serialize(plainObject);

            return ServiceResult<byte[]>.Success(qRCodeService.GenerateQRCode(plainText));
        }

        public async Task<ServiceResult> UpdateAsync(int id, UpdateUserRequest request)
        {
            var user = await userRepository.GetByIdAsync(id);

            mapper.Map(request, user);

            userRepository.Update(user!);
            await unitOfWork.SaveChangesAsync();

            return ServiceResult.Success(HttpStatusCode.NoContent);
        }

        public async Task<ServiceResult> UpdateEmailAsync(int id, UpdateEmailUserRequest request)
        {
            var user = await userRepository.GetByIdAsync(id);

            mapper.Map(request, user);

            userRepository.Update(user!);
            await unitOfWork.SaveChangesAsync();

            return ServiceResult.Success(HttpStatusCode.NoContent);
        }
    }
}
