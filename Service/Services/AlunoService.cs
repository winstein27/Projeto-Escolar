using Model.Models;
using Persistence.DAL;
using System.Linq;

namespace Service.Services
{
    public class AlunoService
    {
        private AlunoDAL alunoDAL = new AlunoDAL();

        public IQueryable<Aluno> ObterAlunosOrdenadosPorNome()
        {
            return alunoDAL.ObterAlunosOrdenadosPorNome();
        }

        public void GravarAluno(Aluno aluno)
        {
            alunoDAL.GravarAluno(aluno);
        }

        public Aluno ObterAlunoPorId(long id)
        {
            return alunoDAL.ObterAlunoPorId(id);
        }

        public Aluno RemoverAlunoPorId(long id)
        {
            return alunoDAL.RemoverAlunoPorId(id);
        }
    }
}
