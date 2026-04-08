using System.Windows.Input;

namespace SupplyWinApp.Presentation.ViewModels;

public class PlaceholderViewModel : ViewModelBase
{
    public string Title { get; }
    public string Message { get; }
    public ICommand BackCommand { get; }

    public event Action? BackRequested;

    public PlaceholderViewModel(string title)
    {
        Title = title;
        Message = $"{title} screen coming soon.";
        BackCommand = new RelayCommand(() =>
        {
            BackRequested?.Invoke();
            return Task.CompletedTask;
        });
    }
}
