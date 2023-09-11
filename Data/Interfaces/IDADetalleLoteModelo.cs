using ProyectGarantia.Models;

namespace ProyectGarantia.Data.Interfaces
{
    public interface IDADetalleLoteModelo
    {
        IEnumerable<DetalleLoteModelo> GetDetalleLoteModelo();
        int InsertDetalleLoteModelo(DetalleLoteModelo DetalleLoteModelo);
        DetalleLoteModelo GetIdDetalleLoteModelo(int id);
        Boolean UpdateDetalleLoteModelo(DetalleLoteModelo DetalleLoteModelo);
        Boolean DeleteDetalleLoteModelo(int id);
    }
}
