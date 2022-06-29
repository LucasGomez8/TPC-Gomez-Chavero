using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using domain;
using services;
using helpers;
using Controllers;


namespace TPC_Gomez_Chavero.Pages.Ver
{
    public partial class VerClientes : System.Web.UI.Page
    {
        private Filters filtros;
        protected void Page_Load(object sender, EventArgs e)
        {
            filtros = new Filters();

            dgvClientes.DataSource = filtros.listarCliente();
            dgvClientes.DataBind();
        }
    }
}