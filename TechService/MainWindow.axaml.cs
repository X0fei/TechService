using Avalonia.Controls;
using TechService.Models;

namespace TechService;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void LoginButton_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        foreach (User user in Utils.Context.Users)
        {
            if (Login.Text == user.Login && Password.Text == user.Password)
            {
                Utils.Context.clientId = user.Id;
                RequestListWindow requestListWindow = new();
                requestListWindow.Show();
                Close();
            }
        }
    }
}