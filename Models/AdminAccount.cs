using System.ComponentModel.DataAnnotations;

namespace Portfolio.Models
{
    public class AdminAccount
    {
        [Key]
        public int Id { get; set; }
        [DataType(DataType.Text)]
        [StringLength(15, MinimumLength = 6, ErrorMessage = "Username must be at least 6 characters and no more than 15 characters.")]
        public string UserName { get; set; } = "";

        [DataType(DataType.Password)]
        [StringLength(15, MinimumLength = 6, ErrorMessage = "Password must have at least 6 characters and no more than 15 characters.")]
        public string Password { get; set; } = "";
    }
}
