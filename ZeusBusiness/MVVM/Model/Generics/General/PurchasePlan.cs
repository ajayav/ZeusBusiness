namespace ZeusBusiness.MVVM.Model.Generics.General
{
    [Flags]
    public enum PurchasePlan
    {
        None = 0,
        Inventory = 1,
        Report = 2,
        Crm = 4,
        CampusDude = 8,
        KoT = 16,
    }
}
