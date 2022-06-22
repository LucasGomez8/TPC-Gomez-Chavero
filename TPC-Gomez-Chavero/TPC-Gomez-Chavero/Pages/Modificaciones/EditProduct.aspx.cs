using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Web.UI.WebControls;
using domain;
using services;
using helpers;

namespace TPC_Gomez_Chavero.Pages.Modificaciones
{
    public partial class EditProduct : System.Web.UI.Page
    {
        private ABMService abm;
        
        public List<Product> productList;
        public List<ProductBranch> branchList;
        public List<ProductCategory> categoryList;
        public List<ProductType> typeList;

        public Product Selected;

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
            productList = abm.getProducts();

            DataTable data = new DataTable();
            data.Columns.Add("id");
            data.Columns.Add("nombre");

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

            dropProductList.DataSource = new DataView(data);
            dropProductList.DataTextField = "nombre";
            dropProductList.DataValueField = "id";
            dropProductList.DataBind();
        }

        public void dropBranchLoader()
        {
            branchList = abm.getBranch();

            DataTable data = new DataTable();
            data.Columns.Add("id");
            data.Columns.Add("descripcion");

            DataRow emptyData = data.NewRow();
            emptyData[0] = 0;
            emptyData[1] = "";
            data.Rows.Add(emptyData);

            foreach (ProductBranch item in branchList)
            {
                DataRow row = data.NewRow();
                row[0] = item.Id;
                row[1] = StringHelper.upperStartChar(item.Descripcion);
                data.Rows.Add(row);
            }

            dropMarca.DataSource = new DataView(data);
            dropMarca.DataTextField = "descripcion";
            dropMarca.DataValueField = "id";
            dropMarca.DataBind();
        }

        public void dropTypeLoader()
        {
            typeList = abm.getProductType();

            DataTable data = new DataTable();
            data.Columns.Add("id");
            data.Columns.Add("descripcion");

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

            dropTipoProducto.DataSource = new DataView(data);
            dropTipoProducto.DataTextField = "descripcion";
            dropTipoProducto.DataValueField = "id";
            dropTipoProducto.DataBind();
        }

        public void dropCategoryLoader()
        {
            categoryList = abm.getCategory();

            DataTable data = new DataTable();
            data.Columns.Add("id");
            data.Columns.Add("descripcion");

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

            dropCategoria.DataSource = new DataView(data);
            dropCategoria.DataTextField = "descripcion";
            dropCategoria.DataValueField = "id";
            dropCategoria.DataBind();
        }

        protected void btnSelect_Click(object sender, EventArgs e)
        {
            dropBranchLoader();
            dropCategoryLoader();
            dropTypeLoader();

            long id = Int64.Parse(dropProductList.SelectedItem.Value);
            Selected = findIt(id);

            txtNombre.Enabled = true;
            txtNombre.Text = Selected.Nombre;
            descripcion.Disabled = false;
            descripcion.InnerText = Selected.Descripcion;
            dropCategoria.Enabled = true;
            dropMarca.Enabled = true;
            dropTipoProducto.Enabled = true;

            txtStock.Enabled = true;
            txtStock.Text = Selected.Stock.ToString();

            txtStockMinimo.Enabled = true;
            txtStockMinimo.Text = Selected.StockMinimo.ToString();

            txtPorcentajeVenta.Enabled = true;
            txtPorcentajeVenta.Text = Selected.PorcentajeVenta.ToString();

            btnSubmit.Enabled = true;
        }

        public Product findIt(long id)
        {
            foreach (Product item in productList)
            {
                if (item.Id == id)
                {
                    return item;
                }
            }

            return null;
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {

            ABMService abm = new ABMService();
            int ids = dropProductList.SelectedIndex;
            Selected = findIt(ids);


            long id = Selected.Id;
            string nuevoNom = txtNombre.Text;
            string descrip = descripcion.Value;
            long idmarc = Int64.Parse(dropMarca.SelectedItem.Value);
            long idtip = Int64.Parse(dropTipoProducto.SelectedItem.Value);
            long idcat = Int64.Parse(dropCategoria.SelectedItem.Value);
            int stock = int.Parse(txtStock.Text);
            int stockMin = int.Parse(txtStockMinimo.Text);
            short porc = Int16.Parse(txtPorcentajeVenta.Text);

            if (abm.editProduct(id, nuevoNom, descrip, idcat, idmarc, idtip, stock, stockMin, porc) == 1)
            {
                lblSuccess.Visible = true;
                lblSuccess.Text = "Modificacion exitosa";
            }
            else
            {
                lblSuccess.Visible = true;
                lblSuccess.Text = "Error al modificar";
            }


        }

    }
}