using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using domain;
using services;
using helpers;
using Controllers;

namespace TPC_Gomez_Chavero.Pages.Ver
{
    public partial class VerVentas : System.Web.UI.Page
    {
        private VentasController vc;
        private Filters filtros;
        public List<Ventas> order;

        protected void Page_Load(object sender, EventArgs e)
        {
            vc = new VentasController();
            filtros = new Filters();

            if (Session["user"] == null)
            {
                Response.Redirect("~/");
            }

            dgvVentas.DataSource = filtros.listarVentas();
            dgvVentas.DataBind();
        }

        protected void dgvVentas_SelectedIndexChanged(object sender, EventArgs e)
        {
            long id = Int64.Parse(dgvVentas.SelectedRow.Cells[0].Text);
            Response.Redirect("~/Pages/Reportes/Reporte.aspx?id=" + id);
        }

        protected void dgvVentas_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvVentas.PageIndex = e.NewPageIndex;
            dgvVentas.DataBind();
        }

        protected void chkCliente_CheckedChanged(object sender, EventArgs e)
        {
            filtros = new Filters();
            order = filtros.listarVentas();

            dgvVentas.DataSource = order.OrderBy(x => x.Cliente.Nombre).ToList();
            dgvVentas.DataBind();
        }

        protected void chkVendedor_CheckedChanged(object sender, EventArgs e)
        {
            filtros = new Filters();
            order = filtros.listarVentas();

            dgvVentas.DataSource = order.OrderBy(x => x.Vendedor.Nick).ToList();
            dgvVentas.DataBind();
        }

        protected void chkFecha_CheckedChanged(object sender, EventArgs e)
        {
            filtros = new Filters();
            order = filtros.listarVentas();

            dgvVentas.DataSource = order.OrderBy(x => x.FechaVenta).ToList();
            dgvVentas.DataBind();
        }

        protected void chkOrdenarFactura_CheckedChanged(object sender, EventArgs e)
        {
            filtros = new Filters();
            order = filtros.listarVentas();

            dgvVentas.DataSource = order.OrderBy(x => x.NumeroFactura).ToList();
            dgvVentas.DataBind();
        }
    }
}