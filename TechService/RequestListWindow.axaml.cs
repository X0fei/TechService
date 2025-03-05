using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using System.Collections.Generic;
using TechService.Models;

namespace TechService;

public partial class RequestListWindow : Window
{
    private List<Request> displayList = Utils.Context.Requests;
    public RequestListWindow()
    {
        InitializeComponent();
        RequestListBox.ItemsSource = displayList;
    }

    private void CreateRequestButton_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        AddEditRequest addEditRequest = new();
        addEditRequest.Show();
        Close();
    }
}