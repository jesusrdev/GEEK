using GEEK.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GEEK.AccesoDatos.Data.Repository.IRepository
{
    public interface IImagenRepository : IRepository<Imagen>
    {
        void Update(Imagen imagen);
    }
}
