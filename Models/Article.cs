using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _12_EntityFramworkEx.Models
{
    public class Article
    {
        [Key]
        public int Id { get; set; }
        [StringLength(100)]
        [Required]
        [Column(TypeName = "nvarchar")]
        public string Title { get; set; }
        [DataType(DataType.Date)]
        [Required]
        public DateTime Created {  get; set; }

        [Column(TypeName = "ntext")]
        public string Content { get; set; }
    }
}
