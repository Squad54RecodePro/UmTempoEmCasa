using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace UmTempoEmCasa.Models
{
    public class Ongs
    {
        public int OngsID { get; set; }


        [Required(ErrorMessage = "Insira o nome da Ong")]
        [MaxLength(50, ErrorMessage = "Quantidade de carateres maior que o permitido")]
        [MinLength(2, ErrorMessage = "Esse Nome é muito curto, verifique e tente novamente")]
        [Display(Name = "Nome Completo")]

        public string Nome { get; set; }


        [MaxLength(14, ErrorMessage = "Quantidade de carateres maior que o permitido")]
        [MinLength(14, ErrorMessage = "Esse CNPJ é muito curto, verifique e tente novamente")]

        public string? CNPJ { get; set; }


        [Required(ErrorMessage = "Preencha o campo endereço")]
        [MaxLength(100, ErrorMessage = "Quantidade de caracteres excedida")]
        [MinLength(5, ErrorMessage = "Confira o endereço informado")]
        [Display(Name = "Endereço")]

        public string Endereco { get; set; }


        [Required(ErrorMessage = "Preencha o campo Telefone para continuar")]
        [MaxLength(11, ErrorMessage = "Preencha apenas o DDD e o número de telefone")]
        [MinLength(10, ErrorMessage = "Confira o número informado, faltam números")]
        [Display(Name = "Telefone")]

        public string Telefone { get; set; }

        [Required(ErrorMessage = "Preencha o campo E-mail para continuar")]
        [MaxLength(50, ErrorMessage = "Máximo de caracteres excedido")]
        [EmailAddress(ErrorMessage = "Preencha um E-mail válido!")]
        [Display(Name = "E-mail")]

        public string Email { get; set; }


    }
}
