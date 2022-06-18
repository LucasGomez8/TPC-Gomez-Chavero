using System;
using domain;

namespace TPC_Gomez_Chavero
{
    public partial class Default : System.Web.UI.Page
    {
        User ingreso;
        protected void Page_Load(object sender, EventArgs e)
        {

            adminSession.Visible = false;
            if (Session["user"] != null)
            {
                ingreso = (User)Session["user"];
                lblBienvenida.Visible = true;
                lblBienvenida.Text = ingreso.Nombre.ToString() + " tu acceso fue exitoso!";
                adminSession.Visible = true;
            }
        }
    }
}