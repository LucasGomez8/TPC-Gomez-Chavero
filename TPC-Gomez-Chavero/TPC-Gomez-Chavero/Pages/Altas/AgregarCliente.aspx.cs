using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web.UI;
using System.Web.UI.WebControls;
using helpers;
using services;

namespace TPC_Gomez_Chavero.Pages.Altas
{
    public partial class AgregarCliente : Page
    {

        ABMService abm;

        protected void Page_Load(object sender, EventArgs e)
        {
            abm = new ABMService();
            txtFechaNac.Attributes["max"] = DateTime.Now.ToString("yyyy-MM-dd");
            if (Session["Vendiendo"] != null)
            {
                btnSubmit.Visible = false;
                btnReturn.Visible = true;
            }
            checkInputs();
        }


        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string nombreCliente = txtNombreCliente.Text;
            string cod = txtDNIorCuit.Text;
            string date = txtFechaNac.Value;
            string telefono = txtTelefono.Text;
            string email = txtEmail.Text;
            if (abm.addClient(nombreCliente, cod, date, telefono, email) == 1)
            {
                lblSuccess.Text = "Cliente cargado con exito";
                btnReload.Visible = true;
                btnSubmit.Visible = false;
            }
            else
            {
                lblSuccess.Text = "Hubo un error al cargar el cliente";
            }
        }

        protected void btnReload_Click(object sender, EventArgs e)
        {
            if (Session["Vendiendo"] != null)
            {
                Response.Redirect("~/Pages/Ventas/MisVentas.aspx");
                return;
            }
            txtNombreCliente.Text = "";
            txtDNIorCuit.Text = "";
            txtFechaNac.Value = "";
            txtTelefono.Text = "";
            txtEmail.Text = "";
            btnReload.Visible = false;
            btnSubmit.Visible = true;
            lblSuccess.Visible = false;
        }

        protected void btnReturn_Click(object sender, EventArgs e)
        {
            string nombreCliente = txtNombreCliente.Text;
            string cod = txtDNIorCuit.Text;
            string date = txtFechaNac.Value;
            string telefono = txtTelefono.Text;
            string email = txtEmail.Text;

            if (abm.addClient(nombreCliente, cod, date, telefono, email) == 1)
            {
                lblSuccess.Text = "Cliente cargado con exito";
                btnReload.Visible = true;
                btnReturn.Visible = false;
            }
            else
            {
                lblSuccess.Text = "Hubo un error al cargar el cliente";
            }
        }

        private void checkInputs()
        {
            if (txtNombreCliente.Text.Length == 0) return;

            if (txtDNIorCuit.Text.Length == 0 || !FormHelper.validateInputDniOrCuit(txtDNIorCuit.Text, errorDNIorCuit)) return;

            if (txtFechaNac.Value.Length == 0) return;

            if (txtTelefono.Text.Length == 0 || !FormHelper.validateInputPhone(txtTelefono.Text, errorTelefono)) return;
            
            if (txtEmail.Text.Length == 0  ||
                !FormHelper.validateInputEmail(txtEmail.Text, errorEmail)) return;
            
            btnSubmit.Enabled = true;
            btnReturn.Enabled = true;
        }

        protected bool onPhoneChanged()
        {
            string data = txtTelefono.Text.Trim();
            if (!data.All(char.IsDigit))
            {
                errorTelefono.Text = "Solo puede contener numeros...";
                errorTelefono.Visible = true;
                return true;
            }
            if (data.Length < 8)
            {
                errorTelefono.Text = "Tiene que tener minimo 8 digitos...";
                errorTelefono.Visible = true;
                return true;
            }
            errorTelefono.Visible = false;
            return false;
        }

        protected void onTextChanged(object sender, EventArgs e)
        {
            TextBox txt = (TextBox)sender;
   
            if (txt.ID == txtDNIorCuit.ID) FormHelper.validateInputDniOrCuit(txtDNIorCuit.Text, errorDNIorCuit);
            if (txt.ID == txtEmail.ID) FormHelper.validateInputEmail(txtEmail.Text, errorEmail);
            if (txt.ID == txtTelefono.ID) FormHelper.validateInputPhone(txtTelefono.Text, errorTelefono);
        }
    }
}