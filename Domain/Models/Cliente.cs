using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace BEBarberShop.Domain.Models
{
    public class Cliente
    {
        public int Id { get; set; }


        [Column(TypeName = "varchar(50)")]
        public string Nombre { get; set; }


        [Column(TypeName = "varchar(50)")]
        public string Apellidos { get; set; }

        [Column(TypeName = "varchar(10)")]
        public string TipoIdentificacion { get; set; }


        [Column(TypeName = "varchar(20)")]
        public string Identificacion { get; set; }



        [Column(TypeName = "varchar(100)")]
        public string Direccion { get; set; }


        [Column(TypeName = "varchar(20)")]
        public string Provincia { get; set; }



        [Column(TypeName = "varchar(20)")]
        public string Celular { get; set; }


        public DateTime FechaNacimiento { get; set; }
        public DateTime FechaCreacion { get; set; }

        public int Activo { get; set; }

        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }

    }
}
