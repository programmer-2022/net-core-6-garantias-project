namespace ProyectGarantia.Models
{
    public class DatosLoteGarantiasResponse
    {
        public int Cedula { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Prestamo { get; set; }
        public int Cod_aval { get; set; }
        public string Nombre_aval { get; set; }
        public int Monto_garantia { get; set; }
        public int Tpaval { get; set; }
        public string Descrip_aval { get; set; }
    }
}
