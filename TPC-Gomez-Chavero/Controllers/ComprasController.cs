using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using services;
using domain;

namespace Controllers
{
    public class ComprasController
    {
       
        public long getTicketNumber(long type)
        {
            ABMService abm = new ABMService();

            return abm.getNumberTicketBuy(type) + 1;
        }

        public List<TipoFactura> getTipoFactura()
        {
            ABMService abm = new ABMService();

            List<TipoFactura> list = new List<TipoFactura>();
            list = abm.getTFacturas();

            if (list != null)
            {
                return list;
            }
            else
            {
                return null;
            }

        }


        public List<User> getAdmins()
        {
            List<User> list = new List<User>();
            UserService us = new UserService();


            list = us.getAdmins();

            if (list != null)
            {
                return list;
            }
            else
            {
                return null;
            }

        }

        public List<Product> filterProducts()
        {
            ABMService abm = new ABMService();
            List<Product> list = new List<Product>();


            list = abm.getProducts();

            if (list != null)
            {
                return list;
            }
            else
            {
                return null;
            }
        }

        public List<Provider> filterProvider()
        {
            ABMService abm = new ABMService();
            List<Provider> list = new List<Provider>();

            list = abm.getProvider();

            if (list != null)
            {
                return list;
            }
            else
            {
                return null;
            }
        }

        public bool register(long numFac, long tipoFac, long idProv, long idAdmn, string fecha, decimal montototal, string detalle, long idprod, long cantidad, decimal pu)
        {
            ABMService abm = new ABMService();

            long idregistro = abm.añadirCompra(numFac, tipoFac, idProv, idAdmn, fecha, montototal, detalle);

            if ( idregistro != 0)
            {
                if (abm.crossProductoCompra(idregistro, idprod, cantidad, pu) == 1)
                {
                    return true;
                }
            }
            else
            {
                return false;
            }

            return false;
           
        }


    }
}
