using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace BEBarberShop.Domain.Models
{
    public class Servicio
    {
        public int Id { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string Nombre { get; set; }

        public string Duracion { get; set; }

        [Column(TypeName = "varchar(50)")]
        public float Precio { get; set; }

        public DateTime FechaCreacion { get; set; }

        public int Activo { get; set; }

        public int UsuarioId { get; set; }

    }
}
