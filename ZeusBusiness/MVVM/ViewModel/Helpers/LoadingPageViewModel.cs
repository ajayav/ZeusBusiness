using ZeusBusiness.Abstraction.Infrastructure.PermissionGuard;
using ZeusBusiness.Abstraction.Infrastructure.Token;
using ZeusBusiness.CustomControls.Flyout;
using ZeusBusiness.Infrastructure.PermissionGuard;
using ZeusBusiness.MVVM.View.Pages.Authentication;

namespace ZeusBusiness.MVVM.ViewModel.Helpers
{
    public class LoadingPageViewModel
    {
        private readonly IOutletUserGuard _guard;
        private IUserToken _token;
        public LoadingPageViewModel(IOutletUserGuard guard, IUserToken token)
        {
            _guard = guard;
            _token = token;
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
                //var authResponse = JsonConvert.DeserializeObject<AuthenticateResponse>(authResponseStr);
                //App.AuthResponse = authResponse;
                await _token.RefreshToken();
                await _guard.SetOutletUser();
                AppShell.Current.FlyoutHeader = new FlyoutHeaderControl(_guard);
                await OutletGuard.AddFlyoutItems();
            }
        }
    }
}
