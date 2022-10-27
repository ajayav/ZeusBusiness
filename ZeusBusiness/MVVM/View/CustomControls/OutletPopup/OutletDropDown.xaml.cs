using MauiPopup;
using System.Collections;
using System.Windows.Input;

namespace ZeusBusiness.MVVM.View.CustomControls.OutletPopup;

public partial class OutletDropDown : Frame
{
    public OutletDropDown()
    {
        InitializeComponent();
    }

    #region PROPERTIES
    public DataTemplate ItemTemplate { get; set; }
    public double PickerHeight { get; set; }
    public string DisplayMember { get; set; }

    public static readonly BindableProperty ItemSourceProperty = BindableProperty.Create(
       propertyName: nameof(ItemSource),
       returnType: typeof(IEnumerable),
       declaringType: typeof(OutletDropDown),
       defaultBindingMode: BindingMode.OneWay);

    public IEnumerable ItemSource
    {
        get => (IEnumerable)GetValue(ItemSourceProperty);
        set => SetValue(ItemSourceProperty, value);
    }

    public static readonly BindableProperty PlaceholderProperty = BindableProperty.Create(
       propertyName: nameof(Placeholder),
       returnType: typeof(string),
       declaringType: typeof(OutletDropDown),
       defaultBindingMode: BindingMode.OneWay,
       propertyChanged: PlaceholderPropertyChanged);

    public string Placeholder
    {
        get => (string)GetValue(PlaceholderProperty);
        set => SetValue(PlaceholderProperty, value);
    }

    public static readonly BindableProperty CurrentItemProperty = BindableProperty.Create(
       propertyName: nameof(CurrentItem),
       returnType: typeof(object),
       declaringType: typeof(OutletDropDown),
       defaultBindingMode: BindingMode.TwoWay,
       propertyChanged: CurrentItemPropertyChanged
       );

    public object CurrentItem
    {
        get => (object)GetValue(CurrentItemProperty);
        set => SetValue(CurrentItemProperty, value);
    }

    public static readonly BindableProperty IsLoadingProperty = BindableProperty.Create(
      propertyName: nameof(IsLoading),
      returnType: typeof(bool),
      declaringType: typeof(OutletDropDown),
      defaultBindingMode: BindingMode.OneWay
      );

    public bool IsLoading
    {
        get => (bool)GetValue(IsLoadingProperty);
        set => SetValue(IsLoadingProperty, value);
    }

    public static readonly BindableProperty OpenPickerCommandProperty = BindableProperty.Create(
        propertyName: nameof(OpenPickerCommand),
        returnType: typeof(ICommand),
        declaringType: typeof(OutletDropDown),
        defaultBindingMode: BindingMode.OneWay);

    public ICommand OpenPickerCommand
    {
        get => (ICommand)GetValue(OpenPickerCommandProperty);
        set => SetValue(OpenPickerCommandProperty, value);
    }

    public static readonly BindableProperty IsDisplayPickerControlProperty = BindableProperty.Create(
     propertyName: nameof(IsDisplayPickerControl),
     returnType: typeof(bool),
     declaringType: typeof(OutletDropDown),
     defaultBindingMode: BindingMode.TwoWay,
     propertyChanged: IsDisplayPickerControlPropertyChanged
     );

    public bool IsDisplayPickerControl
    {
        get => (bool)GetValue(IsDisplayPickerControlProperty);
        set => SetValue(IsDisplayPickerControlProperty, value);
    }

    #endregion

    #region EVENT HANDLER

    private static void PlaceholderPropertyChanged(BindableObject bindable, object oldValue, object newValue)
    {
        var controls = (OutletDropDown)bindable;
        if (controls.CurrentItem != null)
        {
            if (newValue != null)
            {
                controls.lblDropDown.Text = newValue.ToString();
            }
        }
    }

    private static void CurrentItemPropertyChanged(BindableObject bindable, object oldValue, object newValue)
    {
        var controls = (OutletDropDown)bindable;
        if (newValue != null)
        {
            if (!string.IsNullOrWhiteSpace(controls.DisplayMember))
                controls.lblDropDown.Text = newValue.GetType().GetProperty(controls.DisplayMember).GetValue(newValue, null).ToString();
        }
    }

    private async static void IsDisplayPickerControlPropertyChanged(BindableObject bindable, object oldValue, object newValue)
    {
        var controls = (OutletDropDown)bindable;
        if (newValue != null)
        {
            if ((bool)newValue)
            {
                var response = await PopupAction.DisplayPopup<object>(new OutletPopupView(controls.ItemSource, controls.ItemTemplate, controls.PickerHeight));
                if (response != null)
                {
                    controls.CurrentItem = response;
                }
                controls.IsDisplayPickerControl = false;
            }
        }
    }

    private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
    {
        OpenPickerCommand?.Execute(null);
    }
    #endregion
}