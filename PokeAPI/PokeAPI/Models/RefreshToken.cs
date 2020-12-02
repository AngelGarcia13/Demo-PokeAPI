using System;
namespace PokeAPI.Models
{
    public class RefreshToken
    {
        public Guid RefreshTokenId { get; set; }
        public User User { get; set; }
        public string UserId { get; set; }
        public string Token { get; set; }
        public DateTime Expires { get; set; }
    }
}
