using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Model.Models
{
    public class Professor : Pessoa
    {
        public virtual ICollection<Disciplina> DisciplinasQuePodeMinistrar { get; set; }
        public virtual ICollection<Turma> TurmasQueMinistra { get; set; }
    }
}
