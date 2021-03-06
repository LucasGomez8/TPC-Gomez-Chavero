using System;
using System.Data;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using helpers;
using services;
using domain;

namespace TPC_Gomez_Chavero.Pages.Altas
{
    public partial class AgregarCliente : Page
    {

        public ABMService abm;
        public List<Client> dadosBaja;
        public User whoIs;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] != null)
            {
                whoIs = (User)Session["user"];
                if (whoIs.type.Description == "Administrador")
                {
                    btnViejoCliente.Visible = true;
                }
                else
                {
                    btnViejoCliente.Visible = false;
                }
            }
            else
            {
                Response.Redirect("~/");
            }

            abm = new ABMService();
            txtFechaNac.Attributes["max"] = DateTime.Now.ToString("yyyy-MM-dd");
            if (Session["Vendiendo"] != null)
            {
                btnSubmit.Visible = false;
                btnReturn.Visible = true;

            }
            checkInputs();
        }


        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string nombreCliente = txtNombreCliente.Text;
            string cod = txtDNIorCuit.Text;
            string date = txtFechaNac.Value;
            string telefono = txtTelefono.Text;
            string email = txtEmail.Text;
            if (abm.addClient(nombreCliente, cod, date, telefono, email) == 1)
            {
                lblSuccess.Text = "Cliente cargado con exito";
                btnReload.Visible = true;
                btnSubmit.Visible = false;
            }
            else
            {
                lblSuccess.Text = "Hubo un error al cargar el cliente";
            }
        }

        protected void btnReload_Click(object sender, EventArgs e)
        {
            if (Session["Vendiendo"] != null)
            {
                Response.Redirect("~/Pages/Ventas/MisVentas.aspx");
                return;
            }
            txtNombreCliente.Text = "";
            txtDNIorCuit.Text = "";
            txtFechaNac.Value = "";
            txtTelefono.Text = "";
            txtEmail.Text = "";
            btnReload.Visible = false;
            btnSubmit.Visible = true;
            lblSuccess.Visible = false;
        }


        private DataTable createEmptyDataTable()
        {
            DataTable data = new DataTable();
            data.Columns.Add("id");
            data.Columns.Add("description");

            DataRow emptyData = data.NewRow();
            emptyData[0] = 0;
            emptyData[1] = "";
            data.Rows.Add(emptyData);

            return data;
        }

        public void dropDadosBaja()
        {
            ABMService abm = new ABMService();
            dadosBaja = abm.getClients(0);

            DataTable data = createEmptyDataTable();

            foreach (Client item in dadosBaja)
            {
                DataRow row = data.NewRow();
                row[0] = item.Id;
                row[1] = StringHelper.upperStartChar(item.Nombre);
                data.Rows.Add(row);
            }

            populateDropDown(data, dropElimnacionFisica);
        }

        private void populateDropDown(DataTable dataTable, DropDownList dropDown)
        {
            dropDown.DataSource = new DataView(dataTable);
            dropDown.DataTextField = "description";
            dropDown.DataValueField = "id";
            dropDown.DataBind();
        }

        protected void btnReturn_Click(object sender, EventArgs e)
        {
            string nombreCliente = txtNombreCliente.Text;
            string cod = txtDNIorCuit.Text;
            string date = txtFechaNac.Value;
            string telefono = txtTelefono.Text;
            string email = txtEmail.Text;

            if (abm.addClient(nombreCliente, cod, date, telefono, email) == 1)
            {
                lblSuccess.Text = "Cliente cargado con exito";
                btnReload.Visible = true;
                btnReturn.Visible = false;
            }
            else
            {
                lblSuccess.Text = "Hubo un error al cargar el cliente";
            }
        }

        private void checkInputs()
        {
            if (txtNombreCliente.Text.Length == 0) { btnSubmit.Enabled = false; btnReturn.Enabled = false; return; }

            if (txtDNIorCuit.Text.Length == 0 || !FormHelper.validateInputDniOrCuit(txtDNIorCuit.Text, errorDNIorCuit)) { btnSubmit.Enabled = false; btnReturn.Enabled = false; return; }

            if (txtFechaNac.Value.Length == 0) { btnSubmit.Enabled = false; btnReturn.Enabled = false; return; }
            if (txtTelefono.Text.Length == 0 || !FormHelper.validateInputPhone(txtTelefono.Text, errorTelefono)) { btnSubmit.Enabled = false; btnReturn.Enabled = false; return; }

            if (txtEmail.Text.Length == 0  ||
                !FormHelper.validateInputEmail(txtEmail.Text, errorEmail)) { btnSubmit.Enabled = false; btnReturn.Enabled = false; return; }

            btnSubmit.Enabled = true;
            btnReturn.Enabled = true;
        }

        protected void onTextChanged(object sender, EventArgs e)
        {
            TextBox txt = (TextBox)sender;
   
            if (txt.ID == txtDNIorCuit.ID) FormHelper.validateInputDniOrCuit(txtDNIorCuit.Text, errorDNIorCuit);
            if (txt.ID == txtEmail.ID) FormHelper.validateInputEmail(txtEmail.Text, errorEmail);
            if (txt.ID == txtTelefono.ID) FormHelper.validateInputPhone(txtTelefono.Text, errorTelefono);
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            debaja.Visible = false;
            menu.Visible = true;
            lblSucessBaja.Visible = false;
        }

        protected void btnContinue_Click(object sender, EventArgs e)
        {
            lblSucessBaja.Visible = false;
            btnContinuarBaja.Enabled = false;
            dropElimnacionFisica.SelectedValue = 0.ToString();
        }

        protected void btnNuevoCliente_Click(object sender, EventArgs e)
        {
            menu.Visible = false;
            NuevoCliente.Visible = true;
        }

        protected void btnViejoCliente_Click(object sender, EventArgs e)
        {
            menu.Visible = false;
            debaja.Visible = true;
            dropDadosBaja();
        }

        protected void btnOk_Click(object sender, EventArgs e)
        {
            long id = long.Parse(dropElimnacionFisica.SelectedItem.Value);
            if (id == 0)
            {
                lblSucessBaja.Text = "Seleccione una opcion valida!";
                lblSucessBaja.Visible = true;
                return;
            }

            if (abm.changeStatus("Clientes", "IDCliente", 1, id) == 1)
            {
                lblSucessBaja.Text = "Cliente dada de alta nuevamente!";
                lblSucessBaja.Visible = true;

                btnContinuarBaja.Enabled = true;
            }
            else
            {
                lblSucessBaja.Text = "Hubo un error al dar de alta nuevamente el Cliente!";
                lblSucessBaja.Visible = true;
            }
        }

        protected void btnVolver2_Click(object sender, EventArgs e)
        {
            NuevoCliente.Visible = false;
            menu.Visible = true;
        }
    }
}