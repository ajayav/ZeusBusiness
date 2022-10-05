using ZeusBusiness.Domain.Abstract.Route;
using ZeusBusiness.View.Pages.Authentication;
using ZeusBusiness.View.Pages.Dashboard;

namespace ZeusBusiness.Domain.Route
{
    public class ApplicationRoute : IApplicationRoute
    {
        public async void RouteToOwnerDashboard()
        {
            await Shell.Current.GoToAsync($"//{nameof(OwnerDashboardPage)}");
        }

        public async void RouteToLogin()
        {
            await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
        }
    }
}
