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
    public partial class BajaTipoProducto : System.Web.UI.Page
    {

        List<ProductType> typeList;
        protected void Page_Load(object sender, EventArgs e)
        {
            dropLoader();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            ABMService abm = new ABMService();
            int whatType = deleteType.SelectedIndex;

            long x = findIt(whatType);

            abm.deleteTipo(x);
        }

        public void dropLoader()
        {
            ABMService abm = new ABMService();
            typeList = abm.getProductType();

            foreach (ProductType item in typeList)
            {
                deleteType.Items.Add(item.Descripcion);
            }
        }

        public long findIt(int id)
        {
            ProductType thisis = new ProductType();
            thisis = typeList[id];

            return thisis.Id;
        }
    }
}