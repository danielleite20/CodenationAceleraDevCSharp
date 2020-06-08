using Microsoft.EntityFrameworkCore;

namespace Codenation.Challenge.Models
{
    public class CodenationContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Submission> Submissions { get; set; }
        public DbSet<Candidate> Candidates { get; set; }
        public DbSet<Acceleration> Accelerations { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Codenation.Challenge.Models.Challenge> Challenges { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Codenation;Trusted_Connection=True");   
            // optionsBuilder.UseSqlServer("Server=localhost;Database=Codenation;User ID=SA;Password=071090Mcr");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Candidate>()
                .HasKey(c => new { c.UserId, c.AccelerationId, c.CompanyId, c.Status });
            modelBuilder.Entity<Submission>()
                .HasKey(s => new { s.UserId, s.ChallengeId, s.Score });
        }
    }
}