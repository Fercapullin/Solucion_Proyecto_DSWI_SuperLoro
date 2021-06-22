using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto_DSWI_SuperLoro.Models
{
    public class tb_pedido
    {
        public int id_pedido { get; set; }

        public int id_compra { get; set; }

        public DateTime fec_ini { get; set; }

        public DateTime fec_fin { get; set; }

        public string estado { get; set; }

    }
}