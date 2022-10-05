using ZeusBusiness.Domain.Abstract.Route;
using ZeusBusiness.View.Pages.Dashboard;

namespace ZeusBusiness.Route.Navigation.Dashboard
{
    public class DashboardRoute : IDashboardRoute
    {
        public async void RouteToDashboard()
        {
            await Shell.Current.GoToAsync($"//{ nameof(OwnerDashboardPage)}");
        }
    }
}
