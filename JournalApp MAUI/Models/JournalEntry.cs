using SQLite;

namespace JournalApp_MAUI.Models;

public class JournalEntry
{
    [PrimaryKey, AutoIncrement]
    public int EntryId { get; set; }

    [Unique]
    public DateTime EntryDate { get; set; }

    public string Title { get; set; }
    public string Content { get; set; }

    public int PrimaryMoodId { get; set; }

    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    public int WordCount { get; set; }
}
