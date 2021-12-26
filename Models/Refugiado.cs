using System.ComponentModel.DataAnnotations;

namespace UmTempoEmCasa.Models
{
    public class Refugiado
    {
        [Key]
        public string Id { get; set; }

        [Required(ErrorMessage ="Insira seu Nome para efetuar o Cadastro")]
        [MaxLength(50,ErrorMessage ="Quantidade de carateres maior que o permitido")]
        [MinLength(2,ErrorMessage ="Esse Nome é muito curto, verifique e tente novamente")]
        [Display(Name ="Nome Completo")]
        public string Nome { get; set; }

        [Required(ErrorMessage ="É necessário declarar a Nacionalidade")]
        [Display(Name ="Nacionalidade")]
        private string Nacionalidade { get; set;}

        [Required(ErrorMessage ="É necessário possuir um CPF para se cadastrar, verifique o link de acesso disponibilizado ao lado")]
        public string CPF { get; set; }

        [Required(ErrorMessage="Preencha a Data de Nascimento")]
        public Data Nascimento {get;set;}
    }
}
