using ZeusBusiness.Abstraction.Services.General;
using ZeusBusiness.Abstraction.Tokens;

namespace ZeusBusiness.Infrastructure.Tokens
{
    public class OutletUserToken : IOutletUserToken
    {
        private IOutletService _service = null;

        public OutletUserToken(IOutletService service)
        {
            _service = service;
        }
        public async Task SetOutletUser()
        {
            if (!(Preferences.ContainsKey(nameof(App.OutletUser))))
            {
                var listOutletUser = await _service.GetAllOutletsByUserId();

            }
            //await AddFlyoutItems();
        }
    }
}
