using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using TechService.Context;
using TechService.Models;

namespace TechService;

public partial class AddEditRequest : Window
{
    private List<Equipment> equipmentComboBoxList = Utils.Context.Equipment;
    private List<Malfunction> malfunctionComboBoxList = Utils.Context.Malfunctions;
    public AddEditRequest()
    {
        InitializeComponent();
        EquipmentComboBox.ItemsSource = equipmentComboBoxList;
        MalfunctionComboBox.ItemsSource = malfunctionComboBoxList;
    }

    private void CreateRequestButton_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        Request request = new Request()
        {
            EquipmentId = EquipmentComboBox.SelectedIndex + 1,
            MalfunctionId = MalfunctionComboBox.SelectedIndex + 1,
            ProblemDescription = ProblemDescription.Text,
            PriorityId = 1,
            Date = DateOnly.FromDateTime(DateTime.Now),
            ClientId = Utils.Context.clientId,
            StatusId = 1
        };
        using (var context = new User21Context())
        {
            context.Add(request);
            context.SaveChanges();
        }
        Utils.Context.Requests = new List<Request>(Utils.Context.DbContext.Requests
            .Include(r => r.Equipment)
            .Include(r => r.Malfunction)
            .Include(r => r.Priority)
            .Include(r => r.Client)
            .Include(r => r.Status));
        RequestListWindow requestListWindow = new();
        requestListWindow.Show();
        Close();
    }
}