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
    public class CategoriaRepository : Repository<Categoria>, ICategoriaRepository
    {
        private readonly ApplicationDbContext _db;


        public CategoriaRepository(ApplicationDbContext db) : base(db) 
        {
            _db = db;
        }

        public void Create(Categoria categoria)
        {
            categoria.IdCategoria = GenerarIdCategoria();
            _db.Categoria.Add(categoria);
            _db.SaveChanges();
        }

        public IEnumerable<SelectListItem> GetListaCategorias()
        {
            return _db.Categoria
                .Select(c => new SelectListItem
                {
                    Value = c.IdCategoria,
                    Text = c.DescripcionCategoria
                })
                .ToList();
        }

        public void Update(Categoria categoria)
        {
            var objDesdeDb = _db.Categoria.FirstOrDefault(c => c.IdCategoria == categoria.IdCategoria);
            objDesdeDb.DescripcionCategoria = categoria.DescripcionCategoria;

            //_db.SaveChanges();
        }

        public string GenerarIdCategoria()
        {
            // Obtiene el ultimo id
            var ultimoId = _db.Categoria
                        .Select(c => c.IdCategoria)
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
            return $"CA{nuevoNumeroId:D3}"; 
        }
    }
}
