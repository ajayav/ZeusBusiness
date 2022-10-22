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
        //GetSelectedOutlet();
        //outletPicker.SelectedItem = App.OutletUser.Outlet;
    }

    //private void outletPicker_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    if (outletPicker.SelectedIndex != -1)
    //    {
    //        var outlet = outletPicker.SelectedItem;
    //        if (Preferences.ContainsKey(nameof(App.OutletUser), ""))
    //        {
    //            Preferences.Remove(nameof(App.OutletUser));
    //        }
    //        var outletStr = JsonConvert.SerializeObject(outlet);
    //        Preferences.Set(nameof(App.OutletUser.Outlet), outletStr);
    //        App.OutletUser.Outlet = (Outlet)outlet;

    //        OutletUser outletUser = new OutletUser();
    //        if (Preferences.ContainsKey(nameof(App.OutletUser.Outlet)))
    //        {
    //            string outletUserStr = Preferences.Get(nameof(App.OutletUser), "");
    //            outletUser = JsonConvert.DeserializeObject<OutletUser>(outletUserStr);
    //        }

    //    }
    //}

    //private void GetSelectedOutlet()
    //{
    //    //if (Preferences.ContainsKey(nameof(App.OutletUser)))
    //    //{
    //    //    string outletUserStr = Preferences.Get(nameof(App.OutletUser), "");
    //    //    SelectedOutlet = JsonConvert.DeserializeObject<OutletUser>(outletUserStr).Outlet;
    //    //}
    //    //outletPicker.SelectedItem = SelectedOutlet;
    //    //App.OutletUser = outletUser;
    //}
}