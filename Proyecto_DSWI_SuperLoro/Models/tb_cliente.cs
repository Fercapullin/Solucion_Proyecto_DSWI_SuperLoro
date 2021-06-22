using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto_DSWI_SuperLoro.Models
{
    public class tb_cliente
    {
        public int id_cli { get; set; }

        public string nom_cli { get; set; }

        public string ape_cli { get; set; }
        public string cel_cli { get; set; }

        public string dni_cli { get; set; }
        public DateTime fec_nac { get; set; }

    }
}