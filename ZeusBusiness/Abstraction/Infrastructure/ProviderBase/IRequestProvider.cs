using ZeusBusiness.MVVM.Model.Common;

namespace ZeusBusiness.Abstraction.Infrastructure.ProviderBase
{
    public interface IRequestProvider
    {
        public Task<Envelope<T>> PostAsync<T>(string requesturl, StringContent data);
        public Task<string> GetAsync(string requesturl);
    }
}
