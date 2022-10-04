using CommunityToolkit.Mvvm.ComponentModel;

namespace ZeusBusiness.ViewModel.ViewBinder
{
    public partial class BaseViewModel : ObservableObject
    {
        [ObservableProperty]
        public bool _isBusy;

        [ObservableProperty]
        public string _title;
    }
}
