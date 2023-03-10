using RSSApp.Services;

namespace RSSApp.Views;

public partial class InspItem : ContentPage
{
    readonly IInspEquipRepository _inspitems = new InspEquipServices();
    int _InspectionID;

    public InspItem(int InspectionID)
	{
        _InspectionID = InspectionID;
        InitializeComponent();
   

        RefreshDataAsync();
    }

    public async void RefreshDataAsync()
    {
        List<Models.InspEquipView> Items = await _inspitems.InspItems(_InspectionID);

        foreach (var item in Items)
        {
            item.Photos = "https://rssblob.blob.core.windows.net/rssimage/" + item.Photos;
        }
        InspEquipList.ItemsSource = Items;
    }

    async void Button_Edit(System.Object sender, System.EventArgs e)
    {
        Button btn = (Button)sender;
        var InspEquipID = btn.CommandParameter;
        await Navigation.PushAsync(new Views.InspEquip(this,Convert.ToInt32(InspEquipID), _inspitems,_InspectionID));
    }

   async void Button_AddNew(System.Object sender, System.EventArgs e)
    {

        await Navigation.PushAsync(new Views.InspEquip(this,0, _inspitems, _InspectionID));
        //RefreshDataAsync();
    }

   

   async void Button_Delete(System.Object sender, System.EventArgs e)
    {
        Button btn = (Button)sender;
        var InspEquipID = btn.CommandParameter;
        await  _inspitems.Delete(Convert.ToInt32( InspEquipID));
         RefreshDataAsync();
    }
}
