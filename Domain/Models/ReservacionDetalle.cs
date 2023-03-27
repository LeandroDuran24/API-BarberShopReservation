namespace BEBarberShop.Domain.Models
{
    public class ReservacionDetalle
    {
        public int Id { get; set; }

        public int ReservacionId { get; set; }
        public Reservacion? Reservacion { get; set; }

        public int ServicioId { get; set; }
        public Servicio? Servicio { get; set; }
    }
}
