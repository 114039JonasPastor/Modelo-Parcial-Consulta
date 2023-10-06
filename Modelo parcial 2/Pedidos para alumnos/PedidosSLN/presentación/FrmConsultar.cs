using CarpinteriaApp.datos;
using RecetasSLN.datos;
using RecetasSLN.datos.DTOs;
using RecetasSLN.dominio;
using RecetasSLN.Servicios.Implementacion;
using RecetasSLN.Servicios.Interfaz;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RecetasSLN.presentación
{
    public partial class FrmConsultar : Form
    {
        List<PedidoDTO> lPedidos;
        IservicioCliente servCliente = null;
        IServicioPedido servPedido = null;
       
        public FrmConsultar()
        {
            InitializeComponent();
            servCliente = new servicioCliente();
            servPedido = new ServicioPedido();
            lPedidos = new List<PedidoDTO>();
            
        }

        private void FrmConsultar_Load(object sender, EventArgs e)
        {
            dtpDesde.Value = DateTime.Now.AddDays(-30);
            CargarCombo();
            cboClientes.SelectedIndex = -1;
            lblTotal.Text = "Total de pedidos: 0";
        }

        private void CargarCombo()
        {
            cboClientes.DataSource = servCliente.TraeClientes();
            cboClientes.ValueMember = "id_cliente";
            cboClientes.DisplayMember = "nombre";
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            if (cboClientes.SelectedIndex == -1)
            {
                lPedidos.Clear();
                dgvPedidos.Rows.Clear();

                lPedidos.AddRange(servPedido.GetPedidosSinFiltro());

                foreach (PedidoDTO pDTO in lPedidos)
                {
                    dgvPedidos.Rows.Add(new object[] { pDTO.Codigo, pDTO.Cliente, pDTO.FechaEntrega, pDTO.Entregado });
                }

                lblTotal.Text = "Total de pedidos: " + dgvPedidos.Rows.Count.ToString();
            }
            else
            {
                List<Parametro> lista = new List<Parametro>();
                lista.Add(new Parametro("@cliente", Convert.ToInt32(cboClientes.SelectedValue)));
                lista.Add(new Parametro("@fecha_desde", dtpDesde.Value));
                lista.Add(new Parametro("@fecha_hasta", dtpHasta.Value));

                lPedidos.Clear();
                dgvPedidos.Rows.Clear();

                lPedidos.AddRange(servPedido.GetPedidos(lista));

                foreach (PedidoDTO pDTO in lPedidos)
                {
                    dgvPedidos.Rows.Add(new object[] { pDTO.Codigo, pDTO.Cliente, pDTO.FechaEntrega, pDTO.Entregado });
                }

                lblTotal.Text = "Total de pedidos: " + dgvPedidos.Rows.Count.ToString();
                cboClientes.SelectedIndex = -1;
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("¿Esta seguro de que desea salir?","SALIR",MessageBoxButtons.YesNo,MessageBoxIcon.Question)== DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void dgvPedidos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int id = Convert.ToInt32(dgvPedidos.CurrentRow.Cells["colCodigo"].Value.ToString());
            string entregado = dgvPedidos.CurrentRow.Cells["colEntregado"].Value.ToString();
            //Completar...
            if (dgvPedidos.CurrentCell.ColumnIndex == 5)
            {
                if (MessageBox.Show("¿Esta seguro que quiere dar de baja este pedido?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (servPedido.BajaPedido(id))
                    {
                        MessageBox.Show("Se dio de baja el pedido", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dgvPedidos.Rows.RemoveAt(dgvPedidos.CurrentRow.Index);
                        lblTotal.Text = "Total de pedidos: " + dgvPedidos.Rows.Count.ToString();
                        return;
                    }
                    else
                    {
                        MessageBox.Show("Error al dar de baja el pedido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }   
            }
            if(dgvPedidos.CurrentCell.ColumnIndex == 4)
            {
                if(entregado == "S")
                {
                    MessageBox.Show("Este producto ya ha sido entregado", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else
                {
                    if (MessageBox.Show("¿Esta seguro que quiere entregar este pedido?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if (servPedido.EntregaPedido(id))
                        {
                            MessageBox.Show("Se entrego el pedido", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            dgvPedidos.Rows.RemoveAt(dgvPedidos.CurrentRow.Index);
                            lblTotal.Text = "Total de pedidos: " + dgvPedidos.Rows.Count.ToString();
                            return;
                        }
                        else
                        {
                            MessageBox.Show("Error al entregar el pedido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                }

            }
        }
    }
}
