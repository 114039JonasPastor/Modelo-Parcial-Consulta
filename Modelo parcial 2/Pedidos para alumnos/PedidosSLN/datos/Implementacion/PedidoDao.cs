using CarpinteriaApp.datos;
using RecetasSLN.datos.DTOs;
using RecetasSLN.datos.Interfaz;
using RecetasSLN.dominio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecetasSLN.datos.Implementacion
{
    public class PedidoDao : IPedidoDao
    {
        SqlConnection conexion = null;

        public bool Alta(int id)
        {
            bool resultado = true;
            SqlTransaction t = null;
            conexion = HelperDB.ObtenerInstancia().ObtenerConexion();

            try
            {
                conexion.Open();
                t = conexion.BeginTransaction();

                SqlCommand comando = new SqlCommand("SP_REGISTRAR_ENTREGA", conexion, t);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@codigo",id);
                comando.ExecuteNonQuery();

                t.Commit();
            }
            catch
            {
                if(t != null)
                {
                    t.Rollback();
                    resultado = false;
                }
            }
            finally
            {
                if(conexion != null && conexion.State == ConnectionState.Open)
                {
                    conexion.Close();
                }
            }
            return resultado;
        }

        public bool baja(int id)
        {
            bool resultado = true;
            SqlTransaction t = null;
            conexion = HelperDB.ObtenerInstancia().ObtenerConexion();

            try
            {
                conexion.Open();
                t = conexion.BeginTransaction();

                SqlCommand comando = new SqlCommand("SP_REGISTRAR_BAJA", conexion, t);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@codigo", id);
                comando.ExecuteNonQuery();

                t.Commit();
            }
            catch
            {
                if(t != null)
                {
                    t.Rollback();
                    resultado = false;
                }
            }
            finally
            {
                if(conexion != null && conexion.State == ConnectionState.Open)
                {
                    conexion.Close();
                }
            }
            return resultado;
        }

        public List<PedidoDTO> GetPedidos(List<Parametro> lParametros)
        {
            List<PedidoDTO> lista = new List<PedidoDTO>();
            DataTable tabla = HelperDB.ObtenerInstancia().ConsultaSQL("SP_CONSULTAR_PEDIDOS",lParametros);

            PedidoDTO auxiliar = null;

            foreach(DataRow row in tabla.Rows)
            {
                int codigo = (int)row["codigo"];
                string cliente = row["cliente"].ToString();
                DateTime fechaEntrega = Convert.ToDateTime(row["fec_entrega"]);
                string entregado = row["entregado"].ToString();

                auxiliar = new PedidoDTO(codigo, cliente, fechaEntrega, entregado);

                lista.Add(auxiliar);    
            }
            return lista;
        }

        public List<PedidoDTO> GetPedidosSinFiltro()
        {
            List<PedidoDTO> lista = new List<PedidoDTO>();
            DataTable tabla = HelperDB.ObtenerInstancia().Consultar("SP_CONSULTAR_PEDIDOS_SIN_FILTRO");

            PedidoDTO auxiliar = null;

            foreach(DataRow row in tabla.Rows)
            {
                int codigo = (int)row["codigo"];
                string cliente = row["cliente"].ToString();
                DateTime fechaEntrega = Convert.ToDateTime(row["fec_entrega"]);
                string entregado = row["entregado"].ToString();

                auxiliar = new PedidoDTO(codigo, cliente, fechaEntrega, entregado);

                lista.Add(auxiliar);
            }
            return lista;
        }
    }
}
