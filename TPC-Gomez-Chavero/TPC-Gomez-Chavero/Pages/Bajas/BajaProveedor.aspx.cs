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
    public partial class BajaProveedor : System.Web.UI.Page
    {

        List<Provider> provList;
        protected void Page_Load(object sender, EventArgs e)
        {
            dropLoader();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            ABMService abm = new ABMService();
            int whatProduct = deleteProvider.SelectedIndex;

            long x = findIt(whatProduct);

            abm.deleteProduct(x);
        }

        public void dropLoader()
        {
            ABMService abm = new ABMService();
            provList = abm.getProvider();

            foreach (Provider item in provList)
            {
                deleteProvider.Items.Add(item.Nombre);
            }
        }
        public long findIt(int id)
        {
            Provider thisis = new Provider();
            thisis = provList[id];

            return thisis.Id;
        }
    }
}