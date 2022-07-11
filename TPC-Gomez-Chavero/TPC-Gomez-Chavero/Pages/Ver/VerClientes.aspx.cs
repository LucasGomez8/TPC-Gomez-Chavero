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
        public User whoIs;
        public List<Client> paraOrdenar;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] != null)
            {
                whoIs = (User)Session["user"];
                if (whoIs.type.Description == "Administrador")
                {
                    LoadGridData();
                    dgvClientes.Visible = true;
                    dgvClientesEmployee.Visible = false;
                }
                else
                {
                    LoadGridEmployeeData();
                    dgvClientes.Visible = false;
                    dgvClientesEmployee.Visible = true;
                }
            }
            else
            {
                Response.Redirect("~/");
            }


            
        }

        public void LoadGridData()
        {
            filtros = new Filters();
            dgvClientes.DataSource = filtros.listarCliente();
            dgvClientes.DataBind();
        }

        public void LoadGridEmployeeData()
        {
            filtros = new Filters();
            dgvClientesEmployee.DataSource = filtros.listarCliente();
            dgvClientesEmployee.DataBind();
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

        protected void dgvClientes_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvClientes.PageIndex = e.NewPageIndex;
            LoadGridData();
            dgvClientes.DataBind();
        }

        protected void dgvClientesEmployee_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvClientesEmployee.PageIndex = e.NewPageIndex;
            LoadGridEmployeeData();
            dgvClientes.DataBind();
        }

        protected void chkOrdenarNombre_CheckedChanged(object sender, EventArgs e)
        {
            filtros = new Filters();

            paraOrdenar = filtros.listarCliente();
            List<Client> nuevo = new List<Client>();

            nuevo = paraOrdenar.OrderBy(x => x.Nombre).ToList();

            if (whoIs.type.Description == "Administrador")
            {
                dgvClientes.DataSource = nuevo;
                dgvClientes.DataBind();
            }
            else
            {
                dgvClientesEmployee.DataSource = nuevo;
                dgvClientesEmployee.DataBind();
            }
     

        }

        protected void chkCuitOrDni_CheckedChanged(object sender, EventArgs e)
        {
            filtros = new Filters();
            paraOrdenar = filtros.listarCliente();

            if (whoIs.type.Description == "Administrador")
            {
                dgvClientes.DataSource = paraOrdenar.OrderBy(x => x.CuitOrDni).ToList();
                dgvClientes.DataBind();
            }
            else
            {
                dgvClientesEmployee.DataSource = paraOrdenar.OrderBy(x => x.CuitOrDni).ToList();
                dgvClientes.DataBind();
            }

        }
    }
}