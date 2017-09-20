using Model.Models;
using Persistence.DAL;
using System.Linq;

namespace Service.Services
{
    public class TurmaService
    {
        private TurmaDAL turmaDAL = new TurmaDAL();

        public IQueryable<Turma> ObterTurmasOrdenadasPorDisciplina()
        {
            return turmaDAL.ObterTurmasOrdenadasPorDisciplina();
        }

        public void GravarTurma(Turma turma)
        {
            turmaDAL.GravarTurma(turma);
        }

        public Turma ObterTurmaPorId(long id)
        {
            return turmaDAL.ObterTurmaPorId(id);
        }

        public Turma RemoverTurmaPorId(long id)
        {
            return turmaDAL.RemoverTurmaPorId(id);
        }
    }
}
