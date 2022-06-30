using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using services;
using domain;


namespace TPC_Gomez_Chavero.Pages.Ver
{
    public partial class VerUsuarios : System.Web.UI.Page
    {
        private UserService us;
        protected void Page_Load(object sender, EventArgs e)
        {
            us = new UserService();

            dgvUsuarios.DataSource = us.getUser();
            dgvUsuarios.DataBind();
        }
    }
}