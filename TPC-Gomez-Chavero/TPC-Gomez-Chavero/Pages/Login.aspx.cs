using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using services;

namespace TPC_Gomez_Chavero.Pages
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblError.Visible = false;
        }

        protected void btnAcess_Click(object sender, EventArgs e)
        {
            string nick = txtNick.Text;
            string pass = txtPass.Text;

            CommerceConnecction cc = new CommerceConnecction();

            if (cc.UserVerify(nick, pass))
            {
                Session["Nickname"] = nick;
                Session["Password"] = pass;
                Response.Redirect("~/");
            }
            else
            {
                lblError.Text = "Ha ocurrido un error";
                lblError.Visible = true;
            }
        }
    }
}