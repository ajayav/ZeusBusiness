using ZeusBusiness.MVVM.Model.Generics.Authentication;

namespace ZeusBusiness.Model.Generics.General
{
    public class OutletUser
    {
        public Outlet Outlet { get; set; }
        public User User { get; set; }
        public bool IsOwner { get; set; }
        public OutletPermission? Permission { get; set; }
        public bool IsDefaultOutlet { get; set; }
    }
}
