using System.ComponentModel.DataAnnotations;

namespace EISNT_UFCD0815.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        [Display(Name = "Category Name")]
        public string Name { get; set; } = null!;

        [Range(1, 100, ErrorMessage = "Display Order must be between 1-100")]
        [Display(Name = "Display Order")]
        public int DisplayOrder { get; set; }
    }
}
