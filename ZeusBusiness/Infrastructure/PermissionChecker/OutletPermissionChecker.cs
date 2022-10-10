﻿using ZeusBusiness.Controls.AppDrawer;
using ZeusBusiness.MVVM.Model.Generics.General;
using ZeusBusiness.MVVM.Model.Icons;
using ZeusBusiness.MVVM.View.Pages.Crm;
using ZeusBusiness.MVVM.View.Pages.Dashboard;
using ZeusBusiness.MVVM.View.Pages.Inventory;
using ZeusBusiness.MVVM.View.Pages.Report;
using ZeusBusiness.MVVM.View.Pages.Settings;

namespace ZeusBusiness.Infrastructure.PermissionChecker
{
    public class OutletPermissionChecker
    {
        public async static Task AddFlyoutItems()
        {
            AppShell.Current.FlyoutHeader = new FlyoutHeaderControl();
            var flyoutItem = new FlyoutItem();
            var currentFlyout = AppShell.Current.Items.FirstOrDefault(x => x.GetType() == typeof(FlyoutItem));
            if (currentFlyout != null)
                AppShell.Current.Items.Remove(currentFlyout);
            //flyoutItem.Items.Add(new ShellContent
            //{
            //    Title = "Dashboard",
            //    ContentTemplate = new DataTemplate(typeof(OwnerDashboardPage)),
            //    Route = nameof(OwnerDashboardPage)
            //});
            flyoutItem.FlyoutDisplayOptions = FlyoutDisplayOptions.AsMultipleItems;
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

            if (!AppShell.Current.Items.Contains(flyoutItem))
            {
                AppShell.Current.Items.Add(flyoutItem);
                await Shell.Current.GoToAsync($"//{nameof(OwnerDashboardPage)}");
            }
        }
    }
}
