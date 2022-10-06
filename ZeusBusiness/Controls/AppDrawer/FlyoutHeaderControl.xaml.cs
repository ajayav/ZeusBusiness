namespace ZeusBusiness.Controls.AppDrawer;

public partial class FlyoutHeaderControl : StackLayout
{
	public FlyoutHeaderControl()
	{
		InitializeComponent();
        if (App.AuthResponse != null)
        {
            nameLbl.Text = App.AuthResponse.Name;
            emailLbl.Text = App.AuthResponse.Email;
        }
    }
}