using Newtonsoft.Json;
using ZeusBusiness.Abstraction.Infrastructure.PermissionGuard;
using ZeusBusiness.CustomControls.Flyout;
using ZeusBusiness.Infrastructure.PermissionGuard;
using ZeusBusiness.MVVM.Model.Generics.Authentication;
using ZeusBusiness.MVVM.View.Pages.Authentication;

namespace ZeusBusiness.MVVM.ViewModel.Helpers
{
    public class LoadingPageViewModel
    {
        private readonly IOutletUserGuard _guard;
        public LoadingPageViewModel(IOutletUserGuard guard)
        {
            _guard = guard;
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
                await _guard.SetOutletUser();
                AppShell.Current.FlyoutHeader = new FlyoutHeaderControl(_guard);
                await OutletGuard.AddFlyoutItems();
            }
        }
    }
}
