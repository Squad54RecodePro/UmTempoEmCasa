using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace UmTempoEmCasa.Models
{
    public class Anfitriao
    {
        public int AnfitriaoID { get; set; }

        public List<Imovel>? Imovel { get; set; }


        [Required(ErrorMessage = "Insira seu Nome para efetuar o Cadastro")]
        [MaxLength(50, ErrorMessage = "Quantidade de carateres maior que o permitido")]
        [MinLength(2, ErrorMessage = "Esse Nome é muito curto, verifique e tente novamente")]
        [Display(Name = "Nome Completo")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Para prosseguir com o cadastro selecione PF ou PJ")]
        [Display(Name = "Tipo")]
        public string Tipo { get; set; }

        [DisplayFormat(DataFormatString = "mm/dd/yyyy")]
        [Display(Name = "Data de Nascimento")]
        public DateTime? Nascimento { get; set; }

        [Required(ErrorMessage = "Preencha o campo Telefone para continuar")]
        [MaxLength(11, ErrorMessage = "Preencha apenas o DDD e o número de telefone")]
        [MinLength(10, ErrorMessage = "Confira o número informado, faltam números")]
        [Display(Name = "Telefone")]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "Preencha o campo E-mail para continuar")]
        [MaxLength(50, ErrorMessage = "Máximo de caracteres excedido")]
        [EmailAddress]
        [Display(Name = "E-mail")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Preencha o campo endereço")]
        [MaxLength(100, ErrorMessage = "Quantidade de caracteres excedida")]
        [MinLength(5, ErrorMessage = "Confira o endereço informado")]
        [Display(Name = "Endereço")]
        public string Endereco { get; set; }

        [Required(ErrorMessage = "Insira o campo nome para prosseguir")]
        [MaxLength(30, ErrorMessage = "Número de caracteres excedido")]
        [Display(Name = "Cidade")]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "Informe o CEP do seu endereço")]
        [MaxLength(10, ErrorMessage = "Quantidade de caracteres excedida")]
        [MinLength(8, ErrorMessage = "Confira o CEP informado, quantidade de números menor que 8")]
        [Display(Name = "CEP")]
        public string CEP { get; set; }

        [MaxLength(11, ErrorMessage = "Quantidade de carateres maior que o permitido")]
        [MinLength(11, ErrorMessage = "Esse Nome é muito curto, verifique e tente novamente")]
        [Display(Name = "Documento de identificação")]
        public string? CPF { get; set; }

        [MaxLength(14, ErrorMessage = "Quantidade de carateres maior que o permitido")]
        [MinLength(14, ErrorMessage = "Esse Nome é muito curto, verifique e tente novamente")]
        [Display(Name = "Documento de identificação")]
        public string? CNPJ { get; set; }

        [StringLength(10, MinimumLength = 4)]
        [Required(ErrorMessage = "Insira sua senha")]
        [Display(Name = "Senha")]
        public string Senha { get; set; }
    }
}
