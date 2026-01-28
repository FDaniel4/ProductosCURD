using Microsoft.EntityFrameworkCore;
using ProductosCURD.Models;

namespace ProductosCURD.Data
{
    public class ProductosDbContext : DbContext
    {
        public ProductosDbContext(DbContextOptions<ProductosDbContext> options) 
            :base(options)
        {

        }
        public DbSet<Producto> Productos { get; set; }
    }
}
