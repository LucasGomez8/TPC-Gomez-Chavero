using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using domain;
using helpers;
using services;


namespace Controllers
{
    public class VentasController
    {
        private ABMService abm;
        private UserService us;

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


            list = us.getUser();

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


        public List<Client> getAllClients()
        {
            abm = new ABMService();

            List<Client> list = new List<Client>();

            list = abm.getClients();

            if (list != null)
            {
                return list;
            }
            else
            {
                return null;
            }
        }
        public bool register(long numeroFactura, long tipoFactura, long idCliente, long iduser, string fechaVenta, decimal montoTotal, string detalle, long idProducto, long cantidad, decimal precioUnitario)
        {
            abm = new ABMService();

            long id = abm.añadirVenta(numeroFactura, tipoFactura, idCliente, iduser, fechaVenta, montoTotal, detalle);

            if (id != 0)
            {
                if (abm.crossProductoVenta(id, idProducto, cantidad,precioUnitario) == 1)
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
