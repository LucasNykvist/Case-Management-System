using Microsoft.EntityFrameworkCore;

namespace CMS.DBModels
{
    public class CMSContext : DbContext
    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<Case> Cases { get; set; }
        public DbSet<CaseNote> CaseNotes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=CMSDatabase;Trusted_Connection=True;");
        }
    }
}
