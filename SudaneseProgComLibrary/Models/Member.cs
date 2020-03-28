using System.ComponentModel.DataAnnotations;

namespace SudaneseProgComLibrary.Models
{
    public class Member
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "الإسم الكامل")]
        public string FullName { get; set; }

        [Required]
        [Display(Name = "الوظيفة")]
        public string Job { get; set; }
    }
}