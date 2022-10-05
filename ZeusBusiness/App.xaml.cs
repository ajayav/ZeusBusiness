using ZeusBusiness.Domain.Abstract.Route;

namespace ZeusBusiness;

public partial class App : Application
{
	private IApplicationRoute _route;
	public App(IApplicationRoute route)
	{
		_route = route;
		InitializeComponent();

		MainPage = new AppShell(route);
	}
}
