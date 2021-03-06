using System.Collections;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Codenation.Challenge.Models
{
    [Table("user")]
    public class User
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        
        [Column("full_name")]
        [StringLength(100)]
        [Required]
        public string Fullname { get; set; }
        
        [Column("email")]
        [StringLength(100)]
        [Required]
        public string Email { get; set; }
        
        [Column("nickname")]
        [StringLength(50)]
        [Required]
        public string Nickname { get; set; }
        
        [Column("password")]
        [StringLength(255)]
        [Required]
        public string Password { get; set; }
        
        [Column("created_at")]
        [Timestamp]
        [Required]
        public DateTime CreatedAt { get; set; }
        
        public List<Candidate> Candidates { get; set; }
        public List<Submission> Submissions { get; set; }

    }
}