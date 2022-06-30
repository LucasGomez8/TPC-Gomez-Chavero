using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using services;
using domain;
using helpers;

namespace TPC_Gomez_Chavero.Pages.Modificaciones
{
    public partial class EditarTipoProducto : System.Web.UI.Page
    {

        public List<ProductType> typeList;
        public ProductType Selected;
        protected void Page_Load(object sender, EventArgs e)
        {
            ABMService abm = new ABMService();

            typeList = abm.getProductType();

            dropLoader();
        }

        protected void btnSelect_Click(object sender, EventArgs e)
        {
            int id = dropTipo.SelectedIndex;
            Selected = findIt(id);


            txtNTipo.Enabled = true;
            txtNTipo.Text = Selected.Descripcion;
            btnSubmit.Enabled = true;
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            ABMService abm = new ABMService();
            long id = Int64.Parse(dropTipo.SelectedItem.Value);
            Selected = findIt(id);
            string des = txtNTipo.Text;


            abm.editType(Selected.Id, des);

        }

        public void dropLoader()
        {
            ABMService abm = new ABMService();
            typeList = abm.getProductType();
            DataTable data = new DataTable();
            data.Columns.Add("id");
            data.Columns.Add("nombre");

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

            dropTipo.DataSource = new DataView(data);
            dropTipo.DataTextField = "nombre";
            dropTipo.DataValueField = "id";
            dropTipo.DataBind();
        }

        public ProductType findIt(long id)
        {
            ABMService abm = new ABMService();
            typeList = abm.getProductType();
            foreach (ProductType item in typeList)
            {
                if (item.Id == id)
                {
                    return item;
                }
            }

            return null;
        }
    }
}