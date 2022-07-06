using System;

namespace TPC_Gomez_Chavero
{
    public partial class Site : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] != null)
            {
                aLogin.Visible = false;
                btnLogOut.Visible = true;
            }
        }

        protected void btnLogOut_Click(object sender, EventArgs e)
        {
            Session.Remove("user");
            Response.Redirect("~/");
        }
    }
}