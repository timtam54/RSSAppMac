using RSSApp.Models;
using RSSApp.Services;

namespace RSSApp.Views;

public partial class InspEquipTestDet : ContentPage
{

    InspEquipTest _par;
    int _id;
    int _EquipTypeID;
    IInspEquipTestRepository _client;
    int _InspEquipID;
    string _EquipTypeName;
    public InspEquipTestDet(InspEquipTest par, int id, IInspEquipTestRepository client, int EquipTypeID, int InspEquipID, string EquipTypeName)
    {
        _par = par;
        _id = id;
        _client = client;
        _InspEquipID = InspEquipID;
        _EquipTypeID = EquipTypeID;
        _EquipTypeName = EquipTypeName;
        InitializeComponent();
        Title = "Tests for " + EquipTypeName;
        RefreshDataAsync(null);
        Loading = false;
    }

  

    bool Loading = true;
    IEquipTypeRepository equiptypeservice = new EquipTypeServices();
    IEquipTypeTestRepository equiptypetestservice = new EquipTypeTestServices();
    Models.InspEquipTypeTest Item;
    public async void RefreshDataAsync(int? selid)
    {
        
        if (_id == 0)
        {
            Item = new InspEquipTypeTest();
            Item.InspEquipID = _InspEquipID;
            Item.id = 0;
        }
        else
            Item = await _client.InspTest(_id);
        List<EquipTypeTest> equiptypetest = await equiptypetestservice.EquipTypeTests(_EquipTypeID);
        Item.Ett = (from ins in equiptypetest orderby ins.Test select new SelectListItem { Text = ins.Test, Value = ins.id }).ToList();
        SelectListItem sli = new SelectListItem();
        sli.Text = "-Add New-";
        sli.Value = 0;
        Item.Ett.Add(sli);
        if (selid==null)
            Item.SelEquipTypeTest = Item.Ett.Where(i => i.Value == Item.EquipTypeTestID).FirstOrDefault();
        else
            Item.SelEquipTypeTest = Item.Ett.Where(i => i.Value == selid).FirstOrDefault();
        BindingContext = Item;
    }

    async void Button_Clicked(System.Object sender, System.EventArgs e)
    {
        Models.InspEquipTypeTest Item = (Models.InspEquipTypeTest)BindingContext;
        Item.EquipTypeTestID = Item.SelEquipTypeTest.Value;
        if (Item.id != 0)
            await _client.Update(Item);
        else
            await _client.AddNew(Item);
        _par.RefreshDataAsync();
        await Application.Current.MainPage.Navigation.PopAsync();
    }

   
   async void EquipTypeTestID_SelectedIndexChanged(System.Object sender, System.EventArgs e)
    {
        if (Loading)
            return;
        Picker pk = (Picker)sender;
        var ss =((SelectListItem) pk.SelectedItem).Text;
        pk.Unfocus();
        if (ss=="-Add New-")
            await Navigation.PushAsync(new Views.EquipTypeTests(this, equiptypetestservice, _EquipTypeID, _EquipTypeName));
    }
}
