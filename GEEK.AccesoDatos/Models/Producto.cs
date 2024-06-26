using System;
using System.Collections.Generic;

namespace GEEK.AccesoDatos.Models
{
    public partial class Producto
    {
        public Producto()
        {
            Carritos = new HashSet<Carrito>();
            IdImagens = new HashSet<Imagen>();
        }

        public string IdProducto { get; set; } = null!;
        public string NombreProducto { get; set; } = null!;
        public string? Descripcion { get; set; }
        public string? DescripcioGeneral { get; set; }
        public decimal? Precio { get; set; }
        public int? StockProducto { get; set; }
        public decimal? Descuento { get; set; }
        public string? IdMarca { get; set; }
        public string? IdCategoria { get; set; }
        public string? IdEstado { get; set; }

        public virtual Categorium? IdCategoriaNavigation { get; set; }
        public virtual EstadoProducto? IdEstadoNavigation { get; set; }
        public virtual Marca? IdMarcaNavigation { get; set; }
        public virtual ICollection<Carrito> Carritos { get; set; }

        public virtual ICollection<Imagen> IdImagens { get; set; }
    }
}
