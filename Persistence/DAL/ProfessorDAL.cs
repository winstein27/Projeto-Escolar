using Model.Models;
using Persistence.Contexts;
using System.Data.Entity;
using System.Linq;

namespace Persistence.DAL
{
    public class ProfessorDAL
    {
        private EFContext context = EFContext.ObterContext();

        public IQueryable<Professor> ObterProfessoresOrdenadosPorNome()
        {
            return context.Professores.OrderBy(p => p.Nome);
        }

        public void GravarProfessor(Professor professor)
        {
            if (professor.Id == null)
                context.Professores.Add(professor);
            else
            {
                var local = context.Professores.Find(professor.Id);
                context.Entry(local).State = EntityState.Detached;

                context.Entry(professor).State = EntityState.Modified;
            }
                
            context.SaveChanges();
        }

        public Professor ObterProfessorPorId(long id)
        {
            return context.Professores.Where(p => p.Id == id).
                Include(p => p.DisciplinasQuePodeMinistrar).
                Include(p => p.TurmasQueMinistra).First();
        }

        public Professor RemoverProfessorPorId(long id)
        {
            Professor professor = ObterProfessorPorId(id);
            context.Professores.Remove(professor);
            context.SaveChanges();
            return professor;
        }
    }
}
