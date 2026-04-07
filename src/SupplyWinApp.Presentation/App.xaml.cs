using System.IO;
using Microsoft.Extensions.DependencyInjection;
using SupplyWinApp.Infrastructure;
using SupplyWinApp.Presentation.ViewModels;

namespace SupplyWinApp.Presentation;

public partial class App : System.Windows.Application
{
    private ServiceProvider? _serviceProvider;

    protected override void OnStartup(System.Windows.StartupEventArgs e)
    {
        base.OnStartup(e);

        var services = new ServiceCollection();

        var usersJsonPath = Path.Combine(AppContext.BaseDirectory, "Data", "users.json");
        services.AddInfrastructure(usersJsonPath);
        services.AddSingleton<ShellViewModel>();
        services.AddTransient<LoginViewModel>();

        _serviceProvider = services.BuildServiceProvider();

        var shell = _serviceProvider.GetRequiredService<ShellViewModel>();
        var loginVm = _serviceProvider.GetRequiredService<LoginViewModel>();

        loginVm.LoginSucceeded += result =>
        {
            shell.NavigateTo(new MainViewModel(result.DisplayName!, result.Role!));
        };

        shell.NavigateTo(loginVm);

        var mainWindow = new MainWindow { DataContext = shell };
        mainWindow.Show();
    }

    protected override void OnExit(System.Windows.ExitEventArgs e)
    {
        _serviceProvider?.Dispose();
        base.OnExit(e);
    }
}
