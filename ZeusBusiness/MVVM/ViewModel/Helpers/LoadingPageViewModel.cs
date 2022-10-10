using Newtonsoft.Json;
using ZeusBusiness.Controls.AppDrawer;
using ZeusBusiness.Dev;
using ZeusBusiness.Infrastructure.PermissionChecker;
using ZeusBusiness.Model.Generics.Authentication;
using ZeusBusiness.Model.Generics.General;
using ZeusBusiness.View.Pages.Authentication;
using ZeusBusiness.View.Pages.Dashboard;

namespace ZeusBusiness.MVVM.ViewModel.Helpers
{
    public class LoadingPageViewModel
    {
        public LoadingPageViewModel()
        {
            CheckUserLoginDetails();
        }

        private async void CheckUserLoginDetails()
        {
            string outletUserStr = Preferences.Get(nameof(App.OutletUser), "");
            if (string.IsNullOrEmpty(outletUserStr))
            {
                var outletUser = await FakeOutletUser.FetchOutletUser();
                App.OutletUser = outletUser;
            }
            string authResponseStr = Preferences.Get(nameof(App.AuthResponse), "");
            if (string.IsNullOrEmpty(authResponseStr))
            {
                await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
            }
            else
            {
                var authResponse = JsonConvert.DeserializeObject<AuthenticateResponse>(authResponseStr);
                App.AuthResponse = authResponse;
                AppShell.Current.FlyoutHeader = new FlyoutHeaderControl();
                await OutletPermissionChecker.AddFlyoutItems();
                //await Shell.Current.GoToAsync($"//{nameof(OwnerDashboardPage)}");
            }
        }
    }
}
