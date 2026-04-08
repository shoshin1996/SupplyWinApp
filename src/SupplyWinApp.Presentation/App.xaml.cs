using System.IO;
using Microsoft.Extensions.DependencyInjection;
using SupplyWinApp.Infrastructure;
using SupplyWinApp.Presentation.ViewModels;

namespace SupplyWinApp.Presentation;

public partial class App : System.Windows.Application
{
    private ServiceProvider? _serviceProvider;
    private ShellViewModel _shell = null!;

    protected override void OnStartup(System.Windows.StartupEventArgs e)
    {
        base.OnStartup(e);

        var services = new ServiceCollection();

        var usersJsonPath = Path.Combine(AppContext.BaseDirectory, "Data", "users.json");
        services.AddInfrastructure(usersJsonPath);
        services.AddSingleton<ShellViewModel>();
        services.AddTransient<LoginViewModel>();

        _serviceProvider = services.BuildServiceProvider();

        _shell = _serviceProvider.GetRequiredService<ShellViewModel>();

        NavigateToLogin();

        var mainWindow = new MainWindow { DataContext = _shell };
        mainWindow.Show();
    }

    private void NavigateToLogin()
    {
        var loginVm = _serviceProvider!.GetRequiredService<LoginViewModel>();

        loginVm.LoginSucceeded += result =>
        {
            NavigateToMainMenu(result.DisplayName!, result.Role!);
        };

        _shell.NavigateTo(loginVm);
    }

    private void NavigateToMainMenu(string displayName, string role)
    {
        var menuVm = new MainMenuViewModel(displayName, role);

        menuVm.MenuItemSelected += title =>
        {
            NavigateToPlaceholder(title, menuVm);
        };

        menuVm.LogoutRequested += () =>
        {
            NavigateToLogin();
        };

        _shell.NavigateTo(menuVm);
    }

    private void NavigateToPlaceholder(string title, MainMenuViewModel menuVm)
    {
        var placeholderVm = new PlaceholderViewModel(title);

        placeholderVm.BackRequested += () =>
        {
            _shell.NavigateTo(menuVm);
        };

        _shell.NavigateTo(placeholderVm);
    }

    protected override void OnExit(System.Windows.ExitEventArgs e)
    {
        _serviceProvider?.Dispose();
        base.OnExit(e);
    }
}
