using Model.Models;
using Persistence.Contexts;
using System.Data.Entity;
using System.Linq;

namespace Persistence.DAL
{
    public class ProfessorDAL
    {
        private EFContext context = new EFContext();

        public IQueryable<Professor> ObterProfessoresOrdenadosPorNome()
        {
            return context.Professores.OrderBy(p => p.Nome);
        }

        public void GravarProfessor(Professor professor)
        {
            if (professor.Id == null)
                context.Professores.Add(professor);
            else
                context.Entry(professor).State = EntityState.Modified;
            context.SaveChanges();
        }

        public Professor ObterProfessorPorId(long id)
        {
            return context.Professores.Find(id);
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
