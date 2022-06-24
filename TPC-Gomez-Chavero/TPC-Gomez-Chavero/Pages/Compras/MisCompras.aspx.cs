using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using domain;
using Controllers;
using helpers;

namespace TPC_Gomez_Chavero.Pages.Compras
{
    public partial class MisCompras : System.Web.UI.Page
    {
        private ComprasController cc;
        public List<TipoFactura> tfacturaList;
        public List<Provider> providerList;
        public List<User> adminList;
        public List<Product> productList;
        protected void Page_Load(object sender, EventArgs e)
        {
            cc = new ComprasController();

            if (!IsPostBack)
            {
                dropTipoFacturaLoader();
                dropProductoLoader();
                dropAdminLoader();
                dropProveedorLoader();
            }
        }

        public void dropTipoFacturaLoader()
        {
            tfacturaList = cc.getTipoFactura();

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
            productList = cc.filterProducts();

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
        public void dropAdminLoader()
        {
            adminList = cc.getAdmins();

            DataTable data = new DataTable();
            data.Columns.Add("id");
            data.Columns.Add("nombre");

            DataRow emptyData = data.NewRow();
            emptyData[0] = 0;
            emptyData[1] = "";
            data.Rows.Add(emptyData);

            foreach (User item in adminList)
            {
                DataRow row = data.NewRow();
                row[0] = item.ID;
                row[1] = StringHelper.upperStartChar(item.Nombre);
                data.Rows.Add(row);
            }

            dropAdministrador.DataSource = new DataView(data);
            dropAdministrador.DataTextField = "nombre";
            dropAdministrador.DataValueField = "id";
            dropAdministrador.DataBind();
        }

        public void dropProveedorLoader()
        {
            providerList = cc.filterProvider();

            DataTable data = new DataTable();
            data.Columns.Add("id");
            data.Columns.Add("nombre");

            DataRow emptyData = data.NewRow();
            emptyData[0] = 0;
            emptyData[1] = "";
            data.Rows.Add(emptyData);

            foreach (Provider item in providerList)
            {
                DataRow row = data.NewRow();
                row[0] = item.Id;
                row[1] = StringHelper.upperStartChar(item.Nombre);
                data.Rows.Add(row);
            }

            dropProveedor.DataSource = new DataView(data);
            dropProveedor.DataTextField = "nombre";
            dropProveedor.DataValueField = "id";
            dropProveedor.DataBind();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            long numeroFactura = Int64.Parse(txtNumeroFactura.Text);
            long tipoFactura = Int64.Parse(dropTipoFactura.SelectedItem.Value);
            long idProv = Int64.Parse(dropProveedor.SelectedItem.Value);
            long idadmin = Int64.Parse(dropAdministrador.SelectedItem.Value);
            string fechaCompra = txtFechaCompra.Text;
            decimal montoTotal = Decimal.Parse(txtMontoTotal.Text);
            string detalle = txtDetalleCompra.Value;

            long idProducto = Int64.Parse(dropProductos.SelectedItem.Value);
            long cantidad = Int64.Parse(txtCantidadComprada.Text);
            decimal precioUnitario = Decimal.Parse(txtPrecioUnitario.Text);


            if (cc.register(numeroFactura, tipoFactura, idProv, idadmin, fechaCompra, montoTotal, detalle, idProducto, cantidad, precioUnitario))
            {
                lblSuccess.Visible = true;
                lblSuccess.Text = "Compra cargada de forma exitosa";
            }
            else
            {
                lblSuccess.Visible = true;
                lblSuccess.Text = "Error al cargar compra";
            }

            
        }

        protected void txtPrecioUnitario_TextChanged(object sender, EventArgs e)
        {
            decimal precioUnitario = Decimal.Parse(txtPrecioUnitario.Text);
            long cantidad = Int64.Parse(txtCantidadComprada.Text);

            decimal res = cantidad * precioUnitario;
            lblSuccess.Visible = true;

            lblSuccess.Text = res.ToString();

            //txtMontoTotal.Text = res.ToString();
        }
    }
}