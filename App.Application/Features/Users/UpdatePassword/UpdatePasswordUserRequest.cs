namespace App.Application.Features.Users.UpdatePassword;

public record UpdatePasswordUserRequest(string OldPassword, string NewPassword, string ConfirmPassword);