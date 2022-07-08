using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using services;
using domain;

namespace TPC_Gomez_Chavero.Pages.Ver
{
    public partial class VerProveedores : System.Web.UI.Page
    {

        private ABMService abm;
        private Filters fil;
        protected void Page_Load(object sender, EventArgs e)
        {
            fil = new Filters();

            dgvProveedores.DataSource = fil.listarProveedores();
            dgvProveedores.DataBind();
        }

        public bool isActive(long id)
        {
            abm = new ABMService();
            List<Provider> list = abm.getProvider(0);

            foreach (Provider item in list)
            {
                if (item.Id == id)
                {
                    return false;
                }
            }

            return true;
        }

        protected void dgvProveedores_SelectedIndexChanged(object sender, EventArgs e)
        {
            var id = dgvProveedores.SelectedRow.Cells[0].Text;
            if (isActive(Int64.Parse(id)))
            {
                Response.Redirect("~/Pages/Modificaciones/EditarProveedor.aspx?id=" + id);
            }
            else
            {
                Response.Write("<script>alert('El Proveedor se encuentra dado de baja')</script>");
            }

        }

        protected void dgvProveedores_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvProveedores.PageIndex = e.NewPageIndex;
            dgvProveedores.DataBind();
        }
    }
}