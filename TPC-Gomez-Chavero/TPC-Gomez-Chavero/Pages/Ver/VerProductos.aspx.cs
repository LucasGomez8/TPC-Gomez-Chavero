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
        public Filters fil;
        protected void Page_Load(object sender, EventArgs e)
        {
            fil = new Filters();

            dgvProductos.DataSource = fil.getStoresProducts();
            dgvProductos.DataBind();
        }

        public bool isActive(long id)
        {
            abm = new ABMService();
            List<Product> list = abm.getProducts(1);

            foreach (Product item in list)
            {
                if (item.Id == id)
                {
                    return item.Estado;
                }
            }

            return false;
        }

        protected void dgvProductos_SelectedIndexChanged(object sender, EventArgs e)
        {
            var id = dgvProductos.SelectedRow.Cells[0].Text;

            if (isActive(Int64.Parse(id)))
            {
                Response.Redirect("~/Pages/Modificaciones/EditProduct.aspx?id=" + id);
            }
            else
            {
                Response.Write("<script>alert('El Producto se encuentra dado de baja')</script>");
            }
        }
    }
}