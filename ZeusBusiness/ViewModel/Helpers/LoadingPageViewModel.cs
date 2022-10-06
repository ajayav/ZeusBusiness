using Newtonsoft.Json;
using ZeusBusiness.Controls.AppDrawer;
using ZeusBusiness.Model.Generics.Authentication;
using ZeusBusiness.View.Pages.Authentication;
using ZeusBusiness.View.Pages.Dashboard;

namespace ZeusBusiness.ViewModel.Helpers
{
    public class LoadingPageViewModel
    {
        public LoadingPageViewModel()
        {
            CheckUserLoginDetails();
        }

        private async void CheckUserLoginDetails()
        {
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
                await Shell.Current.GoToAsync($"//{nameof(OwnerDashboardPage)}");
            }
        }
    }
}
