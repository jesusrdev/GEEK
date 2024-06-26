﻿using BlogCore.AccesoDatos.Data.Repository.IRepository;
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
            
        }


        

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
