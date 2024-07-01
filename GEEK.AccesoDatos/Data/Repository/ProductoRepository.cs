using GEEK.AccesoDatos.Data.Repository.IRepository;
using GEEK.Data;
using GEEK.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GEEK.AccesoDatos.Data.Repository
{
    public class ProductoRepository : Repository<Producto>, IProductoRepository
    {
        private readonly ApplicationDbContext _db;


        public ProductoRepository(ApplicationDbContext db) : base(db) 
        {
            _db = db;
        }

        public void Create(Producto producto)
        {
            producto.EstadoProducto = "A";
            producto.IdProducto = GenerarIdProducto();
            _db.Producto.Add(producto);
            _db.SaveChanges();
        }

        public string GenerarIdProducto()
        {
            // Obtiene el ultimo id
            var ultimoId = _db.Producto
                        .Select(c => c.IdProducto)
                        .OrderByDescending(id => id)
                        .FirstOrDefault();
            // Calcular el nuevo número ID
            var nuevoNumeroId = 1;


            if (ultimoId != null)
            {
                if (int.TryParse(ultimoId.Substring(2), out int ultimoNumeroID))
                {
                    nuevoNumeroId = ultimoNumeroID + 1;
                }
            }

            // Generar el nuevo ID en formato "PRnnn"
            return $"PR{nuevoNumeroId:D3}";
        }

        public void Update(Producto producto)
        {
            var objDesdeDb = _db.Producto.FirstOrDefault(c => c.IdProducto == producto.IdProducto);
            objDesdeDb.NombreProducto = producto.NombreProducto;
            objDesdeDb.DescripcioGeneral = producto.DescripcioGeneral;
            objDesdeDb.Descripcion = producto.Descripcion;
            objDesdeDb.Precio = producto.Precio;
            objDesdeDb.StockProducto = producto.StockProducto;
            objDesdeDb.Descuento = producto.Descuento;
            objDesdeDb.IdMarca = producto.IdMarca;
            objDesdeDb.IdCategoria = producto.IdCategoria;
            objDesdeDb.EstadoProducto = producto.EstadoProducto;

            //_db.SaveChanges();
        }
    }
}
