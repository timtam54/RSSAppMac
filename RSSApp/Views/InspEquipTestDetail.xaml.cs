using RSSApp.Models;
using RSSApp.Services;
using CommunityToolkit.Maui.Views;
namespace RSSApp.Views;

public partial class InspEquipTestDetail : Popup
{
	int _id;
    int _EquipTypeID;
    IInspEquipTestRepository _client;
    int _InspEquipID;
    public InspEquipTestDetail(int id, IInspEquipTestRepository client,int EquipTypeID,int InspEquipID)
	{
		_id = id;
		_client = client;
        _InspEquipID = InspEquipID;
        _EquipTypeID = EquipTypeID;
        InitializeComponent();
        RefreshDataAsync();
    }

    IEquipTypeRepository equiptypeservice = new EquipTypeServices();
    public async void RefreshDataAsync()
    {
        Models.InspEquipTypeTest Item;
        if (_id == 0)
        {
            Item = new InspEquipTypeTest();
            Item.InspEquipID = _InspEquipID;
            Item.id = 0;
        }
        else
            Item = await _client.InspTest(_id);
        List<EquipTypeTest> equiptypetest = await (new EquipTypeTestServices()).EquipTypeTests(_EquipTypeID);
        Item.Ett = (from ins in equiptypetest select new SelectListItem { Text = ins.Test, Value = ins.id }).ToList();
        if (_id != 0)
            Item.SelEquipTypeTest = Item.Ett.Where(i => i.Value == Item.EquipTypeTestID).FirstOrDefault();
        BindingContext = Item;
    }

    async void Button_Clicked(System.Object sender, System.EventArgs e)
    {
        Models.InspEquipTypeTest Item = (Models.InspEquipTypeTest)BindingContext;
        Item.EquipTypeTestID = Item.SelEquipTypeTest.Value;
        if (Item.id!=0)
           await _client.Update(Item);
        else
          await  _client.AddNew(Item);
        Close();
    }
}
