using GEEK.AccesoDatos.Data.Repository.IRepository;
using GEEK.Data;
using GEEK.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GEEK.AccesoDatos.Data.Repository
{
    public class UsuarioRepository : Repository<Usuario>, IUsuarioRepository
    {
        private readonly ApplicationDbContext _db;

        public UsuarioRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void BloquearUsuario(string IdUsuario)
        {
            var usuarioDesdeBd = _db.Usuario.FirstOrDefault(u => u.Id == IdUsuario);

            usuarioDesdeBd.LockoutEnd = DateTime.Now.AddYears(1000);
            _db.SaveChanges();
        }

        public void DesbloquearUsuario(string IdUsuario)
        {
            var usuarioDesdeBd = _db.Usuario.FirstOrDefault(u => u.Id == IdUsuario);

            usuarioDesdeBd.LockoutEnd = DateTime.Now;
            _db.SaveChanges();
        }
    }
}
