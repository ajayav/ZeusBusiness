using ZeusBusiness.Abstraction.Infrastructure.Encryption;
using ZeusBusiness.Abstraction.Services.General;

namespace ZeusBusiness.Infrastructure.Tokens;

public class OutletToken
{
    #region PRIVATE INSTANCE FEILD
    private ICrypto _crypto = null;
    private IOutletService _service = null;
    #endregion

    #region CONSTRUCTOR
    public OutletToken(ICrypto crypto, IOutletService service)
    {
        _crypto = crypto;
        _service = service;
    }
    #endregion

    #region PUBLIC METHODS
    #endregion
}
