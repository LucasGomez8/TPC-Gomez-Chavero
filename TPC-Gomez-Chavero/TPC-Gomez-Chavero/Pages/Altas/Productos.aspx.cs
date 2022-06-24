using System;
using System.Collections.Generic;
using System.Web.UI;
using services;
using domain;
using System.Data;
using helpers;
using System.Web.UI.WebControls;

namespace TPC_Gomez_Chavero.Pages.Altas
{
    public partial class Productos : Page
    {
        private ABMService abm;

        private List<ProductBranch> branchList;
        private List<ProductType> typeList;
        private List<ProductCategory> categoryList;

        protected void Page_Load(object sender, EventArgs e)
        {
            abm = new ABMService();
            if (!IsPostBack)
            {
                dropBranch();
                dropCategory();
                dropProductType();
            }
        }

        public void dropBranch()
        {
            branchList = abm.getBranch();

            DataTable data = createEmptyDataTable();

            foreach (ProductBranch item in branchList)
            {
                DataRow row = data.NewRow();
                row[0] = item.Id;
                row[1] = StringHelper.upperStartChar(item.Descripcion);
                data.Rows.Add(row);
            }

            populateDropDown(data, dropMarca);
        }

        public void dropProductType()
        {
            typeList = abm.getProductType();

            DataTable data = createEmptyDataTable();

            foreach (ProductType item in typeList)
            {
                DataRow row = data.NewRow();
                row[0] = item.Id;
                row[1] = StringHelper.upperStartChar(item.Descripcion);
                data.Rows.Add(row);
            }

            populateDropDown(data, dropProducto);
        }
        
        public void dropCategory()
        {
            categoryList = abm.getCategory();

            DataTable data = createEmptyDataTable();

            foreach (ProductCategory item in categoryList)
            {
                DataRow row = data.NewRow();
                row[0] = item.Id;
                row[1] = StringHelper.upperStartChar(item.Descripcion);
                data.Rows.Add(row);
            }

            populateDropDown(data, dropCategoria);
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            ABMService abm = new ABMService();
            string nombre = txtNombre.Text;
            string des = descripcion.Value;
            int idcategoria = dropCategoria.SelectedIndex+1;
            int idmarca = dropMarca.SelectedIndex+1;
            int idtipo = dropProducto.SelectedIndex+1;
            int stock = int.Parse(txtStock.Text);
            int stockmin = int.Parse(txtStockMinimo.Text);
            short porc = Int16.Parse(txtPorcentajeVenta.Text);

            abm.addProduct(nombre, des, idcategoria, idmarca, idtipo, stock, stockmin, porc);
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

        private void populateDropDown(DataTable dataTable, DropDownList dropDown)
        {
            dropDown.DataSource = new DataView(dataTable);
            dropDown.DataTextField = "description";
            dropDown.DataValueField = "id";
            dropDown.DataBind();
        }

        protected void dropCategoriaChanged(object sender, EventArgs e)
        {
            long idSelected = long.Parse(dropCategoria.SelectedValue);

            if (idSelected == -1)
            {
                addCategoryBtn.Visible = true;
                addCategoryTxt.Visible = true;
            }
            else
            {
                addCategoryBtn.Visible = false;
                addCategoryTxt.Visible = false;
            }
        }

        protected void dropMarcaChanged(object sender, EventArgs e)
        {
            long idSelected = long.Parse(dropMarca.SelectedValue);

            if (idSelected == -1)
            {
                addBranchBtn.Visible = true;
                addBranchTxt.Visible = true;
            }
            else
            {
                addBranchBtn.Visible = false;
                addBranchTxt.Visible = false;
            }
        }

        protected void dropProductoChanged(object sender, EventArgs e)
        {
            long idSelected = long.Parse(dropProducto.SelectedValue);

            if (idSelected == -1)
            {
                addTypeBtn.Visible = true;
                addTypeTxt.Visible = true;
            }
            else
            {
                addTypeBtn.Visible = false;
                addTypeTxt.Visible = false;
            }
        }
    }
}