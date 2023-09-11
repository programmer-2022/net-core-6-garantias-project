using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ProyectGarantia.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ProyectGarantia.Models.Lote> Lote { get; set; }
        public virtual DbSet<ProyectGarantia.Models.Agencia> Agencia { get; set; }
        public virtual DbSet<ProyectGarantia.Models.Cliente> Cliente { get; set; }
        public virtual DbSet<ProyectGarantia.Models.DetalleLote> DetalleLote { get; set; }
        public virtual DbSet<ProyectGarantia.Models.DetalleLoteModelo> DetalleLoteModelo { get; set; }
        public virtual DbSet<ProyectGarantia.Models.Documentacion> Documentacion { get; set; }
        public virtual DbSet<ProyectGarantia.Models.Garantia> Garantia { get; set; }
        public virtual DbSet<ProyectGarantia.Models.Almacen> Almacen { get; set; }
    }
}