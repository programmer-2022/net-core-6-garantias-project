using ProyectGarantia.Models;

namespace ProyectGarantia.Data.Interfaces
{
    public interface IDALote
    {
        IEnumerable<Lote> GetLote();

        int InsertLote(Lote Lote);
        Lote GetIdLote(int id);
        Boolean UpdateLote(Lote Lote);
        Boolean DeleteLote(int id);
    }
}
