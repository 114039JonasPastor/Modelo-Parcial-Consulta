using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecetasSLN.datos.DTOs
{
    public class ClienteDTO
    {
        public int Id_cliente { get; set; }
        public string Nombre { get; set; }

        public ClienteDTO(int id_cliente, string nombre)
        {
            this.Id_cliente = id_cliente;
            this.Nombre = nombre;
        }
    }
}
