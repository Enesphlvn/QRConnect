using App.Application.Features.Users.Create;
using App.Application.Features.Users.Dto;
using App.Application.Features.Users.Update;
using App.Application.Features.Users.UpdateEmail;
using App.Application.Features.Users.UpdatePassword;

namespace App.Application.Features.Users
{
    public interface IUserService
    {
        Task<ServiceResult<List<UserDto>>> GetAllListAsync();
        Task<ServiceResult<List<UserDto>>> GetPagedAllListAsync(int pageNumber, int pageSize);
        Task<ServiceResult<UserDto>> GetByIdAsync(int id);
        Task<ServiceResult<int>> CreateAsync(CreateUserRequest request);
        Task<ServiceResult> UpdateAsync(int id, UpdateUserRequest request);
        Task<ServiceResult> UpdateEmailAsync(int id, UpdateEmailUserRequest request);
        Task<ServiceResult> UpdatePasswordAsync(int id, UpdatePasswordUserRequest request);
        Task<ServiceResult> DeleteAsync(int id);
        Task<ServiceResult<byte[]>> QrCodeToUserAsync(int userId);
        Task<ServiceResult> PassiveAsync(int id);
    }
}
