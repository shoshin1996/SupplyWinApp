using System.Windows.Input;
using SupplyWinApp.Application.DTOs;
using SupplyWinApp.Application.Interfaces;

namespace SupplyWinApp.Presentation.ViewModels;

public class LoginViewModel : ViewModelBase
{
    private readonly IAuthenticationService _authService;
    private string _username = string.Empty;
    private string _password = string.Empty;
    private string? _errorMessage;
    private bool _isLoggingIn;

    public LoginViewModel(IAuthenticationService authService)
    {
        _authService = authService;
        LoginCommand = new RelayCommand(LoginAsync, () => !IsLoggingIn);
    }

    public string Username
    {
        get => _username;
        set => SetProperty(ref _username, value);
    }

    public string Password
    {
        get => _password;
        set => SetProperty(ref _password, value);
    }

    public string? ErrorMessage
    {
        get => _errorMessage;
        set => SetProperty(ref _errorMessage, value);
    }

    public bool IsLoggingIn
    {
        get => _isLoggingIn;
        set => SetProperty(ref _isLoggingIn, value);
    }

    public ICommand LoginCommand { get; }

    public event Action<LoginResult>? LoginSucceeded;

    private async Task LoginAsync()
    {
        ErrorMessage = null;
        IsLoggingIn = true;

        try
        {
            var result = await _authService.LoginAsync(new LoginRequest(Username, Password));

            if (result.Success)
                LoginSucceeded?.Invoke(result);
            else
                ErrorMessage = result.ErrorMessage;
        }
        finally
        {
            IsLoggingIn = false;
        }
    }
}
