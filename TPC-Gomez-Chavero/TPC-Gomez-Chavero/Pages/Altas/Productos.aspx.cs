using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using services;
using domain;

namespace TPC_Gomez_Chavero.Pages.Altas
{
    public partial class Productos : System.Web.UI.Page
    {
        private List<ProductBranch> branchList;
        private List<ProductType> typeList;
        private List<ProductCategory> categoryList;

        protected void Page_Load(object sender, EventArgs e)
        {
            ABMService abm = new ABMService();

            branchList = abm.getBranch();
            typeList = abm.getProductType();
            categoryList = abm.getCategory();

            dropListAdder();
        }

        public void dropListAdder()
        {
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
            int porc = int.Parse(txtPorcentajeVenta.Text);

            abm.addProduct(nombre, des, idcategoria, idmarca, idtipo, stock, stockmin, porc);
        }
    }
}