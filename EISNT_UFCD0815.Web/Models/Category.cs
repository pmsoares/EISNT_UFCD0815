using System.ComponentModel.DataAnnotations;

namespace EISNT_UFCD0815.Web.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = null!;

        public int DisplayOrder { get; set; }
    }
}
