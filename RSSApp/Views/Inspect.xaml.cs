using RSSApp.Models;
using RSSApp.Services;


namespace RSSApp.Views;

public partial class Inspect : ContentPage
{

	//Models.InspectionView _ItemView;
    //Models.InspectionView Item;
    readonly IInspectionRepository _insp;
    readonly IEmployeeRepository _emp = new EmployeeServices();
    readonly IBuildingRepository _bui = new BuildingServices();
    int _InspectionID;
    readonly IInspEquipRepository _inspitems = new InspEquipServices();

    public Inspect(int InspectionID,string Address, IInspectionRepository insp)
	{
        _insp = insp;
		InitializeComponent();
        Title = "Inspection of " + Address;
        _InspectionID = InspectionID;
        RefreshDataAsync();
       
    }

  
    public async void RefreshDataAsync()
    {

        List<Models.Employee> Insps = await _emp.Employees();
        List<Models.Building> Bui = await _bui.Buildings();
        Models.Inspection Item = await _insp.Inspection(_InspectionID);


        Item.Insps = (from ins in Insps select new SelectListItem { Text =ins.Given + " " + ins.Surname, Value = ins.id }).ToList(); 
        Item.SelectInspectorID = Item.Insps.Where(i => i.Value == Item.InspectorID).FirstOrDefault();
        Item.Buildings = (from bd in Bui select new SelectListItem { Text = bd.Address, Value = bd.id }).ToList();
        Item.SelectBuidingID = Item.Buildings.Where(i => i.Value == Item.BuildingID).FirstOrDefault();
        BindingContext = Item;
    }

    async void  Button_Clicked(System.Object sender, System.EventArgs e)
    {
        await Navigation.PushAsync(new Views.InspItem(Convert.ToInt32(_InspectionID)));
    }

   async void Button_Clicked_1(System.Object sender, System.EventArgs e)
    {
        Models.Inspection Item = (Models.Inspection)BindingContext;

        if (Item.id != 0)
            await _insp.Update(Item);
        else
            await _insp.AddNew(Item);
       
        RefreshDataAsync();
    }

}