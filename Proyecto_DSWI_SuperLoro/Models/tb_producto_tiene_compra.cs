using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto_DSWI_SuperLoro.Models
{
    public class tb_producto_tiene_compra
    {
        public int cod_prod { get; set; }

        public int id_compra { get; set; }

        public double precio { get; set; }

        public int cantidad { get; set; }

    }
}