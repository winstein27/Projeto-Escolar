using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Model.Models
{
    public class Disciplina
    {
        public long? Id { get; set; }
        [Required(ErrorMessage = "Informe o nome.")]
        [StringLength(100, ErrorMessage = "Nome deve ter no máximo 100 caracteres.")]
        public String Nome { get; set; }
        public ICollection<Disciplina> PreRequisitos { get; set; }
        public virtual ICollection<Professor> ProfessoresHabilitados { get; set; }
        public virtual ICollection<Turma> Turmas { get; set; }
    }
}
