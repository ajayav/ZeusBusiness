using Newtonsoft.Json;
using System.Text;
using ZeusBusiness.Abstraction.Infrastructure.ProviderBase;
using ZeusBusiness.Abstraction.Services.Authentication;
using ZeusBusiness.MVVM.Model.Common;
using ZeusBusiness.MVVM.Model.Generics.Authentication;

namespace ZeusBusiness.Services.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
        #region PRIVATE INSTANCES
        private IRequestProvider _request;
        #endregion

        #region CONSTRUCTOR
        public AuthenticationService(IRequestProvider request)
        {
            _request = request;
        }
        #endregion

        #region PUBLIC METHODS
        public async Task<Envelope<AuthenticateResponse>> Login(AuthenticateRequest request)
        {
            var json = JsonConvert.SerializeObject(request);
            var stringContent = new StringContent(json.ToString(), Encoding.UTF8, "application/json");
            var response = await _request.PostAsync<AuthenticateResponse>($"authentication/login", stringContent).ConfigureAwait(false);
            return response;
        }
        #endregion
    }
}
