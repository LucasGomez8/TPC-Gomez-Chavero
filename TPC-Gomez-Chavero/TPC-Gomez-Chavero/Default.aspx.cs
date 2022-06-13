using System;
using domain;

namespace TPC_Gomez_Chavero
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblBienvenida.Visible = false;
            adminSession.Visible = false;
            if (Session["Nickname"] != null && Session["Password"] != null)
            {
                string nick = Session["Nickname"].ToString();
                lblBienvenida.Visible = true;
                lblBienvenida.Text =nick + " tu acceso fue exitoso!";
                adminSession.Visible = true;
            }
        }
    }
}