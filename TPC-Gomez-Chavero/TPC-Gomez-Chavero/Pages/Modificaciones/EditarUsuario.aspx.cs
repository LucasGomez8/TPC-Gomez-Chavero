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
    public partial class EditarUsuario : Page
    {

        public List<User> userList;
        public List<UserType> userTypeList;
        private UserService us;
        public User whoIs;
        protected void Page_Load(object sender, EventArgs e)
        {
            us = new UserService();

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

            if (!IsPostBack)
            {
                dropUserLoader();
            }

            txtFechaNac.Attributes["max"] = DateTime.Now.ToString("yyyy-MM-dd");
            txtFechaNac.Attributes["min"] = DateTime.MinValue.ToString("yyyy-MM-dd");
            if (Request.QueryString["id"] != null)
            {
                long id = long.Parse(Request.QueryString["id"].ToString());
                cargarDatos(id);
            }

            checkInputs();
        }
        
        public void cargarDatos(long id)
        {
            dropTypeUserLoader();
            User selected = find(id);
            if (selected == null)
            {
                Response.Write("<script>alert('Hubo un error al cargar la informacion del cliente')</script>");
                dropUsuarios.Enabled = true;
                btnSelect.Enabled = true;
                return;
            }

            btnSelect.Enabled = false;
            dropUsuarios.Enabled = false;

            txtNombre.Text = StringHelper.upperStartCharInAllWords(selected.Nombre, ' ', "de");

            txtApellido.Text = StringHelper.upperStartCharInAllWords(selected.Apellido, ' ', "de");

            txtDni.Text = selected.DNI;

            txtNick.Enabled = true;
            txtNick.Text = StringHelper.upperStartChar(selected.Nick);

            dropTipoUsuario.Enabled = true;
            dropTipoUsuario.SelectedValue = selected.type.ID.ToString();

            txtPass.Enabled = true;
            txtPass.Text = selected.Pass;

            txtFechaNac.Attributes.Remove("disabled");
            txtFechaNac.Value = selected.FechaNacimiento.ToString("yyyy-MM-dd");

            btnSubmit.Enabled = true;
            btnCancelar.Enabled = true;
        }

        public void dropUserLoader()
        {
            userList = us.getUser(1);

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
            long id = long.Parse(dropUsuarios.SelectedItem.Value);
            if (id == 0)
            {
                lblSuccess.Text = "Por favor seleccione una opcion";
                lblSuccess.Visible = true;
                return;
            }
            lblSuccess.Visible = false;
            cargarDatos(id);
        }

        public User find(long id)
        {
            userList = us.getUser(1);
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
            userTypeList = us.getTypes();

            DataTable datatwo = new DataTable();
            datatwo.Columns.Add("id");
            datatwo.Columns.Add("descripcion");

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
            long id = long.Parse(dropUsuarios.SelectedItem.Value);
            string nombre = txtNombre.Text;
            string ape = txtApellido.Text;
            string dni = txtDni.Text;
            string fec = txtFechaNac.Value;
            string nick = txtNick.Text;
            string pass = txtPass.Text;
            long idt = long.Parse(dropTipoUsuario.SelectedItem.Value);

            if (us.editUser(id, nombre, ape, dni, fec, nick, pass, idt) > 0)
            {
                lblSuccess.Text = "Usuario Modificado con exito";
                lblSuccess.Visible = true;
                btnSubmit.Visible = false;
                btnCancelar.Visible = false;
                btnContinue.Visible = true;
            }
            else
            {
                lblError.Text = "Ocurrrio un error al modificar el Usuario";
                lblError.Visible = true;
            }
            
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Pages/Modificaciones/EditarUsuario.aspx");
        }

        protected void btnContinue_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Pages/Modificaciones/EditarUsuario.aspx");
        }

        protected void onTextChanged(object sender, EventArgs e)
        {
            TextBox txt = (TextBox)sender;

            txtFechaNac.Attributes.Remove("disabled");
            if (txt.ID == txtPass.ID) FormHelper.validateInputPassword(txtPass.Text, errorPass);
        }

        private void checkInputs()
        {
            btnSubmit.Enabled = false;

            if (txtFechaNac.Value.Length == 0) return;

            if (txtPass.Text.Length == 0 || !FormHelper.validateInputPassword(txtPass.Text, errorPass)) return;

            if (txtNick.Text.Length == 0) return;

            btnSubmit.Enabled = true;
        }

    }
}