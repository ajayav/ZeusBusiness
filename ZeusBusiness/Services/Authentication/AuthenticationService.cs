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
        private IRequestProvider _http;
        #endregion

        #region CONSTRUCTOR
        public AuthenticationService(IRequestProvider http)
        {
            _http = http;
        }
        #endregion

        #region PUBLIC METHODS
        public async Task<Envelope<AuthenticateResponse>> Login(AuthenticateRequest request)
        {
            var json = JsonConvert.SerializeObject(request);
            var stringContent = new StringContent(json.ToString(), Encoding.UTF8, "application/json");
            var response = await _http.PostAsync<AuthenticateResponse>($"authentication/login", stringContent).ConfigureAwait(false);
            return response;
        }

        public async Task<Envelope<AuthenticateResponse>> GenerateJwtToken()
        {
            var response = await _http.GetAsync($"authentication/refresh-token");
            var authResponse = JsonConvert.DeserializeObject<Envelope<AuthenticateResponse>>(response);
            return authResponse;
        }
        #endregion
    }
}
