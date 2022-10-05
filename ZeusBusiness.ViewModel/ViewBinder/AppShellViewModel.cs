using CommunityToolkit.Mvvm.Input;
using ZeusBusiness.Domain.Abstract.Route;

namespace ZeusBusiness.ViewModel.ViewBinder
{
    public partial class AppShellViewModel : BaseViewModel
    {
        private IApplicationRoute _route;
        public AppShellViewModel(IApplicationRoute route)
        {
            _route = route;
        }

        [RelayCommand]
        void Logout()
        {
            _route.RouteToLogin();
        }
    }
}
