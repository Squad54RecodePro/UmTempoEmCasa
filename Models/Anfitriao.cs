using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace UmTempoEmCasa.Models
{
    public class Anfitriao
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Insira seu Nome para efetuar o Cadastro")]
        [MaxLength(50, ErrorMessage = "Quantidade de carateres maior que o permitido")]
        [MinLength(2, ErrorMessage = "Esse Nome é muito curto, verifique e tente novamente")]
        [DisplayName("Nome Completo")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Para prosseguir com o cadastro selecione PF ou PJ")]
        [DisplayName("Tipo")]
        public string Tipo { get; set; }

        [Required(ErrorMessage = "Informe sua data de nascimento")]
        [DisplayName("Data de Nascimento")]
        public DateTime Data_nascimento { get; set; }

        [Required(ErrorMessage = "Insira seu telefone")]
        [DisplayName("Telefone")]
        public int Contato { get; set; }

        [Required(ErrorMessage = "Insira o campo nome para prosseguir")]
        [MaxLength(100, ErrorMessage = "Número de caracteres excedido")]
        [DisplayName("Endereço")]
        public string Endereco { get; set; }

        [Required(ErrorMessage = "Insira o seu CEP")]
        [DisplayName("CEP")]
        public string Cep { get; set; }

        [Required(ErrorMessage = "Insira o documento para identificação")]
        [DisplayName("Documento de identificação")]
        public string Documento { get; set; }

        [Required(ErrorMessage = "Insira o seu e-mail")]
        [EmailAddress(ErrorMessage = "Preencha um E-mail Válido")]
        [DisplayName("E-mail")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Insira sua senha")]
        [DisplayName("Senha")]
        public string Senha { get; set; }
    }
}
