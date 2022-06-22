using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using domain;
using services;
using helpers;


namespace TPC_Gomez_Chavero.Pages.Modificaciones
{
    public partial class EditarUsuario : System.Web.UI.Page
    {

        public List<User> userList;
        public List<UserType> userTypeList;
        private UserService us;

        protected void Page_Load(object sender, EventArgs e)
        {
            us = new UserService();
            if (!IsPostBack)
            {
                dropUserLoader();
            }
        }

        public void dropUserLoader()
        {
            userList = us.getUser();

            DataTable data = new DataTable();
            data.Columns.Add("id");
            data.Columns.Add("nombre");

            DataRow emptyData = data.NewRow();
            emptyData[0] = 0;
            emptyData[1] = "";
            data.Rows.Add(emptyData);

            foreach (User item in userList)
            {
                DataRow row = data.NewRow();
                row[0] = item.ID;
                row[1] = StringHelper.upperStartChar(item.Nombre);
                data.Rows.Add(row);
            }

            dropUsuarios.DataSource = new DataView(data);
            dropUsuarios.DataTextField = "nombre";
            dropUsuarios.DataValueField = "id";
            dropUsuarios.DataBind();
        }

        protected void btnSelect_Click(object sender, EventArgs e)
        {
            dropTypeUserLoader();
            User x = find(Int64.Parse(dropUsuarios.SelectedItem.Value));


            txtNombre.Enabled = true;
            txtNombre.Text = x.Nombre;

            txtApellido.Enabled = true;
            txtApellido.Text = x.Apellido;

            txtDni.Enabled = true;
            txtDni.Text = x.DNI;

            dropTipoUsuario.Enabled = true;

            txtNick.Enabled = true;
            txtNick.Text = x.Nick;

            txtPass.Enabled = true;
            txtPass.Text = x.Pass;

            txtFechaNac.Enabled = true;
            txtFechaNac.Text = x.FechaNacimiento.ToString("dd-MM-yyyy");

            btnSubmit.Enabled = true;
        }

        public User find(long id)
        {
            userList = us.getUser();
            foreach (User item in userList)
            {
                if (item.ID == id)
                {
                    return item;
                }
            }

            return null;
        }

        public void dropTypeUserLoader()
        {
            userTypeList = us.getTypes(); ;

            DataTable datatwo = new DataTable();
            datatwo.Columns.Add("id");
            datatwo.Columns.Add("descripcion");

            DataRow emptyData = datatwo.NewRow();
            emptyData[0] = 0;
            emptyData[1] = "";
            datatwo.Rows.Add(emptyData);

            foreach (UserType item in userTypeList)
            {
                DataRow row = datatwo.NewRow();
                row[0] = item.ID;
                row[1] = StringHelper.upperStartChar(item.Description);
                datatwo.Rows.Add(row);
            }


            dropTipoUsuario.DataSource = new DataView(datatwo);
            dropTipoUsuario.DataTextField = "descripcion";
            dropTipoUsuario.DataValueField = "id";
            dropTipoUsuario.DataBind();
        }



        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            long id = Int64.Parse(dropUsuarios.SelectedItem.Value);
            string nombre = txtNombre.Text;
            string ape = txtApellido.Text;
            string dni = txtDni.Text;
            string fec = txtFechaNac.Text;
            string nick = txtNick.Text;
            string pass = txtPass.Text;
            long idt = Int64.Parse(dropTipoUsuario.SelectedItem.Value);

            us.editUser(id, nombre, ape, dni, fec, nick, pass, idt);
        }
    }
}