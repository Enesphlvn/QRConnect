using App.Application.Features.OperationClaims.Dto;
using App.Application.Features.Users.Dto;

namespace App.Application.Features.UserOperationClaims.Dto;

public record UserOperationClaimByOperationClaimResponse(int Id, UserResponse User, OperationClaimResponse OperationClaim);