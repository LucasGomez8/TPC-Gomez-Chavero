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

            if (abm.deleteProvider(idSelected) == 1)
            {
                lblSuccess.Text = "Proveedor eliminado con exito";
                lblSuccess.Visible = true;

                btnContinuar.Visible = true;
                btnSubmit.Visible = false;
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
            provList = abm.getProvider(1);

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

        protected void btnContinuar_Click(object sender, EventArgs e)
        {
            lblSuccess.Visible = false;
            btnContinuar.Visible = false;
            btnSubmit.Visible = true;

            dropLoader();
        }
    }
}