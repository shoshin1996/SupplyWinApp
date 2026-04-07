namespace SupplyWinApp.Application.DTOs;

public record LoginResult(bool Success, string? DisplayName = null, string? Role = null, string? ErrorMessage = null);
