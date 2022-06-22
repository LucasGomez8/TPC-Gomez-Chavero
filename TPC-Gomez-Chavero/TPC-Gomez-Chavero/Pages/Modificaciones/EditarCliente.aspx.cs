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
        }

        protected void btnSelect_Click(object sender, EventArgs e)
        {
            long id = Int64.Parse(dropClientes.SelectedItem.Value);
            Selected = findIt(id);

            txtNombre.Enabled = true;
            txtNombre.Text = Selected.Nombre;

            txtDNIoCuit.Enabled = true;
            txtDNIoCuit.Text = Selected.CuitOrDni;

            txtFechNac.Enabled = true;
            txtFechNac.Text = Selected.fechaNac.ToString();

            txtEmail.Enabled = true;
            txtEmail.Text = Selected.Email;

            txtTelefono.Enabled = true;
            txtTelefono.Text = Selected.Telefono;

            btnSubmit.Enabled = true;

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

            if (abm.editClient(Selected.Id, nombre, cod, fec, tele, mail) == 1)
            {
                lblSuccess.Visible = true;
                lblSuccess.Text = "Modificacion exitosa";
            }
            else
            {
                lblSuccess.Visible = false;
                lblSuccess.Text = "Error al modificar";
            }
           
        }

        public void dropLoader()
        {
            clientList = abm.getClients();
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
            clientList = abm.getClients();
            foreach (Client item in clientList)
            {
                if (item.Id == id)
                {
                    return item;
                }
            }

            return null;
        }
    }
}