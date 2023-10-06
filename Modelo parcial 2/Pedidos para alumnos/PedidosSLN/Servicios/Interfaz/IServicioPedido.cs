using CarpinteriaApp.datos;
using RecetasSLN.datos.DTOs;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecetasSLN.Servicios.Interfaz
{
    public interface IServicioPedido
    {
        List<PedidoDTO> GetPedidos(List<Parametro> lParametros);
        bool BajaPedido(int id);
        bool EntregaPedido(int id);
        List<PedidoDTO> GetPedidosSinFiltro();
    }
}
