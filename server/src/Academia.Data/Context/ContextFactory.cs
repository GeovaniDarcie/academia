using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Academia.Data.Context
{
    public class ContextFactory : IDesignTimeDbContextFactory<AcademiaContext>
    {
        public AcademiaContext CreateDbContext(string[] args)
        {
            var connectionString = "Integrated Security=SSPI;Persist Security Info=False;User ID=sa;Initial Catalog=academiadb;Data Source=localhost\\SQLEXPRESS";
            var optionsBuilder = new DbContextOptionsBuilder<AcademiaContext>();
            optionsBuilder.UseSqlServer(connectionString);
            return new AcademiaContext(optionsBuilder.Options);
        }
    }
}