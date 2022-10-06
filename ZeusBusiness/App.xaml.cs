using ZeusBusiness.Model.Generics.Authentication;
using ZeusBusiness.Model.Generics.General;

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
