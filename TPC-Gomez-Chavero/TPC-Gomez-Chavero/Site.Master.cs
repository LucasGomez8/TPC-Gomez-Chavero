using System;
using domain;
using services;
using Controllers;


namespace TPC_Gomez_Chavero
{
    public partial class Site : System.Web.UI.MasterPage
    {
        public User inSession;

        protected void Page_Load(object sender, EventArgs e)
        {

            onLoad();

            if (Session["user"] != null)
            {
                inSession = (User)Session["user"];

                if (inSession.type.Description == "Administrador")
                {
                    adminViews();
                    aLogin.Visible = false;
                    btnLogOut.Visible = true;
                }
                else
                {
                    employeView();
                    aLogin.Visible = false;
                    btnLogOut.Visible = true;
                }
            }
        }

        public void employeView()
        {
            adminView.Visible = false;
            adminView2.Visible = true;
            clientes.Visible = true;
            adminView4.Visible = false;
            adminView5.Visible = false;
            admin7.Visible = true;
            adminView8.Visible = false;
            adminView9.Visible = false;
            Ventas.Visible = true;
            adminView3.Visible = false;
            verventas.Visible = true;
            altaCliente.Visible = true;
            productos.Visible = true;

            altaProducto.Visible = false;
            altaCategoria.Visible = false;
            altaMarca.Visible = false;
            altaProveedor.Visible = false;
            altaTipo.Visible = false;
            altaUsuario.Visible = false;
        }

        public void adminViews()
        {
            adminView.Visible = true;
            adminView2.Visible = true;
            adminView4.Visible = true;
            adminView5.Visible = true;
            admin7.Visible = true;
            adminView8.Visible = true;
            adminView9.Visible = true;
            Ventas.Visible = true;
            adminView3.Visible = true;
            verventas.Visible = true;
            clientes.Visible = true;
            productos.Visible = true;
        }

        public void onLoad()
        {
            adminView.Visible = false;
            adminView2.Visible = false;
            adminView4.Visible = false;
            adminView5.Visible = false;
            admin7.Visible = false;
            adminView8.Visible = false;
            adminView9.Visible = false;
            Ventas.Visible = false;
            adminView3.Visible = false;
            verventas.Visible = false;
            clientes.Visible = false;
            productos.Visible = false;
        }

        protected void btnLogOut_Click(object sender, EventArgs e)
        {
            Session.Remove("user");
            Response.Redirect("~/");
        }
    }
}