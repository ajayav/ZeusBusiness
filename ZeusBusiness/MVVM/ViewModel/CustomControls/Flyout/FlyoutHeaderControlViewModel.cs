using CommunityToolkit.Mvvm.ComponentModel;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using ZeusBusiness.Abstraction.Infrastructure.PermissionGuard;
using ZeusBusiness.Abstraction.Services.General;
using ZeusBusiness.Dev;
using ZeusBusiness.Model.Generics.General;
using ZeusBusiness.MVVM.Model.Generics.General;
using ZeusBusiness.MVVM.ViewModel.ViewBinder;

namespace ZeusBusiness.MVVM.ViewModel.CustomControls.Flyout
{
    public partial class FlyoutHeaderControlViewModel : BaseViewModel
    {
        #region PRIVATE INSTANCE FEILD
        private IOutletUserGuard _guard;
        #endregion

        #region CONSTRUCTOR
        public FlyoutHeaderControlViewModel(IOutletUserGuard guard)
        {
            _guard = guard;
            //GetSelectedOutlet();
            //GetAllOutlets();
        }
        #endregion

        //[ObservableProperty]
        //public ObservableCollection<Outlet> outletList = new();

        //[ObservableProperty]
        //public Outlet selectedOutlet = new Outlet();

        //private async void GetAllOutlets()
        //{
        //    var outletUserList = await _guard.GetAllOutletUser();
        //    foreach (var outletUser in outletUserList)
        //    {
        //        outletUser.Outlet.Name = outletUser.Outlet.Name + ", " + outletUser.Outlet.Location;
        //        outletList.Add(outletUser.Outlet);
        //    }
        //}

        //private void GetSelectedOutlet()
        //{
        //    if (Preferences.ContainsKey(nameof(App.OutletUser)))
        //    {
        //        string outletUserStr = Preferences.Get(nameof(App.OutletUser), "");
        //        selectedOutlet = JsonConvert.DeserializeObject<OutletUser>(outletUserStr).Outlet;
        //    }
        //}

    }
}
