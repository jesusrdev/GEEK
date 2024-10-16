﻿using GEEK.AccesoDatos.Data.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GEEK.AccesoDatos.Data.Repository.IRepository
{
    public interface IContenedorTrabajo : IDisposable
    {
        // Aqui se deben de ir agregando los diferentes repositorios
        IProductoRepository Producto { get; }
        ICategoriaRepository Categoria { get; }
        IMarcaRepository Marca { get; }
        IImagenRepository Imagen { get; }
        IUsuarioRepository Usuario { get; }


        void Save();
    }
}
