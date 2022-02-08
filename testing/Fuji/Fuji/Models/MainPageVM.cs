using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Fuji.Models
{
    // #nullable disable
    public class MainPageVM
    {
        public IdentityUser? TheIdentityUser { get; set; }
        public FujiUser? TheFujiUser { get; set; }
        public IEnumerable<Apple>? Apples { get; set; }

        [Required]
        public string? FirstName { get; set; }
    }
}
