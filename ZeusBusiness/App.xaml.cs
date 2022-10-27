using ZeusBusiness.Model.Generics.General;
using ZeusBusiness.MVVM.Model.Generics.Authentication;
using ZeusBusiness.MVVM.Model.Generics.General;

namespace ZeusBusiness;


public partial class App : Application
{
	public static AuthenticateResponse AuthResponse;
	public static OutletUser OutletUser;
	public static Outlet Outlet;
	public static string JwtToken;
	public App()
	{
		InitializeComponent();

		MainPage = new AppShell();
	}
}
