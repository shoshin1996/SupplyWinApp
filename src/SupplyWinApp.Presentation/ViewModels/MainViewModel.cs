namespace SupplyWinApp.Presentation.ViewModels;

public class MainViewModel : ViewModelBase
{
    public string WelcomeMessage { get; }

    public MainViewModel(string displayName, string role)
    {
        WelcomeMessage = $"Welcome, {displayName} ({role})";
    }
}
