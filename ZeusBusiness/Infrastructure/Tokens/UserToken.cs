using System.IdentityModel.Tokens.Jwt;
using ZeusBusiness.Abstraction.Infrastructure.Token;
using ZeusBusiness.Abstraction.Services.Authentication;

namespace ZeusBusiness.Infrastructure.Tokens
{
    public class UserToken : IUserToken
    {
        #region PRIVATE INSTANCE FEILD
        private IAuthenticationService _service;
        #endregion

        #region
        public UserToken(IAuthenticationService service)
        {
            _service = service;
        }
        #endregion

        #region PUBLIC METHODS
        public async Task RefreshToken()
        {
            var jwt = await SecureStorage.GetAsync(nameof(App.JwtToken));
            App.JwtToken = jwt;
            var handler = new JwtSecurityTokenHandler();
            var jsonToken = handler.ReadJwtToken(jwt) as JwtSecurityToken;
            if (jsonToken.ValidTo < DateTime.UtcNow)
            {
                var authResponse = await _service.GenerateJwtToken();
                await SecureStorage.SetAsync(nameof(App.JwtToken), authResponse.Data.JwtToken);
                App.JwtToken = authResponse.Data.JwtToken;
            }
            
        }
        #endregion
    }
}
