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
    public partial class VerProductos : System.Web.UI.Page
    {
        public ABMService abm;
        protected void Page_Load(object sender, EventArgs e)
        {
            abm = new ABMService();

            dgvProductos.DataSource = abm.getProducts(1);
            dgvProductos.DataBind();
        }

        protected void dgvProductos_SelectedIndexChanged(object sender, EventArgs e)
        {
            var id = dgvProductos.SelectedRow.Cells[0].Text;

            Response.Redirect("~/Pages/Modificaciones/EditProduct.aspx?id=" + id);
        }
    }
}