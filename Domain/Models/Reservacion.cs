namespace BEBarberShop.Domain.Models
{
    public class Reservacion
    {
        public int Id { get; set; }

        public int ClienteId { get; set; }
        public Cliente? Cliente { get; set; }

        public int EstilistaId { get; set; }
        public Estilista? Estilista { get; set; }

        public int ServicioId { get; set; }
        public Servicio? Servicio { get; set; }

        public DateTime Fecha { get; set; }
        public string Hora { get; set; }

        public DateTime FechaCreacion { get; set; }

        public int Activo { get; set; }

        public int UsuarioId { get; set; }
        public Usuario? Usuario { get; set; }

    }
}
