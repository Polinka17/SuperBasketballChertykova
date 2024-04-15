using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using MsBox.Avalonia;
using MsBox.Avalonia.Enums;

namespace SuperVolleyballChertykova;

public partial class LoginWindow : Window
{
    public LoginWindow()
    {
        InitializeComponent();
        RoleCBox.Items.Add("Администратор"); 
        RoleCBox.Items.Add("Менеджер");
    }

    private void AuthBtn_OnClick(object? sender, RoutedEventArgs e)
    {
        if (RoleCBox.SelectedItem != null)
        {
            if (RoleCBox.SelectedItem == "Администратор")
            {
                MainWindow mainAdminWindow = new MainWindow();
                mainAdminWindow.Show();
                this.Close();
            }
            else
            {
                MainWindow mainManagerWindow = new MainWindow();
                mainManagerWindow.Show();
                this.Close();
            }
        }
        else
        {
            var error = MessageBoxManager.GetMessageBoxStandard("Ошибка", "Выберите роль для входа", ButtonEnum.Ok);
            var result = error.ShowAsync();
        }
    }
}