using System.ComponentModel.DataAnnotations;

namespace Portfolio.Models
{
    public class ProjectDto
    {
        [Required, MaxLength(100)]
        public string Name { get; set; } = "";
        public string? Description { get; set; }
        [Required, MaxLength(100)]
        public string Category { get; set; } = "";
        public string? LinkReview { get; set; }
        public string? LinkPlay { get; set; }
        public IFormFile? ImageFile { get; set; }

        public bool IsHighlighted { get; set; } = false;
    }
}
