﻿using App.API.Filters;
using App.Application.Features.Users;
using App.Application.Features.Users.Create;
using App.Application.Features.Users.Update;
using App.Application.Features.Users.UpdateEmail;
using App.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace App.API.Controllers
{
    public class UsersController(IUserService userService) : CustomBaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            return CreateActionResult(await userService.GetAllListAsync());
        }

        [HttpGet("{pageNumber:int}/{pageSize:int}")]
        public async Task<IActionResult> GetPagedUsers(int pageNumber, int pageSize)
        {
            return CreateActionResult(await userService.GetPagedAllListAsync(pageNumber, pageSize));
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetUser(int id)
        {
            return CreateActionResult(await userService.GetByIdAsync(id));
        }

        [HttpGet("qrcode/{userId:int}")]
        public async Task<IActionResult> GetQRCode(int userId)
        {
            var result = await userService.QrCodeToUserAsync(userId);

            if (result.IsSuccess)
            {
                return File(result.Data!, "image/png");
            }

            return CreateActionResult(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(CreateUserRequest request)
        {
            return CreateActionResult(await userService.CreateAsync(request));
        }

        [ServiceFilter(typeof(NotFoundFilter<User, int>))]
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateUser(int id, UpdateUserRequest request)
        {
            return CreateActionResult(await userService.UpdateAsync(id, request));
        }

        [ServiceFilter(typeof(NotFoundFilter<User, int>))]
        [HttpPatch("email/{id:int}")]
        public async Task<IActionResult> UpdateEmail(int id, UpdateEmailUserRequest request)
        {
            return CreateActionResult(await userService.UpdateEmailAsync(id, request));
        }

        [ServiceFilter(typeof(NotFoundFilter<User, int>))]
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            return CreateActionResult(await userService.DeleteAsync(id));
        }
    }
}