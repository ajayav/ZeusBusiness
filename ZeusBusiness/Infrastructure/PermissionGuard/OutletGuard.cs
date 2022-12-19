using ZeusBusiness.Abstraction.Infrastructure.PermissionGuard;
using ZeusBusiness.MVVM.Model.Generics.General;
using ZeusBusiness.MVVM.Model.Icons;
using ZeusBusiness.MVVM.View.Pages.Crm;
using ZeusBusiness.MVVM.View.Pages.Dashboard;
using ZeusBusiness.MVVM.View.Pages.Inventory;
using ZeusBusiness.MVVM.View.Pages.Report;
using ZeusBusiness.MVVM.View.Pages.Settings;

namespace ZeusBusiness.Infrastructure.PermissionGuard;

public class OutletGuard
{
    private IOutletUserGuard _guard;

    public OutletGuard(IOutletUserGuard guard)
    {
        _guard = guard;
    }
    #region PUBLIC METHODS
    public static async Task AddFlyoutItems()
    {

        OutletUser outletUser = new OutletUser();

        var flyoutItem = new FlyoutItem();
        var currentFlyout = AppShell.Current.Items.FirstOrDefault(x => x.GetType() == typeof(FlyoutItem));
        if (currentFlyout != null)
            AppShell.Current.Items.Remove(currentFlyout);
        flyoutItem.FlyoutDisplayOptions = FlyoutDisplayOptions.AsMultipleItems;

        if (!App.OutletUser.IsOwner)
        {
            flyoutItem.Items.Add(new ShellContent
            {
                Title = "Dashboard",
                ContentTemplate = new DataTemplate(typeof(UserDashboardPage)),
                Icon = AppDrawer.Dashboard,
                Route = nameof(UserDashboardPage)
            });

            flyoutItem.Items.Add(new ShellContent
            {
                Title = "Settings",
                Icon = AppDrawer.Setting,
                ContentTemplate = new DataTemplate(typeof(SettingsPage))
            });
            AppShell.Current.Items.Add(flyoutItem);
            if (DeviceInfo.Platform == DevicePlatform.WinUI)
            {
                AppShell.Current.Dispatcher.Dispatch(async () =>
                {
                    await Shell.Current.GoToAsync($"//{nameof(UserDashboardPage)}");
                });
            }
            else
            {
                await Shell.Current.GoToAsync($"//{nameof(UserDashboardPage)}");
            }

        }
        else
        {
            flyoutItem.Items.Add(new ShellContent
            {
                Title = "Dashboard",
                ContentTemplate = new DataTemplate(typeof(OwnerDashboardPage)),
                Icon = AppDrawer.Dashboard,
                Route = nameof(OwnerDashboardPage)
            });

            if (App.OutletUser.Outlet.PurchasePlan.HasFlag(PurchasePlan.Inventory))
            {
                flyoutItem.Items.Add(new ShellContent
                {
                    Title = "Inventory",
                    Icon = AppDrawer.Inventory,
                    ContentTemplate = new DataTemplate(typeof(InventoryPage))
                });
            }

            if (App.OutletUser.Outlet.PurchasePlan.HasFlag(PurchasePlan.Report))
            {
                flyoutItem.Items.Add(new ShellContent
                {
                    Title = "Report",
                    Icon = AppDrawer.Report,
                    ContentTemplate = new DataTemplate(typeof(ReportPage))
                });
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

            AppShell.Current.Items.Add(flyoutItem);
            if (DeviceInfo.Platform == DevicePlatform.WinUI)
            {
                AppShell.Current.Dispatcher.Dispatch(async () =>
                {
                    await Shell.Current.GoToAsync($"//{nameof(OwnerDashboardPage)}");
                });
            }
            else
            {
                await Shell.Current.GoToAsync($"//{nameof(OwnerDashboardPage)}");
            }

        }
    }
    #endregion


}
