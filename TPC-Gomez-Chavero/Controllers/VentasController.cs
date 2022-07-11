using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using domain;
using helpers;
using services;


namespace Controllers
{
    public class VentasController
    {
        private ABMService abm;
        private UserService us;

        public Product findIt(long id)
        {
            abm = new ABMService();
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

            return abm.getNumberTicketBuy(type, "ventas") + 1;
        }

        public List<TipoFactura> getTipoFactura()
        {
            abm = new ABMService();

            List<TipoFactura> list = new List<TipoFactura>();
            list = abm.getTFacturas();

            if (list != null)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    if (i == 1)
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

        public List<User> getAllUsers()
        {
            List<User> list = new List<User>();
            us = new UserService();


            list = us.getUser(1);

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
            abm = new ABMService();
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


        public List<Client> getAllClients()
        {
            abm = new ABMService();

            List<Client> list = new List<Client>();

            list = abm.getClients(1);

            if (list != null)
            {
                return list;
            }
            else
            {
                return null;
            }
        }
        public bool register(long numeroFactura, long tipoFactura, long idCliente, long iduser, string fechaVenta, decimal montoTotal, string detalle, List<Product> cross)
        {
            abm = new ABMService();

            long id = abm.añadirVenta(numeroFactura, tipoFactura, idCliente, iduser, fechaVenta, montoTotal, detalle);

            if (id != 0)
            {
                foreach (Product item in cross)
                {
                    if (abm.crossProductoVenta(id, item.Id, item.Cantidad, item.PU) > 0)
                    {
                        int newStock = item.Stock - item.Cantidad;

                        if (abm.stockAction(item.Id, newStock) < 0)
                        {
                            return false;
                        }
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
