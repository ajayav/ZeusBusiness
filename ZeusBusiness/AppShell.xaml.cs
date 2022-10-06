using ZeusBusiness.View.Helpers;
using ZeusBusiness.View.Pages.Dashboard;
using ZeusBusiness.ViewModel.ViewBinder;

namespace ZeusBusiness;

public partial class AppShell : Shell
{
	public AppShell()
	{

		InitializeComponent();
		this.BindingContext = new AppShellViewModel();
		//Routing.RegisterRoute(nameof(LoadingPage), typeof(LoadingPage));
		Routing.RegisterRoute(nameof(OwnerDashboardPage), typeof(OwnerDashboardPage));
	}
}
