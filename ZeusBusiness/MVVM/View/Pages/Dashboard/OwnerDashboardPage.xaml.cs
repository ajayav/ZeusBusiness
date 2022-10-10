

using ZeusBusiness.ViewModel.ViewBinder.Dashboard;

namespace ZeusBusiness.View.Pages.Dashboard;

public partial class OwnerDashboardPage : ContentPage
{
	public OwnerDashboardPage(OwnerDashboardViewModel vm)
	{
		InitializeComponent();
		this.BindingContext = vm;
	}
}