using System.Windows;
using System.Windows.Controls;
using SupplyWinApp.Presentation.ViewModels;

namespace SupplyWinApp.Presentation.Views;

public partial class LoginView : UserControl
{
    public LoginView()
    {
        InitializeComponent();
    }

    private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
    {
        if (DataContext is LoginViewModel vm)
            vm.Password = PasswordBox.Password;

        PasswordBox.Tag = PasswordBox.Password.Length > 0 ? "HasContent" : null;
    }
}
