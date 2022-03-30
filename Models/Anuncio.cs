using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UmTempoEmCasa.Models
{
    public class Anuncio
    {

        public int AnuncioID { get; set; }

        public List<Reserva>? Reservas { get; set; }
        
        [Required(ErrorMessage ="Insira um Nome no anuncio para continuar")]
        [Display(Name ="Nome do Anuncio")]
        public string NomeAnuncio { get; set; }


        [Display(Name = "CEP do Imovel")]
        public int ImovelForeignKey { get; set; }
        public Imovel? Imovel { get; set; }



        public DateTime inicio { get; set; }

        [Required(ErrorMessage = "Informe o valor do Anuncio")]
        [Display(Name = "Valor")]
        public float valor { get; set; }

        public string?  nomeimagem { get; set; }

        [NotMapped]
        [Display(Name ="Foto do Imovel")]
        public IFormFile ImagemAnuncio { get; set; }


    }
}