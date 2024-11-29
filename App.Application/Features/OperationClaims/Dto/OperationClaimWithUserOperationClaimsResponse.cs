using App.Application.Features.UserOperationClaims.Dto;

namespace App.Application.Features.OperationClaims.Dto;

public record OperationClaimWithUserOperationClaimsResponse(int Id, string Name, List<UserOperationClaimWithDetailResponse> UserOperationClaims);