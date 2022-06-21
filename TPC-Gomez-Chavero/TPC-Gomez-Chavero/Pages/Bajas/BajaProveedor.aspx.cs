using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI;
using domain;
using helpers;
using services;

namespace TPC_Gomez_Chavero.Pages.Bajas
{
    public partial class BajaProveedor : Page
    {

        List<Provider> provList;
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
            long idSelected = long.Parse(deleteProvider.SelectedValue);

            if (idSelected == 0)
            {
                lblSuccess.Text = "Por favor seleccione una opcion";
                lblSuccess.Visible = true;
                return;
            }

            ABMService abm = new ABMService();

            if (abm.deleteCategory(idSelected) == 1)
            {
                lblSuccess.Text = "Proveedor eliminado con exito";
                lblSuccess.Visible = true;
            }
            else
            {
                lblSuccess.Text = "Ocurrio un error al eliminar el proveedor";
                lblSuccess.Visible = true;
            }
            dropLoader();
        }

        public void dropLoader()
        {
            ABMService abm = new ABMService();
            provList = abm.getProvider();

            DataTable data = new DataTable();
            data.Columns.Add("id");
            data.Columns.Add("description");
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

            deleteProvider.DataSource = new DataView(data);
            deleteProvider.DataTextField = "description";
            deleteProvider.DataValueField = "id";
            deleteProvider.DataBind();
        }
    }
}