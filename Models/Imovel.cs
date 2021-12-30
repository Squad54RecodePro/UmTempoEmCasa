using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UmTempoEmCasa.Models
{
    public class Imovel
    {
        public int ImovelID { get; set; }



        public virtual List<Anuncio>? Anuncios { get; set; }


        [Display(Name = "Nome do Anfitrião")]
        public int AnfitriaoForeignKey { get; set; }
        public Anfitriao? Anfitrioes { get; set; }

        [Required(ErrorMessage = "Informe o Endereço do Imovel")]
        [MaxLength(50, ErrorMessage = "Maximo de caracteres excedido")]
        [MinLength(5, ErrorMessage = "Confira o endereço digitado, números de caracteres muito curto")]
        [Display(Name = "Endereço")]
        public string Endereco { get; set; }

        [Required(ErrorMessage = "Informe a Cidade do Imovel")]
        [MaxLength(50, ErrorMessage = "Maximo de caracteres excedido")]
        [MinLength(3, ErrorMessage = "Número de caracteres muito curto, verifique o nome da cidade")]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "Informe o CEP da localização do Imovel")]
        [MaxLength(11, ErrorMessage = "Maximo de caracteres excedido")]
        [MinLength(8, ErrorMessage = "Confira o CEP digitado, número minimo não atingido")]
        [Display(Name = "Cep ( Código Postal )")]
        public string Cep { get; set; }


    }
}