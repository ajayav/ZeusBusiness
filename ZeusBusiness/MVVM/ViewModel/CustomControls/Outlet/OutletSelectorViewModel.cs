using ZeusBusiness.Abstraction.Services.General;
using ZeusBusiness.MVVM.Model.Generics.General;
using ZeusBusiness.MVVM.ViewModel.ViewBinder;

namespace ZeusBusiness.MVVM.ViewModel.CustomControls.Outlet;

public partial class OutletSelectorViewModel : BaseViewModel
{
    private IOutletService _service;


    public List<OutletUser> OutletUser { get; set; } = new List<OutletUser>();
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
