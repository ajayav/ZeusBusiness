using System.Text.Json.Serialization;

namespace ZeusBusiness.Model.Generics.Authentication
{
    public class AuthenticateResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public Role Role { get; set; }
        public DateTime CreatedDateUTC { get; set; }
        public DateTime? ModifiedDateUTC { get; set; }
        public bool IsVerified { get; set; }
        public string JwtToken { get; set; }

        [JsonIgnore] // refresh token is returned in http only cookie
        public string RefreshToken { get; set; }
    }
}
