using RSSApp.Models;
using RSSApp.Services;


namespace RSSApp.Views;

public partial class InspEquip : ContentPage
{
	IInspEquipRepository _inspitems;
    InspItem _par;
    int _id;
    int _InspectionID;
    public InspEquip(InspItem par,int id, IInspEquipRepository inspitems,int InspectionID)
	{
        _par = par;
        _InspectionID = InspectionID;
        _inspitems = inspitems;
        _id = id;
        InitializeComponent();
        RefreshDataAsync();
    }

    Models.InspEquip Item;
    public async void RefreshDataAsync()
    {
        if (_id == 0)
        {
            Item = new Models.InspEquip();
            Item.InspectionID = _InspectionID;
        }
        else
            Item = await _inspitems.InspItem(_id);

        List<EquipType> equiptype = await (new EquipTypeServices()).EquipTypes();

        Item.Et = (from ins in equiptype select new SelectListItem { Text = ins.EquipTypeDesc, Value = ins.id }).ToList();
        if (_id == 0)
        {
            Item.SelEquipType = Item.Et.FirstOrDefault();

            EquipTypeName = Item.SelEquipType.Text;
        }
        else
        {
            Item.SelEquipType = Item.Et.Where(i => i.Value == Item.EquipTypeID).FirstOrDefault();

            EquipTypeName = Item.SelEquipType.Text;

        }
        BindingContext = Item;
    }
    string EquipTypeName;
   async void Button_Clicked(System.Object sender, System.EventArgs e)
    {
        await Navigation.PushAsync(new Views.InspEquipPhotos(_id));// Convert.ToInt32(_ID)));
    }

    async void TestClicked(System.Object sender, System.EventArgs e)
    {

        await Navigation.PushAsync(new Views.InspEquipTest(_id,Item.EquipTypeID, EquipTypeName));// Convert.ToInt32(_ID)));
    }

    async void Button_SaveClose(System.Object sender, System.EventArgs e)
    {
        Models.InspEquip Item = (Models.InspEquip)BindingContext;
        Item.EquipTypeID = Item.SelEquipType.Value;
        if (Item.id != 0)
            await _inspitems.Update(Item);
        else
            await _inspitems.AddNew(Item);
        _par.RefreshDataAsync();
        await Application.Current.MainPage.Navigation.PopAsync();
    }
}
