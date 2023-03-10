using RSSApp.Models;
using RSSApp.Services;

namespace RSSApp.Views;

public partial class EquipTypeTests : ContentPage
{
	InspEquipTestDet _par;
	
	int _EquipTypeID;
readonly	IEquipTypeTestRepository _equiptypetestservice;
    public EquipTypeTests(InspEquipTestDet par,  IEquipTypeTestRepository equiptypetestservice, int EquipTypeID,string EquipTypeName)
	{
		_par = par;
		_EquipTypeID = EquipTypeID;
		_equiptypetestservice = equiptypetestservice;
        InitializeComponent();
        Title = "New test for:"+ EquipTypeName;
        RefreshDataAsync();
    }


    public async void RefreshDataAsync()
    {
        Models.EquipTypeTest Item = new Models.EquipTypeTest();
        Item.EquipTypeID = _EquipTypeID;
        BindingContext = Item;
    }

   async void Button_Clicked(System.Object sender, System.EventArgs e)
    {
        Models.EquipTypeTest Item = (Models.EquipTypeTest)BindingContext;

        //if (Item.id != 0)
        //      await _insp.Update(Item);
        //    else
        EquipTypeTest res= await _equiptypetestservice.AddNew(Item);

       _par.RefreshDataAsync(res.id);

        await Application.Current.MainPage.Navigation.PopAsync();

    }

}
