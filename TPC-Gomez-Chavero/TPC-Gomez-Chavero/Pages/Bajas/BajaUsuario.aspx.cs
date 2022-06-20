using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using domain;
using services;

namespace TPC_Gomez_Chavero.Pages.Bajas
{
    public partial class BajaUsuario : System.Web.UI.Page
    {
        public List<User> userList;
        protected void Page_Load(object sender, EventArgs e)
        {
            dropLoader();
        }

        public void dropLoader()
        {
            UserService us = new UserService();
            userList = us.getUser();

            foreach (User item in userList)
            {
                deleteUser.Items.Add(item.Nombre);
            }
        }

        public long findIt(int id)
        {
            User thisis = new User();
            thisis = userList[id];

            return thisis.ID;
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            UserService us = new UserService();
            int whatUser = deleteUser.SelectedIndex;

            long x = findIt(whatUser);

            us.delete(x);
        }
    }
}