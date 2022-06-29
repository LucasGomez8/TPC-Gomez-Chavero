using System;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using domain;
using services;

namespace TPC_Gomez_Chavero.Pages.Altas
{
    public partial class AgregarCliente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Vendiendo"] != null)
            {
                btnSubmit.Visible = false;
                btnReturn.Visible = true;
            }
        }


        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            ABMService abm = new ABMService();
            string nombreCliente = txtNombreCliente.Text;
            string cod = txtDNIorCuit.Text;
            string date = txtFechaNac.Text.ToString();
            string telefono = txtTelefono.Text;
            string email = txtEmail.Text;
            abm.addClient(nombreCliente, cod, date, telefono, email);
        }

        protected void btnReturn_Click(object sender, EventArgs e)
        {
            ABMService abm = new ABMService();
            string nombreCliente = txtNombreCliente.Text;
            string cod = txtDNIorCuit.Text;
            string date = txtFechaNac.Text.ToString();
            string telefono = txtTelefono.Text;
            string email = txtEmail.Text;

            if (abm.addClient(nombreCliente, cod, date, telefono, email) == 1)
            {
                Response.Redirect("~/Pages/Ventas/MisVentas.aspx");
            }

        }
    }
}