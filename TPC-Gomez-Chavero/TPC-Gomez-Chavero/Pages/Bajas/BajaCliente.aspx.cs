using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using domain;
using services;
using helpers;

namespace TPC_Gomez_Chavero.Pages.Bajas
{
    public partial class BajaCliente : System.Web.UI.Page
    {

        List<Client> clist = new List<Client>();
        Client selected;
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


        public void dropLoader()
        {
            ABMService abm = new ABMService();
            clist = abm.getClients(1);

            DataTable data = new DataTable();
            data.Columns.Add("id");
            data.Columns.Add("description");

            DataRow emptyData = data.NewRow();
            emptyData[0] = 0;
            emptyData[1] = "";
            data.Rows.Add(emptyData);

            foreach (Client item in clist)
            {
                DataRow row = data.NewRow();
                row[0] = item.Id;
                row[1] = StringHelper.upperStartChar(item.Nombre);
                data.Rows.Add(row);
            }

            deleteClient.DataSource = new DataView(data);
            deleteClient.DataTextField = "description";
            deleteClient.DataValueField = "id";
            deleteClient.DataBind();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            lblSuccess.Visible = false;
            ABMService abm = new ABMService();
            if (int.Parse(deleteClient.SelectedValue) > 0)
            {
                long whatClient = Int64.Parse(deleteClient.SelectedValue);

                selected = findIt(whatClient);

                if (abm.deleteClient(selected.Id) == 1)
                {
                    lblSuccess.Text = "Cliente dado de baja de forma exitosa!";
                    lblSuccess.Visible = true;
                    deleteClient.SelectedValue = 0.ToString();
                }
            }
            else
            {
                lblSuccess.Text = "Por favor, seleccione una opcion valida";
                lblSuccess.Visible = true;
            }

        }

        public Client findIt(long id)
        {
            ABMService abm = new ABMService();
            List<Client> list = abm.getClients(1);

            foreach (Client item in list)
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