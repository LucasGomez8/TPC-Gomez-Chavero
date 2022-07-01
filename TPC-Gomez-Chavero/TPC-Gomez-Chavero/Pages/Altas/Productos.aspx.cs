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
        private List<Product> dadosBaja;

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
            branchList = abm.getBranch(1);

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
            typeList = abm.getProductType(1);

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
            categoryList = abm.getCategory(1);

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
            int stockmin = int.Parse(txtStockMinimo.Text);
            short porc = Int16.Parse(txtPorcentajeVenta.Text);

            if (abm.addProduct(nombre, des, idcategoria, idmarca, idtipo, stockmin, porc) == 1)
            {
                lblSuccess.Text = "Producto cargado de forma exitosa!";
                lblSuccess.Visible = true;
                btnSubmit.Visible = false;
                btnContinue.Visible = true;
            }

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
            int stockmin = int.Parse(txtStockMinimo.Text);
            short porc = Int16.Parse(txtPorcentajeVenta.Text);

            if (abm.addProduct(nombre, des, idcategoria, idmarca, idtipo, stockmin, porc) == 1)
            {
                Response.Redirect("~/Pages/Compras/MisCompras.aspx");
            }
        }

        protected void btnContinue_Click(object sender, EventArgs e)
        {
            txtNombre.Text = "";
            txtStockMinimo.Text = "";
            txtPorcentajeVenta.Text = "";
            descripcion.Value = "";

            btnContinue.Visible = false;
            btnSubmit.Visible = true;
            lblSuccess.Visible = false;
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            Nuevo.Visible = true;
            menu.Visible = false;
        }

        public void dropDadosBaja()
        {
             dadosBaja= abm.getProducts(0);

            DataTable data = createEmptyDataTable();

            foreach (Product item in dadosBaja)
            {
                DataRow row = data.NewRow();
                row[0] = item.Id;
                row[1] = StringHelper.upperStartChar(item.Nombre);
                data.Rows.Add(row);
            }

            populateDropDown(data, dropElimnacionFisica);
        }

        protected void btnExistente_Click(object sender, EventArgs e)
        {
            dropDadosBaja();

            debaja.Visible = true;
            menu.Visible = false;
        }

        protected void btnOk_Click(object sender, EventArgs e)
        {
            long id = Int64.Parse(dropElimnacionFisica.SelectedItem.Value);
            ABMService abm = new ABMService();

            if (abm.changeStatus("Productos", "IDProducto", 1, id)==1)
            {
                lblSucessBaja.Visible = true;
                lblSucessBaja.Text = "El producto Vuelve a estar de alta";

                

                btnContinuarBaja.Enabled = true;
                btnOk.Enabled = false;
            }
           
        }

        protected void btnContinuarBaja_Click(object sender, EventArgs e)
        {
            dropDadosBaja();

            btnOk.Visible = true;

            btnContinuarBaja.Enabled = false;
            lblSucessBaja.Visible = false;
            btnOk.Enabled = true;
            btnVolver.Enabled = true;
        }

        protected void btnVolverBaja_Click(object sender, EventArgs e)
        {
            debaja.Visible = false;
            btnOk.Enabled = true;
            btnVolver.Enabled = true;
            btnContinuarBaja.Enabled = false;
            lblSucessBaja.Visible = false;

            menu.Visible = true;

        }
        
        protected void btnVolver_Click(object sender, EventArgs e)
        {
            menu.Visible = true;
            Nuevo.Visible = false;


        }
    }
}