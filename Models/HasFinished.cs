using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace BacPeBune.Models
{
    public class HasFinished
    {
        [Key]
        public int HasFinishedID { get; set; }

        [Required]
        public required string UserID { get; set; }

        [ForeignKey(nameof(UserID))]
        public required IdentityUser User { get; set; } 

        [Required]
        public required int LessonID { get; set; }

        [ForeignKey(nameof(LessonID))]
        public required Lesson lesson { get; set; } 
    }
}