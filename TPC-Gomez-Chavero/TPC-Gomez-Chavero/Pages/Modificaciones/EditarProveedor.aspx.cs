using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using domain;
using helpers;
using services;


namespace TPC_Gomez_Chavero.Pages.Modificaciones
{
    public partial class EditarProveedor : System.Web.UI.Page
    {

        public List<Provider> provList;
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
            provList = abm.getProvider(1);

            DataTable data = new DataTable();
            data.Columns.Add("id");
            data.Columns.Add("nombre");

            DataRow emptyData = data.NewRow();
            emptyData[0] = 0;
            emptyData[1] = "";
            data.Rows.Add(emptyData);

            foreach (Provider item in provList)
            {
                DataRow row = data.NewRow();
                row[0] = item.Id;
                row[1] = StringHelper.upperStartChar(item.Nombre);
                data.Rows.Add(row);
            }

            dropProveedor.DataSource = new DataView(data);
            dropProveedor.DataTextField = "nombre";
            dropProveedor.DataValueField = "id";
            dropProveedor.DataBind();
        }


        protected void btnSelect_Click(object sender, EventArgs e)
        {

            txtPNombre.Enabled = true;
            txtPNombre.Text = dropProveedor.SelectedItem.Text;

            btnSubmit.Enabled = true;
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            long id = Int64.Parse(dropProveedor.SelectedValue);
            string nom = txtPNombre.Text;


            if (abm.editProvider(id, nom) == 1)
            {
                lblSuccess.Text = "Proveedor Modificado con exito";
                lblSuccess.Visible = true;
            }
            else
            {
                lblSuccess.Visible = true;
                lblSuccess.Text = "Error al modificar";
            }
            dropLoader();
        }
    }
}