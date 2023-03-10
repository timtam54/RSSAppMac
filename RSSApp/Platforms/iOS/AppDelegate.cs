using Foundation;
using SQLitePCL;

namespace RSSApp;

[Register("AppDelegate")]
public class AppDelegate : MauiUIApplicationDelegate
{
    protected override MauiApp CreateMauiApp()
    {
        raw.SetProvider(new SQLite3Provider_sqlite3());
        return MauiProgram.CreateMauiApp();
    }

//    protected override MauiApp CreateMauiApp() => raw.SetProvider(new SQLitePCL.SQLite3Provider_dynamic_cdecl()); MauiProgram.CreateMauiApp();

}

