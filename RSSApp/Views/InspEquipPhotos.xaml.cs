using RSSApp.Services;

namespace RSSApp.Views;

public partial class InspEquipPhotos : ContentPage
{
    int _InspEquipID;

    public InspEquipPhotos(int InspEquipID)
	{
        _InspEquipID = InspEquipID;
        InitializeComponent();
        RefreshDataAsync();
    }

    IInspPhotoRepository ip = new InspPhotoServices();
    List<Models.InspPhoto> Items;

    public async void RefreshDataAsync()
    {
        Items = await ip.InspPhotos(_InspEquipID);

        foreach (var item in Items)
        {
            item.photoname = "https://rssblob.blob.core.windows.net/rssimage/" + item.photoname;
        }
        InspPhotosList.ItemsSource = Items;
        BindingContext = Items;
        //return Items;
    }

   async void Button_Clicked(System.Object sender, System.EventArgs e)
    {
        await Navigation.PushAsync(new  Photo(_InspEquipID));
    }
}
