using ZeusBusiness.MVVM.View.CustomControls.Outlet;
using ZeusBusiness.MVVM.View.Pages.Dashboard;
using ZeusBusiness.MVVM.ViewModel.ViewBinder;

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
