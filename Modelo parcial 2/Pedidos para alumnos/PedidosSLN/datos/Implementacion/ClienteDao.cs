using CarpinteriaApp.datos;
using RecetasSLN.datos.DTOs;
using RecetasSLN.datos.Interfaz;
using RecetasSLN.dominio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecetasSLN.datos.Implementacion
{
    public class ClienteDao : IClienteDao
    {
        public List<ClienteDTO> GetClientes()
        {
            List<ClienteDTO> lista = new List<ClienteDTO>();
            DataTable tabla = HelperDB.ObtenerInstancia().Consultar("SP_CONSULTAR_CLIENTES");

            ClienteDTO auxiliar = null;

            foreach (DataRow row in tabla.Rows)
            {
                int id_cliente = (int)row["id_cliente"];
                string nombre = (string)row["nombre"];

                auxiliar = new ClienteDTO(id_cliente, nombre);

                lista.Add(auxiliar);
            }

            return lista;
        }
    }
}
