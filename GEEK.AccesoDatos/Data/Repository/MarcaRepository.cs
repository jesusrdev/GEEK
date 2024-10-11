using GEEK.AccesoDatos.Data.Repository.IRepository;
using GEEK.Data;
using GEEK.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GEEK.AccesoDatos.Data.Repository
{
    public class MarcaRepository : Repository<Marca>, IMarcaRepository
    {
        private readonly ApplicationDbContext _db;


        public MarcaRepository(ApplicationDbContext db) : base(db) 
        {
            _db = db;
        }

        public string GenerarIdMarca()
        {
            // Obtiene el ultimo id
            var ultimoId = _db.Marca
                        .Select(c => c.IdMarca)
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
            return $"MA{nuevoNumeroId:D3}";
        }

        public IEnumerable<SelectListItem> GetListaMarcas()
        {
            return _db.Marca
                .Select(c => new SelectListItem
                {
                    Value = c.IdMarca,
                    Text = c.NombreMarca
                })
                .ToList();
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
