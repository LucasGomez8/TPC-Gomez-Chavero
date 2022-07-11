using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using helpers;
using domain;
using services;

namespace TPC_Gomez_Chavero.Pages.Modificaciones
{
    public partial class EditarCategoria : Page
    {

        private ABMService abm;
        public List<ProductCategory> categoryList;
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

            if (!IsPostBack)
            {
                dropLoader();
            }
        }
        public void dropLoader()
        {
            categoryList = abm.getCategory(1);

            DataTable data = new DataTable();
            data.Columns.Add("id");
            data.Columns.Add("description");

            DataRow emptyData = data.NewRow();
            emptyData[0] = 0;
            emptyData[1] = "";
            data.Rows.Add(emptyData);

            foreach (ProductCategory item in categoryList)
            {
                DataRow row = data.NewRow();
                row[0] = item.Id;
                row[1] = StringHelper.upperStartChar(item.Descripcion);
                data.Rows.Add(row);
            }

            dropCategorias.DataSource = new DataView(data);
            dropCategorias.DataTextField = "description";
            dropCategorias.DataValueField = "id";
            dropCategorias.DataBind();
        }


        protected void btnSelect_Click(object sender, EventArgs e)
        {
            long id = long.Parse(dropCategorias.SelectedItem.Value);
            if(id == 0)
            {
                lblSuccess.Text = "Por favor seleccione una opcion";
                txtNCategoria.Text = "";
                lblSuccess.Visible = true;
                return;
            }
            txtNCategoria.Enabled = true;
            lblSuccess.Visible = false;
            txtNCategoria.Text = dropCategorias.SelectedItem.Text;
            btnSubmit.Enabled = false;
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            ABMService abm = new ABMService();
            long id = long.Parse(dropCategorias.SelectedValue);
            string des = txtNCategoria.Text;

            if (abm.editType(id, des.ToLower()) == 1)
            {
                lblSuccess.Text = "Categoria Modificada con exito!";
                lblSuccess.Visible = true;
            }
            else
            {
                lblSuccess.Text = "Hubo un error al modificar la Categoria";
                lblSuccess.Visible = false;
            }
            dropLoader();
        }

        protected void dropCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            long idSelected = long.Parse(dropCategorias.SelectedValue);
            if (idSelected == 0)
            {
                txtNCategoria.Enabled = false;
                txtNCategoria.Text = "";
                lblSuccess.Visible = false;
                return;
            }
            txtNCategoria.Enabled = true;
            txtNCategoria.Text = dropCategorias.SelectedItem.Text;
            btnSubmit.Enabled = false;
            lblSuccess.Visible = false;
        }

        protected void btnContinue_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Pages/Modificaciones/EditarCategoria.aspx");
        }

        protected void txtNCategoria_TextChanged(object sender, EventArgs e)
        {
            if (txtNCategoria.Text != dropCategorias.SelectedItem.Text && txtNCategoria.Text.Length != 0)
                btnSubmit.Enabled = true;
            else
                btnSubmit.Enabled = false;
        }
    }
}