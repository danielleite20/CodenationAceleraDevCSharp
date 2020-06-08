using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Codenation.Challenge.Models
{   
    [Table("candidate")]
    public class Candidate
    {   
        [Column("status")]
        [Required]
        public int Status { get; set; }
        
        [Column("created_at")]
        [Timestamp]
        [Required]
        public DateTime CreatedAt { get; set; }
        
        [Column("user_id")]
        [ForeignKey("User")]
        [Required]
        public int UserId { get; set; }
        public User User { get; set; }
        

        [Column("acceleration_id")]
        [ForeignKey("Acceleration")]
        [Required]
        public int AccelerationId { get; set; }
        public Acceleration Acceleration { get; set; }
        
        [Column("company_id")]
        [ForeignKey("Company")]
        [Required]
        public int CompanyId { get; set; }
        public Company Company { get; set; }
    }
}