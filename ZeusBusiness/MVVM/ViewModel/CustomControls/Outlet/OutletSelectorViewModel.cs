using System.Collections.ObjectModel;
using ZeusBusiness.Abstraction.Services.General;
using ZeusBusiness.MVVM.Model.Generics.General;
using ZeusBusiness.MVVM.ViewModel.ViewBinder;

namespace ZeusBusiness.MVVM.ViewModel.CustomControls.Outlet;

public partial class OutletSelectorViewModel : BaseViewModel
{
    private IOutletService _service;


    public ObservableCollection<OutletUser> OutletUser { get; set; } = new ObservableCollection<OutletUser>();
    public OutletSelectorViewModel(IOutletService service)
    {
        _service = service;
        //outletuser.add(new outletuser() { new outlet { } })
        //var outletuser = new OutletUser
        //{
        //    Outlet = new Model.Generics.General.Outlet
        //    {
        //        Name = "aj"
        //    },
        //    IsDefaultOutlet= true,
        //    IsOwner = true
        //};
        GetOutletsByUserId();

    }       

    private async Task GetOutletsByUserId()
    {
        var result = await _service.GetAllOutletsByUserId();
        foreach (var data in result)
        {
            OutletUser.Add(data);
        }
    }
}
