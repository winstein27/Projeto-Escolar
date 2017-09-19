using Model.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProjetoEscolar.Models
{
    public class DisciplinaEditModel
    {
        public Disciplina Disciplina { get; set; }
        public IEnumerable<Disciplina> DisciplinasNaoPreRequisitos { get; set; }
        public IEnumerable<Professor> ProfessoresNaoHabilitados { get; set; }

    }

    public class DisciplinaSaveModel
    {
        [Required]
        public Disciplina Disciplina { get; set; }
        public string[] IdsDisciplinasParaAdicionar { get; set; }
        public string[] IdsDisciplinasParaRemover { get; set; }
        public string[] IdsProfessoresParaAdicionar { get; set; }
        public string[] IdsProfessoresParaRemover { get; set; }
    }
}