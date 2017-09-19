using Model.Models;
using Persistence.Contexts;
using System.Data.Entity;
using System.Linq;

namespace Persistence.DAL
{
    public class AlunoDAL
    {
        private EFContext context = EFContext.ObterContext();

        public IQueryable<Aluno> ObterAlunosOrdenadosPorNome()
        {
            return context.Alunos.OrderBy(a => a.Nome);
        }

        public Aluno ObterAlunoPorId(long id)
        {
            return context.Alunos.Find(id);
        }

        public void GravarAluno(Aluno aluno)
        {
            if (aluno.Id == null)
                context.Alunos.Add(aluno);
            else
                context.Entry(aluno).State = EntityState.Modified;

            context.SaveChanges();
        }

        public Aluno RemoverAlunoPorId(long id)
        {
            Aluno aluno = ObterAlunoPorId(id);
            context.Alunos.Remove(aluno);
            context.SaveChanges();
            return aluno;
        }
    }
}
