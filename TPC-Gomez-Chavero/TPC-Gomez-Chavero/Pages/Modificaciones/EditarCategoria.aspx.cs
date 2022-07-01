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
    public partial class EditarCategoria : System.Web.UI.Page
    {

        private ABMService abm;
        public List<ProductCategory> categoryList;
        public ProductCategory Selected;

        protected void Page_Load(object sender, EventArgs e)
        {
            abm = new ABMService();

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
            long id = Int64.Parse(dropCategorias.SelectedItem.Value);
            Selected = findIt(id);

            txtNCategoria.Enabled = true;
            txtNCategoria.Text = Selected.Descripcion;

            btnSubmit.Enabled = true;
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {

            ABMService abm = new ABMService();
            long ids = Int64.Parse(dropCategorias.SelectedValue);
            Selected = findIt(ids);

            string des = txtNCategoria.Text;

            if (abm.changeStatus("Categorias","idCategoria",0,ids)==1)
            {
                if (abm.createTypes(des.ToLower(), "Categorias")==1)
                {
                    lblSuccess.Text = "Categoria Modificada con exito!";
                }
            }

        }

        public ProductCategory findIt(long id)
        {
            categoryList = abm.getCategory(1);
            foreach (ProductCategory item in categoryList)
            {
                if (item.Id == id)
                {
                    return item;
                }
            }

            return null;
        }

        protected void btnContinue_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Pages/Modificaciones/EditarCategoria.aspx");
        }
    }
}