using Model.Models;
using Persistence.DAL;
using System.Linq;

namespace Service.Services
{
    public class ProfessorService
    {
        private ProfessorDAL professorDAL = new ProfessorDAL();

        public IQueryable<Professor> ObterProfessoresOrdenadosPorNome()
        {
            return professorDAL.ObterProfessoresOrdenadosPorNome();
        }

        public Professor ObterProfessorPorId(long id)
        {
            return professorDAL.ObterProfessorPorId(id);
        }

        public void GravarProfessor(Professor professor)
        {
            professorDAL.GravarProfessor(professor);
        }

        public Professor RemoverProfessorPorId(long id)
        {
            return professorDAL.RemoverProfessorPorId(id);
        }
    }
}
