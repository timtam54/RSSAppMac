using RSSApp.Models;
using RSSApp.Services;
//using static Android.Content.ClipData;

namespace RSSApp;

public partial class LoginPage : ContentPage
{
	readonly EmployeeDatabase _rssDatabase;

    readonly ILoginRepository _loginRepository=new LoginServices();

	public LoginPage(EmployeeDatabase rssDatabase)
	{
        InitializeComponent();
        Loaded += LoginPage_Loaded;
        _rssDatabase = rssDatabase;
		
    }
    List<Employee> emps;
    private async void LoginPage_Loaded(object sender, EventArgs e)
    {
        emps = await _rssDatabase.GetItemsAsync();
        if (emps != null)
        {
            emps.FirstOrDefault().id = 1;
            txtEmail.Text = emps.FirstOrDefault().Email;
            txtPassword.Text = emps.FirstOrDefault().Password;
        }
    }

    async void btnLogin_Clicked(System.Object sender, System.EventArgs e)
    {
		string email = txtEmail.Text;
		string password = txtPassword.Text;
		if (email==null || password ==null)
		{
			await DisplayAlert("Warning", "Please enter email and password", "ok");
			return;
		}
		Employee employee = await _loginRepository.Login(email, password);
		if (employee!=null)
		{
            var exists = emps.Where(i => i.Email == email).Count();
            if (exists==0)
            //todo see if this exist in the database and if not then 
			    employee.id = 0;
            await _rssDatabase.SaveItemAsync(employee);

            await Navigation.PushAsync(new  Views.Dashboard());
		}
		else
		{
            await DisplayAlert("Warning", "Login failed", "ok");
        }
    }
}
