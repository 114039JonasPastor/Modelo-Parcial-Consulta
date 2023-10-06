using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace RecetasSLN.dominio
{
    public class Pedido
    {
        public string Codigo { get; set; }
        public DateTime FechaEntrega { get; set; }
        public string DireccionEntrega { get; set; }
        public DateTime FechaBaja { get; set; }
        public string Entregado { get; set; }

        public Pedido(string codigo, DateTime fechaEntrega, string direccionEntrega, DateTime fechaBaja, string entregado)
        {
            Codigo = codigo;
            FechaEntrega = fechaEntrega;
            DireccionEntrega = direccionEntrega;
            FechaBaja = fechaBaja;
            Entregado = entregado;
        }
    }
}
