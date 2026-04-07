using SupplyWinApp.Application.DTOs;

namespace SupplyWinApp.Application.Interfaces;

public interface IAuthenticationService
{
    Task<LoginResult> LoginAsync(LoginRequest request);
}
