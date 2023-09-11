using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectGarantia.Models
{
    [Table("Lotes")]
    public class Lote
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }

        [Column("NumeroCorrelativo")]
        public string NumeroCorrelativo { get; set; }

        [Column("Estado")]
        public EstadoLote Estado { get; set; }

        [Column("FechaCreacion")]
        public DateOnly FechaCreacion { get; set; }

        [Column("NombreCreador")]
        public string NombreCreador { get; set; }

        public List<DetalleLote>? DetallesLote { get; set; }
    }

    public enum EstadoLote
    {
        Enviado,
        EnCurso,
        Recibido,
        Aprobado,
        Rechazado
    }
}
