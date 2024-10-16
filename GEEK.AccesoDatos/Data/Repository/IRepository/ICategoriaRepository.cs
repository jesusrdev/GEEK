﻿using GEEK.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GEEK.AccesoDatos.Data.Repository.IRepository
{
    public interface ICategoriaRepository : IRepository<Categoria>
    {
        void Create(Categoria categoria);   
        void Update(Categoria categoria);

        public IEnumerable<SelectListItem> GetListaCategorias();

        string GenerarIdCategoria();
    }
}
