using CommunityToolkit.Mvvm.Input;
using ZeusBusiness.Domain.Abstract.Route;
using ZeusBusiness.ViewModel.ViewBinder.Dashboard;

namespace ZeusBusiness.ViewModel.ViewBinder.Authentication
{
    public partial class LoginPageViewModel : BaseViewModel
    {
        private IApplicationRoute _route;

        public LoginPageViewModel(IApplicationRoute route)
        {
            _route = route;
        }

        #region COMMANDS
        [RelayCommand]
         void Login()
        {
             _route.RouteToOwnerDashboard();
        }
        #endregion
    }
}
