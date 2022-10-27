using ZeusBusiness.Abstraction.Infrastructure.PermissionGuard;
using ZeusBusiness.MVVM.Model.Generics.General;
using ZeusBusiness.MVVM.ViewModel.CustomControls.Flyout;

namespace ZeusBusiness.CustomControls.Flyout;

public partial class FlyoutHeaderControl : StackLayout
{
    private IOutletUserGuard _guard;
    public Outlet SelectedOutlet { get; set; }
    public FlyoutHeaderControl(IOutletUserGuard guard)
    {
        _guard = guard;
        this.BindingContext = new FlyoutHeaderControlViewModel(_guard);
        InitializeComponent();
        if (App.AuthResponse != null)
        {
            nameLbl.Text = App.AuthResponse.Name;
            emailLbl.Text = App.AuthResponse.Email;
        }
    }

}