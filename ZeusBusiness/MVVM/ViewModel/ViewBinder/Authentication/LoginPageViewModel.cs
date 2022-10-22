using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Newtonsoft.Json;
using ZeusBusiness.Abstraction.Infrastructure.PermissionGuard;
using ZeusBusiness.Abstraction.Services.Authentication;
using ZeusBusiness.CustomControls.Flyout;
using ZeusBusiness.Infrastructure.PermissionGuard;
using ZeusBusiness.MVVM.Model.Generics.Authentication;

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

                    string authResponseStr = JsonConvert.SerializeObject(authResponse.Data);
                    Preferences.Set(nameof(App.AuthResponse), authResponseStr);
                    App.AuthResponse = authResponse.Data;
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
        #endregion
    }
}
