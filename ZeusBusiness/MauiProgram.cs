using CommunityToolkit.Maui;
using ZeusBusiness.Abstraction.Infrastructure.PermissionGuard;
using ZeusBusiness.Abstraction.Infrastructure.ProviderBase;
using ZeusBusiness.Abstraction.Services.Authentication;
using ZeusBusiness.Abstraction.Services.General;
using ZeusBusiness.Infrastructure.PermissionGuard;
using ZeusBusiness.Infrastructure.ProviderBase;
using ZeusBusiness.MVVM.View.Helpers;
using ZeusBusiness.MVVM.View.Pages.Authentication;
using ZeusBusiness.MVVM.View.Pages.Crm;
using ZeusBusiness.MVVM.View.Pages.Dashboard;
using ZeusBusiness.MVVM.View.Pages.Inventory;
using ZeusBusiness.MVVM.View.Pages.Report;
using ZeusBusiness.MVVM.View.Pages.Settings;
using ZeusBusiness.MVVM.ViewModel.CustomControls.Flyout;
using ZeusBusiness.MVVM.ViewModel.Helpers;
using ZeusBusiness.MVVM.ViewModel.ViewBinder;
using ZeusBusiness.MVVM.ViewModel.ViewBinder.Authentication;
using ZeusBusiness.MVVM.ViewModel.ViewBinder.Dashboard;
using ZeusBusiness.Services.Authentication;
using ZeusBusiness.Services.General;

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
		builder.Services.AddSingleton<UserDashboardPage>();

		//View-Models
		builder.Services.AddSingleton<LoginPageViewModel>();
		builder.Services.AddSingleton<OwnerDashboardViewModel>();
		builder.Services.AddSingleton<AppShellViewModel>();
		builder.Services.AddSingleton<LoadingPageViewModel>();
		builder.Services.AddSingleton<FlyoutHeaderControlViewModel>();

		//Services

		builder.Services.AddSingleton<IRequestProvider, RequestProvider>();
		builder.Services.AddSingleton<IAuthenticationService, AuthenticationService>();
		builder.Services.AddSingleton<IOutletService, OutletService>();

		//
		builder.Services.AddSingleton<IOutletUserGuard, OutletUserGuard>();


		//Routing
		//builder.Services.AddSingleton<IDashboardRoute, DashboardRoute>();
		//builder.Services.AddSingleton<IAuthenticationRoute, AuthenticationRoute>();

		return builder.Build();
	}
}
