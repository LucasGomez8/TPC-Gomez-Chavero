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

namespace TPC_Gomez_Chavero.Pages.Bajas
{
    public partial class BajaProducto : System.Web.UI.Page
    {

        public List<Product> productList;
        public ABMService abm;

        protected void Page_Load(object sender, EventArgs e)
        {
            abm = new ABMService();
            if (!IsPostBack)
            {
                dropLoader();
            }

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {

            long idSelected = Int64.Parse(deleteProduct.SelectedItem.Value);

            if (abm.changeStatus("Productos", "IDProducto", 0, idSelected) == 1)
            {
                lblError.Visible = false;
                lblSuccess.Text = "Producto Eliminado con Exito!";
                lblSuccess.Visible = true;

                btnSubmit.Visible = false;
                btnContinue.Visible = true;
            }
            else
            {
                lblError.Text = "Error al eliminar el producto";
                lblError.Visible = true;
                lblSuccess.Visible = false;
            }


        }

        public void dropLoader()
        {
            productList = abm.getProducts(1);

            DataTable data = new DataTable();
            data.Columns.Add("id");
            data.Columns.Add("description");
            DataRow emptyData = data.NewRow();
            emptyData[0] = 0;
            emptyData[1] = "";
            data.Rows.Add(emptyData);

            foreach (Product item in productList)
            {
                DataRow row = data.NewRow();
                row[0] = item.Id;
                row[1] = StringHelper.upperStartChar(item.Nombre);
                data.Rows.Add(row);
            }

            deleteProduct.DataSource = new DataView(data);
            deleteProduct.DataTextField = "description";
            deleteProduct.DataValueField = "id";
            deleteProduct.DataBind();
        }

        protected void btnContinue_Click(object sender, EventArgs e)
        {
            lblSuccess.Visible = false;

            btnContinue.Visible = false;
            btnSubmit.Visible = true;
            dropLoader();
        }
    }
}