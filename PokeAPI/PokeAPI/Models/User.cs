using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace PokeAPI.Models
{
    public class User : IdentityUser
    {
        public List<RefreshToken> RefreshTokens { get; set; }
    }
}
