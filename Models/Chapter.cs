using System.ComponentModel.DataAnnotations;

namespace BacPeBune.Models
{
    public class Chapter
    {
        [Key]
        public required string ChapterId { get; set; }

        [Required]
        public required string Name { get; set; }

        [Required]
        public required int YearID { get; set; }
    }
}