using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using services;
using domain;


namespace TPC_Gomez_Chavero.Pages.Modificaciones
{
    public partial class EditarCliente : System.Web.UI.Page
    {

        public List<Client> clientList;
        public Client Selected;

        protected void Page_Load(object sender, EventArgs e)
        {
            ABMService abm = new ABMService();
            clientList = abm.getClients();

            dropLoader();
        }

        protected void btnSelect_Click(object sender, EventArgs e)
        {
            int id = dropClientes.SelectedIndex;
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

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            int id = dropClientes.SelectedIndex;
            Selected = findIt(id);


        }

        public void dropLoader()
        {
            foreach (Client item in clientList)
            {
                dropClientes.Items.Add(item.Nombre);
            }
        }

        public Client findIt(int id)
        {
            Client thisis = new Client();
            thisis = clientList[id];

            return thisis;
        }
    }
}