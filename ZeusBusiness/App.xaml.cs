using ZeusBusiness.Domain.Abstract.Route;

namespace ZeusBusiness;

public partial class App : Application
{
	private IAuthenticationRoute _route;
	public App(IAuthenticationRoute route)
	{
		_route = route;
		InitializeComponent();

		MainPage = new AppShell(route);
	}
}
