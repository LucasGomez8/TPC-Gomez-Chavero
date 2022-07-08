using System;
using System.Data;
using System.Collections.Generic;
using services;
using helpers;
using domain;
using Controllers;

namespace TPC_Gomez_Chavero
{
    public partial class MisVentas : System.Web.UI.Page
    {

        private VentasController vc;
        public List<TipoFactura> tfacturaList;
        public List<Client> clientList;
        public List<User> sellerList;
        public List<Product> productList;
        public List<Product> productosAgregados;
        public Filters fil;

        protected void Page_Load(object sender, EventArgs e)
        {

            vc = new VentasController();


            if (!adminOrEmployee())
            {
                Response.Redirect("~/");
            }

            User whoIs = (User)Session["user"];



            setTicketNumber(1);
            if (!IsPostBack)
            {
                dropTipoFacturaLoader();
                dropClientLoader();
                if (whoIs.type.Description == "Vendedor")
                {
                    dropSellersLoader();
                    dropUsuario.Enabled = false;
                    dropUsuario.SelectedValue = whoIs.ID.ToString();
                }
                else
                {
                    dropSellersLoader();
                }
                dropProductoLoader();

                if (Session["Vendiendo"] != null)
                {
                    recargarDatosAnteriores();
                }

            }
        }

        public bool adminOrEmployee()
        {
            if (Session["user"] != null)
            {
                return true;
            }
            return false;
        }

        protected bool checkInputs()
        {

            if (txtNumeroFactura.Text.Length == 0) return false;
            if (long.Parse(dropCliente.SelectedItem.Value) == 0) return false;
            if (long.Parse(dropUsuario.SelectedItem.Value) == 0) return false;
            if (txtFechaVenta.Text.Length == 0) return false;
            if (Decimal.Parse(txtVenta.Text) == 0) return false;

            return true;
        }


        public void recargarDatosAnteriores()
        {


            if (Session["TipoFactura"] != null)
            {
                dropTipoFactura.SelectedValue = (string)Session["TipoFactura"];
                Session.Remove("TipoFactura");
            }
            if (Session["Cliente"] != null)
            {
                dropCliente.SelectedValue = (string)Session["Cliente"];
                Session.Remove("Cliente");
            }
            if (Session["FechaVenta"] != null)
            {
                txtFechaVenta.Text = (string)Session["FechaVenta"];
                Session.Remove("FechaVenta");
            }
            if (Session["MontoTotal"] != null)
            {
                txtVenta.Text = (string)Session["MontoTotal"];
                Session.Remove("MontoTotal");
            }
            if (Session["Detalle"] != null)
            {
                txtDetalleCompra.Value = (string)Session["Detalle"];
                Session.Remove("Detalle");
            }
            if (Session["VAgregando"] != null)
            {
                productosAgregados = (List<Product>)Session["VAgregando"];
            }
        }


            private void setTicketNumber(long type)
            {
            long ticketNumber = vc.getTicketNumber(type);
            txtNumeroFactura.Text = StringHelper.completeTicketNumbers(ticketNumber);
            txtNumeroFactura.Enabled = false;
            }

        public void dropTipoFacturaLoader()
        {
            tfacturaList = vc.getTipoFactura();

            DataTable data = new DataTable();
            data.Columns.Add("id");
            data.Columns.Add("description");

            DataRow emptyData = data.NewRow();
            emptyData[0] = 0;
            emptyData[1] = "";
            data.Rows.Add(emptyData);

            foreach (TipoFactura item in tfacturaList)
            {
                DataRow row = data.NewRow();
                row[0] = item.IdTipo;
                row[1] = StringHelper.upperStartChar(item.Descripcion);
                data.Rows.Add(row);
            }

            dropTipoFactura.DataSource = new DataView(data);
            dropTipoFactura.DataTextField = "description";
            dropTipoFactura.DataValueField = "id";
            dropTipoFactura.DataBind();
        }

