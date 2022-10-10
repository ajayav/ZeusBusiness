using ZeusBusiness.Model.Generics.General;
using ZeusBusiness.MVVM.Model.Generics.Authentication;
using ZeusBusiness.MVVM.Model.Generics.General;

namespace ZeusBusiness.Dev
{
    public class FakeOutlet
    {
        public async static Task<IList<OutletUser>> FetchOutlets()
        {
            Outlet outlet1 = new Outlet
            {
                Id = 1,
                Name = "Outlet 1",
                Location = "Test",
                PurchasePlan = (PurchasePlan)3,
            };

            Outlet outlet2 = new Outlet
            {
                Id = 1,
                Name = "Outlet 2",
                Location = "Test",
                PurchasePlan = (PurchasePlan)7,
            };

            Outlet outlet3 = new Outlet
            {
                Id = 1,
                Name = "Outlet 3",
                Location = "Test",
                PurchasePlan = (PurchasePlan)7,
            };

            Outlet outlet4 = new Outlet
            {
                Id = 1,
                Name = "Outlet 4",
                Location = "Test",
                PurchasePlan = (PurchasePlan)7,
            };

            User user = new User
            {
                Id = 1,
                Name = "AJ"
            };

            OutletUser outletUser1 = new OutletUser
            {
                Outlet = outlet1,
                User = user
            };
            OutletUser outletUser2 = new OutletUser
            {
                Outlet = outlet2,
                User = user
            };

            OutletUser outletUser3 = new OutletUser
            {
                Outlet = outlet3,
                User = user
            };

            OutletUser outletUser4 = new OutletUser
            {
                Outlet = outlet4,
                User = user
            };


            IList<OutletUser> listOutletUser = new List<OutletUser>();
            listOutletUser.Add(outletUser1);
            listOutletUser.Add(outletUser2);
            listOutletUser.Add(outletUser3);
            listOutletUser.Add(outletUser4);
            return listOutletUser;
        }
    }
}
