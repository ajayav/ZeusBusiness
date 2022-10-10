using CommunityToolkit.Maui;
using ZeusBusiness.MVVM.ViewModel.Controls.AppDrawer;
using ZeusBusiness.MVVM.ViewModel.Helpers;
using ZeusBusiness.MVVM.ViewModel.ViewBinder;
using ZeusBusiness.MVVM.ViewModel.ViewBinder.Authentication;
using ZeusBusiness.MVVM.ViewModel.ViewBinder.Dashboard;
using ZeusBusiness.View.Helpers;
using ZeusBusiness.View.Pages.Authentication;
using ZeusBusiness.View.Pages.Crm;
using ZeusBusiness.View.Pages.Dashboard;
using ZeusBusiness.View.Pages.Inventory;
using ZeusBusiness.View.Pages.Report;
using ZeusBusiness.View.Pages.Settings;

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
		builder.Services.AddSingleton<LoadingPage>();
		builder.Services.AddSingleton<InventoryPage>();
		builder.Services.AddSingleton<ReportPage>();
		builder.Services.AddSingleton<CrmPage>();
		builder.Services.AddSingleton<SettingsPage>();

		//View-Models
		builder.Services.AddSingleton<LoginPageViewModel>();
		builder.Services.AddSingleton<OwnerDashboardViewModel>();
		builder.Services.AddSingleton<AppShellViewModel>();
		builder.Services.AddSingleton<LoadingPageViewModel>();
		builder.Services.AddSingleton<FlyoutHeaderControlViewModel>();


		//Routing
		//builder.Services.AddSingleton<IDashboardRoute, DashboardRoute>();
		//builder.Services.AddSingleton<IAuthenticationRoute, AuthenticationRoute>();

		return builder.Build();
	}
}
