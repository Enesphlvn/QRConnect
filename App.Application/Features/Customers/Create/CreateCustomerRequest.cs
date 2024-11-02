namespace App.Application.Features.Customers.Create;

public record CreateCustomerRequest(string FirstName, string LastName, string Email, string Password);
