using CommunityToolkit.Mvvm.Input;
using ZeusBusiness.View.Pages.Authentication;

namespace ZeusBusiness.ViewModel.ViewBinder
{
    public partial class AppShellViewModel : BaseViewModel { 

        [RelayCommand]
        async void Logout()
        {
            await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
        }
    }
}
