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
    public class MarcaRepository : Repository<Marca>, IMarcaRepository
    {
        private readonly ApplicationDbContext _db;


        public MarcaRepository(ApplicationDbContext db) : base(db) 
        {
            _db = db;
        }

        public IEnumerable<SelectListItem> GetListaMarcas()
        {
            return _db.Marca.Select(i => new SelectListItem()
            {
                Text = i.NombreMarca,
                Value = i.IdMarca.ToString()
            });
        }

        public void Update(Marca marca)
        {
            var objDesdeDb = _db.Marca.FirstOrDefault(c => c.IdMarca == marca.IdMarca);
            objDesdeDb.NombreMarca = marca.NombreMarca;
            objDesdeDb.RutaImagen = objDesdeDb.RutaImagen;

            //_db.SaveChanges();
        }
    }
}
