using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using domain;
using services;

namespace TPC_Gomez_Chavero.Pages
{
    public partial class Login : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblError.Visible = false;
        }

        protected void btnAcess_Click(object sender, EventArgs e)
        {
            string nick = txtNick.Text;
            string pass = txtPass.Text;

            ABMService abm = new ABMService();
            UserService userService = new UserService();
            User user = userService.login(nick, pass);

            
            if (abm.createTypes("Samsung", "Marcas") == 1)
            {
                Session["user"] = user;
                lblError.Text = "Marca cargada con existo";
                lblError.Visible = true;

            }
            else
            {
                lblError.Text = "Ha ocurrido un error";
                lblError.Visible = true;
            }
            /*
            if (user != null)
            {
                Session["user"] = user;
                lblError.Text = "Hola " + user.Nick + " eres " + user.type.Description;
                lblError.Visible = true;

            }
            else
            {
                lblError.Text = "Ha ocurrido un error";
                lblError.Visible = true;
            }*/
        }
    }
}