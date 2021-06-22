using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto_DSWI_SuperLoro.Models
{
    public class tb_producto
    {
        public int id_prod { get; set; }

        public string producto { get; set; }

        public double precio { get; set; }

        public int stock { get; set; }

        public string prod_img { get; set; }

        public int id_cat { get; set; }
    }
}