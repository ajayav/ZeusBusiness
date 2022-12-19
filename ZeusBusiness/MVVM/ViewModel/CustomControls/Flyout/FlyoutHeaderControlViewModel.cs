using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ZeusBusiness.Abstraction.Infrastructure.PermissionGuard;

namespace ZeusBusiness.MVVM.ViewModel.CustomControls.Flyout
{
    public partial class FlyoutHeaderControlViewModel : ObservableObject
    {
        #region PRIVATE INSTANCE FEILD
        private IOutletUserGuard _guard;

        #endregion

        #region CONSTRUCTOR
        public FlyoutHeaderControlViewModel(IOutletUserGuard guard)
        {
            _guard = guard;
        }
        #endregion       

        [RelayCommand]
        public async void ChangeOutlet()
        {

        }

    }
}
