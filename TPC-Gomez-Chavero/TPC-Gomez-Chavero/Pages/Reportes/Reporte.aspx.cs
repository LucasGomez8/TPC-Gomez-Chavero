using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using services;
using domain;
using Controllers;


namespace TPC_Gomez_Chavero.Pages.Reportes
{
    public partial class Reporte : System.Web.UI.Page
    {
        ReportesController rep = new ReportesController();
        public List<Product> lista;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] != null)
            {
                long id = Int64.Parse(Request.QueryString["id"].ToString());
                cargarVentaURL(id);
            }
            else
            {
                cargarVenta();
            }

        }

        public void cargarVentaURL(long id)
        {
            domain.Reportitos res = rep.setReporte(id);
            lista = rep.setProductosReporte(id);

            lblNumeroFactura.Text = res.NumeroDeFactura.ToString();

            forlblFecha.Text = "Fecha de Venta";
            lblFecha.Text = res.Fecha.ToString();

            lblPersona.Text = res.Cliente.Nombre;
            lblPersonaCuitDni.Text = res.Cliente.CuitOrDni;
            lblPersonaEmail.Text = res.Cliente.Email;
            lblPersonTelefono.Text = res.Cliente.Telefono;

            lblUsuarioNombre.Text = res.Usuario.Nombre;
            lblUsuarioApellido.Text = res.Usuario.Apellido;
            lblDNIUsuario.Text = res.Usuario.DNI;
            lblTipoUsuario.Text = res.Usuario.type.Description;

            lblMontoTotal.Text = res.MontoFinal.ToString();
        }

        public void cargarVenta()
        {
            rep = new ReportesController();
            long id = rep.getId();
            domain.Reportitos res = rep.setReporte(id);
            lista = rep.setProductosReporte(id);

            lblNumeroFactura.Text = res.NumeroDeFactura.ToString();

            forlblFecha.Text = "Fecha de Venta";
            lblFecha.Text = res.Fecha.ToString();

            lblPersona.Text = res.Cliente.Nombre;
            lblPersonaCuitDni.Text = res.Cliente.CuitOrDni;
            lblPersonaEmail.Text = res.Cliente.Email;
            lblPersonTelefono.Text = res.Cliente.Telefono;

            lblUsuarioNombre.Text = res.Usuario.Nombre;
            lblUsuarioApellido.Text = res.Usuario.Apellido;
            lblDNIUsuario.Text = res.Usuario.DNI;
            lblTipoUsuario.Text = res.Usuario.type.Description;

            lblMontoTotal.Text = res.MontoFinal.ToString();

        }

        protected void btnVolverHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/");
        }
    }
}