using CulinaryApp.Data;
using CulinaryApp.ViewModel;
using Microsoft.Extensions.Logging;

namespace CulinaryApp;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

		builder.Services.AddSingleton<ShoppingListPage>();
        builder.Services.AddSingleton<ShoppingListViewModel>();
        builder.Services.AddSingleton<ShoppingListItemDB>();

        builder.Services.AddSingleton<UserRecipesPage>();
        builder.Services.AddSingleton<UserRecipesViewModel>();
        builder.Services.AddSingleton<UserRecipeDB>();

        builder.Services.AddTransient<EditUserRecipePage>();
        builder.Services.AddTransient<EditUserRecipeViewModel>();

#if DEBUG
        builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}

