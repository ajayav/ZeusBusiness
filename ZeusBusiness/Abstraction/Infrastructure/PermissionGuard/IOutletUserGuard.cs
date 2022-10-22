using ZeusBusiness.Model.Generics.General;

namespace ZeusBusiness.Abstraction.Infrastructure.PermissionGuard
{
    public interface IOutletUserGuard
    {
        public Task<IList<OutletUser>> GetAllOutletUser();
        public Task SetOutletUser();
    }
}
