using System;
using System.Web.UI;
using System.Data;
using System.Web.UI.WebControls;
using System.Collections.Generic;
using domain;
using helpers;
using services;


namespace TPC_Gomez_Chavero.Pages.Altas
{
    public partial class AgregarTipoProducto : Page
    {
        public List<ProductType> dadosBaja;

        protected void Page_Load(object sender, EventArgs e)
        {
            btnReload.Visible = false;
            lblSuccess.Visible = false;
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string descripcion = txtNombre.Text;
            if (descripcion.Length == 0)
            {
                lblSuccess.Text = "Por favor, ingrese informacion correcta";
                lblSuccess.Visible = true;
                return;
            }

            ABMService abm = new ABMService();

            if (abm.createTypes(descripcion.ToLower(), "TipoProducto") == 1)
            {
                lblSuccess.Text = "Tipo de producto cargado con exito";
                lblSuccess.Visible = true;
                btnReload.Visible = true;
                btnSubmit.Visible = false;
            }
            else
            {
                lblSuccess.Text = "Hubo un error al cargar el tipo de producto, o bien este ya existe.";
                lblSuccess.Visible = true;
            }
        }

        protected void btnReload_Click(object sender, EventArgs e)
        {
            btnReload.Visible = false;
            lblSuccess.Visible = false;
            txtNombre.Text = "";
            btnSubmit.Visible = true;
        }

        public void dropDadosBaja()
        {
            ABMService abm = new ABMService();

            dadosBaja = abm.getProductType(0);

            DataTable data = createEmptyDataTable();

            foreach (ProductType item in dadosBaja)
            {
                DataRow row = data.NewRow();
                row[0] = item.Id;
                row[1] = StringHelper.upperStartChar(item.Descripcion);
                data.Rows.Add(row);
            }

            populateDropDown(data, dropElimnacionFisica);
        }

        private DataTable createEmptyDataTable()
        {
            DataTable data = new DataTable();
            data.Columns.Add("id");
            data.Columns.Add("description");

            DataRow emptyData = data.NewRow();
            emptyData[0] = 0;
            emptyData[1] = "";
            data.Rows.Add(emptyData);

            DataRow newData = data.NewRow();
            newData[0] = -1;
            newData[1] = "Nuevo...";
            data.Rows.Add(newData);

            return data;
        }

        private void populateDropDown(DataTable dataTable, DropDownList dropDown)
        {
            dropDown.DataSource = new DataView(dataTable);
            dropDown.DataTextField = "description";
            dropDown.DataValueField = "id";
            dropDown.DataBind();
        }


        protected void brnNuevoTipo_Click(object sender, EventArgs e)
        {
            menu.Visible = false;
            NuevoTipo.Visible = true;
        }

        protected void btnViejoTipo_Click(object sender, EventArgs e)
        {
            menu.Visible = false;
            dropDadosBaja();
            debaja.Visible = true;
        }

        protected void btnOk_Click(object sender, EventArgs e)
        {
            ABMService abm = new ABMService();
            long id = Int64.Parse(dropElimnacionFisica.SelectedItem.Value);

            if (abm.changeStatus("TipoProducto","idTipoProducto",1,id)==1)
            {
                lblSucessBaja.Text = "Tipo de producto seleccionado vuelve a estar de alta";
                btnOk.Enabled = false;
                btnContinuarBaja.Enabled = true;
            }


        }

        protected void btnVolverBaja_Click(object sender, EventArgs e)
        {
            menu.Visible = true;
            debaja.Visible = false;
            lblSuccess.Visible = false;
        }

        protected void btnContinuarBaja_Click(object sender, EventArgs e)
        {
            dropDadosBaja();

            btnContinuarBaja.Enabled = false;
            lblSucessBaja.Visible = false;
            btnOk.Enabled = true;
            btnOk.Visible = true;
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            menu.Visible = true;
            NuevoTipo.Visible = false;
        }
    }
}