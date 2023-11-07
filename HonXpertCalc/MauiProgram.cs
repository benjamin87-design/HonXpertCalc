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

		builder.Services.AddSingleton<HomePage>();

		builder.Services.AddSingleton<StockRemovalViewModel>();

		builder.Services.AddSingleton<StockRemovalPage>();

		builder.Services.AddSingleton<ProfileShiftFactorViewModel>();

		builder.Services.AddSingleton<ProfileShiftFactorPage>();

		builder.Services.AddSingleton<FrequencyToOrderViewModel>();

		builder.Services.AddSingleton<FrequencyToOrderPage>();

		return builder.Build();
	}
}
