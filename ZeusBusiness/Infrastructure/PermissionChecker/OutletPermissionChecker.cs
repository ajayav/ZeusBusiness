using ZeusBusiness.Controls.AppDrawer;
using ZeusBusiness.Model.Generics.General;
using ZeusBusiness.Model.Icons;
using ZeusBusiness.View.Pages.Crm;
using ZeusBusiness.View.Pages.Dashboard;
using ZeusBusiness.View.Pages.Inventory;
using ZeusBusiness.View.Pages.Report;
using ZeusBusiness.View.Pages.Settings;

namespace ZeusBusiness.Infrastructure.PermissionChecker
{
    public class OutletPermissionChecker
    {
        public async static Task AddFlyoutItems()
        {
            AppShell.Current.FlyoutHeader = new FlyoutHeaderControl();
            var flyoutItem = new FlyoutItem();
            //flyoutItem.Title = "Dashboard";
            //flyoutItem.Route = nameof(OwnerDashboardPage);
            flyoutItem.FlyoutDisplayOptions = FlyoutDisplayOptions.AsMultipleItems;
            if (App.OutletUser.Outlet.PurchasePlan.HasFlag(PurchasePlan.Inventory))
            {
                flyoutItem.Items.Add(new ShellContent
                {
                    Title = "Inventory",
                    Icon = AppDrawer.Inventory,
                    ContentTemplate = new DataTemplate(typeof(InventoryPage))

                }) ;   
                
            }

            if (App.OutletUser.Outlet.PurchasePlan.HasFlag(PurchasePlan.Report))
            {
                flyoutItem.Items.Add(new ShellContent
                {
                    Title = "Report",
                    Icon = AppDrawer.Report,
                    ContentTemplate = new DataTemplate(typeof(ReportPage))
                }) ;
            }

            if (App.OutletUser.Outlet.PurchasePlan.HasFlag(PurchasePlan.Crm))
            {
                flyoutItem.Items.Add(new ShellContent
                {
                    Title = "Crm",
                    Icon = AppDrawer.Crm,
                    ContentTemplate = new DataTemplate(typeof(CrmPage))
                });
            }

            flyoutItem.Items.Add(new ShellContent
            {
                Title = "Settings",
                Icon = AppDrawer.Setting,
                ContentTemplate = new DataTemplate(typeof(SettingsPage))
            });

            await Shell.Current.GoToAsync($"//{nameof(OwnerDashboardPage)}");
        }
    }
}
