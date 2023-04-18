using Microsoft.EntityFrameworkCore;
using RepoMinerAnalysis.Models.Domain;

namespace RepoMinerAnalysis.Data
{
    public class RepoMinerDbContext : DbContext
    {
        public RepoMinerDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var roles = new List<Roles>() {
                new Roles(){
                    Id = Guid.Parse("554e22fc-aa28-4ba4-ae2e-bc409bfc4802"),
                    Role = "Admin"
                },
                new Roles(){
                    Id = Guid.Parse("8abd6df2-b423-4b67-8686-512e3c81811f"),
                    Role = "Collaborator"
                }
            };
            modelBuilder.Entity<Roles>().HasData(roles);
        }
    }
}
