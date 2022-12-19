using ZeusBusiness.MVVM.ViewModel.ViewBinder.Dashboard;

namespace ZeusBusiness.MVVM.View.Pages.Dashboard;

public partial class UserDashboardPage : ContentPage
{
	public UserDashboardPage(UserDashboardViewModel vm)
	{
		InitializeComponent();
		this.BindingContext = vm;
	}
}