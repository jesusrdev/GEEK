using BlogCore.AccesoDatos.Data.Repository.IRepository;
using GEEK.AccesoDatos.Data.Repository.IRepository;
using GEEK.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogCore.AccesoDatos.Data.Repository
{
    public class ContenedorTrabajo : IContenedorTrabajo
    {
        private readonly ApplicationDbContext _db;


        public ContenedorTrabajo(ApplicationDbContext db)
        {
            _db = db;

            Producto = new ProductoRepository(_db);
            Categoria = new CategoriaRepository(_db);
            Marca = new MarcaRepository(_db);
            Imagen = new ImagenRepository(_db);
            
        }

        public IProductoRepository Producto { get; private set; }

        public ICategoriaRepository Categoria { get; private set; }

        public IMarcaRepository Marca { get; private set; }

        public IImagenRepository Imagen { get; private set; }



        public void Dispose()
        {
            _db.Dispose();
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
