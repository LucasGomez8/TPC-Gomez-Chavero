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

        protected void Page_Load(object sender, EventArgs e)
        {
            vc = new VentasController();
            filtros = new Filters();

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

        }
    }
}