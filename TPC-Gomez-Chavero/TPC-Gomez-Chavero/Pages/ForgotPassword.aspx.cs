using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using domain;
using Controllers;
using services;


namespace TPC_Gomez_Chavero.Pages
{
    public partial class ForgotPassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void send_Click(object sender, EventArgs e)
        {
            EmailController ec = new EmailController();
            EmailService es = new EmailService();

            if (txtEmail.Text.Length > 0)
            {
                string email = txtEmail.Text;
                if (ec.isUserExists(email))
                {
                    es.armarCorreo(email, "Nueva Contraseña");

                    if (es.enviarEmail())
                    {
                        if (ec.newPass(email))
                        {
                            lblError.Text = "Correo enviado con exito";
                        }
                    }
                    else
                    {
                        lblError.Text = "Error al enviar mail";
                        lblError.Visible = true;
                    }


                }
                else
                {
                    lblError.Text = "Email Incorrecto o bien no existe un usuario con ese email";
                    lblError.Visible = true;
                }

            }
            else
            {
                lblError.Text = "Ups, debe ingresar un correo...";
                lblError.Visible = true;
            }
        }
    }
}