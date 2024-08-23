using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Npgsql.EntityFrameworkCore.PostgreSQL.Infrastructure;
using System;

namespace Academia.Data.Context
{
    public class ContextFactory : IDesignTimeDbContextFactory<AcademiaContext>
    {
        public AcademiaContext CreateDbContext(string[] args)
        {
            var connectionString = "Server=localhost;Port=5432;Database=Academia;User Id=postgres;Password=8161;";
            var optionsBuilder = new DbContextOptionsBuilder<AcademiaContext>();
            optionsBuilder.UseNpgsql(connectionString);
            return new AcademiaContext(optionsBuilder.Options);
        }
    }
}