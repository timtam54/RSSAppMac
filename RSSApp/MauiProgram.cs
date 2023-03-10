using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using Microsoft.Maui.Controls.Hosting;

namespace RSSApp;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
        //builder.Services.AddSingleton<EmployeePage>();
        //    builder.Services.AddTransient<EmployeePage>();
        builder.Services.AddSingleton<EmployeeDatabase>();

        builder
            .UseMauiApp<App>()
            .UseMauiCommunityToolkit()
            .ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			})
            .UseMauiMaps();

#if DEBUG
        builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}

