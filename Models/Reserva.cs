using System.ComponentModel.DataAnnotations;

namespace UmTempoEmCasa.Models
{
    public class Reserva
    {

    
        [Key]
        public int Id { get; set; }

        public virtual Refugiado Refugiado { get; set; }
        public virtual Anfitriao Anfitriao { get; set; }

        [Required(ErrorMessage ="Defina a Data de Inicio do Contrato")]
        [Display(Name ="Data de Inicio")]
        public DateTime DateInicio { get; set; }

        [Required(ErrorMessage ="Defina a Data de Termino do Contrato")]
        [Display(Name ="Data de Encerramento")]
        public DateTime DataFim { get; set; }


    }
}
