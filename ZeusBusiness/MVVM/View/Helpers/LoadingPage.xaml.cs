using ZeusBusiness.MVVM.ViewModel.Helpers;

namespace ZeusBusiness.MVVM.View.Helpers;

public partial class LoadingPage : ContentPage
{
	public LoadingPage(LoadingPageViewModel vm)
	{
		InitializeComponent();
		this.BindingContext = vm;
	}
}