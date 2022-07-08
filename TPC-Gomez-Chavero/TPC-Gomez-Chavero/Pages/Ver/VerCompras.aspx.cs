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
        public User whoIs;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] != null)
            {
                whoIs = (User)Session["user"];
                if (whoIs.type.Description != "Administrador")
                {
                    Response.Redirect("~/");
                }
            }
            else
            {
                Response.Redirect("~/");
            }

            LoadGridData();
        }

        public void LoadGridData()
        {
            filtro = new Filters();
            dgvCompras.DataSource = filtro.listarCompras();
            dgvCompras.DataBind();
        }

        protected void dgvCompras_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvCompras.PageIndex = e.NewPageIndex;
            dgvCompras.DataBind();
        }

        protected void dgvCompras_PageIndexChanging1(object sender, GridViewPageEventArgs e)
        {
            dgvCompras.PageIndex = e.NewPageIndex;
            dgvCompras.DataBind();
        }
    }
}