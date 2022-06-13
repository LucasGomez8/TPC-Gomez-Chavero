using System;

namespace TPC_Gomez_Chavero
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            bool login = false;
            lblBienvenida.Visible = false;
            if (Request.QueryString["login"] != null)
            {
                    Boolean.TryParse(Request.QueryString["login"], out login);
            }

            if (login)
            {
                lblBienvenida.Visible = true;
                lblBienvenida.Text = "Bienvenido!";
            }
        }
    }
}