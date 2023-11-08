namespace HonXpertCalc;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.UseMauiCommunityToolkit()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("FontAwesome6FreeBrands.otf", "FontAwesomeBrands");
				fonts.AddFont("FontAwesome6FreeRegular.otf", "FontAwesomeRegular");
				fonts.AddFont("FontAwesome6FreeSolid.otf", "FontAwesomeSolid");
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

		builder.Services.AddSingleton<HomeViewModel>();
        builder.Services.AddSingleton<StockRemovalViewModel>();
        builder.Services.AddSingleton<ProfileShiftFactorViewModel>();
		builder.Services.AddSingleton<FrequencyToOrderViewModel>();
		builder.Services.AddSingleton<ToothMeshingFrequenciesViewModel>();

        builder.Services.AddSingleton<HomePage>();
        builder.Services.AddSingleton<StockRemovalPage>();
        builder.Services.AddSingleton<FrequencyToOrderPage>();
		builder.Services.AddSingleton<ToothMeshingFrequenciesPage>();
        builder.Services.AddSingleton<ProfileShiftFactorPage>();

        return builder.Build();
	}
}
