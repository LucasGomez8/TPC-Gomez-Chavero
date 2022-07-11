using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using helpers;
using services;
using domain;


namespace TPC_Gomez_Chavero.Pages.Modificaciones
{
    public partial class EditarCliente : Page
    {

        public List<Client> clientList;
        public Client Selected;
        private ABMService abm;
        public User whoIs;

        protected void Page_Load(object sender, EventArgs e)
        {
            abm = new ABMService();

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

            txtFechaNac.Attributes["max"] = DateTime.Now.ToString("yyyy-MM-dd");
            txtFechaNac.Attributes["min"] = DateTime.MinValue.ToString("yyyy-MM-dd");
            if (!IsPostBack)
            {
                dropLoader();
            }
            if (Request.QueryString["id"] != null)
            {
                long id = long.Parse(Request.QueryString["id"].ToString());
                preLoad(id);
            }
            checkInputs();
        }

        public void preLoad(long id)
        {
            dropClientes.Enabled = false;
            btnSelect.Enabled = false;

            Selected = findIt(id);
            if (Selected == null)
            {
                Response.Write("<script>alert('Hubo un error al cargar la informacion del cliente')</script>");
                dropClientes.Enabled = true;
                btnSelect.Enabled = true;
                return;
            }

            txtNombre.Text = StringHelper.upperStartCharInAllWords(Selected.Nombre, ' ', "de");
            txtDNIoCuit.Text = Selected.CuitOrDni;

            txtFechaNac.Attributes.Remove("disabled");
            txtFechaNac.Value = Selected.fechaNac.ToString("yyyy-MM-dd");

            txtEmail.Enabled = true;
            txtEmail.Text = Selected.Email.ToLower();

            txtTelefono.Enabled = true;
            txtTelefono.Text = Selected.Telefono;
            
            btnCancelar.Enabled = true;
            btnSubmit.Enabled = true;
        }

        protected void btnSelect_Click(object sender, EventArgs e)
        {
            long id = long.Parse(dropClientes.SelectedItem.Value);
            preLoad(id);
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            long id = long.Parse(dropClientes.SelectedItem.Value);
            string nombre = txtNombre.Text;
            string cod = txtDNIoCuit.Text;
            string fec = txtFechaNac.Value;
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
                lblSuccess.Visible = true;
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
                row[1] = StringHelper.upperStartCharInAllWords(item.Nombre,' ', "de");
                data.Rows.Add(row);
            }

            dropClientes.DataSource = new DataView(data);
            dropClientes.DataTextField = "nombre";
            dropClientes.DataValueField = "id";
            dropClientes.DataBind();

            if (Request.QueryString["id"] != null)
            {
                long id = long.Parse(Request.QueryString["id"].ToString());
                dropClientes.SelectedValue = id.ToString();
            }
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

        protected void onTextChanged(object sender, EventArgs e)
        {
            TextBox txt = (TextBox)sender;

            txtFechaNac.Attributes.Remove("disabled");
            if (txt.ID == txtTelefono.ID) FormHelper.validateInputPhone(txtTelefono.Text, errorPhone);
            if (txt.ID == txtEmail.ID) FormHelper.validateInputEmail(txtEmail.Text, errorEmail);
        }

        private void checkInputs()
        {
            btnSubmit.Enabled = false;

            if (txtFechaNac.Value.Length == 0) return;

            if (txtTelefono.Text.Length == 0 || !FormHelper.validateInputPhone(txtTelefono.Text, errorPhone)) return;

            if (txtEmail.Text.Length == 0 ||
                !FormHelper.validateInputEmail(txtEmail.Text, errorEmail)) return;
            
            btnSubmit.Enabled = true;

        }
    }
}