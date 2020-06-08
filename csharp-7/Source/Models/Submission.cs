using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Codenation.Challenge.Models
{
    [Table("submission")]
    public class Submission
    {
        [Column("score")]
        [Required]
        public decimal Score { get; set; }
        
        [Column("created_at")]
        [Timestamp]
        [Required]
        public DateTime CreatedAt { get; set; }
        
        [Column("user_id")]
        [ForeignKey("User")]
        [Required]
        public int UserId { get; set; }
        public User User { get; set; }
        
        [Column("challenge_id")]
        [ForeignKey("Challenge")]
        [Required]
        public int ChallengeId { get; set; }
        public Codenation.Challenge.Models.Challenge Challenge { get; set; }
        
    }
}
