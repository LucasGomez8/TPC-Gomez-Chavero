using System;

namespace TPC_Gomez_Chavero
{
    public partial class Site : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Nickname"] != null && Session["Password"] != null)
            {
                aLogin.Visible = false;
            }
        }
    }
}