using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProyectGarantia.Models
{
    [Table("Garantias")]
    public class Garantia
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }

        [Column("DetalleLoteId")]
        public int DetalleLoteId { get; set; }
        [ForeignKey("DetalleLoteId")]
        public DetalleLote DetalleLote { get; set; }

        [Column("Tipo")]
        public TipoGarantia Tipo { get; set; }

        [Column("Estado")]
        public EstadoGarantia Estado { get; set; }

        [Column("AlmacenId")]
        public int AlmacenId { get; set; }
        [ForeignKey("AlmacenId")]
        public Almacen Almacen { get; set; }
    }

    public enum TipoGarantia
    {
        Vehiculo,
        Hipotecaria
    }

    public enum EstadoGarantia
    {
        Activa,
        Inactiva,
        EnDemanda
    }
}
