namespace RSSApp;


public partial class App : Application
{
    //readonly EmployeeDatabase _rssDatabase;
    public App(EmployeeDatabase rssDatabase)
    {
        InitializeComponent();

        MainPage = new NavigationPage( new LoginPage(rssDatabase));
    }
}
