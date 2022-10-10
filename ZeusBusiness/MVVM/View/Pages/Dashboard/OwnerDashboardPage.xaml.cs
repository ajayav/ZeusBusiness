using ZeusBusiness.MVVM.ViewModel.ViewBinder.Dashboard;

namespace ZeusBusiness.MVVM.View.Pages.Dashboard;

public partial class OwnerDashboardPage : ContentPage
{
	public OwnerDashboardPage(OwnerDashboardViewModel vm)
	{
		InitializeComponent();
		this.BindingContext = vm;
	}
}