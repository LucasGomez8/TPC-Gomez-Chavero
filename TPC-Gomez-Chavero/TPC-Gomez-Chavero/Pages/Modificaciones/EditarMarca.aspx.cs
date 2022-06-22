using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI;
using domain;
using helpers;
using services;



namespace TPC_Gomez_Chavero.Pages.Modificaciones
{
    public partial class EditarMarca : Page
    {
        public List<ProductBranch> branchList;
        private ABMService abm;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            abm = new ABMService();
            if (!IsPostBack)
            {
                dropLoader();
            }
        }

        public void dropLoader()
        {
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

            dropMarca.DataSource = new DataView(data);
            dropMarca.DataTextField = "description";
            dropMarca.DataValueField = "id";
            dropMarca.DataBind();
        }

        protected void btnSelect_Click(object sender, EventArgs e)
        {
            txtNMarca.Enabled = true;
            txtNMarca.Text = dropMarca.SelectedItem.Text;
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            long idSelected = long.Parse(dropMarca.SelectedValue);
            string des = txtNMarca.Text;

            if (abm.editBranch(idSelected, des) == 1)
            {
                lblSuccess.Text = "Marca modificada con exito";
                lblSuccess.Visible = true;
            }
            else
            {
                lblSuccess.Text = "Hubo un error al modificar la Marca";
                lblSuccess.Visible = false;
            }
            dropLoader();
        }

        protected void dropMarca_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtNMarca.Enabled = true;
            txtNMarca.Text = dropMarca.SelectedItem.Text;
            btnSubmit.Enabled = false;
            lblSuccess.Visible = false;
        }

        protected void txtNMarca_TextChanged(object sender, EventArgs e)
        {
            if (txtNMarca.Text != dropMarca.SelectedItem.Text && txtNMarca.Text.Length != 0)
                btnSubmit.Enabled = true;
            else
                btnSubmit.Enabled = false;
        }
    }
}