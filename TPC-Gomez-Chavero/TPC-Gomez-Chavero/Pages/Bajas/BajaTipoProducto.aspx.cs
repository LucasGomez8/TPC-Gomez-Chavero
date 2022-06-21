using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI;
using domain;
using helpers;
using services;

namespace TPC_Gomez_Chavero.Pages.Bajas
{
    public partial class BajaTipoProducto : Page
    {

        List<ProductType> typeList;
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
            long idSelected = long.Parse(deleteType.SelectedValue);

            if (idSelected == 0)
            {
                lblSuccess.Text = "Por favor seleccione una opcion";
                lblSuccess.Visible = true;
                return;
            }

            ABMService abm = new ABMService();

            if (abm.deleteCategory(idSelected) == 1)
            {
                lblSuccess.Text = "Tipo de producto eliminado con exito";
                lblSuccess.Visible = true;
            }
            else
            {
                lblSuccess.Text = "Ocurrio un error al eliminar el tipo de producto";
                lblSuccess.Visible = true;
            }
            dropLoader();
        }

        public void dropLoader()
        {
            ABMService abm = new ABMService();
            typeList = abm.getProductType();

            DataTable data = new DataTable();
            data.Columns.Add("id");
            data.Columns.Add("description");
            DataRow emptyData = data.NewRow();
            emptyData[0] = 0;
            emptyData[1] = "";
            data.Rows.Add(emptyData);

            foreach (ProductType item in typeList)
            {
                DataRow row = data.NewRow();
                row[0] = item.Id;
                row[1] = StringHelper.upperStartChar(item.Descripcion);
                data.Rows.Add(row);
            }

            deleteType.DataSource = new DataView(data);
            deleteType.DataTextField = "description";
            deleteType.DataValueField = "id";
            deleteType.DataBind();
        }
    }
}