using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI.WebControls;
using domain;
using services;
using helpers;

namespace TPC_Gomez_Chavero.Pages.Altas
{
    public partial class AgregarUsuario : System.Web.UI.Page
    {
        public List<UserType> uTypeList;
        public List<User> dadosBaja;
        protected void Page_Load(object sender, EventArgs e)
        {
            dropAdder();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            UserService us = new UserService();

            string nombre = txtNombreUsuario.Text;
            string apellido = txtApellidoUsuario.Text;
            string dni = txtDni.Text;
            string date = txtFechaNac.Text.ToString();
            long idtipo = dropUserType.SelectedIndex + 1;
            string nick = txtNick.Text;
            string pass = txtPass.Text;

            us.userAdd(nombre, apellido, dni, idtipo, nick, pass, date);

        }

        public void dropAdder()
        {
            UserService us = new UserService();
            uTypeList = us.getTypes();

            foreach (UserType item in uTypeList)
            {
                dropUserType.Items.Add(item.Description);
            }

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

            DataRow newData = data.NewRow();
            newData[0] = -1;
            newData[1] = "Nuevo...";
            data.Rows.Add(newData);

            return data;
        }

        public void dropDadosBaja()
        {
            UserService us = new UserService();

            dadosBaja = us.getUser(0);

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
            UserService us = new UserService();
            long id = Int64.Parse(dropElimnacionFisica.SelectedValue);

            if (us.changeStatus(id, 1)==1)
            {
                lblSucessBaja.Text = "El usuario vuelve a poder manejar el sistema!";
                btnOk.Enabled = false;
                btnContinuarBaja.Enabled = true;
            }
        }

        protected void btnVolverBaja_Click(object sender, EventArgs e)
        {
            lblSucessBaja.Visible = false;
            menu.Visible = true;
            debaja.Visible = false;
            btnContinuarBaja.Enabled = false;

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
    }
}