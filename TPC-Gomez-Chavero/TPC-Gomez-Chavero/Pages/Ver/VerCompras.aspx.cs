using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using domain;
using services;
using helpers;


namespace TPC_Gomez_Chavero.Pages.Ver
{
    public partial class VerCompras : System.Web.UI.Page
    {

        private Filters filtro;
        protected void Page_Load(object sender, EventArgs e)
        {
            filtro = new Filters();
            dgvCompras.DataSource = filtro.listarCompras();
            dgvCompras.DataBind();
        }
    }
}