using Microsoft.EntityFrameworkCore;
using Academia.Domain.Models;

namespace Academia.Data.Repositorios
{
    public class AlunoContext : DbContext
    {
        public AlunoContext(DbContextOptions<AlunoContext> options)
            : base(options)
        {
        }
        public DbSet<Aluno> Alunos { get; set; }
    }
}