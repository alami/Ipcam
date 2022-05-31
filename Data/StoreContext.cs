using Ipcam.Models;
using Microsoft.EntityFrameworkCore;

namespace Ipcam.Data
{
    public class StoreContext : DbContext
    {
        public StoreContext(DbContextOptions<StoreContext> options) : base(options)
        {
        }
        public DbSet<Resolution> Resolution { get; set; }
        public DbSet<Period> Period { get; set; }
        public DbSet<Tariff> Tariff { get; set; }

    }
}
