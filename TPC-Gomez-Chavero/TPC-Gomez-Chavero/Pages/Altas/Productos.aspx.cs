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

                if(Session["Comprando"] != null)
                {
                    btnSubmit.Visible = false;
                    btnRetorno.Visible = true;
                    Session.Remove("Comprando");
                }
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
            long idcategoria = Int64.Parse(dropCategoria.SelectedItem.Value);
            long idmarca = Int64.Parse(dropMarca.SelectedItem.Value);
            long idtipo = Int64.Parse(dropProducto.SelectedItem.Value);
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

        protected void onCreateBranchClicked(object sender, EventArgs e)
        {
            string descripcion = addBranchTxt.Text;
            if (descripcion.Length == 0)
            {
                return;
            }

            if (abm.createTypes(descripcion.ToLower(), "Marcas") == 1)
            {
                dropBranch();
                dropMarca.SelectedIndex = branchList.Count + 1;
                addBranchBtn.Visible = false;
                addBranchTxt.Visible = false;
            }
        }
    
        protected void onCreateTypeClicked(object sender, EventArgs e)
        {
            string descripcion = addTypeTxt.Text;
            if (descripcion.Length == 0)
            {
                return;
            }

            if (abm.createTypes(descripcion.ToLower(), "TipoProducto") == 1)
            {
                dropProductType();
                dropProducto.SelectedIndex = typeList.Count + 1;
                addTypeBtn.Visible = false;
                addTypeTxt.Visible = false;
            }
        }
    
        protected void onCreateCategoryClicked(object sender, EventArgs e)
        {
            string descripcion = addCategoryTxt.Text;
            if (descripcion.Length == 0)
            {
                return;
            }

            if (abm.createTypes(descripcion.ToLower(), "Categorias") == 1)
            {
                dropCategory();
                dropCategoria.SelectedIndex= categoryList.Count + 1;
                addCategoryBtn.Visible = false;
                addCategoryTxt.Visible = false;
            }
        }

        protected void btnRetorno_Click(object sender, EventArgs e)
        {
            ABMService abm = new ABMService();
            string nombre = txtNombre.Text;
            string des = descripcion.Value;
            long idcategoria = Int64.Parse(dropCategoria.SelectedItem.Value);
            long idmarca = Int64.Parse(dropMarca.SelectedItem.Value);
            long idtipo = Int64.Parse(dropProducto.SelectedItem.Value);
            int stock = int.Parse(txtStock.Text);
            int stockmin = int.Parse(txtStockMinimo.Text);
            short porc = Int16.Parse(txtPorcentajeVenta.Text);

            if (abm.addProduct(nombre, des, idcategoria, idmarca, idtipo, stock, stockmin, porc) == 1)
            {
                Response.Redirect("~/Pages/Compras/MisCompras.aspx");
            }
        }
    }
}