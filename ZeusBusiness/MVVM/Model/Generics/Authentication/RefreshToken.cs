namespace ZeusBusiness.MVVM.Model.Generics.Authentication
{
    public class RefreshToken
    {
        public int Id { get; set; }
        public User Account { get; set; }
        public string Token { get; set; }
        public DateTime ExpiryDateUTC { get; set; }
        public bool IsExpired => DateTime.UtcNow >= ExpiryDateUTC;
        public DateTime CreatedDateUTC { get; set; }
        public string CreatedByIp { get; set; }
        public DateTime? RevokedDateUTC { get; set; }
        public string RevokedByIp { get; set; }
        public string ReplacedByToken { get; set; }
        public bool IsActive => RevokedDateUTC == null && !IsExpired;
    }
}
