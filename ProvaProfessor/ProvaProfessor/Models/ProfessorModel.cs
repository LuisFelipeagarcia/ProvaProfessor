using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProvaProfessor.Models
{
    public class ProfessorModel
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Nome: ")]
        [Required(ErrorMessage = "Informe o Nome")]
        public string Nome { get; set; }

        [Display(Name = "Disciplina que leciona: ")]
        [Required(ErrorMessage = "Informe a disciplina")]
        public string Disciplina { get; set; }

        [Display(Name = "Telefone: ")]
        [Required(ErrorMessage = "Informe o Telefone")]
        public string Telefone { get; set; }
        [Display(Name = "Endereço: ")]
        [Required(ErrorMessage = "Informe o Endereço")]
        public string Endereco { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "Infore E-mail")]
        [EmailAddress(ErrorMessage = "E-mail inválido")]
        public string Email { get; set; }

        
    }
}