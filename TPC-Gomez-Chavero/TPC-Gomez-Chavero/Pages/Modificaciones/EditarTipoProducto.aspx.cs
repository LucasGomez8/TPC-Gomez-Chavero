using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using services;
using domain;

namespace TPC_Gomez_Chavero.Pages.Modificaciones
{
    public partial class EditarTipoProducto : System.Web.UI.Page
    {

        public List<ProductType> typeList;
        public ProductType Selected;
        protected void Page_Load(object sender, EventArgs e)
        {
            ABMService abm = new ABMService();

            typeList = abm.getProductType();

            dropLoader();
        }

        protected void btnSelect_Click(object sender, EventArgs e)
        {
            int id = dropTipo.SelectedIndex;
            Selected = findIt(id);


            txtNTipo.Enabled = true;
            txtNTipo.Text = Selected.Descripcion;
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            ABMService abm = new ABMService();
            int id = dropTipo.SelectedIndex;
            Selected = findIt(id);
            string des = txtNTipo.Text;


            abm.editType(Selected.Id, des);

        }

        public void dropLoader()
        {
            foreach (ProductType item in typeList)
            {
                dropTipo.Items.Add(item.Descripcion);
            }
        }

        public ProductType findIt(int id)
        {
            ProductType thisis = new ProductType();
            thisis = typeList[id];

            return thisis;
        }
    }
}