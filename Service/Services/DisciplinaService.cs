using Model.Models;
using Persistence.DAL;
using System.Linq;
using System;

namespace Service.Services
{
    public class DisciplinaService
    {
        private DisciplinaDAL disciplinaDAL = new DisciplinaDAL();

        public IQueryable<Disciplina> ObterDisciplinasOrdenadasPorNome()
        {
            return disciplinaDAL.ObterDisciplinasOrdenadasPorNome();
        }

        public void GravarDisciplina(Disciplina disciplina)
        {
            disciplinaDAL.GravarDisciplina(disciplina);
        }

        public Disciplina RemoverDisciplinaPorId(long id)
        {
            return disciplinaDAL.RemoverDisciplinaPorId(id);
        }

        public Disciplina ObterDisciplinaPorId(long id)
        {
            return disciplinaDAL.ObterDisciplinaPorId(id);
        }
    }
}
