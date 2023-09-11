using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProyectGarantia.Models
{
    [Table("Documentaciones")]
    public class Documentacion
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }

        [Column("DetalleLoteId")]
        public int DetalleLoteId { get; set; }
        [ForeignKey("DetalleLoteId")]
        public DetalleLote DetalleLote { get; set; }

        [Column("TipoOperacion")]
        public TipoOperacionDocumentacion TipoOperacion { get; set; }
    }

    public enum TipoOperacionDocumentacion
    {
        SalidaPrestamo,
        SalidaCambioGarantia,
        IngresoCambioGarantia,
        BajaCancelacionPrestamo,
        EnDemanda
    }
}
