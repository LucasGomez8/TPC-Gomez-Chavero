using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using domain;
using helpers;
using services;


namespace TPC_Gomez_Chavero.Pages.Modificaciones
{
    public partial class EditarProveedor : Page
    {

        public List<Provider> provList;
        private ABMService abm;
        public User whoIs;
        protected void Page_Load(object sender, EventArgs e)
        {
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

            abm = new ABMService();
            if (!IsPostBack)
            {
                dropLoader();
            }

            if (Request.QueryString["id"] != null)
            {
                long id = long.Parse(Request.QueryString["id"]);
                cargarDatos(id);
            }
        }

        public void cargarDatos(long id)
        {
            Provider selected = findIt(id);
            if (selected == null)
            {
                lblSuccess.Text = "Error al cargar los datos";
                btnSubmit.Enabled = false;
                txtPNombre.Enabled = false;
                txtPNombre.Text = "";
                return;
            }
            txtPNombre.Text = selected.Nombre;
            btnSubmit.Enabled = true;
            txtPNombre.Enabled = true;
        }


        public Provider findIt(long id)
        {
            provList = abm.getProvider(1);
            foreach (Provider item in provList)
            {
                if (item.Id == id)
                {
                    return item;
                }
            }

            return null;
        }

        public void dropLoader()
        {
            provList = abm.getProvider(1);

            DataTable data = new DataTable();
            data.Columns.Add("id");
            data.Columns.Add("nombre");

            DataRow emptyData = data.NewRow();
            emptyData[0] = 0;
            emptyData[1] = "";
            data.Rows.Add(emptyData);

            foreach (Provider item in provList)
            {
                DataRow row = data.NewRow();
                row[0] = item.Id;
                row[1] = StringHelper.upperStartChar(item.Nombre);
                data.Rows.Add(row);
            }

            dropProveedor.DataSource = new DataView(data);
            dropProveedor.DataTextField = "nombre";
            dropProveedor.DataValueField = "id";
            dropProveedor.DataBind();
        }

        protected void btnSelect_Click(object sender, EventArgs e)
        {
            long id = long.Parse(dropProveedor.SelectedValue);
            if (id == 0)
            {
                lblSuccess.Text = "Por favor seleccione una opcion";
                txtPNombre.Text = "";
                txtPNombre.Enabled = false;
                lblSuccess.Visible = true;
                return;
            }
            txtPNombre.Enabled = true;
            txtPNombre.Text = dropProveedor.SelectedItem.Text;
            btnSubmit.Enabled = false;
        }

        protected void dropProveedor_SelectedIndexChanged(object sender, EventArgs e)
        {
            long idSelected = long.Parse(dropProveedor.SelectedValue);
            if (idSelected == 0)
            {
                txtPNombre.Enabled = false;
                txtPNombre.Text = "";
                lblSuccess.Visible = false;
                return;
            }
            txtPNombre.Enabled = true;
            txtPNombre.Text = dropProveedor.SelectedItem.Text;
            btnSubmit.Enabled = false;
            lblSuccess.Visible = false;
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            long id = long.Parse(dropProveedor.SelectedValue);

            string nom = txtPNombre.Text;

            if (abm.editProvider(id, nom) == 1)
            {
                lblSuccess.Text = "Proveedor Modificado con exito";
                lblSuccess.Visible = true;
            }
            else
            {
                lblSuccess.Visible = true;
                lblSuccess.Text = "Error al modificar";
            }
            dropLoader();
        }
        protected void txtNProveedor_TextChanged(object sender, EventArgs e)
        {
            if (txtPNombre.Text != dropProveedor.SelectedItem.Text && txtPNombre.Text.Length != 0)
                btnSubmit.Enabled = true;
            else
                btnSubmit.Enabled = false;
        }
    }
}