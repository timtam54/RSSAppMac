using CommunityToolkit.Maui.Views;
using RSSApp.Models;
using RSSApp.Services;
//using static Android.Gms.Common.Apis.Api;

namespace RSSApp.Views;

public partial class InspEquipTest : ContentPage
{
    int _id;
    int _EquipTypeID;
    public InspEquipTest(int id,int EquipTypeID,string EquipTypeName)
	{
        _id = id;
        _EquipTypeID = EquipTypeID;
        InitializeComponent();
        _EquipTypeName = EquipTypeName;
        Title = EquipTypeName + " Tests";
        RefreshDataAsync();
    }
    string _EquipTypeName;

    InspEquipTypeTestViewModel Items = new InspEquipTypeTestViewModel();
    IInspEquipTestRepository _client = new InspEquipTestService();

    public async void RefreshDataAsync()
    {
        List<Models.InspEquipTypeTestRpt> It = await _client.InspTests(_id);
        
        Items.InspEquipTypeTests = It;

        InspectionList.ItemsSource = It;
        BindingContext = Items;
        //return Items;
    }

    async void Button_Clicked(System.Object sender, System.EventArgs e)
    {
        Button btn = (Button)sender;
        var InspectionID = btn.CommandParameter;
        await Navigation.PushAsync(new Views.InspEquipTestDet(this,Convert.ToInt32(InspectionID),_client, _EquipTypeID, _id, _EquipTypeName));
      
    }

    //add new
  

   

   async void Button_Delete(System.Object sender, System.EventArgs e)
    {
        Button btn = (Button)sender;
        var id = btn.CommandParameter;
        await _client.Delete(Convert.ToInt32( id));
        RefreshDataAsync();
    }

   async void Button_AddNew(System.Object sender, System.EventArgs e)
    {
        await Navigation.PushAsync(new Views.InspEquipTestDet(this, Convert.ToInt32(0), _client, _EquipTypeID, _id, _EquipTypeName));

    }
}
