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
    public string MachineName { get; }
    public ObservableCollection<MenuItemViewModel> MenuItems { get; }

    public event Action<string>? MenuItemSelected;
    public event Action? LogoutRequested;
    public event Action? SelectMachineRequested;

    public ICommand LogoutCommand { get; }
    public ICommand SelectMachineCommand { get; }

    public MainMenuViewModel(string displayName, string role, string machineName)
    {
        DisplayName = displayName;
        Role = role;
        MachineName = machineName;

        LogoutCommand = new RelayCommand(() =>
        {
            LogoutRequested?.Invoke();
            return Task.CompletedTask;
        });

        SelectMachineCommand = new RelayCommand(() =>
        {
            SelectMachineRequested?.Invoke();
            return Task.CompletedTask;
        });

        MenuItems = new ObservableCollection<MenuItemViewModel>
        {
            CreateMenuItem("TAKE", "/Assets/Icons/mdi_take.png"),
            CreateMenuItem("RECLAIM", "/Assets/Icons/mdi_reclaim.png"),
            CreateMenuItem("RETURN", "/Assets/Icons/mdi_return.png"),
            CreateMenuItem("INVENTORY CHECK", "/Assets/Icons/mdi_inventory_check.png"),
            CreateMenuItem("STOCK", "/Assets/Icons/mdi_stock.png"),
            CreateMenuItem("ADHOC ORDER", "/Assets/Icons/mdi_adhoc_order.png"),
        };
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
