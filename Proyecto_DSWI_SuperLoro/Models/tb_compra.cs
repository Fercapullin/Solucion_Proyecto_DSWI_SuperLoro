using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto_DSWI_SuperLoro.Models
{
    public class tb_compra
    {
        public int id_compra { get; set; }

        public int id_cliente { get; set; }

        public int id_usuario { get; set; }

        public DateTime fec_compra { get; set; }

        public string estado { get; set; }

    }
}