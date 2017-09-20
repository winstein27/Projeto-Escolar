using Model.Models;
using Persistence.Contexts;
using System.Data.Entity;
using System.Linq;

namespace Persistence.DAL
{
    public class TurmaDAL
    {
        private EFContext context = EFContext.ObterContext();

        public IQueryable<Turma> ObterTurmasOrdenadasPorDisciplina()
        {
            return context.Turmas.OrderBy(t => t.Disciplina.Nome).Include(
                t => t.Disciplina).Include(t => t.Professor);
        }

        public void GravarTurma(Turma turma)
        {
            if (turma.Id == null)
                context.Turmas.Add(turma);
            else
            {
                context.Entry(turma).State = EntityState.Modified;
            }
            context.SaveChanges();
        }

        public Turma ObterTurmaPorId(long id)
        {
            return context.Turmas.Where(t => t.Id == id).Include(
                t => t.Disciplina).Include(t => t.Professor).First();
        }

        public Turma RemoverTurmaPorId(long id)
        {
            Turma turma = ObterTurmaPorId(id);
            context.Turmas.Remove(turma);
            context.SaveChanges();
            return turma;
        }
    }
}
