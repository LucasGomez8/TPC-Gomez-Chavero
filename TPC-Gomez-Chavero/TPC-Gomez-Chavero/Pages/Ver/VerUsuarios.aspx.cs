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
        private Filters fil;
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

            fil = new Filters();

            dgvUsuarios.DataSource = fil.listarUsuarios();
            dgvUsuarios.DataBind();
        }

        public bool isActive(long id)
        {
            us = new UserService();
            List<User> list = us.getUser(0);

            foreach (User item in list)
            {
                if (item.ID == id)
                {
                    return false;
                }
            }

            return true;
        }

        protected void dgvUsuarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            var id = dgvUsuarios.SelectedRow.Cells[0].Text;

            if (isActive(Int64.Parse(id)))
            {
                Response.Redirect("~/Pages/Modificaciones/EditarUsuario.aspx?id=" + id);
            }
            else
            {
                Response.Write("<script>alert('El Usuario se encuentra dado de baja')</script>");
            }
        }

        protected void dgvUsuarios_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvUsuarios.PageIndex = e.NewPageIndex;
            dgvUsuarios.DataBind();
        }
    }
}