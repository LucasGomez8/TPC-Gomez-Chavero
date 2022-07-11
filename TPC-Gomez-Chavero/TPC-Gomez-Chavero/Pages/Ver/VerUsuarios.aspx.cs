using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using services;
using domain;
using helpers;


namespace TPC_Gomez_Chavero.Pages.Ver
{
    public partial class VerUsuarios : System.Web.UI.Page
    {
        private UserService us;
        private Filters fil;
        public User whoIs;
        public List<User> order;
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

        protected void chkApellido_CheckedChanged(object sender, EventArgs e)
        {
            fil = new Filters();
            order = fil.listarUsuarios();

            dgvUsuarios.DataSource = order.OrderBy(x => x.Apellido).ToList();
            dgvUsuarios.DataBind();
        }

        protected void chkDni_CheckedChanged(object sender, EventArgs e)
        {
            fil = new Filters();
            order = fil.listarUsuarios();

            dgvUsuarios.DataSource = order.OrderBy(x => x.DNI).ToList();
            dgvUsuarios.DataBind();
        }

        protected void chkTipoUsuario_CheckedChanged(object sender, EventArgs e)
        {
            fil = new Filters();
            order = fil.listarUsuarios();

            dgvUsuarios.DataSource = order.OrderBy(x => x.type.Description).ToList();
            dgvUsuarios.DataBind();
        }

        protected void chkUsername_CheckedChanged(object sender, EventArgs e)
        {
            fil = new Filters();
            order = fil.listarUsuarios();

            dgvUsuarios.DataSource = order.OrderBy(x => x.Nick).ToList();
            dgvUsuarios.DataBind();
        }

        public bool checkNotLetters(string q, Label lblError)
        {
            if (!FormHelper.validateNumber(q, lblError))
            {
                return false;
            }

            return true;
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            colError.Visible = false;
            if (txtBuscar.Text.Length > 0)
            {
                string que = txtBuscar.Text;
                if (checkNotLetters(que,lblErroBuscar))
                {
                    fil = new Filters();
                    order = fil.listarUsuarios();

                    dgvUsuarios.DataSource = order.Where(x => x.DNI == que).ToList();
                    dgvUsuarios.DataBind();
                }
                else
                {
                    colError.Visible = true;
                }

            }
            else
            {
                colError.Visible = true;
                lblErroBuscar.Text = "Por favor, Ingrese un valor al buscar...";
            }

        }
    }
}