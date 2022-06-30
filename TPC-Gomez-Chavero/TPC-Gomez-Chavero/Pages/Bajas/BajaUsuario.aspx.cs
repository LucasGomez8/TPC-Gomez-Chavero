using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using domain;
using services;
using helpers;


namespace TPC_Gomez_Chavero.Pages.Bajas
{
    public partial class BajaUsuario : System.Web.UI.Page
    {
        public List<User> userList;
        private UserService us;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                dropLoader();
            }
        }

        public void dropLoader()
        {
            us = new UserService();
            userList = us.getUser();

            DataTable data = new DataTable();
            data.Columns.Add("id");
            data.Columns.Add("description");
            DataRow emptyData = data.NewRow();
            emptyData[0] = 0;
            emptyData[1] = "";
            data.Rows.Add(emptyData);

            foreach (User item in userList)
            {
                DataRow row = data.NewRow();
                row[0] = item.ID;
                row[1] = StringHelper.upperStartChar(item.Nick);
                data.Rows.Add(row);
            }

            deleteUser.DataSource = new DataView(data);
            deleteUser.DataTextField = "description";
            deleteUser.DataValueField = "id";
            deleteUser.DataBind();
        }


        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            us = new UserService();

            long idSelected = Int64.Parse(deleteUser.SelectedItem.Value);

            if (us.delete(idSelected) == 1)
            {
                lblSuccess.Text = "Usuario eliminado con exito!";
                lblSuccess.Visible = true;
                btnContinue.Visible = true;
                btnSubmit.Visible = false;
            }
        
        }

        protected void btnContinue_Click(object sender, EventArgs e)
        {
            btnSubmit.Visible = true;
            btnContinue.Visible = false;


            lblSuccess.Visible = false;

            dropLoader();
        }
    }
}