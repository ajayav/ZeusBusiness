using ZeusBusiness.Domain.Abstract.Route;
using ZeusBusiness.View.Pages.Authentication;

namespace ZeusBusiness.Route.Navigation.Authentication
{
    public class AuthenticationRoute: IAuthenticationRoute
    {
        public async void RouteToLogin()
        {
            await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
        }
    }
}
