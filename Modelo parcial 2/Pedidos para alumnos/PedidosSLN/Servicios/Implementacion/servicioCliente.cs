using RecetasSLN.datos.DTOs;
using RecetasSLN.datos.Implementacion;
using RecetasSLN.datos.Interfaz;
using RecetasSLN.dominio;
using RecetasSLN.Servicios.Interfaz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecetasSLN.Servicios.Implementacion
{
    public class servicioCliente : IservicioCliente
    {
        IClienteDao dao;

        public servicioCliente()
        {
            dao = new ClienteDao();
        }

        public List<ClienteDTO> TraeClientes()
        {
            return dao.GetClientes();
        }
    }
}
