using System.ComponentModel.DataAnnotations;

namespace BLeader.ViewModels
{
    public class ContactViewModel
    {
        [Required]
        [MinLength(3, ErrorMessage = "Input more that 3 signs")]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        [MaxLength(50)]
        public string Email { get; set; }
    }
}
