using ZeusBusiness.Abstraction.Services.General;
using ZeusBusiness.MVVM.ViewModel.CustomControls.Outlet;

namespace ZeusBusiness.MVVM.View.CustomControls.Outlet;

public partial class OutletSelectorView : ContentPage
{
	private IOutletService _service;

    public OutletSelectorView(IOutletService service)
	{
		_service = service;
		InitializeComponent();
        //Routing.RegisterRoute(nameof(OutletSelectorView), typeof(OutletSelectorView));
        this.BindingContext = new OutletSelectorViewModel(service);
	}
}