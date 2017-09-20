using Model.Models;
using Persistence.Migrations;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Persistence.Contexts
{
    public class EFContext : DbContext
    {
        private static EFContext context;

        public static EFContext ObterContext()
        {
            if (context == null)
                context = new EFContext();
            return context;
        }

        public EFContext() : base("Projeto_Escolar")
        {
            Database.SetInitializer<EFContext>(
                new MigrateDatabaseToLatestVersion<EFContext, Configuration>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Entity<Disciplina>().
                HasMany<Professor>(d => d.ProfessoresHabilitados)
                .WithMany(p => p.DisciplinasQuePodeMinistrar)
                .Map(pd =>
                    {
                        pd.MapLeftKey("DisciplinaId");
                        pd.MapRightKey("ProfessorId");
                        pd.ToTable("DisciplinaProfessor");
                    }
                );
        }

        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Professor> Professores { get; set; }
        public DbSet<Disciplina> Disciplinas { get; set; }
        public DbSet<Turma> Turmas { get; set; }
    }
}