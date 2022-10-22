using Newtonsoft.Json;
using ZeusBusiness.Abstraction.Infrastructure.PermissionGuard;
using ZeusBusiness.Abstraction.Services.General;
using ZeusBusiness.Model.Generics.General;

namespace ZeusBusiness.Infrastructure.PermissionGuard
{
    public class OutletUserGuard : IOutletUserGuard
    {
        #region
        private IOutletService _service;
        #endregion

        #region CONSTRUCTOR
        public OutletUserGuard(IOutletService service)
        {
            _service = service;
        }
        #endregion

        public async Task<IList<OutletUser>> GetAllOutletUser()
        {
            var response = await _service.GetAllOutletsByUserId();
            return response;
        }

        public async Task SetOutletUser()
        {
            var result = await GetAllOutletUser();
            if (Preferences.ContainsKey(nameof(App.OutletUser)))
            {
                Preferences.Remove(nameof(App.OutletUser));
            }
            string outletUserStr = JsonConvert.SerializeObject(result[0]);
            Preferences.Set(nameof(App.OutletUser), outletUserStr);
            App.OutletUser = result[0];
        }
    }
}
