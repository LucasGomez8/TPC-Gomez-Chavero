using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI.WebControls;
using domain;
using services;
using helpers;
using System.Web.UI;

namespace TPC_Gomez_Chavero.Pages.Altas
{
    public partial class AgregarUsuario : Page
    {
        public ABMService abm;
        public UserService us;
        public List<UserType> uTypeList;
        public List<User> dadosBaja;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            abm = new ABMService();
            us = new UserService();
            txtFechaNac.Attributes["max"] = DateTime.Now.ToString("yyyy-MM-dd");
            checkInputs();
            if (!IsPostBack) dropAdder();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string nombre = txtNombreUsuario.Text;
            string apellido = txtApellidoUsuario.Text;
            string dni = txtDni.Text;
            string date = txtFechaNac.Value.ToString();
            long idtipo = long.Parse(dropUserType.SelectedValue);
            string nick = txtNick.Text;
            string pass = txtPass.Text;

            if (us.userAdd(nombre, apellido, dni, idtipo, nick, pass, date) == 1)
            {
                lblSuccess.Text = "Usuario cargado con exito";
                lblSuccess.Visible = true;
                btnReload.Visible = true;
                btnSubmit.Visible = false;
            }
            else
            {
                lblSuccess.Text = "Hubo un error al cargar el usuario";
                lblSuccess.Visible = true;
            }
        }
        public void dropAdder()
        {
            uTypeList = us.getTypes();

            if (uTypeList == null) return;
            DataTable data = createEmptyDataTable();

            foreach (UserType item in uTypeList)
            {
                DataRow row = data.NewRow();
                row[0] = item.ID;
                row[1] = StringHelper.upperStartChar(item.Description);
                data.Rows.Add(row);
            }

            populateDropDown(data, dropUserType);
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
            dadosBaja = us.getUser(0);

            if (dadosBaja == null) return;
            DataTable data = createEmptyDataTable();

            foreach (User item in dadosBaja)
            {
                DataRow row = data.NewRow();
                row[0] = item.ID;
                row[1] = StringHelper.upperStartChar(item.Nick);
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


        protected void btnOk_Click(object sender, EventArgs e)
        {
            long id = long.Parse(dropElimnacionFisica.SelectedValue);

            if (id == 0)
            {
                lblSucessBaja.Text = "Seleccione una opcion valida!";
                lblSucessBaja.Visible = true;
                return;
            }

            if (us.changeStatus(id, 1) == 1)
            {
                lblSucessBaja.Text = "El usuario vuelve a poder manejar el sistema!";
                lblSucessBaja.Visible = true;
                btnOk.Enabled = false;
                btnContinuarBaja.Enabled = true;
            }
            else
            {
                lblSucessBaja.Text = "Hubo un error al dar de alta el Usuario!";
                lblSucessBaja.Visible = true;
            }
        }

        protected void btnVolverBaja_Click(object sender, EventArgs e)
        {
            lblSucessBaja.Visible = false;
            menu.Visible = true;
            debaja.Visible = false;
            btnContinuarBaja.Enabled = false;
        }

        protected void btnVolver2_Click(object sender, EventArgs e)
        {
            NuevoUsuario.Visible = false;
            menu.Visible = true;
        }

        protected void btnReload_Click(object sender, EventArgs e)
        {
            txtApellidoUsuario.Text = "";
            txtNombreUsuario.Text = "";
            txtFechaNac.Value = "";
            txtDni.Text = "";
            txtNick.Text = "";
            txtPass.Text = "";
            btnReload.Visible = false;
            btnSubmit.Visible = true;
            btnSubmit.Enabled= false;
            lblSuccess.Visible = false;
        }


        protected void btnContinuarBaja_Click(object sender, EventArgs e)
        {
            dropDadosBaja();
            btnContinuarBaja.Enabled = false;
            lblSucessBaja.Visible = false;
            btnOk.Enabled = true;
            btnOk.Visible = true;
        }

        protected void brnNuevoUsuario_Click(object sender, EventArgs e)
        {
            menu.Visible = false;
            NuevoUsuario.Visible = true;
        }

        protected void btnViejoUsuario_Click(object sender, EventArgs e)
        {
            dropDadosBaja();

            menu.Visible = false;
            debaja.Visible = true;
        }

        private void checkInputs()
        {
            if (txtNombreUsuario.Text.Length == 0) return;

            if (txtApellidoUsuario.Text.Length == 0) return;

            if (txtDni.Text.Length == 0 || !FormHelper.validateInputDniOrCuit(txtDni.Text, errorDNI)) return;

            if (txtFechaNac.Value.Length == 0) return;

            if (txtNick.Text.Length == 0) return;

            if (txtPass.Text.Length < 8 || !FormHelper.validateInputPassword(txtPass.Text, errorPasswd)) return;

            if (long.Parse(dropUserType.SelectedValue) == 0) return;

            btnSubmit.Enabled = true;
        }

        protected void onTextChanged(object sender, EventArgs e)
        {
            TextBox txt = (TextBox)sender;

            if (txt.ID == txtDni.ID) FormHelper.validateInputDniOrCuit(txtDni.Text, errorDNI);
            if (txt.ID == txtPass.ID) FormHelper.validateInputPassword(txtPass.Text, errorPasswd);
        }
    }
}