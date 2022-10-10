using ZeusBusiness.MVVM.ViewModel.ViewBinder.Authentication;

namespace ZeusBusiness.MVVM.View.Pages.Authentication;

public partial class LoginPage : ContentPage
{
	public LoginPage(LoginPageViewModel vm)
	{
		InitializeComponent();
		this.BindingContext = vm;
	}
}