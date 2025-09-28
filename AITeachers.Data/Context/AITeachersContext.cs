using Microsoft.EntityFrameworkCore;

namespace AITeachers.Data.Context
{
    public class AITeachersContext : DbContext
    {
        public AITeachersContext(DbContextOptions<AITeachersContext> options) : base(options) { }

        public AITeachersContext() { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=localhost;Database=AITeachers;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True");
            }
        }
    }
}
