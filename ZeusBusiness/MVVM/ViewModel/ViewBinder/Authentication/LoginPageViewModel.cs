using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Newtonsoft.Json;
using ZeusBusiness.Abstraction.Infrastructure.PermissionGuard;
using ZeusBusiness.Abstraction.Services.Authentication;
using ZeusBusiness.CustomControls.Flyout;
using ZeusBusiness.Infrastructure.PermissionGuard;
using ZeusBusiness.MVVM.Model.Common;
using ZeusBusiness.MVVM.Model.Generics.Authentication;
using ZeusBusiness.MVVM.View.Pages.Authentication;
using ZeusBusiness.MVVM.View.Pages.Dashboard;

namespace ZeusBusiness.MVVM.ViewModel.ViewBinder.Authentication
{
    public partial class LoginPageViewModel : BaseViewModel
    {
        #region PRIVATE INSTANCE FEILD
        private IAuthenticationService _service;
        private IOutletUserGuard _guard;
        #endregion

        #region CONSTUCTOR
        public LoginPageViewModel(IAuthenticationService service, IOutletUserGuard guard)
        {
            _service = service;
            _guard = guard;
        }
        #endregion

        #region OBSERVABLES
        [ObservableProperty]
        private string _email;

        [ObservableProperty]
        private string _password;
        #endregion


        #region COMMANDS
        [RelayCommand]
        async void Login()
        {
            if (!string.IsNullOrWhiteSpace(Email) && !string.IsNullOrWhiteSpace(Password))
            {
                var authResponse = await _service.Login(new AuthenticateRequest
                {
                    Email = Email,
                    Password = Password
                });

                if (authResponse.Success)
                {
                    if (Preferences.ContainsKey(nameof(App.AuthResponse)))
                    {
                        Preferences.Remove(nameof(App.AuthResponse));
                    }
                    await SecureStorage.SetAsync(nameof(App.JwtToken), authResponse.Data.JwtToken);
                    string authResponseStr = JsonConvert.SerializeObject(authResponse.Data);
                    Preferences.Set(nameof(App.AuthResponse), authResponseStr);
                    App.AuthResponse = authResponse.Data;
                    App.JwtToken = authResponse.Data.JwtToken;
                    AppShell.Current.FlyoutHeader = new FlyoutHeaderControl(_guard);
                    Email = "";
                    Password = "";
                    await _guard.SetOutletUser();
                    await OutletGuard.AddFlyoutItems();
                }
                else
                {
                    await AppShell.Current.DisplayAlert("Invalid User", authResponse.Response, "OK");
                }
            }
        }

        [RelayCommand]
        async void ForgotPassword()
        {
            await Shell.Current.GoToAsync($"//{nameof(ForgotPasswordPage)}");
        }
        #endregion
    }
}
