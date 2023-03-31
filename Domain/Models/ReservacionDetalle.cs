using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BEBarberShop.Domain.Models
{
    public class ReservacionDetalle
    {

        public int Id { get; set; }

        [ForeignKey("ReservacionId")]
        public int ReservacionId { get; set; }
        public Reservacion? Reservacion { get; set; }
        [ForeignKey("ServicioId")]
        public int ServicioId { get; set; }
        public Servicio? Servicio { get; set; }

 }
}
