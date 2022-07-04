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
    public partial class VerClientes : System.Web.UI.Page
    {
        private Filters filtros;
        protected void Page_Load(object sender, EventArgs e)
        {
            filtros = new Filters();
                dgvClientes.DataSource = filtros.listarCliente();
                dgvClientes.DataBind();
        }


        public bool isActive(long id)
        {
            ABMService abm = new ABMService();
            List<Client> list = abm.getClients(0);

            foreach (Client item in list)
            {
                if (item.Id == id)
                {
                    return false;
                }
            }

            return true;
        }

        protected void dgvClientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            var id = dgvClientes.SelectedRow.Cells[0].Text;
            if (isActive(Int64.Parse(id)))
            {
                Response.Redirect("~/Pages/Modificaciones/EditarCliente.aspx?id=" + id);
            }
            else
            {
                Response.Write("<script>alert('El Cliente se encuentra dado de baja')</script>");
            }
           
        }
    }
}