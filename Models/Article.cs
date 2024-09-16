using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _12_EntityFramworkEx.Models
{
    public class Article
    {
        [Key]
        public int Id { get; set; }
        [StringLength(100, MinimumLength = 5, ErrorMessage = "{0} phải dài từ {2} đến {1}")]
        [Required(ErrorMessage = "{0} phải nhập")]
        [Column(TypeName = "nvarchar")]
        [Display(Name = "Tiêu đề")]
        public string Title { get; set; }
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "{0} phải nhập")]
        [Display(Name = "Ngày tạo")]
        public DateTime Created {  get; set; }

        [Column(TypeName = "ntext")]
        [Display(Name = "Nội dung")]
        [Required(ErrorMessage = "{0} phải nhập")]
        public string? Content { get; set; }
    }
}