        public void dropProductoLoader()
        {
            productList = vc.filterProducts();

            DataTable data = new DataTable();
            data.Columns.Add("id");
            data.Columns.Add("description");

            DataRow emptyData = data.NewRow();
            emptyData[0] = 0;
            emptyData[1] = "";
            data.Rows.Add(emptyData);

            foreach (Product item in productList)
            {
                DataRow row = data.NewRow();
                row[0] = item.Id;
                row[1] = StringHelper.upperStartChar(item.Nombre);
                data.Rows.Add(row);
            }

            dropProductos.DataSource = new DataView(data);
            dropProductos.DataTextField = "description";
            dropProductos.DataValueField = "id";
            dropProductos.DataBind();
        }
        public void dropSellersLoader()
        {
            sellerList = vc.getAllUsers();

            DataTable data = new DataTable();
            data.Columns.Add("id");
            data.Columns.Add("nombre");

            DataRow emptyData = data.NewRow();
            emptyData[0] = 0;
            emptyData[1] = "";
            data.Rows.Add(emptyData);

            foreach (User item in sellerList)
            {
                DataRow row = data.NewRow();
                row[0] = item.ID;
                row[1] = StringHelper.upperStartChar(item.Nick);
                data.Rows.Add(row);
            }

            dropUsuario.DataSource = new DataView(data);
            dropUsuario.DataTextField = "nombre";
            dropUsuario.DataValueField = "id";
            dropUsuario.DataBind();
        }

        public void dropClientLoader()
        {
            clientList = vc.getAllClients();

            DataTable data = new DataTable();
            data.Columns.Add("id");
            data.Columns.Add("nombre");

            DataRow emptyData = data.NewRow();
            emptyData[0] = 0;
            emptyData[1] = "";
            data.Rows.Add(emptyData);

            DataRow newdata = data.NewRow();
            newdata[0] = -1;
            newdata[1] = "Nuevo...";
            data.Rows.Add(newdata);

            foreach (Client item in clientList)
            {
                DataRow row = data.NewRow();
                row[0] = item.Id;
                row[1] = StringHelper.upperStartChar(item.Nombre);
                data.Rows.Add(row);
            }

            dropCliente.DataSource = new DataView(data);
            dropCliente.DataTextField = "nombre";
            dropCliente.DataValueField = "id";
            dropCliente.DataBind();
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (checkInputs())
            {
                long numeroFactura = StringHelper.removeTicketNumbers(txtNumeroFactura.Text);
                long tipoFactura = Int64.Parse(dropTipoFactura.SelectedItem.Value);
                long idCliente = Int64.Parse(dropCliente.SelectedItem.Value);
                long iduser = Int64.Parse(dropUsuario.SelectedItem.Value);
                string fechaVenta = txtFechaVenta.Text;
                decimal montoTotal = Decimal.Parse(txtVenta.Text);
                string detalle = txtDetalleCompra.Value;


                productosAgregados = (List<Product>)Session["VAgregando"];


                if (vc.register(numeroFactura, tipoFactura, idCliente, iduser, fechaVenta, montoTotal, detalle, productosAgregados))
                {
                    lblError.Visible = false;
                    lblSuccess.Text = "Registro Exitoso";
                    lblSuccess.Visible = true;

                    btnSubmit.Visible = false;
                    btnSeguirVendiendo.Visible = true;
                    btnVerReporte.Visible = true;
                    Session.Remove("VAgregando");
                }
                else
                {
                    lblError.Text = "Error al cargar registro";
                    lblError.Visible = true;
                }
            }
            else
            {
                lblError.Text = "Faltan Cargar datos, por favor, llene todos los campos";
                lblError.Visible = true;
            }

            

        }

        protected void onPriceAndUnityChanges(object sender, EventArgs e)
        {
            decimal precioUnitario = 0;
            if (txtPrecioUnitario.Text.Length != 0)
                precioUnitario = Decimal.Parse(txtPrecioUnitario.Text);
            long cantidad = 0;
            if (txtCantidadVendida.Text.Length != 0)
                cantidad = Int64.Parse(txtCantidadVendida.Text);

            decimal res = cantidad * precioUnitario;

            txtVenta.Text = res.ToString();
        }

        protected void onDropProductoChanges(object sender, EventArgs e)
        {
            
        }

