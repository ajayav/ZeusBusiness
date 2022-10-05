using ZeusBusiness.View.Pages.Dashboard;

namespace ZeusBusiness;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
		Routing.RegisterRoute(nameof(OwnerDashboardPage), typeof(OwnerDashboardPage));
	}
}
