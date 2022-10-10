using CommunityToolkit.Mvvm.Input;
using ZeusBusiness.View.Pages.Authentication;

namespace ZeusBusiness.MVVM.ViewModel.ViewBinder
{
    public partial class AppShellViewModel : BaseViewModel { 

        [RelayCommand]
        async void Logout()
        {
            if (Preferences.ContainsKey(nameof(App.AuthResponse)))
            {
                Preferences.Remove(nameof(App.AuthResponse));
            }
            
            await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
            //AppShell.Current.Items.Clear();
        }
    }
}
