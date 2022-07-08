using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI;
using domain;
using services;
using helpers;

namespace TPC_Gomez_Chavero.Pages.Bajas
{
    public partial class BajaCategoria : Page
    {
        public List<ProductCategory> categoryList;
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

            lblSuccess.Visible = false;
            if (!IsPostBack)
            {
                dropLoader();
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            long idSelected = long.Parse(deleteCategoria.SelectedValue);

            if (idSelected == 0)
            {
                lblSuccess.Text = "Por favor seleccione una opcion";
                lblSuccess.Visible = true;
                return;
            }

            ABMService abm = new ABMService();

            if (abm.deleteCategory(idSelected) == 1)
            {
                lblSuccess.Text = "Categoria eliminada con exito";
                lblSuccess.Visible = true;
            }
            else
            {
                lblSuccess.Text = "Ocurrio un error al eliminar la categoria";
                lblSuccess.Visible = true;
            }
            dropLoader();
        }

        public void dropLoader()
        {
            ABMService abm = new ABMService();
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

            deleteCategoria.DataSource = new DataView(data);
            deleteCategoria.DataTextField = "description";
            deleteCategoria.DataValueField = "id";
            deleteCategoria.DataBind();
        }
    }
}