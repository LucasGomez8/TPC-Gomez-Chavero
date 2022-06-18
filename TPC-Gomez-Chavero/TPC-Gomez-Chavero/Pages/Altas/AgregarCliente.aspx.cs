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
    }
}