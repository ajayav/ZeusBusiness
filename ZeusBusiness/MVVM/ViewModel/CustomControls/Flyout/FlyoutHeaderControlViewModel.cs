using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
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

        public ObservableCollection<Outlet> Outlets { get; set; } = new ObservableCollection<Outlet>();

        [ObservableProperty]
        private bool _isLoading;

        [ObservableProperty]
        private bool _isDisplayPicker;

        [ObservableProperty]
        private Outlet _currentOutlet;

        [RelayCommand]
        public async void OpenPicker()
        {
            IsLoading = true;
            await Task.Delay(2000);
            Outlets.Clear();
            Outlets.Add(new Outlet { Name = "Mint Super Bazar" });
            Outlets.Add(new Outlet { Name = "Mint Hebbal" });
            Outlets.Add(new Outlet { Name = "Mint Wtf" });
            Outlets.Add(new Outlet { Name = "Smart Infotech" });
            Outlets.Add(new Outlet { Name = "Shopwel" });
            Outlets.Add(new Outlet { Name = "All Market" });
            Outlets.Add(new Outlet { Name = "All Season" });

            IsLoading = false;
            IsDisplayPicker = true;
        }

    }
}
