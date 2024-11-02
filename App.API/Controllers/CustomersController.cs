using App.Application.Features.Customers;
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
    }
}
