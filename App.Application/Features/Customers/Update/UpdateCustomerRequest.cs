﻿namespace App.Application.Features.Customers.Update;

public record UpdateCustomerRequest(string FirstName, string LastName, string Email, string Password);