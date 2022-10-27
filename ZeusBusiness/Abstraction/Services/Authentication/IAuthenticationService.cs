using ZeusBusiness.MVVM.Model.Common;
using ZeusBusiness.MVVM.Model.Generics.Authentication;

namespace ZeusBusiness.Abstraction.Services.Authentication
{
    public interface IAuthenticationService
    {
        public Task<Envelope<AuthenticateResponse>> Login(AuthenticateRequest request);
        public Task<Envelope<AuthenticateResponse>> GenerateJwtToken();
    }
}
