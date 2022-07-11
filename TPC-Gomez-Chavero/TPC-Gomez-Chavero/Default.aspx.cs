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
            employeeSession.Visible = false;
            if (Session["user"] != null)
            {
                User ingreso = (User)Session["user"];
                if (ingreso.type.Description == "Administrador")
                {
                    adminSession.Visible = true;
                }
                else
                {
                    employeeSession.Visible = true;
                }
            }
        }
    }
}