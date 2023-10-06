using CarpinteriaApp.datos;
using RecetasSLN.datos.DTOs;
using RecetasSLN.dominio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecetasSLN.datos.Interfaz
{
    public interface IPedidoDao
    {
        bool Alta(int id);
        bool baja(int id);
        List<PedidoDTO> GetPedidos(List<Parametro>lParametros);
        List<PedidoDTO> GetPedidosSinFiltro();
    }
}
