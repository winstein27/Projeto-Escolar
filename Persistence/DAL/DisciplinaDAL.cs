using Model.Models;
using Persistence.Contexts;
using System.Data.Entity;
using System.Linq;

namespace Persistence.DAL
{
    public class DisciplinaDAL
    {
        private EFContext context = EFContext.ObterContext();

        public IQueryable<Disciplina> ObterDisciplinasOrdenadasPorNome()
        {
            return context.Disciplinas.OrderBy(d => d.Nome);
        }

        public Disciplina ObterDisciplinaPorId(long id)
        {
            return context.Disciplinas.Where(d => d.Id == id).Include(
                d => d.PreRequisitos).Include(d => d.ProfessoresHabilitados).
                First();
        }
        
        public void GravarDisciplina(Disciplina disciplina)
        {
            if (disciplina.Id == null)
                context.Disciplinas.Add(disciplina);
            else
                context.Entry(disciplina).State = EntityState.Modified;
                
                
            context.SaveChanges();
        }

        public Disciplina RemoverDisciplinaPorId(long id)
        {
            Disciplina disciplina = ObterDisciplinaPorId(id);
            context.Disciplinas.Remove(disciplina);
            context.SaveChanges();
            return disciplina;
        }
    }
}
