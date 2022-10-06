using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Newtonsoft.Json;
using System.Text.Json.Serialization;
using ZeusBusiness.Controls.AppDrawer;
using ZeusBusiness.Dev;
using ZeusBusiness.Infrastructure.PermissionChecker;
using ZeusBusiness.Model.Generics.Authentication;
using ZeusBusiness.View.Pages.Dashboard;

namespace ZeusBusiness.ViewModel.ViewBinder.Authentication
{
    public partial class LoginPageViewModel : BaseViewModel
    {
        [ObservableProperty]
        private string _email;

        [ObservableProperty]
        private string _password;


        #region COMMANDS
        [RelayCommand]
        async void Login()
        {
            if (!string.IsNullOrWhiteSpace(Email) && !string.IsNullOrWhiteSpace(Password))
            {
                //call authenticate api here

                var authResponse = new AuthenticateResponse
                {
                    Email = Email,
                    Name = "AJ"
                };
                if (Preferences.ContainsKey(nameof(App.AuthResponse)))
                {
                    Preferences.Remove(nameof(App.AuthResponse));
                }

                string authResponseStr = JsonConvert.SerializeObject(authResponse);
                Preferences.Set(nameof(App.AuthResponse), authResponseStr);
                App.AuthResponse = authResponse;
                AppShell.Current.FlyoutHeader = new FlyoutHeaderControl();
                Email = "";
                Password = "";
                string outletUserStr = Preferences.Get(nameof(App.OutletUser), "");
                if (string.IsNullOrEmpty(outletUserStr))
                {
                    var outletUser = await FakeOutletUser.FetchOutletUser();
                    App.OutletUser = outletUser;
                }
                await OutletPermissionChecker.AddFlyoutItems();
                //await Shell.Current.GoToAsync($"//{nameof(OwnerDashboardPage)}");
            }
        }
        #endregion
    }
}
