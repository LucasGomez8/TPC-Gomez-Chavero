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
    public partial class EditarMarca : System.Web.UI.Page
    {
        public List<ProductBranch> branchList;
        public ProductBranch Selected;

        protected void Page_Load(object sender, EventArgs e)
        {
            ABMService abm = new ABMService();
            branchList = abm.getBranch();

            dropLoader();
        }

        protected void btnSelect_Click(object sender, EventArgs e)
        {
            int id = dropMarca.SelectedIndex;
            Selected = findIt(id);


            txtNMarca.Enabled = true;
            txtNMarca.Text = Selected.Descripcion;

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            ABMService abm = new ABMService();
            int id = dropMarca.SelectedIndex;
            Selected = findIt(id);
            string des = txtNMarca.Text;


            abm.editBranch(Selected.Id, des);

        }

        public void dropLoader()
        {
            foreach (ProductBranch item in branchList)
            {
                dropMarca.Items.Add(item.Descripcion);
            }
        }

        public ProductBranch findIt(int id)
        {
            ProductBranch thisis = new ProductBranch();
            thisis = branchList[id];

            return thisis;
        }
    }
}