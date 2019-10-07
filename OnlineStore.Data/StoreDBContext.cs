using Microsoft.EntityFrameworkCore;
using OnlineStore.Domain.DataObjects;
using OnlineStore.SharedClasses;

namespace OnlineStore.Data
{
    public class StoreDBContext : DbContext
    {

        public DbSet<tblBrands> tblBrands { get; set; }
        public DbSet<tblCategory> tblCategories { get; set; }
        public DbSet<tblProducts> tblProducts { get; set; }
        public DbSet<tblSupplier> tblSuppliers { get; set; }
        public DbSet<BrandsProducts> brandsProducts { get; set; }
        public DbSet<Product> products { get; set; }

        public StoreDBContext(DbContextOptions<StoreDBContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<tblBrands>().ToTable("tblBrands").HasKey(a => new { a.Id });
            modelBuilder.Entity<tblCategory>().ToTable("tblCategory").HasKey(a => new { a.Id });
            modelBuilder.Entity<tblProducts>().ToTable("tblProducts").HasKey(a => new { a.Id });
            modelBuilder.Entity<tblSupplier>().ToTable("tblSupplier").HasKey(a => new { a.Id });
        }
    }
}
