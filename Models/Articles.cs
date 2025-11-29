using System.ComponentModel.DataAnnotations;

namespace PersonalBlog.Models
{
    public class Articles
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(200)]
        public string? Title { get; set; } 
        [Required]
        public string? Content { get; set; }
        [Required]
        public DateTime PublishedDate { get; set; }
    }
}
