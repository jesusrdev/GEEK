using BlogCore.AccesoDatos.Data.Repository.IRepository;
using GEEK.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GEEK.AccesoDatos.Data.Repository.IRepository
{
    public interface IMarcaRepository : IRepository<Marca>
    {
        void Update(Marca marca);

        IEnumerable<SelectListItem> GetListaMarcas();
        string GenerarIdMarca();
    }
}
