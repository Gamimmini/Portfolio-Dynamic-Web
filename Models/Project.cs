using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace Portfolio.Models
{
    
    public class Project
    {
        public int Id { get; set; }

        [MaxLength(100)]
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";
        [MaxLength(250)]
        public string Category { get; set; } = "";
        [MaxLength(250)]
        public string LinkReview { get; set; } = "";
        [MaxLength(250)]
        public string LinkPlay { get; set; } = "";
        [MaxLength(250)]
        public string ImageFileName { get; set; } = "";
        public bool IsHighlighted { get; set; }
    }
}
