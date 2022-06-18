using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using domain;
using services;

namespace TPC_Gomez_Chavero.Pages.Altas
{
    public partial class AgregarUsuario : System.Web.UI.Page
    {
        public List<UserType> uTypeList;
        protected void Page_Load(object sender, EventArgs e)
        {
            dropAdder();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            UserService us = new UserService();

            string nombre = txtNombreUsuario.Text;
            string apellido = txtApellidoUsuario.Text;
            string dni = txtDni.Text;
            string date = txtFechaNac.Text.ToString();
            long idtipo = dropUserType.SelectedIndex + 1;
            string nick = txtNick.Text;
            string pass = txtPass.Text;

            us.userAdd(nombre, apellido, dni, idtipo, nick, pass, date);

        }

        public void dropAdder()
        {
            UserService us = new UserService();
            uTypeList = us.getTypes();

            foreach (UserType item in uTypeList)
            {
                dropUserType.Items.Add(item.Description);
            }

        }
    }
}