        public void guardarEnSession()
        {
            if (int.Parse(dropTipoFactura.SelectedValue) > 0)
            {
                Session["TipoFactura"] = dropTipoFactura.SelectedValue;
            }
            if (int.Parse(dropCliente.SelectedValue) > 0)
            {
                Session["Cliente"] = dropCliente.SelectedValue;
            }
            if (txtFechaVenta.Text.Length > 0)
            {
                Session["FechaVenta"] = txtFechaVenta.Text;
            }
            if (txtVenta.Text.Length > 0)
            {
                Session["MontoTotal"] = txtVenta.Text;
            }
            if (txtDetalleCompra.Value.Length > 0)
            {
                Session["Detalle"] = txtDetalleCompra.Value;
            }
        }

        protected void dropCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            long idselected = Int64.Parse(dropCliente.SelectedValue);

            if (idselected == -1)
            {
                Session["Vendiendo"] = true;
                guardarEnSession();
                Response.Redirect("~/Pages/Altas/AgregarCliente.aspx");
            }
        }

        protected void addProduct_Click(object sender, EventArgs e)
        {
            decimal res = 0;
            if ( txtCantidadVendida.Text.Length > 0 && int.Parse(dropProductos.SelectedValue) > 0 && int.Parse(txtCantidadVendida.Text) > 0)
            {

                Product añadir = vc.findIt(Int64.Parse(dropProductos.SelectedValue));
                añadir.Cantidad = int.Parse(txtCantidadVendida.Text);
                añadir.PU = decimal.Parse(txtPrecioUnitario.Text);


                if (stockCheck(añadir.Cantidad, añadir.StockMinimo, añadir.Stock))
                {
                    lblErrorCantidad.Visible = false;
                    errocantidad.Visible = false;
                    productosAgregados = Session["VAgregando"] != null ? (List<Product>)Session["VAgregando"] : new List<Product>();
                    productosAgregados.Add(añadir);

                    Session.Add("VAgregando", productosAgregados);

                    foreach (Product item in productosAgregados)
                    {
                        res += item.PU * item.Cantidad;
                    }

                    txtCantidadVendida.Text = "";
                    txtPrecioUnitario.Text = "";

                    txtVenta.Text = res.ToString();
                }
                else
                {
                    errocantidad.Visible = true;
                    lblErrorCantidad.Text = "Cantidad Vendida menor a la que se tiene, por favor revise el producto";
                    lblErrorCantidad.Visible = true;
                }


            }
            else
            {
                errocantidad.Visible = true;
                lblErrorCantidad.Text = "Seleccione un producto o ingrese una cantidad ventida";
                lblErrorCantidad.Visible = true;
            }


        }

        protected bool stockCheck(int cantidadquesevende, int stockMinimo, int stockActual )
        {
            int resultado = stockActual - cantidadquesevende;

            if (resultado < 0 || resultado < stockMinimo )
            {
                return false;
            }

            return true;
        }

        protected void btnSeguirVendiendo_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Pages/Ventas/MisVentas.aspx");
        }

        protected void txtCantidadVendida_TextChanged(object sender, EventArgs e)
        {
            txtPrecioUnitario.Text = "";
            errocantidad.Visible = false;
            fil = new Filters();
            decimal result = 0;
            Product costo = fil.getUltimoCosto(Int64.Parse(dropProductos.SelectedValue));

            if (int.Parse(txtCantidadVendida.Text) > 0 && costo != null )
            {
                long cantidad = 0;
                if (txtCantidadVendida.Text.Length != 0) cantidad = Int64.Parse(txtCantidadVendida.Text);
                result = (costo.Costo + ((costo.Costo * costo.PorcentajeVenta) / 100));
                if (txtPrecioUnitario.Text.Length == 0) txtPrecioUnitario.Text = result.ToString();
            }
            else
            {
                errocantidad.Visible = true;
                lblError.Text = "Ingrese una cantidad vendida valida o bien, revise si el producto fue compado independientemente del alta correspondiente";
                lblError.Visible = true;
            }


            result = 0;

        }

        protected void btnVerReporte_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Pages/Reportes/Reporte.aspx");
        }
    }
}