using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Model.Models
{
    public class Aluno : Pessoa
    {
        [DisplayName("Matrícula")]
        [Required(ErrorMessage = "Informe a matrícula.")]
        public long? Matricula { get; set; }
    }
}