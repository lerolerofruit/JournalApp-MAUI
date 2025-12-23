using SQLite;
using JournalApp_MAUI.Models;

namespace JournalApp_MAUI.Services;

public class StreakService
{
    private readonly SQLiteAsyncConnection _db;

    public StreakService(SQLiteAsyncConnection db)
    {
        _db = db;
    }

    public async Task<int> GetCurrentStreak()
    {
        var entries = await _db.Table<JournalEntry>()
                               .OrderByDescending(e => e.EntryDate)
                               .ToListAsync();

        int streak = 0;
        DateTime expectedDate = DateTime.Today;

        foreach (var entry in entries)
        {
            if (entry.EntryDate.Date == expectedDate)
            {
                streak++;
                expectedDate = expectedDate.AddDays(-1);
            }
            else
                break;
        }
        return streak;
    }
}
