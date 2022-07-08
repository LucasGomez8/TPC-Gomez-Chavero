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
    public partial class AgregarCategoria : Page
    {
        public List<ProductCategory> dadosBaja;
        public User whoIs;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] != null)
            {
                whoIs = (User)Session["user"];
                if (whoIs.type.Description != "Administrador")
                {
                    Response.Redirect("~/");
                }
            }
            else
            {
                Response.Redirect("~/");
            }
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

            if(abm.createTypes(descripcion.ToLower(), "Categorias") == 1)
            {
                lblSuccess.Text = "Categoria cargada con exito";
                lblSuccess.Visible = true;
                btnReload.Visible = true;
                btnSubmit.Visible = false;
            }
            else
            {
                lblSuccess.Text = "Hubo un error al cargar la categoria, o bien esta ya existe.";
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

        private DataTable createEmptyDataTable()
        {
            DataTable data = new DataTable();
            data.Columns.Add("id");
            data.Columns.Add("description");

            DataRow emptyData = data.NewRow();
            emptyData[0] = 0;
            emptyData[1] = "";
            data.Rows.Add(emptyData);

            return data;
        }

        public void dropDadosBaja()
        {
            ABMService abm = new ABMService();

            dadosBaja = abm.getCategory(0);

            DataTable data = createEmptyDataTable();

            foreach (ProductCategory item in dadosBaja)
            {
                DataRow row = data.NewRow();
                row[0] = item.Id;
                row[1] = StringHelper.upperStartChar(item.Descripcion);
                data.Rows.Add(row);
            }

            populateDropDown(data, dropElimnacionFisica);
        }

        private void populateDropDown(DataTable dataTable, DropDownList dropDown)
        {
            dropDown.DataSource = new DataView(dataTable);
            dropDown.DataTextField = "description";
            dropDown.DataValueField = "id";
            dropDown.DataBind();
        }


        protected void btnNuevaCategoria_Click(object sender, EventArgs e)
        {
            nuevaCategoria.Visible = true;
            menu.Visible = false;
        }

        protected void btnViejaCategoria_Click(object sender, EventArgs e)
        {
            menu.Visible = false;
            debaja.Visible = true;
            dropDadosBaja();
        }

        protected void btnOk_Click(object sender, EventArgs e)
        {
            long id = long.Parse(dropElimnacionFisica.SelectedItem.Value);

            if (id==0)
            {
                lblSucessBaja.Text = "Por favor seleccione una opcion!";
                lblSucessBaja.Visible = true;
                return;
            }
            ABMService abm = new ABMService();

            if (abm.changeStatus("Categorias", "IDCategoria", 1, id) == 1)
            {
                lblSucessBaja.Text = "Categoria dada de alta nuevamente!";
                lblSucessBaja.Visible = true;
                btnContinuarBaja.Enabled = true;
            }
            else
            {
                lblSucessBaja.Text = "Hubo un error al dar de alta nuevamente la categoria!";
                lblSucessBaja.Visible = true;
                btnContinuarBaja.Enabled = true;
            }

        }

        protected void btnVolverBaja_Click(object sender, EventArgs e)
        {
            lblSucessBaja.Visible = false;
            debaja.Visible = false;
            menu.Visible = true;
        }

        protected void btnContinuarBaja_Click(object sender, EventArgs e)
        {
            dropDadosBaja();

            btnOk.Visible = true;
            btnContinuarBaja.Enabled = false;
            lblSucessBaja.Visible = false;
            btnOk.Enabled = true;
        }
    }
}