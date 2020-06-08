using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Codenation.Challeng.Models
{
    [Table("acceleration")]
    public class Acceleration
    { 
        [Key]
        [Column("id"), Required]
        public int Id { get; set; }

        [Column("name")]
        [StringLength(100)]
        [Required]
        public string Name { get; set; }
    
        [Column("slug")]
        [StringLength(50)]
        [Required]
        public string Slug { get; set; }

        [Column("created_at")]
        [Timestamp]
        [Required]
        public DateTime CreatedAt { get; set; }
        
        [Column("challenge_id")]
        [ForeignKey("Challenge")]
        [Required]
        public int ChallengeId { get; set; }
        public Codenation.Challenge.Models.Challenge Challenge { get; set; }
        
        public List<Codenation.Challenge.Models.Candidate> Candidates { get; set; }
    }
}