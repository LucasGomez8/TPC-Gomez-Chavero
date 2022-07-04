using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using helpers;
using services;
using domain;


namespace TPC_Gomez_Chavero.Pages.Modificaciones
{
    public partial class EditarCliente : System.Web.UI.Page
    {

        public List<Client> clientList;
        public Client Selected;
        private ABMService abm;


        protected void Page_Load(object sender, EventArgs e)
        {
            abm = new ABMService();

            if (!IsPostBack)
            {
                dropLoader();
            }
            if (Request.QueryString["id"] != null)
            {
                long id = Int64.Parse(Request.QueryString["id"].ToString());
                preLoad(id);
            }
        }

        public void preLoad(long id)
        {
            dropClientes.Enabled = false;
            btnSelect.Enabled = false;

            Selected = findIt(id);

            txtNombre.Text = Selected.Nombre;
            txtDNIoCuit.Text = Selected.CuitOrDni;

            txtFechNac.Enabled = true;
            txtFechNac.Text = Selected.fechaNac.ToString("yyyy-MM-dd");

            txtEmail.Enabled = true;
            txtEmail.Text = Selected.Email;


            txtTelefono.Enabled = true;
            txtTelefono.Text = Selected.Telefono;


            
            btnSubmit.Enabled = true;
            btnCancelar.Enabled = true;
        }

        protected void btnSelect_Click(object sender, EventArgs e)
        {
            long id = Int64.Parse(dropClientes.SelectedItem.Value);
            Selected = findIt(id);

            txtNombre.Text = Selected.Nombre;

            txtDNIoCuit.Text = Selected.CuitOrDni;

            txtFechNac.Text = Selected.fechaNac.ToString("yyyy-MM-dd");

            txtEmail.Enabled = true;
            txtEmail.Text = Selected.Email;

            txtTelefono.Enabled = true;
            txtTelefono.Text = Selected.Telefono;

            btnSubmit.Enabled = true;
            btnCancelar.Enabled = true;

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            long id = Int64.Parse(dropClientes.SelectedItem.Value);
            Selected = findIt(id);

            string nombre = txtNombre.Text;
            string cod = txtDNIoCuit.Text;
            string fec = txtFechNac.Text;
            string tele = txtTelefono.Text;
            string mail = txtEmail.Text;

            if (abm.editClient(id, nombre, cod, fec, tele, mail) == 1)
            {
                lblSuccess.Visible = true;
                lblSuccess.Text = "Modificacion exitosa";
                btnCancelar.Visible = false;
                btnSubmit.Visible = false;
                btnContinuar.Visible = true;
            }
            else
            {
                lblSuccess.Visible = false;
                lblSuccess.Text = "Error al modificar";
            }
           
        }

        public void dropLoader()
        {
            clientList = abm.getClients(1);
            DataTable data = new DataTable();
            data.Columns.Add("id");
            data.Columns.Add("nombre");

            DataRow emptyData = data.NewRow();
            emptyData[0] = 0;
            emptyData[1] = "";
            data.Rows.Add(emptyData);

            foreach (Client item in clientList)
            {
                DataRow row = data.NewRow();
                row[0] = item.Id;
                row[1] = StringHelper.upperStartChar(item.Nombre);
                data.Rows.Add(row);
            }

            dropClientes.DataSource = new DataView(data);
            dropClientes.DataTextField = "nombre";
            dropClientes.DataValueField = "id";
            dropClientes.DataBind();
        }

        public Client findIt(long id)
        {
            clientList = abm.getClients(1);
            foreach (Client item in clientList)
            {
                if (item.Id == id)
                {
                    return item;
                }
            }

            return null;
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Pages/Modificaciones/EditarCliente.aspx");
        }

        protected void btnContinuar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Pages/Modificaciones/EditarCliente.aspx");
        }
    }
}