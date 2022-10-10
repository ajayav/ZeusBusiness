namespace ZeusBusiness.MVVM.Model.Generics.General
{
    [Flags]
    public enum OutletPermission
    {
        None = 0,
        SalesReport = 1,
        StockReport = 2,
        PurchaseReport = 4,
        SaleReturnReport = 8,
        PurchaseReturnReport = 16,
        StockTransfer = 32,
        ItemCreation = 64,
        PurchaseOrder = 128,
        StockUpdation = 256,
        EventLog = 512,
        CustomerManagement = 1024,
    }
}
