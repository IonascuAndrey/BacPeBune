using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace BacPeBune.Models
{
    public class UserReward
    {
        [Key]
        public int UserRewardId { get; set; }

        [Required]
        public required string UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public required IdentityUser User { get; set; } 

        [Required]
        public required int QuizId { get; set; }

        [ForeignKey(nameof(QuizId))]
        public required Quiz Quiz { get; set; }

        [Required]
        public required int Reward { get; set; }
       
        public DateTime Date { get; set; } = DateTime.Now;


    }
}