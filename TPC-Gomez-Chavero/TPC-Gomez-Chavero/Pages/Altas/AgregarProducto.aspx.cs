using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using services;
using domain;

namespace TPC_Gomez_Chavero
{
    public partial class AgregarProducto : System.Web.UI.Page
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

        }
    }
}