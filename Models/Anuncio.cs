using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UmTempoEmCasa.Models
{
    public class Anuncio
    {
        [Key]
        public int ID { get; set; }

        [ForeignKey("Anfitriao")]
        public int AnfitriaoID { get; set; }
        public virtual Anfitriao Anfitriao { get; set; }

        [Required(ErrorMessage ="Especifique o nome do anuncio")]
        [Display(Name ="Nome do Anuncio")]
        [MaxLength(20,ErrorMessage ="Máximo de caracteres ultrapassado")]
        [MinLength(3,ErrorMessage ="Minimo de caracteres não atingido")]
        public string Nome { get; set; }

        [Required(ErrorMessage ="Informe o valor do Anuncio")]
        [Display(Name ="Valor")]
        public float valor { get; set; }

        public virtual Imovel Imovel { get; set; }

       

        public virtual Reserva Reserva { get; set; }

        public Anuncio()
        {
            this.Reserva = new Reserva();
        }



    }
}