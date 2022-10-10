using CommunityToolkit.Mvvm.ComponentModel;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using ZeusBusiness.Dev;
using ZeusBusiness.Model.Generics.General;
using ZeusBusiness.MVVM.Model.Generics.General;
using ZeusBusiness.MVVM.ViewModel.ViewBinder;

namespace ZeusBusiness.MVVM.ViewModel.Controls.AppDrawer
{
    public partial class FlyoutHeaderControlViewModel : BaseViewModel
    {
        public FlyoutHeaderControlViewModel()
        {
            //GetSelectedOutlet();
            GetAllOutlets();
        }

        [ObservableProperty]
        public ObservableCollection<Outlet> outletList = new();

        private async void GetAllOutlets()
        {
            var outletUserList = await FakeOutlet.FetchOutlets();
            foreach (var outletUser in outletUserList)
            {
                //outletUser.Outlet.Name = outletUser.Outlet.Name + ", " + outletUser.Outlet.Location;
                outletList.Add(outletUser.Outlet);
            }
        }

        private void GetSelectedOutlet()
        {
            OutletUser outletUser = new OutletUser();
            if (Preferences.ContainsKey(nameof(App.OutletUser)))
            {
                string outletUserStr = Preferences.Get(nameof(App.OutletUser), "");
                outletUser = JsonConvert.DeserializeObject<OutletUser>(outletUserStr);
            }

            //App.OutletUser = outletUser;
        }

    }
}
