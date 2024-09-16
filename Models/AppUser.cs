using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _12_EntityFramworkEx.Models
{
    public class AppUser: IdentityUser
    {
        [Column(TypeName = "nvarchar")]
        [StringLength(50)]
        public string? HomeAdress { get; set; }
    }
}
