using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Academia.Data.Context
{
    public class ContextFactory : IDesignTimeDbContextFactory<AcademiaContext>
    {
        public AcademiaContext CreateDbContext(string[] args)
        {
            var connectionString = "Integrated Security=true;Initial Catalog=academiadb;Data Source=DESKTOP-1P1RRGF\\SQLEXPRESS";
            var optionsBuilder = new DbContextOptionsBuilder<AcademiaContext>();
            optionsBuilder.UseSqlServer(connectionString);
            return new AcademiaContext(optionsBuilder.Options);
        }
    }
}