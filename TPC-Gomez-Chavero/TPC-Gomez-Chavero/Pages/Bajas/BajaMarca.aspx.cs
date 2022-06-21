using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using domain;
using helpers;
using services;

namespace TPC_Gomez_Chavero.Pages.Bajas
{
    public partial class BajaMarca : System.Web.UI.Page
    {
        List<ProductBranch> branchList;
        protected void Page_Load(object sender, EventArgs e)
        {
            lblSuccess.Visible = false;
            if (!IsPostBack)
            {
                dropLoader();
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            long idSelected = long.Parse(deleteMarca.SelectedValue);

            if (idSelected == 0)
            {
                lblSuccess.Text = "Por favor seleccione una opcion";
                lblSuccess.Visible = true;
                return;
            }

            ABMService abm = new ABMService();

            if (abm.deleteCategory(idSelected) == 1)
            {
                lblSuccess.Text = "Marca eliminada con exito";
                lblSuccess.Visible = true;
            }
            else
            {
                lblSuccess.Text = "Ocurrio un error al eliminar la marca";
                lblSuccess.Visible = true;
            }
            dropLoader();
        }

        public void dropLoader()
        {
            ABMService abm = new ABMService();
            branchList = abm.getBranch();

            DataTable data = new DataTable();
            data.Columns.Add("id");
            data.Columns.Add("description");

            DataRow emptyData = data.NewRow();
            emptyData[0] = 0;
            emptyData[1] = "";
            data.Rows.Add(emptyData);

            foreach (ProductBranch item in branchList)
            {
                DataRow row = data.NewRow();
                row[0] = item.Id;
                row[1] = StringHelper.upperStartChar(item.Descripcion);
                data.Rows.Add(row);
            }

            deleteMarca.DataSource = new DataView(data);
            deleteMarca.DataTextField = "description";
            deleteMarca.DataValueField = "id";
            deleteMarca.DataBind();
        }

        public long findIt(int id)
        {
            ProductBranch thisis = new ProductBranch();
            thisis = branchList[id];

            return thisis.Id;
        }
    }
}