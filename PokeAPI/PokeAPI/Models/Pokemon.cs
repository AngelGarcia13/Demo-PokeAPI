using System;
using System.ComponentModel.DataAnnotations;

namespace PokeAPI.Models
{
    public class Pokemon
    {
        [Required]
        public string Code { get; set; }

        public string ImageUrl { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Type1 { get; set; }

        public string Type2 { get; set; }
    }
}
