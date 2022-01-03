using System.ComponentModel.DataAnnotations;

namespace UmTempoEmCasa.Models
{
    public class Contato
    {
        [Key]
        public int Id { get; set; }
        
        [Required(ErrorMessage ="Preencha seu nome")]
        [StringLength(50, MinimumLength =6,ErrorMessage ="Nome informado é muito curto, digite um nome que contenha mais de 6 caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage ="Preencha o campo E-mail")]
        [EmailAddress(ErrorMessage ="Preencha um Email correto")]
        [Display(Name ="E-mail")]
        public string Email { get; set; }

        [Required(ErrorMessage ="Preencha o Assunto")]
        [StringLength(100, MinimumLength =5,ErrorMessage ="Assunto muito curto, o minimo necessário são 5 caracteres")]
        [Display(Name ="Assunto")]
        public string assunto { get; set; }

        [Required(ErrorMessage ="Preencha o campo Mensagem")]
        [StringLength(1000, MinimumLength = 40,ErrorMessage ="O campo mensagem precisa ter pelomenos 40 caracteres informados")]
        [Display(Name ="Mensagem")]
        public string mensagem { get; set; }
    }
}
