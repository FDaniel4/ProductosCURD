using Microsoft.EntityFrameworkCore;
using ProductosCURD.Data;
using ProductosCURD.Models;

namespace ProductosCURD.Services
{
    public class GestorProductos
    {
        private readonly ProductosDbContext _context;

        public GestorProductos(ProductosDbContext context)
        {
            _context = context;
        }

        public List<Producto> ObtenerProductos()
        {
            return _context.Productos.AsNoTracking().ToList();
        }

        public bool AgregarProducto(Producto producto)
        {
            bool existe = _context.Productos.Any(p => p.Id == producto.Id);
            if (existe)
                return false;                
            _context.Productos.Add(producto);
            try
            {
                _context.SaveChanges();
                return true;
            }catch(Exception e)
            {
                return false;
            }
        }
        public bool EditarProducto(Producto productoeditado)
        {
            var productoenBD = _context.Productos.Find(productoeditado.Id);

            if(productoenBD is null)
            {
                return false;
            }
            productoenBD.Nombre = productoeditado.Nombre;
            productoenBD.Precio = productoeditado.Precio;
            productoenBD.Stock = productoeditado.Stock;
            _context.SaveChanges();
            return true;
        } 
        public bool EliminarProducto(int id)
        {
            var producto = _context.Productos.Find(id);
            if(producto is null)
            {
                return false;
            }
            _context.Productos.Remove(producto);
            _context.SaveChanges();
            return true;
        }
    }
}
