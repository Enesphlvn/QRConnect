namespace App.Application.Features.Users.Create;

public record CreateUserRequest(string FirstName, string LastName, string Email, string Password);
