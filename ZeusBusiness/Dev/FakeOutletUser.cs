using ZeusBusiness.Model.Generics.General;
using ZeusBusiness.MVVM.Model.Generics.Authentication;
using ZeusBusiness.MVVM.Model.Generics.General;

namespace ZeusBusiness.Dev
{
    public class FakeOutletUser
    {
        public async static Task<OutletUser> FetchOutletUser()
        {
            Outlet outlet = new Outlet
            {
                Id = 1,
                Name = "AJ TEST",
                Location = "Test",
                PurchasePlan = (PurchasePlan)3,
            };

            User user = new User
            {
                Id = 2,
                Name = "AJ"
            };

            OutletUser outletUser = new OutletUser
            {
                Outlet = outlet,
                User = user
            };
            return outletUser;
        }
    }
}
