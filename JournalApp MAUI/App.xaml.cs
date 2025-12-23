using JournalApp_MAUI.Services;

namespace JournalApp_MAUI;

public partial class App : Application
{
    public static DatabaseService Database { get; private set; }

    public App(DatabaseService database)
    {
        InitializeComponent();
        Database = database;
        MainPage = new AppShell();
    }
}
