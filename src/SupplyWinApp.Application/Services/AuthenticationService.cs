using SupplyWinApp.Application.DTOs;
using SupplyWinApp.Application.Interfaces;
using SupplyWinApp.Domain.Interfaces;

namespace SupplyWinApp.Application.Services;

public class AuthenticationService : IAuthenticationService
{
    private readonly IUserRepository _userRepository;

    public AuthenticationService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<LoginResult> LoginAsync(LoginRequest request)
    {
        if (string.IsNullOrWhiteSpace(request.Username) || string.IsNullOrWhiteSpace(request.Password))
            return new LoginResult(false, ErrorMessage: "Username and password are required.");

        var user = await _userRepository.GetByCredentialsAsync(request.Username, request.Password);

        if (user is null)
            return new LoginResult(false, ErrorMessage: "Invalid username or password.");

        return new LoginResult(true, user.DisplayName, user.Role);
    }
}
