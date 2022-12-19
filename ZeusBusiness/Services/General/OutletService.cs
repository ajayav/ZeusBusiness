using Newtonsoft.Json;
using ZeusBusiness.Abstraction.Infrastructure.ProviderBase;
using ZeusBusiness.Abstraction.Services.General;
using ZeusBusiness.MVVM.Model.Common;
using ZeusBusiness.MVVM.Model.Generics.General;

namespace ZeusBusiness.Services.General
{
    public class OutletService : IOutletService
    {
        #region PRIVATE INSTANCE FEILD
        private IRequestProvider _http = null;
        #endregion

        #region CONSTRUCTOR
        public OutletService(IRequestProvider http)
        {
            _http = http;
        }
        #endregion

        #region PUBLIC METHODS
        public async Task<IList<OutletUser>> GetAllOutletsByUserId()
        {
            var response = await _http.GetAsync("outlet/get-outlets-by-userid");
            var listOutletUser = JsonConvert.DeserializeObject<Envelope<IList<OutletUser>>>(response).Data;
            return listOutletUser;
        }
        #endregion
    }
}
