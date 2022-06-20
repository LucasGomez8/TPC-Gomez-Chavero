using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using domain;
using services;

namespace TPC_Gomez_Chavero.Pages.Modificaciones
{
    public partial class EditProduct : System.Web.UI.Page
    {
        public List<Product> productList;
        public List<ProductBranch> branchList;
        public List<ProductCategory> categoryList;
        public List<ProductType> typeList;

        public Product Selected;

        protected void Page_Load(object sender, EventArgs e)
        {
            dropLoader();
        }

        public void dropLoader()
        {
            ABMService abm = new ABMService();
            productList = abm.getProducts();
            branchList = abm.getBranch();
            categoryList = abm.getCategory();
            typeList = abm.getProductType();

            foreach (Product item in productList)
            {
                dropProductList.Items.Add(item.Nombre);
            }
            foreach (ProductBranch item in branchList)
            {
                dropMarca.Items.Add(item.Descripcion);
            }
            foreach (ProductCategory item in categoryList)
            {
                dropCategoria.Items.Add(item.Descripcion);
            }
            foreach (ProductType item in typeList)
            {
                dropProducto.Items.Add(item.Descripcion);
            }
        }

        protected void btnSelect_Click(object sender, EventArgs e)
        {
            int id = dropProductList.SelectedIndex;
            Selected = findIt(id);

            txtNombre.Enabled = true;
            txtNombre.Text = Selected.Nombre;
            descripcion.Disabled = false;
            descripcion.InnerText = Selected.Descripcion;
            dropCategoria.Enabled = true;
            dropMarca.Enabled = true;
            dropProducto.Enabled = true;

            txtStock.Enabled = true;
            txtStock.Text = Selected.Stock.ToString();

            txtStockMinimo.Enabled = true;
            txtStockMinimo.Text = Selected.StockMinimo.ToString();

            txtPorcentajeVenta.Enabled = true;
            txtPorcentajeVenta.Text = Selected.PorcentajeVenta.ToString();

            btnSubmit.Enabled = true;
        }

        public Product findIt(int id)
        {
            Product thisis = new Product();
            thisis = productList[id];

            return thisis;
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {

            ABMService abm = new ABMService();
            int ids = dropProductList.SelectedIndex;
            Selected = findIt(ids);


            long id = Selected.Id;
            string nuevoNom = txtNombre.Text;
            string descrip = descripcion.Value;
            long idmarc = findBranch(dropMarca.SelectedIndex);
            long idtip = findType(dropProducto.SelectedIndex);
            long idcat = findCategory(dropCategoria.SelectedIndex);
            int stock = int.Parse(txtStock.Text);
            int stockMin = int.Parse(txtStockMinimo.Text);
            short porc = Int16.Parse(txtPorcentajeVenta.Text);

            abm.editProduct(id, nuevoNom, descrip, idcat, idmarc, idtip, stock, stockMin, porc);

        }


        public long findBranch(int id)
        {
            ProductBranch thisis = new ProductBranch();
            thisis = branchList[id];

            return thisis.Id;
        }

        public long findType(int id)
        {
            ProductType thisis = new ProductType();
            thisis = typeList[id];

            return thisis.Id;
        }
        public long findCategory(int id)
        {
            ProductCategory thisis = new ProductCategory();
            thisis = categoryList[id];

            return thisis.Id;
        }
    }
}