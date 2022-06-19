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
    public partial class BajaMarca : System.Web.UI.Page
    {
        List<ProductBranch> branchList;
        protected void Page_Load(object sender, EventArgs e)
        {
            dropLoader();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            ABMService abm = new ABMService();
            int whatBranch = deleteMarca.SelectedIndex;

            long x = findIt(whatBranch);

            abm.deleteBranch(x);
        }

        public void dropLoader()
        {
            ABMService abm = new ABMService();
            branchList = abm.getBranch();

            foreach (ProductBranch item in branchList)
            {
                deleteMarca.Items.Add(item.Descripcion);
            }
        }

        public long findIt(int id)
        {
            ProductBranch thisis = new ProductBranch();
            thisis = branchList[id];

            return thisis.Id;
        }
    }
}