using ZeusBusiness.Model.Generics.General;
using ZeusBusiness.MVVM.Model.Generics.Authentication;

namespace ZeusBusiness;


public partial class App : Application
{
	public static AuthenticateResponse AuthResponse;
	public static OutletUser OutletUser;
	public App()
	{
		InitializeComponent();

		MainPage = new AppShell();
	}
}
