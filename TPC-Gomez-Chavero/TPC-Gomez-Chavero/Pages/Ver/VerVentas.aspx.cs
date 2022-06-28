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
    }
}