using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using helpers;
using domain;
using Controllers;

namespace TPC_Gomez_Chavero.Pages.Reportes
{
    public partial class ReporteCompras : System.Web.UI.Page
    {
        ReportesController rep = new ReportesController();
        public List<Product> lista;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] != null)
            {
                long id = long.Parse(Request.QueryString["id"].ToString());
                cargarCompraUrl(id);
            }
            else
            {
                Response.Redirect("~/");
            }
        }
        

        public void cargarCompraUrl(long id)
        {
            domain.ReporteCompra res = rep.setReporteCompra(id);
            lista = rep.setProductosReporteCompra(id);

            lblNumeroFactura.Text = StringHelper.completeTicketNumbers(res.NumeroDeFactura, 1);

            forlblFecha.Text = "Fecha de Venta";
            lblFecha.Text = res.Fecha.ToString("dd/MM/yyyy");

            lblPersona.Text = res.Proveedor.Nombre;
    

            lblUsuarioNombre.Text = res.Usuario.Nombre;
            lblUsuarioApellido.Text = res.Usuario.Apellido;
            lblTipoUsuario.Text = res.Usuario.type.Description;

            lblMontoTotal.Text = res.MontoFinal.ToString();
        }

        protected void btnVolverHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/");
        }
    }
}