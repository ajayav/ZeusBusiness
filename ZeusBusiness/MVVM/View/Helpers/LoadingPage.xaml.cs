using ZeusBusiness.ViewModel.Helpers;

namespace ZeusBusiness.View.Helpers;

public partial class LoadingPage : ContentPage
{
	public LoadingPage(LoadingPageViewModel vm)
	{
		InitializeComponent();
		this.BindingContext = vm;
	}
}