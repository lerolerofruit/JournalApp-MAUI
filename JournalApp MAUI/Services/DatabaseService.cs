using SQLite;
using JournalApp_MAUI.Models;

namespace JournalApp_MAUI.Services;

public class DatabaseService
{
    private readonly SQLiteAsyncConnection _db;

    public DatabaseService(string dbPath)
    {
        _db = new SQLiteAsyncConnection(dbPath);
        _db.CreateTableAsync<JournalEntry>().Wait();
    }

    public Task<JournalEntry> GetEntryByDate(DateTime date)
    {
        return _db.Table<JournalEntry>()
                  .FirstOrDefaultAsync(e => e.EntryDate == date.Date);
    }

    public Task<int> SaveEntry(JournalEntry entry)
    {
        entry.UpdatedAt = DateTime.Now;

        if (entry.EntryId == 0)
        {
            entry.CreatedAt = DateTime.Now;
            return _db.InsertAsync(entry);
        }
        return _db.UpdateAsync(entry);
    }

    public Task<int> DeleteEntry(JournalEntry entry)
    {
        return _db.DeleteAsync(entry);
    }
}
