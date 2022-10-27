using MauiPopup;
using MauiPopup.Views;
using System.Collections;

namespace ZeusBusiness.MVVM.View.CustomControls.OutletPopup;

public partial class OutletPopupView : BasePopupPage
{
	public OutletPopupView(IEnumerable itemSource, DataTemplate itemTemplate, double pickerHeight = 200)
	{
		InitializeComponent();
        clPicker.ItemsSource = itemSource;
        clPicker.ItemTemplate = itemTemplate;
        clPicker.HeightRequest = pickerHeight;
    }

	private void clPicker_SelectionChanged(object sender, SelectionChangedEventArgs e)
	{
        var currentOutlet = e.CurrentSelection.FirstOrDefault();
        PopupAction.ClosePopup(currentOutlet);
    }
}