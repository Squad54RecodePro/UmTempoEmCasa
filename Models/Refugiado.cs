using System.ComponentModel.DataAnnotations;

namespace UmTempoEmCasa.Models
{
    public class Refugiado
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage ="Insira seu Nome para efetuar o Cadastro")]
        [MaxLength(50,ErrorMessage ="Quantidade de carateres maior que o permitido")]
        [MinLength(2,ErrorMessage ="Esse Nome é muito curto, verifique e tente novamente")]
        [Display(Name ="Nome Completo")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Preencha a Data de Nascimento")]
        [Display(Name = "Data de Nascimento")]
        [DisplayFormat(DataFormatString = "mm/dd/yyyy")]
        public DateTime Nascimento { get; set; }

        [Required(ErrorMessage = "É necessário possuir um CPF para se cadastrar, verifique o link de acesso disponibilizado ao lado")]
        [MaxLength(11, ErrorMessage = "Quantidade de carateres maior que o permitido")]
        [MinLength(11, ErrorMessage = "Esse Nome é muito curto, verifique e tente novamente")]
        public string CPF { get; set; }

        [Required(ErrorMessage ="Preencha o campo Telefone para continuar")]
        [MaxLength(11, ErrorMessage ="Preencha apenas o DDD e o número de telefone")]
        [MinLength(10,ErrorMessage ="Confira o número informado, faltam números")]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "Preencha o campo E-mail para continuar")]
        [MaxLength(50, ErrorMessage = "Máximo de caracteres excedido")]
        [EmailAddress]
        [Display(Name ="E-mail")]
        public string Email { get; set; }

        [Required(ErrorMessage = "É necessário declarar a Nacionalidade")]
        [Display(Name = "Nacionalidade")]
        private string Nacionalidade { get; set; }

        [Required(ErrorMessage ="Preencha o campo endereço")]
        [MaxLength(100, ErrorMessage ="Quantidade de caracteres excedida")]
        [MinLength(5, ErrorMessage ="Confira o endereço informado")]
        [Display(Name="Endereço")]
        public string Endereco { get; set; }

        [Required(ErrorMessage ="Informe o CEP do seu endereço")]
        [MaxLength (10, ErrorMessage ="Quantidade de caracteres excedida")]
        [MinLength(8, ErrorMessage="Confira o CEP informado, quantidade de números menor que 8")]
        public string CEP { get; set; }


        public virtual Reserva Reserva { get; set; }

        

        public Refugiado()
        {
            this.Reserva = new Reserva();
           
        }




    }

        

       

      
}
