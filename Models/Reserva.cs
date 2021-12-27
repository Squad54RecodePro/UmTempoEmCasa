using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UmTempoEmCasa.Models
{
    public class Reserva
    {

    
        [Key]
        public int ID { get; set; }


        [ForeignKey("Refugiado")]
        public int RefugiadoID { get; set; }
        public virtual Refugiado Refugiado { get; set; }

        [ForeignKey("Anfitriao")]
        public int AnfitriaoID { get; set; }
        public virtual Anfitriao Anfitriao { get; set; }

        [ForeignKey("Anuncio")]
        public int AnuncioID { get; set; }
        public virtual Anuncio Anuncio { get; set; }

        [ForeignKey("Imovel")]
        public int ImovelID { get; set; }
        public virtual Imovel Imovel { get; set; }


        [Required(ErrorMessage ="Defina a Data de Inicio da Reserva")]
        [Display(Name ="Data de Inicio")]
        public DateTime DateInicio { get; set; }

        [Required(ErrorMessage ="Defina a Data de Termino da Reserva")]
        [Display(Name ="Data de Encerramento")]
        public DateTime DataFim { get; set; }


    }
}
