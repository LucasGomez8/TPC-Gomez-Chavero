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

        public Product findIt(long id)
        {
            ABMService abm = new ABMService();
            List<Product> list = abm.getProducts(1);

            foreach (Product item in list)
            {
                if (item.Id == id)
                {
                    return item;
                }
            }

            return null;
        }
        
        public long getTicketNumber(long type)
        {
            ABMService abm = new ABMService();

            return abm.getNumberTicketBuy(type, "compras") + 1;
        }

        public List<TipoFactura> getTipoFactura()
        {
            ABMService abm = new ABMService();

            List<TipoFactura> list = new List<TipoFactura>();
            list = abm.getTFacturas();


            if (list != null)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    if (list[i].Descripcion == "Factura Duplicada")
                    {
                        list.Remove(list[i]);
                    }
                }
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


            list = abm.getProducts(1);

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

            list = abm.getProvider(1);

            if (list != null)
            {
                return list;
            }
            else
            {
                return null;
            }
        }

        public bool register(long numFac, long tipoFac, long idProv, long idAdmn, string fecha, decimal montototal, string detalle, List<Product> cross)
        {
            ABMService abm = new ABMService();

            long idregistro = abm.añadirCompra(numFac, tipoFac, idProv, idAdmn, fecha, montototal, detalle);

            if ( idregistro != 0)
            {
                foreach (Product item in cross)
                {
                    if (abm.crossProductoCompra(idregistro, item.Id, item.Cantidad, item.PU) > 0)
                    {
                        int newStock = item.Stock + item.Cantidad;

                        if (abm.stockAction(item.Id, newStock) < 0)
                        {
                            return false;
                        }

                    }
                    else
                    {
                        return false;
                    }

                }
                return true;
            }
            else
            {
                return false;
            }
           
        }


    }
}
