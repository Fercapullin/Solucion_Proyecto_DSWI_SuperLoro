using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto_DSWI_SuperLoro.Models
{
    public class tb_usuario
    {
        public int id_usuario { get; set; }

        public string usuario { get; set; }

        public string contraseña { get; set; }

        public DateTime fec_Reg { get; set; }

        public int id_cli { get; set; }

        public int id_rol { get; set; }
    }
}