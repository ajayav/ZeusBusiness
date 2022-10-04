using ZeusBusiness.ViewModel.ViewBinder.Authentication;

namespace ZeusBusiness.View.Pages.Authentication;

public partial class LoginPage : ContentPage
{
	public LoginPage(LoginPageViewModel vm)
	{
		InitializeComponent();
		this.BindingContext = vm;
	}
}