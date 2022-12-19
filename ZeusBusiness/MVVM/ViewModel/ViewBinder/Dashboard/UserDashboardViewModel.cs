using CommunityToolkit.Mvvm.Input;
using ZeusBusiness.MVVM.View.CustomControls.Outlet;

namespace ZeusBusiness.MVVM.ViewModel.ViewBinder.Dashboard;

public partial class UserDashboardViewModel : BaseViewModel
{
    public UserDashboardViewModel()
    {

    }

    [RelayCommand]
    async void ChangeOutlet()
    {
        if (DeviceInfo.Platform == DevicePlatform.WinUI)
        {
            AppShell.Current.Dispatcher.Dispatch(async () =>
            {
                await Shell.Current.GoToAsync($"//{nameof(OutletSelectorView)}");
            });
        }
        else
        {
            await Shell.Current.GoToAsync($"//{nameof(OutletSelectorView)}");
        }
    }
}
