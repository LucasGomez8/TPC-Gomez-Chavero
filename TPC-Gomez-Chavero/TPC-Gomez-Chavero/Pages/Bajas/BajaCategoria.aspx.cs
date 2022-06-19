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
    public partial class BajaCategoria : System.Web.UI.Page
    {
        List<ProductCategory> categoryList;
        protected void Page_Load(object sender, EventArgs e)
        {
            dropLoader();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            ABMService abm = new ABMService();
            int whatCategory = deleteCategoria.SelectedIndex;

            long x = findIt(whatCategory);

            abm.deleteCategory(x);
        }

        public void dropLoader()
        {
            ABMService abm = new ABMService();

            categoryList = abm.getCategory();

            foreach (ProductCategory item in categoryList)
            {
                deleteCategoria.Items.Add(item.Descripcion);
            }
        }

        public long findIt(int id)
        {
            ProductCategory thisis = new ProductCategory();
            thisis = categoryList[id];

            return thisis.Id;
        }
    }
}