using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using domain;
using services;

namespace TPC_Gomez_Chavero.Pages.Bajas
{
    public partial class BajaProducto : System.Web.UI.Page
    {

        public List<Product> productList;
        protected void Page_Load(object sender, EventArgs e)
        {
            dropLoader();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            ABMService abm = new ABMService();
            int whatProduct = deleteProduct.SelectedIndex;

            long x = findIt(whatProduct);

            abm.deleteProduct(x);
        }

        public void dropLoader()
        {
            ABMService abm = new ABMService();
            productList = abm.getProducts();

            foreach (Product item in productList)
            {
                deleteProduct.Items.Add(item.Nombre);
            }
        }

        public long findIt(int id)
        {
            Product thisis = new Product();
            thisis = productList[id];

            return thisis.Id;
        }
    }
}