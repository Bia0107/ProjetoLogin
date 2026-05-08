using System.ComponentModel.DataAnnotations;

namespace ProjetoLogin.Models
{
    public class Colaborador
    {
        [Display(Name = "Nome completo", Description = "Nome e Sobrenome.")]
        [Required(ErrorMessage = "O nome completo é obrigatório.")]
        public string Nome { get; set; }

        [Display(Name = "Celular")]
        [Required(ErrorMessage = "O Celular é obrigatório.")]
        public string Telefone { get; set; }

        [Display(Name = "CPF")]
        [Required(ErrorMessage = "O CPF é obrigatório.")]
        public string CPF{ get; set; }

        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage = "O Email é obrigatório.")]
        [RegularExpression(".+\\@.+\\..+", ErrorMessage = "Informe um email válido.")]
        public string Email{ get; set; }

        [Display(Name = "Senha")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "A senha é obrogatória.")]
        [StringLength(10, MinimumLength = 6, ErrorMessage = "A senha deter ter entre 6 e 10 caracteres.")]
        public string Senha { get; set; }


    }

}
