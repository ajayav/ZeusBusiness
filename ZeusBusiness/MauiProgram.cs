using CommunityToolkit.Maui;
using ZeusBusiness.View.Pages.Authentication;
using ZeusBusiness.View.Pages.Dashboard;
using ZeusBusiness.ViewModel.ViewBinder;
using ZeusBusiness.ViewModel.ViewBinder.Authentication;
using ZeusBusiness.ViewModel.ViewBinder.Dashboard;

namespace ZeusBusiness;

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
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

		//Views
		builder.Services.AddSingleton<LoginPage>();
		builder.Services.AddSingleton<OwnerDashboardPage>();

		//View-Models
		builder.Services.AddSingleton<LoginPageViewModel>();
		builder.Services.AddSingleton<OwnerDashboardViewModel>();
		builder.Services.AddSingleton<AppShellViewModel>();


		//Routing
		//builder.Services.AddSingleton<IDashboardRoute, DashboardRoute>();
		//builder.Services.AddSingleton<IAuthenticationRoute, AuthenticationRoute>();

		return builder.Build();
	}
}
