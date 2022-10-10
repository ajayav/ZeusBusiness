using CommunityToolkit.Mvvm.ComponentModel;
using Newtonsoft.Json;
using ZeusBusiness.Dev;
using ZeusBusiness.Model.Generics.General;
using ZeusBusiness.ViewModel.Controls.AppDrawer;
using ZeusBusiness.ViewModel.ViewBinder.Authentication;

namespace ZeusBusiness.Controls.AppDrawer;

public partial class FlyoutHeaderControl : StackLayout
{
    public FlyoutHeaderControl()
    {
        this.BindingContext = new FlyoutHeaderControlViewModel();
        InitializeComponent();
        if (App.AuthResponse != null)
        {
            nameLbl.Text = App.AuthResponse.Name;
            emailLbl.Text = App.AuthResponse.Email;
        }
    }

    private void outletPicker_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (outletPicker.SelectedIndex != -1)
        {
            var outlet = outletPicker.SelectedItem;
            if (Preferences.ContainsKey(nameof(App.OutletUser), ""))
            {
                Preferences.Remove(nameof(App.OutletUser));
            }
            var outletStr = JsonConvert.SerializeObject(outlet);
            Preferences.Set(nameof(App.OutletUser.Outlet), outletStr);
            App.OutletUser.Outlet = (Outlet)outlet;

            OutletUser outletUser = new OutletUser();
            if (Preferences.ContainsKey(nameof(App.OutletUser.Outlet)))
            {
                string outletUserStr = Preferences.Get(nameof(App.OutletUser), "");
                outletUser = JsonConvert.DeserializeObject<OutletUser>(outletUserStr);
            }

        }
    }
}