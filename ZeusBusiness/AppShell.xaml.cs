using ZeusBusiness.Domain.Abstract.Route;
using ZeusBusiness.View.Pages.Dashboard;
using ZeusBusiness.ViewModel.ViewBinder;

namespace ZeusBusiness;

public partial class AppShell : Shell
{
	private IApplicationRoute _route;
	public AppShell(IApplicationRoute route)
	{
		_route = route;
		InitializeComponent();
		this.BindingContext = new AppShellViewModel(route);
		Routing.RegisterRoute(nameof(OwnerDashboardPage), typeof(OwnerDashboardPage));
	}
}
