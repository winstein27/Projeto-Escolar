using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Model.Models
{
    public class Turma
    {
        public long? Id { get; set; }
        [Required]
        public long? DisciplinaId { get; set; }
        public Disciplina Disciplina { get; set; }
        public long? ProfessorId { get; set; }
        public Professor Professor { get; set; }
        [Required]
        public string Turno { get; set; }
        [Required]
        [DisplayName("Número de Vagas")]
        public int Vagas { get; set; }
    }
}
