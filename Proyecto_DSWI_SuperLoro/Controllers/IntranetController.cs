using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.Remoting.Messaging;
using Proyecto_DSWI_SuperLoro.Models;
using Antlr.Runtime.Tree;

namespace Proyecto_DSWI_SuperLoro.Controllers
{
    public class IntranetController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString);


        IEnumerable<tb_categoria> categorias()
        {

            List<tb_categoria> temporal = new List<tb_categoria>();
            SqlCommand cmd = new SqlCommand("usp_lista_categorias", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cn.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                tb_categoria reg = new tb_categoria()
                {
                    id_cat = dr.GetInt32(1),
                    categoria = dr.GetString(2)
                };
                temporal.Add(reg);
            }
            dr.Close(); cn.Close();
            return temporal;

        }

 

        IEnumerable<tb_pedido> pedidos()
        {

            List<tb_pedido> temporal = new List<tb_pedido>();
            SqlCommand cmd = new SqlCommand("usp_lista_pedidos", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                tb_pedido reg = new tb_pedido()
                {
                    id_pedido = dr.GetInt32(0),
                    id_compra = dr.GetInt32(1),
                    fec_ini = dr.GetDateTime(2),
                    fec_fin = dr.GetDateTime(3),
                    estado = dr.GetString(4)
                };
                temporal.Add(reg);
            }
            dr.Close(); cn.Close();
            return temporal;
        }

        IEnumerable<tb_pedido> pedidosfiltro(int idcompra)
        {

            List<tb_pedido> temporal = new List<tb_pedido>();
            SqlCommand cmd = new SqlCommand("usp_busca_pedido", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idcompra", idcompra);
            cn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                tb_pedido reg = new tb_pedido()
                {
                    id_pedido = dr.GetInt32(0),
                    id_compra = dr.GetInt32(1),
                    fec_ini = dr.GetDateTime(2),
                    fec_fin = dr.GetDateTime(3),
                    estado = dr.GetString(4)
                };
                temporal.Add(reg);
            }
            dr.Close(); cn.Close();
            return temporal;
        }

        string CRUD(string proceso, List<SqlParameter> pars)
        {
            string mensaje = "";
            SqlCommand cmd = new SqlCommand(proceso, cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddRange(pars.ToArray());
            cn.Open();
            try
            {
                int n = cmd.ExecuteNonQuery();
                mensaje = n + "Pedido Actualizado";
            }
            catch (SqlException ex)
            {

                mensaje = ex.Message;
            }
            finally { cn.Close(); }

            return mensaje;
        }
        [HttpPost]
        public ActionResult create(tb_pedido reg)
        {
            // creamos la lista de parametros
            List<SqlParameter> lista = new List<SqlParameter>() {
           new SqlParameter(){ ParameterName="@idcompra",SqlDbType=SqlDbType.Int,Value=reg.id_compra},
           new SqlParameter(){ ParameterName="@fecini",SqlDbType=SqlDbType.DateTime,Value=reg.fec_ini},
           new SqlParameter(){ ParameterName="@fecfin",SqlDbType=SqlDbType.DateTime,Value=reg.fec_fin},
           new SqlParameter(){ ParameterName="@estado",SqlDbType=SqlDbType.VarChar,Value=reg.estado}
           };
            // ejecutar procedimiento alamcenado para insertar pedido
            ViewBag.mensaje = CRUD("usp_inserta_pedido", lista);

            return View(reg);

        }
        public ActionResult EditarPedido(int id)
        {

            // buscamos el pedido por id
            tb_pedido reg = pedidos().Where(x => x.id_pedido == id).FirstOrDefault();

            return View(reg);


        }
        [HttpPost]
        public ActionResult EditarPedido(tb_pedido reg)
        {

            List<SqlParameter> lista = new List<SqlParameter>() {
           new SqlParameter(){ ParameterName="@idpedido",SqlDbType=SqlDbType.Int,Value=reg.id_pedido},
           new SqlParameter(){ ParameterName="@idcompra",SqlDbType=SqlDbType.Int,Value=reg.id_compra},
           new SqlParameter(){ ParameterName="@fecini",SqlDbType=SqlDbType.DateTime,Value=reg.fec_ini},
           new SqlParameter(){ ParameterName="@fecfin",SqlDbType=SqlDbType.DateTime,Value=reg.fec_fin},
           new SqlParameter(){ ParameterName="@estado",SqlDbType=SqlDbType.VarChar,Value=reg.estado}
            };
            // ejecutamos el procedimiento alamcenado
            ViewBag.mensaje = CRUD("usp_actualiza_pedido", lista);

            return View(reg);
        }


        public ActionResult Lista(int id_compra)
        {

            IEnumerable<tb_pedido> ped = new List<tb_pedido>();
            ped = pedidosfiltro(id_compra);
            return View(ped);

        }

        public ActionResult Listaped()
        { 
            return View(pedidos());

        }

    }
}