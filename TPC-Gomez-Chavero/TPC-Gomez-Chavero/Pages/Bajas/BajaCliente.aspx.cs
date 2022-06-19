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
    public partial class BajaCliente : System.Web.UI.Page
    {

        List<Client> clist = new List<Client>();
        protected void Page_Load(object sender, EventArgs e)
        {
            dropLoader();
        }


        public void dropLoader()
        {
            ABMService abm = new ABMService();

            clist = abm.getClients();

            foreach (Client item in clist)
            {
                deleteClient.Items.Add(item.Nombre);
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            ABMService abm = new ABMService();

            int whatClient = deleteClient.SelectedIndex;

            long x = findIt(whatClient);

            abm.deleteClient(x);
        }

        public long findIt(int id)
        {
            Client thisis = new Client();
            thisis = clist[id];

            return thisis.Id;
        }
    }
}