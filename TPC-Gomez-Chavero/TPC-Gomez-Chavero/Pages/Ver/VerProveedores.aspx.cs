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
    public partial class VerProveedores : System.Web.UI.Page
    {

        private ABMService abm;
        protected void Page_Load(object sender, EventArgs e)
        {
            abm = new ABMService();

            dgvProveedores.DataSource = abm.getProvider();
            dgvProveedores.DataBind();
        }
    }
}