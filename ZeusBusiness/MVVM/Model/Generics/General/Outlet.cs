namespace ZeusBusiness.MVVM.Model.Generics.General
{
    public class Outlet
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Pincode { get; set; }
        public string District { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public DbConfiguration HostDb { get; set; }
        public bool IsActive { get; set; }
        public DateTime LicenseValidityDateUTC { get; set; }
        public string GstIn { get; set; }
        public Organization Organization { get; set; }
        public bool IsGrouped { get; set; }
        public PurchasePlan PurchasePlan { get; set; }
        public bool IsSelected { get; set; }
    }
}
