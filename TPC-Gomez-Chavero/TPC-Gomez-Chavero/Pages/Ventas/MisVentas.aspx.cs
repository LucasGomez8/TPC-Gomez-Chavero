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


        protected void Page_Load(object sender, EventArgs e)
        {

            vc = new VentasController();

            setTicketNumber(1);
            if (!IsPostBack)
            {
                dropTipoFacturaLoader();
                dropClientLoader();
                dropSellersLoader();
                dropProductoLoader();
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
                row[1] = StringHelper.upperStartChar(item.Nombre);
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
            long numeroFactura = Int64.Parse(txtNumeroFactura.Text);
            long tipoFactura = Int64.Parse(dropTipoFactura.SelectedItem.Value);
            long idCliente = Int64.Parse(dropCliente.SelectedItem.Value);
            long iduser = Int64.Parse(dropUsuario.SelectedItem.Value);
            string fechaVenta = txtFechaVenta.Text;
            decimal montoTotal = Decimal.Parse(txtVenta.Text);
            string detalle = txtDetalleCompra.Value;

            long idProducto = Int64.Parse(dropProductos.SelectedItem.Value);
            long cantidad = Int64.Parse(txtCantidadVendida.Text);
            decimal precioUnitario = Decimal.Parse(txtPrecioUnitario.Text);

        
         if (vc.register(numeroFactura, tipoFactura, idCliente, iduser, fechaVenta, montoTotal, detalle, idProducto, cantidad, precioUnitario))
         {
             lblSuccess.Text = "Registro Exitoso";
             lblSuccess.Visible = true;
         }
         else
         {
             lblSuccess.Text = "Error al cargar registro";
             lblSuccess.Visible = true;
         }

        }
    }
}