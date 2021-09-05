using Microsoft.EntityFrameworkCore;
using Academia.Domain.Entities;
using Academia.Data.Mapping;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Academia.Data.Context
{
    public class AcademiaContext : IdentityDbContext<ApplicationUser>
    {
        public AcademiaContext(DbContextOptions<AcademiaContext> options)
        : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Aluno>(new AlunoMap().Configure);
        }

        public DbSet<AcademiaEntity> Academias { get; set; }
        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Admin> Admin { get; set; }
        public DbSet<Professor> Professores { get; set; }


        public DbSet<Anamnese> Anamneses { get; set; }
        public DbSet<Antropometria> Antropometrias { get; set; }
        public DbSet<DobrasCutaneas> DobrasCutaneas { get; set; }

        public DbSet<Atividade> Atividades { get; set; }
        public DbSet<Treino> Treinos { get; set; }
    }
}