using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Model.Models
{
    public abstract class Pessoa
    {
        [DisplayName("ID")]
        public long? Id { get; set; }

        [StringLength(100, ErrorMessage = "Nome deve ter no máximo 100 caracteres.")]
        [Required(ErrorMessage = "Informe o nome.")]
        public string Nome { get; set; }

        [DisplayName("Data de nascimento")]
        [Required(ErrorMessage = "Informe a data de nascimento.")]
        [DataType(DataType.Date)]
        public DateTime DataNascimento { get; set; }

        [Required(ErrorMessage = "Informe o RG.")]
        [StringLength(10, ErrorMessage = "RG deve ter no máximo 10 caracteres.")]
        public string RG { get; set; }

        [StringLength(11, ErrorMessage = "CPF deve ter 11 caracteres (Apenas números).",
            MinimumLength = 11)]
        [Required(ErrorMessage = "Informe o CPF.")]
        public string CPF { get; set; }

        [StringLength(100, ErrorMessage = "Endereço deve ter no máximo 100 caracteres.")]
        [Required(ErrorMessage = "Informe o endereço.")]
        [DisplayName("Endereço")]
        public string Endereco { get; set; }

        [StringLength(15, ErrorMessage = "Telefone deve ter no máximo 15 caracteres.")]
        [Required(ErrorMessage = "Informe o telefone.")]
        public string Telefone { get; set; }
    }
}
