﻿using App.Application.Contracts.Persistence;
using App.Application.Features.Passwords;
using App.Application.Features.QRCodes;
using App.Application.Features.Users.Create;
using App.Application.Features.Users.Dto;
using App.Application.Features.Users.Update;
using App.Application.Features.Users.UpdateEmail;
using App.Application.Features.Users.UpdatePassword;
using App.Domain.Entities;
using AutoMapper;
using System.Globalization;
using System.Net;
using System.Text.Json;

namespace App.Application.Features.Users
{
    public class UserService(IUserRepository userRepository, IUnitOfWork unitOfWork, IMapper mapper, IQRCodeService qRCodeService, IPasswordHashingService passwordHashingService) : IUserService
    {
        public async Task<ServiceResult<int>> CreateAsync(CreateUserRequest request)
        {
            var anyUserEmail = await userRepository.AnyAsync(x => x.Email.ToLower() == request.Email.ToLower());

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

        public async Task<ServiceResult<List<UserResponse>>> GetAllListAsync()
        {
            var users = await userRepository.GetAllAsync();

            var usersAsDto = mapper.Map<List<UserResponse>>(users);

            return ServiceResult<List<UserResponse>>.Success(usersAsDto);
        }

        public async Task<ServiceResult<UserResponse>> GetByIdAsync(int id)
        {
            var user = await userRepository.GetByIdAsync(id);

            if (user is null)
            {
                return ServiceResult<UserResponse>.Fail("Müşteri bulunamadı", HttpStatusCode.NotFound);
            }

            var userAsDto = mapper.Map<UserResponse>(user);

            return ServiceResult<UserResponse>.Success(userAsDto);
        }

        public async Task<ServiceResult<List<UserResponse>>> GetPagedAllListAsync(int pageNumber, int pageSize)
        {
            if (pageNumber <= 0 || pageSize <= 0)
            {
                return ServiceResult<List<UserResponse>>.Fail("Geçersiz sayı", HttpStatusCode.BadRequest);
            }

            var users = await userRepository.GetAllPagedAsync(pageNumber, pageSize);

            var usersAsDto = mapper.Map<List<UserResponse>>(users);

            return ServiceResult<List<UserResponse>>.Success(usersAsDto);
        }

        public async Task<ServiceResult<UserResponse>> GetUserByEmailAsync(string email)
        {
            var user = await userRepository.GetUserByEmailAsync(email);

            if (user is null)
            {
                return ServiceResult<UserResponse>.Fail("User bulunamadı", HttpStatusCode.NotFound);
            }

            var userAsDto = mapper.Map<UserResponse>(user);

            return ServiceResult<UserResponse>.Success(userAsDto);
        }

        public async Task<ServiceResult<List<UserWithTicketsResponse>>> GetUsersWithTicketsAsync()
        {
            var users = await userRepository.GetUsersWithTicketsAsync();

            var userAsDto = mapper.Map<List<UserWithTicketsResponse>>(users);

            return ServiceResult<List<UserWithTicketsResponse>>.Success(userAsDto);
        }

        public async Task<ServiceResult<UserWithTicketsResponse>> GetUserWithTicketsAsync(int userId)
        {
            var user = await userRepository.GetUserWithTicketsAsync(userId);

            if (user is null)
            {
                return ServiceResult<UserWithTicketsResponse>.Fail("User bulunamadı", HttpStatusCode.NotFound);
            }

            var userAsDto = mapper.Map<UserWithTicketsResponse>(user);

            return ServiceResult<UserWithTicketsResponse>.Success(userAsDto);
        }

        public async Task<ServiceResult> PassiveAsync(int id)
        {
            await userRepository.PassiveAsync(id);

            return ServiceResult.Success(HttpStatusCode.NoContent);
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

        public async Task<ServiceResult> UpdatePasswordAsync(int id, UpdatePasswordUserRequest request)
        {
            var user = await userRepository.GetByIdAsync(id);

            if (!passwordHashingService.VerifyPasswordHash(request.OldPassword, user!.PasswordHash, user.PasswordSalt))
            {
                return ServiceResult.Fail("Eski şifre hatalı", HttpStatusCode.BadRequest);
            };

            if (request.OldPassword == request.NewPassword)
            {
                return ServiceResult.Fail("Yeni şifre eskisinden farklı olmalı", HttpStatusCode.BadRequest);
            }

            mapper.Map(request, user);

            passwordHashingService.GeneratePasswordhash(request.NewPassword, out byte[] passwordHash, out byte[] passwordSalt);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            userRepository.Update(user);
            await unitOfWork.SaveChangesAsync();

            return ServiceResult.Success(HttpStatusCode.NoContent);
        }
    }
}
