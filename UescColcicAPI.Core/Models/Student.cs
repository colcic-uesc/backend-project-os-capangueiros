using System.ComponentModel.DataAnnotations;

namespace UescColcicAPI.Core
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }

        [Required]
        [StringLength(100)]
        public string Registration { get; set; } = string.Empty;

        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string Course { get; set; } = string.Empty;

        public string Bio { get; set; } = string.Empty;
    }
}