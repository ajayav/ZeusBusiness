using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
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
            await Shell.Current.GoToAsync($"//{nameof(OwnerDashboardPage)}");
            //if(string.IsNullOrWhiteSpace(Email) && string.IsNullOrWhiteSpace(Password))
            //{
            //    //call authenticate api here

            //    var authResponse = new AuthenticateResponse
            //    {
            //        Email = Email,
            //        Name = "AJ"
            //    };
            //    //Preferences.ContainsKey(nameof(App))
            //}

        }
        #endregion
    }
}
