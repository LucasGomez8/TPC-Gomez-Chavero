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
    public partial class VerCompras : Page
    {

        private Filters filtro;
        public User whoIs;
        public List<domain.Compras> paraOrdenar;
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

        protected void chkOrdenarFactura_CheckedChanged(object sender, EventArgs e)
        {
            filtro = new Filters();
            paraOrdenar = filtro.listarCompras();
            dgvCompras.DataSource = paraOrdenar.OrderBy(x => x.NumeroFactura).ToList();
            dgvCompras.DataBind();
        }

        protected void chkProveedor_CheckedChanged(object sender, EventArgs e)
        {
            filtro = new Filters();
            paraOrdenar = filtro.listarCompras();
            dgvCompras.DataSource = paraOrdenar.OrderBy(x => x.Proveedor.Nombre).ToList();
            dgvCompras.DataBind();
        }

        protected void chkVendedor_CheckedChanged(object sender, EventArgs e)
        {
            filtro = new Filters();
            paraOrdenar = filtro.listarCompras();
            dgvCompras.DataSource = paraOrdenar.OrderBy(x => x.Usuario.Nick).ToList();
            dgvCompras.DataBind();
        }

        protected void chkFecha_CheckedChanged(object sender, EventArgs e)
        {
            filtro = new Filters();
            paraOrdenar = filtro.listarCompras();
            dgvCompras.DataSource = paraOrdenar.OrderBy(x => x.FechaVenta).ToList();
            dgvCompras.DataBind();
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

                if (checkNotLetters(txtBuscar.Text,lblErroBuscar))
                {
                    long quer = long.Parse(txtBuscar.Text);
                    filtro = new Filters();
                    paraOrdenar = filtro.listarCompras();
                    dgvCompras.DataSource = paraOrdenar.Where(x => x.NumeroFactura == quer).ToList();
                    dgvCompras.DataBind();
                }
                else
                {
                    colError.Visible = true;
                }
            }
            else
            {
                colError.Visible = true;
                lblErroBuscar.Text = "Por favor, Ingrese datos al buscar";
            }

        }

        protected void dgvCompras_SelectedIndexChanged(object sender, EventArgs e)
        {
            long id = long.Parse(dgvCompras.SelectedRow.Cells[0].Text);
            Response.Redirect("~/Pages/Reportes/ReporteCompras.aspx?id=" + id);
        }
    }
}