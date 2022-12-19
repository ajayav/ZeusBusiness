using ZeusBusiness.MVVM.Model.Generics.General;

namespace ZeusBusiness.Abstraction.Services.General;

public interface IOutletService
{
    public Task<IList<OutletUser>> GetAllOutletsByUserId(); 
}
