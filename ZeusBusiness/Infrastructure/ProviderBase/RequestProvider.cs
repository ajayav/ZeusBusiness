using Newtonsoft.Json;
using System.Net;
using System.Net.Http.Headers;
using ZeusBusiness.Abstraction.Infrastructure.ProviderBase;
using ZeusBusiness.MVVM.Model.Common;

namespace ZeusBusiness.Infrastructure.ProviderBase
{
    public class RequestProvider : IRequestProvider
    {
        #region STATIC
        public static HttpClient _client = null;
        #endregion

        #region CONSTRUCTOR
        public RequestProvider()
        {
            CookieContainer cookies = new CookieContainer();
            HttpClientHandler handler = new HttpClientHandler();
            handler.CookieContainer = cookies;
            handler.UseCookies = true;
            _client = new HttpClient(handler)
            {
                BaseAddress = new Uri("http://49.205.192.134:505/api/v1/")
            };
            _client.DefaultRequestHeaders.Clear();
        }
        #endregion

        #region PUBLIC METHODS
        public async Task<Envelope<T>> PostAsync<T>(string requesturl, StringContent data)
        {
            if (App.JwtToken != null)
            {
                _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", App.JwtToken);
            }
            var response = await _client.PostAsync(requesturl, data).ConfigureAwait(false);
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                var httpResponse = JsonConvert.DeserializeObject<Envelope<T>>(result);
                return httpResponse;
            }
            return default(Envelope<T>);
        }

        public async Task<string> GetAsync(string requesturl)
        {
            if (App.JwtToken != null)
            {
                _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", App.JwtToken);
            }
            var response = await _client.GetAsync(requesturl).ConfigureAwait(false);
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                return result;
            }
            return null;
        }
        #endregion
    }
}
