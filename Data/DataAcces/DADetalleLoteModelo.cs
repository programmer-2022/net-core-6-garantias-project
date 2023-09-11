using Microsoft.EntityFrameworkCore;
using ProyectGarantia.Data.Interfaces;
using ProyectGarantia.Models;
//using static ProyectGarantia.Data.DataAcces.DADetalleLoteModelo;

namespace ProyectGarantia.Data.DataAcces
{
    public class DADetalleLoteModelo: IDADetalleLoteModelo
    {
        private readonly ApplicationDbContext dbDetalleLoteModelo;

        public DADetalleLoteModelo(ApplicationDbContext dbContext)
        {
            dbDetalleLoteModelo = dbContext;
        }

        public IEnumerable<DetalleLoteModelo> GetDetalleLoteModelo()
        {
            return dbDetalleLoteModelo.DetalleLoteModelo.Include(item => item.Lote).ToList();
        }

        public int InsertDetalleLoteModelo(DetalleLoteModelo DetalleLoteModelo)
        {
            dbDetalleLoteModelo.Add(DetalleLoteModelo);
            dbDetalleLoteModelo.SaveChanges();
            return DetalleLoteModelo.Id;
        }

        public DetalleLoteModelo GetIdDetalleLoteModelo(int id)
        {
            return dbDetalleLoteModelo.DetalleLoteModelo.Where(item => item.Id == id).FirstOrDefault();
        }

        public Boolean UpdateDetalleLoteModelo(DetalleLoteModelo DetalleLoteModelo)
        {
            dbDetalleLoteModelo.DetalleLoteModelo.Attach(DetalleLoteModelo);
            dbDetalleLoteModelo.Entry(DetalleLoteModelo).State = EntityState.Modified;
            return dbDetalleLoteModelo.SaveChanges() != 0;
        }

        public Boolean DeleteDetalleLoteModelo(int id)
        {
            var entity = new DetalleLoteModelo() { Id = id };
            dbDetalleLoteModelo.DetalleLoteModelo.Attach(entity);
            dbDetalleLoteModelo.DetalleLoteModelo.Remove(entity);
            return dbDetalleLoteModelo.SaveChanges() != 0;
        }
    }
}
