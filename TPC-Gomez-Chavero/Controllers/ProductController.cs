using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using domain;
using services;

namespace Controllers
{
    public class ProductController
    {

        public bool isExists(Product ex)
        {
            ABMService abm = new ABMService();
            List<Product> listAlta = abm.getProducts(1);
            List<Product> listBaja = abm.getProducts(0);

            foreach (Product item in listAlta)
            {
                if (item.Nombre.ToLower() == ex.Nombre.ToLower() && item.Marca.Id == ex.Marca.Id)
                {
                    return false;
                }
            }

            foreach (Product item in listBaja)
            {
                if (item.Nombre == ex.Nombre && item.Marca.Id == ex.Marca.Id)
                {
                    return false;
                }
            }

            return true;

        }
    }
}
