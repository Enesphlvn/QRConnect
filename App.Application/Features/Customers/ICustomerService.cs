﻿using App.Application.Features.Customers.Create;
using App.Application.Features.Customers.Dto;
using App.Application.Features.Customers.Update;

namespace App.Application.Features.Customers
{
    public interface ICustomerService
    {
        Task<ServiceResult<List<CustomerDto>>> GetAllListAsync();
        Task<ServiceResult<CustomerDto>> GetByIdAsync(int id);
        Task<ServiceResult<int>> CreateAsync(CreateCustomerRequest request);
        Task<ServiceResult> UpdateAsync(int id, UpdateCustomerRequest request);
        Task<ServiceResult> DeleteAsync(int id);
    }
}
