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
    public class ImagenRepository : Repository<Imagen>, IImagenRepository
    {
        private readonly ApplicationDbContext _db;


        public ImagenRepository(ApplicationDbContext db) : base(db) 
        {
            _db = db;
        }

        public string GenerarIdImagen()
        {
            // Obtiene el ultimo id
            var ultimoId = _db.Imagen
                        .Select(c => c.IdImagen)
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
            return $"IM{nuevoNumeroId:D3}";
        }

        public void Update(Imagen imagen)
        {
            var objDesdeDb = _db.Imagen.FirstOrDefault(c => c.IdImagen == imagen.IdImagen);
            objDesdeDb.RutaImagen = imagen.RutaImagen;

            //_db.SaveChanges();
        }
    }
}
