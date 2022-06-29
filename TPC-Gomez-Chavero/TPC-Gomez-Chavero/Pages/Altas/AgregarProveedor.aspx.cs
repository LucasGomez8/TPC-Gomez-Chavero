using System;
using System.Web.UI;
using services;


namespace TPC_Gomez_Chavero.Pages.Altas
{
    public partial class AgregarProveedor : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            btnReload.Visible = false;
            lblSuccess.Visible = false;
            if(Session["Comprando"] != null)
            {
                btnSubmit.Visible = false;
                btnReturn.Visible = true;
                Session.Remove("Comprando");
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string descripcion = txtNombre.Text;
            if (descripcion.Length == 0)
            {
                lblSuccess.Text = "Por favor, ingrese informacion correcta";
                lblSuccess.Visible = true;
                return;
            }

            ABMService abm = new ABMService();

            if (abm.addProvider(descripcion.ToLower()) == 1)
            {
                lblSuccess.Text = "Proveedor cargado con exito";
                lblSuccess.Visible = true;
                btnReload.Visible = true;
                btnSubmit.Visible = false;
            }
            else
            {
                lblSuccess.Text = "Hubo un error al cargar el proveedor, o bien, este ya existe.";
                lblSuccess.Visible = true;
            }
        }

        protected void btnReload_Click(object sender, EventArgs e)
        {
            btnReload.Visible = false;
            lblSuccess.Visible = false;
            txtNombre.Text = "";
            btnSubmit.Visible = true;
        }

        protected void btnReturn_Click(object sender, EventArgs e)
        {
            string descripcion = txtNombre.Text;
            if (descripcion.Length == 0)
            {
                lblSuccess.Text = "Por favor, ingrese informacion correcta";
                lblSuccess.Visible = true;
                return;
            }

            ABMService abm = new ABMService();

            if (abm.addProvider(descripcion.ToLower()) == 1)
            {
                Response.Redirect("~/Pages/Compras/MisCompras.aspx");
            }
        }
    }
}