using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BEBarberShop.Domain.Models
{
    public class Usuario
    {
        public int Id { get; set; }


        [Column(TypeName = "varchar(50)")]
        public string Nombre { get; set; }


        [Column(TypeName = "varchar(50)")]
        public string Apellidos { get; set; }

        [Column(TypeName = "varchar(20)")]
        public string NombreUsuario { get; set; }


        [Column(TypeName = "varchar(20)")]
        public string Password { get; set; }

        public DateTime FechaCreacion { get; set; }

        public int Activo { get; set; }



    }
}
