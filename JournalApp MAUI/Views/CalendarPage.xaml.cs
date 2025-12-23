using Microsoft.Maui.Controls;
using JournalApp_MAUI.ViewModels;

namespace JournalApp_MAUI.Views;

public partial class CalendarPage : ContentPage
{
    private readonly CalendarViewModel viewModel;

    public CalendarPage()
    {
        InitializeComponent();
        viewModel = new CalendarViewModel(App.Database);
    }

    private async void OnDateSelected(object sender, DateChangedEventArgs e)
    {
        var entry = await viewModel.LoadEntry(e.NewDate);

        if (entry != null)
            await Shell.Current.GoToAsync("EntryPage");
    }
}
