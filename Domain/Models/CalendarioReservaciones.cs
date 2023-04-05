namespace BEBarberShop.Domain.Models
{
    public class CalendarioReservaciones
    {
        public int Id { get; set; }

        public int ReservacionId { get; set; }

        public Reservacion? Reservacion { get; set; }
        public DateTime FechaReserva { get; set; }
        public string HoraInicio { get; set; }
        public string HoraFinal { get; set; }

        public int Activo { get; set; }
    }
}
