using GEEK.AccesoDatos.Data.Repository.IRepository;
using GEEK.Data;
using GEEK.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogCore.AccesoDatos.Data.Repository
{
    public class ProductoRepository : Repository<Producto>, IProductoRepository
    {
        private readonly ApplicationDbContext _db;


        public ProductoRepository(ApplicationDbContext db) : base(db) 
        {
            _db = db;
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
            objDesdeDb.IdEstado = producto.IdEstado;

            //_db.SaveChanges();
        }
    }
}
