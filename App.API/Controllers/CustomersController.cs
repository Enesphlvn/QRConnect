using App.API.Filters;
using App.Application.Features.Customers;
using App.Application.Features.Customers.Create;
using App.Application.Features.Customers.Update;
using App.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace App.API.Controllers
{
    public class CustomersController(ICustomerService customerService) : CustomBaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetCustomers()
        {
            return CreateActionResult(await customerService.GetAllListAsync());
        }

        [HttpGet("{pageNumber:int}/{pageSize:int}")]
        public async Task<IActionResult> GetPagedCustomers(int pageNumber, int pageSize)
        {
            return CreateActionResult(await customerService.GetPagedAllListAsync(pageNumber, pageSize));
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetCustomer(int id)
        {
            return CreateActionResult(await customerService.GetByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> CreateCustomer(CreateCustomerRequest request)
        {
            return CreateActionResult(await customerService.CreateAsync(request));
        }

        [ServiceFilter(typeof(NotFoundFilter<Customer, int>))]
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateCustomer(int id, UpdateCustomerRequest request)
        {
            return CreateActionResult(await customerService.UpdateAsync(id, request));
        }

        [ServiceFilter(typeof(NotFoundFilter<Customer, int>))]
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            return CreateActionResult(await customerService.DeleteAsync(id));
        }
    }
}
