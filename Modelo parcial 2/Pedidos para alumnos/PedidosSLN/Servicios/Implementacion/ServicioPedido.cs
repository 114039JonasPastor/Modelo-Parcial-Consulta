using CarpinteriaApp.datos;
using RecetasSLN.datos.DTOs;
using RecetasSLN.datos.Implementacion;
using RecetasSLN.datos.Interfaz;
using RecetasSLN.Servicios.Interfaz;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecetasSLN.Servicios.Implementacion
{
    public class ServicioPedido : IServicioPedido
    {
        IPedidoDao dao;

        public ServicioPedido()
        {
            dao = new PedidoDao();
        }

        public bool BajaPedido(int id)
        {
            return dao.baja(id);
        }

        public bool EntregaPedido(int id)
        {
            return dao.Alta(id);
        }

        public List<PedidoDTO> GetPedidos(List<Parametro> lParametros)
        {
            return dao.GetPedidos(lParametros);
        }

        public List<PedidoDTO> GetPedidosSinFiltro()
        {
            return dao.GetPedidosSinFiltro();
        }
    }
}
