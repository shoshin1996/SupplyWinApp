using System.Collections.ObjectModel;
using System.Windows.Input;

namespace SupplyWinApp.Presentation.ViewModels;

public class MenuItemViewModel
{
    public string Title { get; init; } = string.Empty;
    public string Icon { get; init; } = string.Empty;
    public ICommand NavigateCommand { get; init; } = null!;
}

public class MainMenuViewModel : ViewModelBase
{
    public string DisplayName { get; }
    public string Role { get; }
    public string WelcomeMessage { get; }
    public ObservableCollection<MenuItemViewModel> MenuItems { get; }

    public event Action<string>? MenuItemSelected;
    public event Action? LogoutRequested;

    public ICommand LogoutCommand { get; }

    public MainMenuViewModel(string displayName, string role)
    {
        DisplayName = displayName;
        Role = role;
        WelcomeMessage = $"Welcome, {displayName}";

        LogoutCommand = new RelayCommand(() =>
        {
            LogoutRequested?.Invoke();
            return Task.CompletedTask;
        });

        var items = new List<MenuItemViewModel>
        {
            CreateMenuItem("Take", "\u2B07"),
            CreateMenuItem("Return", "\u2B06"),
            CreateMenuItem("Inventory", "\uD83D\uDCE6"),
        };

        if (string.Equals(role, "Admin", StringComparison.OrdinalIgnoreCase))
        {
            items.Add(CreateMenuItem("Load", "\uD83D\uDCE5"));
            items.Add(CreateMenuItem("Unload", "\uD83D\uDCE4"));
        }

        items.Add(CreateMenuItem("Settings", "\u2699"));

        MenuItems = new ObservableCollection<MenuItemViewModel>(items);
    }

    private MenuItemViewModel CreateMenuItem(string title, string icon)
    {
        return new MenuItemViewModel
        {
            Title = title,
            Icon = icon,
            NavigateCommand = new RelayCommand(() =>
            {
                MenuItemSelected?.Invoke(title);
                return Task.CompletedTask;
            })
        };
    }
}
