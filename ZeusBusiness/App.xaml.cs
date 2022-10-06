using ZeusBusiness.Model.Generics.Authentication;

namespace ZeusBusiness;


public partial class App : Application
{
    public static AuthenticateResponse AuthResponse;
    public App()
	{
		InitializeComponent();

		MainPage = new AppShell();
	}
}
