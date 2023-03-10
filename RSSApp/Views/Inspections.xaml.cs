namespace RSSApp.Views;
using RSSApp.Services;
public partial class Inspections : ContentPage
{
    readonly IInspectionRepository _client = new InspectionServices();

   // public List<Models.InspectionView> inspectiondata;

    public Inspections()
	{
		InitializeComponent();
        RefreshDataAsync();
    }

    public Inspections(List<Models.InspectionView> _Items)
    {
        Items = _Items;
        InitializeComponent();
        Loaded += Inspections_Loaded;
    }

    
    private void Inspections_Loaded(object sender, EventArgs e)
    {
        foreach (var item in Items)
        {
            item.Photo = "https://rssblob.blob.core.windows.net/rssimage/" + item.Photo;
        }
        InspectionList.ItemsSource = Items;
        BindingContext = Items;
    }


    List<Models.InspectionView> Items;

    public async void RefreshDataAsync()
    {
         Items = await _client.Inspections();

        foreach (var item in Items)
        {
            item.Photo = "https://rssblob.blob.core.windows.net/rssimage/"+item.Photo;
        }
        InspectionList.ItemsSource = Items;
        BindingContext = Items;
        //return Items;
    }

    async void Button_Clicked(System.Object sender, System.EventArgs e)
    {
        Button btn = (Button)sender;
        var InspectionID = btn.CommandParameter;
        await Navigation.PushAsync(new Views.Inspect(Convert.ToInt32(InspectionID),btn.Text, _client));
    }

   async void Button_Clicked_1(System.Object sender, System.EventArgs e)
    {
        await Navigation.PushAsync(new Views.maps(Items));

    }
}
