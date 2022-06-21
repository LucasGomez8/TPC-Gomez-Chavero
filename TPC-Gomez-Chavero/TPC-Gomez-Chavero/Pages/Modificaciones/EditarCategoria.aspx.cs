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
    public partial class EditarCategoria : System.Web.UI.Page
    {

        public List<ProductCategory> categoryList;
        public ProductCategory Selected;

        protected void Page_Load(object sender, EventArgs e)
        {
            ABMService abm = new ABMService();

            categoryList = abm.getCategory();


            dropLoader();
        }
        public void dropLoader()
        {
            foreach (ProductCategory item in categoryList)
            {
                dropCategorias.Items.Add(item.Descripcion);
            }
        }


        protected void btnSelect_Click(object sender, EventArgs e)
        {
            int id = dropCategorias.SelectedIndex;
            Selected = findIt(id);

            txtNCategoria.Enabled = true;
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {

            ABMService abm = new ABMService();
            int ids = dropCategorias.SelectedIndex;
            Selected = findIt(ids);

            string des = txtNCategoria.Text;

            abm.editCategory(Selected.Id, des);

        }

        public ProductCategory findIt(int id)
        {
            ProductCategory thisis = new ProductCategory();
            thisis = categoryList[id];

            return thisis;
        }
    }
}