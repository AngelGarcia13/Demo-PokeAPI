using System;
using System.ComponentModel.DataAnnotations;

namespace PokeAPI.Models
{
    public class UserCredentials
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
