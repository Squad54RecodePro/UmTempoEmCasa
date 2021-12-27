using System.ComponentModel.DataAnnotations;

namespace UmTempoEmCasa.Models
{
    public class Reserva
    {

    
        [Key]
        public int ID { get; set; }

        public int RefugiadoID { get; set; }
        public int AnfitriaoID { get; set; }
        public int AnuncioID { get; set; }
        public int ImovelID { get; set; }

        public virtual Refugiado Refugiado { get; set; }
        public virtual Anfitriao Anfitriao { get; set; }

        public virtual Anuncio Anuncio { get; set; }

        public virtual Imovel Imovel { get; set; }

        [Required(ErrorMessage ="Defina a Data de Inicio da Reserva")]
        [Display(Name ="Data de Inicio")]
        public DateTime DateInicio { get; set; }

        [Required(ErrorMessage ="Defina a Data de Termino da Reserva")]
        [Display(Name ="Data de Encerramento")]
        public DateTime DataFim { get; set; }


    }
}
