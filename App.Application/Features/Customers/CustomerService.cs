using App.Application.Contracts.Persistence;
using App.Application.Features.Customers.Create;
using App.Application.Features.Customers.Dto;
using App.Application.Features.Customers.Update;
using App.Application.Features.Customers.UpdateEmail;
using App.Domain.Entities;
using AutoMapper;
using System.Net;

namespace App.Application.Features.Customers
{
    public class CustomerService(ICustomerRepository customerRepository, IUnitOfWork unitOfWork, IMapper mapper) : ICustomerService
    {
        public async Task<ServiceResult<int>> CreateAsync(CreateCustomerRequest request)
        {
            var anyCustomerEmail = await customerRepository.AnyAsync(x => x.Email == request.Email);

            if (anyCustomerEmail)
            {
                return ServiceResult<int>.Fail("Müşteri email veritabanında bulunmaktadır", HttpStatusCode.NotFound);
            }

            var newCustomer = mapper.Map<Customer>(request);

            await customerRepository.AddAsync(newCustomer);
            await unitOfWork.SaveChangesAsync();

            return ServiceResult<int>.SuccessAsCreated(newCustomer.Id, $"api/customers/{newCustomer.Id}");
        }

        public async Task<ServiceResult> DeleteAsync(int id)
        {
            var customer = await customerRepository.GetByIdAsync(id);

            customerRepository.Delete(customer!);
            await unitOfWork.SaveChangesAsync();

            return ServiceResult.Success(HttpStatusCode.NoContent);
        }

        public async Task<ServiceResult<List<CustomerDto>>> GetAllListAsync()
        {
            var customers = await customerRepository.GetAllAsync();

            var customersAsDto = mapper.Map<List<CustomerDto>>(customers);

            return ServiceResult<List<CustomerDto>>.Success(customersAsDto);
        }

        public async Task<ServiceResult<CustomerDto>> GetByIdAsync(int id)
        {
            var customer = await customerRepository.GetByIdAsync(id);

            if (customer is null)
            {
                return ServiceResult<CustomerDto>.Fail("Müşteri bulunamadı", HttpStatusCode.NotFound);
            }

            var customerAsDto = mapper.Map<CustomerDto>(customer);

            return ServiceResult<CustomerDto>.Success(customerAsDto);
        }

        public async Task<ServiceResult<List<CustomerDto>>> GetPagedAllListAsync(int pageNumber, int pageSize)
        {
            if (pageNumber <= 0 || pageSize <= 0)
            {
                return ServiceResult<List<CustomerDto>>.Fail("Geçersiz sayı", HttpStatusCode.BadRequest);
            }

            var customers = await customerRepository.GetAllPagedAsync(pageNumber, pageSize);

            var customersAsDto = mapper.Map<List<CustomerDto>>(customers);

            return ServiceResult<List<CustomerDto>>.Success(customersAsDto);
        }

        public async Task<ServiceResult> UpdateAsync(int id, UpdateCustomerRequest request)
        {
            var customer = await customerRepository.GetByIdAsync(id);

            mapper.Map(request, customer);

            customerRepository.Update(customer!);
            await unitOfWork.SaveChangesAsync();

            return ServiceResult.Success(HttpStatusCode.NoContent);
        }

        public async Task<ServiceResult> UpdateEmailAsync(int id, UpdateEmailCustomerRequest request)
        {
            var customer = await customerRepository.GetByIdAsync(id);

            mapper.Map(request, customer);

            customerRepository.Update(customer!);
            await unitOfWork.SaveChangesAsync();

            return ServiceResult.Success(HttpStatusCode.NoContent);
        }
    }
}
