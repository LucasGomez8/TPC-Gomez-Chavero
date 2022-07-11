using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using services;
using domain;
using helpers;

namespace TPC_Gomez_Chavero.Pages.Modificaciones
{
    public partial class EditarTipoProducto : Page
    {

        public List<ProductType> typeList;
        public User whoIs;
        private ABMService abm;

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


            typeList = abm.getProductType(1);
            if (!IsPostBack)
            {
                dropLoader();
            }
        }

        protected void btnSelect_Click(object sender, EventArgs e)
        {
            long id = long.Parse(dropTipo.SelectedValue);
            if (id == 0)
            {
                lblSuccess.Text = "Por favor seleccione una opcion";
                txtNTipo.Text = "";
                lblSuccess.Visible = true;
                return;
            }
            txtNTipo.Enabled = true;
            txtNTipo.Text = dropTipo.SelectedItem.Text;
            btnSubmit.Enabled = false;
        }

        protected void dropTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            long idSelected = long.Parse(dropTipo.SelectedValue);
            if (idSelected == 0)
            {
                txtNTipo.Enabled = false;
                txtNTipo.Text = "";
                lblSuccess.Visible = false;
                return;
            }
            txtNTipo.Enabled = true;
            txtNTipo.Text = dropTipo.SelectedItem.Text;
            btnSubmit.Enabled = false;
            lblSuccess.Visible = false;
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            long id = long.Parse(dropTipo.SelectedItem.Value);
            string des = txtNTipo.Text;

            if (abm.editType(id, des) == 1)
            {
                lblSuccess.Text = "Tipo de producto modificado con exito!";
                lblSuccess.Visible = true;
            }
            else
            {
                lblSuccess.Text = "Hubo un error al modificar la Tipo de Producto";
                lblSuccess.Visible = false;
            }
            dropLoader();
        }

        public void dropLoader()
        {
            typeList = abm.getProductType(1);

            DataTable data = new DataTable();
            data.Columns.Add("id");
            data.Columns.Add("nombre");

            DataRow emptyData = data.NewRow();
            emptyData[0] = 0;
            emptyData[1] = "";
            data.Rows.Add(emptyData);

            foreach (ProductType item in typeList)
            {
                DataRow row = data.NewRow();
                row[0] = item.Id;
                row[1] = StringHelper.upperStartChar(item.Descripcion);
                data.Rows.Add(row);
            }

            dropTipo.DataSource = new DataView(data);
            dropTipo.DataTextField = "nombre";
            dropTipo.DataValueField = "id";
            dropTipo.DataBind();
        }
        protected void txtNTipo_TextChanged(object sender, EventArgs e)
        {
            if (txtNTipo.Text != dropTipo.SelectedItem.Text && txtNTipo.Text.Length != 0)
                btnSubmit.Enabled = true;
            else
                btnSubmit.Enabled = false;
        }

    }
}