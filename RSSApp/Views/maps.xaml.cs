using System.Net;
using Microsoft.Maui.Controls.Maps;
using Microsoft.Maui.Maps;
using RSSApp.Services;
using Map = Microsoft.Maui.Controls.Maps.Map;
namespace RSSApp.Views;

public partial class maps : ContentPage
{

    readonly IInspectionRepository _client = new InspectionServices();
//    public List<Models.InspectionView> inspectiondata;

    public maps()
	{
		InitializeComponent();
        Location location = new Location(-31.9523, 115.8613);
        MapSpan mapSpan = new MapSpan(location, .5, .5);
        Map map = new Map(mapSpan)
        {
            MapType = MapType.Street
        };
        Content = map;
        map.IsTrafficEnabled = true;
        map.IsShowingUser = true;
        RefreshDataAsync(map);
        //Button btn = new Button();
        map.MapClicked += Map_MapClicked;
    }

    public maps(List<Models.InspectionView> _Items)
    {
        InitializeComponent();
        Location location = new Location(-31.9523, 115.8613);
        MapSpan mapSpan = new MapSpan(location, .5, .5);
        Map map = new Map(mapSpan)
        {
            MapType = MapType.Street
        };
        Content = map;
        map.IsTrafficEnabled = true;
        map.IsShowingUser = true;
        /////
        Items = _Items;

        AddLatLonPins(map);
        map.MapClicked += Map_MapClicked;
    }

    private async void Map_MapClicked(object sender, MapClickedEventArgs e)
    {
       // new NavigationPage(new Inspections(inspectiondata));
        await Navigation.PushAsync(new Views.Inspections(Items));
    }

    public List<Models.InspectionView> Items { get; private set; }

    public async void RefreshDataAsync(Map map)
    {
        Items = await _client.Inspections();
        await AddLatLonPins(map);

    }

    private async Task AddLatLonPins(Map map)
    {
        try
        {
            foreach (var iv in Items)
            {
                IEnumerable<Microsoft.Maui.Devices.Sensors.Location> locations = (await Geocoding.Default.GetLocationsAsync(iv.Address));
                Microsoft.Maui.Devices.Sensors.Location location = locations?.FirstOrDefault();
                if (location != null)
                {
                    iv.Lat = location.Latitude;
                    iv.Lon = location.Longitude;
                    //+ "~" + location.Altitude;
                }
            }
        }
        catch (Exception ex)
        {
            DisplayAlert("Error1", ex.Message, "Cancel");
        }
        try {
            foreach (var iv in Items)
            {
                if (iv.Lat != null)
                {
                    if (iv.Lon != null)
                    {
                        Pin pin = new Pin
                        {
                            Label = iv.ClientName + " " + iv.InspDate.ToShortDateString(),
                            Address = iv.Address,
                            Type = PinType.Place,
                            Location = new Location(iv.Lat.Value, iv.Lon.Value)
                        };
                        pin.StyleId = iv.id.ToString();
                        map.Pins.Add(pin);
                        pin.MarkerClicked += Pin_MarkerClicked;
                    }
                }
            }
        }
        catch (Exception ex)
        {
            DisplayAlert("Error2",ex.Message,"Cancel");
        }
    }

    private async void Pin_MarkerClicked(object sender, PinClickedEventArgs e)
    {
        Pin Det = (Pin)sender;
        string InspectionID = Det.StyleId.ToString();
        await Navigation.PushAsync(new Views.Inspect( Convert.ToInt32(InspectionID),Det.Address,_client));
    }
}
