using JournalApp_MAUI.Models;
using JournalApp_MAUI.Services;

namespace JournalApp_MAUI.ViewModels;

public class CalendarViewModel
{
    private readonly DatabaseService _database;

    public CalendarViewModel(DatabaseService database)
    {
        _database = database;
    }

    public Task<JournalEntry> LoadEntry(DateTime date)
    {
        return _database.GetEntryByDate(date);
    }
}
