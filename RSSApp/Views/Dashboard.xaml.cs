namespace RSSApp.Views;

public partial class Dashboard : ContentPage
{
	public Dashboard()
	{
		InitializeComponent();
	}

  async  void Button_MapView(System.Object sender, System.EventArgs e)
    {
        await Navigation.PushAsync(new Views.maps());
    }

  async  void Button_Tabular(System.Object sender, System.EventArgs e)
    {
        await Navigation.PushAsync(new Views.Inspections());
    }
}
