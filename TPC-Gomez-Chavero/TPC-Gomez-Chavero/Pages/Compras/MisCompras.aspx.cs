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
    public partial class MisCompras : Page
    {
        private ComprasController cc;
        public List<TipoFactura> tfacturaList;
        public List<Provider> providerList;
        public List<User> adminList;
        public User sessionUser;
        public List<Product> productList;
        public List<Product> productosAgregados;

        public int itemsSaved { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {


            productosAgregados = new List<Product>();
            cc = new ComprasController();
            if (Session["user"] != null)
            {
            sessionUser = (User)Session["user"];
            }
            itemsSaved = Session["itemsSaved"] != null
                ? (int)Session["itemsSaved"]
                : 1;

            if (!IsPostBack)
            {
                setTicketNumber(1);
                dropTipoFacturaLoader();
                dropProductoLoader();
                dropAdministrador.Visible = true;
                dropAdminLoader();
                dropProveedorLoader();
            }
            checkInputs();
        }

        private void setTicketNumber(long type)
        {
            long ticketNumber = cc.getTicketNumber(type);
            txtNumeroFactura.Text = StringHelper.completeTicketNumbers(ticketNumber);
            txtNumeroFactura.Enabled = false;
        }

        public void dropTipoFacturaLoader()
        {
            tfacturaList = cc.getTipoFactura();

            DataTable data = new DataTable();
            data.Columns.Add("id");
            data.Columns.Add("description");

            foreach (TipoFactura item in tfacturaList)
            {
                DataRow row = data.NewRow();
                row[0] = item.IdTipo;
                row[1] = StringHelper.upperStartCharInAllWords(item.Descripcion, ' ', "de");
                data.Rows.Add(row);
            }

            populateDropDown(data, dropTipoFactura);
        }

        protected void dropTypeTicketOnChange(object sender, EventArgs e)
        {
            long type = long.Parse(dropTipoFactura.SelectedValue);
            setTicketNumber(type);
        }

        public void dropProductoLoader()
        {
            productList = cc.filterProducts();

            DataTable data = createEmptyDataTable();

            foreach (Product item in productList)
            {
                DataRow row = data.NewRow();
                row[0] = item.Id;
                row[1] = StringHelper.upperStartCharInAllWords(item.Nombre, ' ', "de"); ;
                data.Rows.Add(row);
            }

            populateDropDown(data, dropProductos);
        }
        
        public void dropAdminLoader()
        {
            adminList = cc.getAdmins();

            DataTable data = createEmptyDataTable();

            foreach (User item in adminList)
            {
                DataRow row = data.NewRow();
                row[0] = item.ID;
                row[1] = StringHelper.upperStartCharInAllWords(item.Nombre, ' ', "de");
                data.Rows.Add(row);
            }

            populateDropDown(data, dropAdministrador);
        }

        public void dropProveedorLoader()
        {
            providerList = cc.filterProvider();

            DataTable data = createEmptyDataTable();

            foreach (Provider item in providerList)
            {
                DataRow row = data.NewRow();
                row[0] = item.Id;
                row[1] = StringHelper.upperStartChar(item.Nombre);
                data.Rows.Add(row);
            }

            populateDropDown(data, dropProveedor);
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {

            long idadmin = 0;

            productosAgregados = (List<Product>)Session["Agregando"];


            long numeroFactura = StringHelper.removeTicketNumbers(txtNumeroFactura.Text);
            long tipoFactura = Int64.Parse(dropTipoFactura.SelectedItem.Value);
            long idProv = Int64.Parse(dropProveedor.SelectedItem.Value);
            if (sessionUser.type.ID == 1)
            {
                idadmin = Int64.Parse(dropAdministrador.SelectedItem.Value);
            }
            else
            {
                idadmin = sessionUser.ID;
            }

            string fechaCompra = txtFechaCompra.Text;
            decimal montoTotal = Decimal.Parse(txtMontoTotal.Text);
            string detalle = txtDetalleCompra.Value;


            if (cc.register(numeroFactura, tipoFactura, idProv, idadmin, fechaCompra, montoTotal, detalle, productosAgregados))
            {
                lblSuccess.Visible = true;
                lblSuccess.Text = "Compra cargada de forma exitosa";

                Session.Remove("Agregando");
            }
            else
            {
                lblSuccess.Visible = true;
                lblSuccess.Text = "Error al cargar compra";
            }
        }

        protected void onPriceAndUnityChanges(object sender, EventArgs e)
        {
            productosAgregados = Session["Agregando"] != null ? (List<Product>)Session["Agregando"] : new List<Product>();
            decimal res = 0;

            foreach (Product item in productosAgregados)
            {
                res = res + item.PU;
            }

            //decimal precioUnitario = 0;
            //if (txtPrecioUnitario.Text.Length != 0) 
            //    precioUnitario = Decimal.Parse(txtPrecioUnitario.Text);
            //long cantidad = 0;
            //if (txtCantidadComprada.Text.Length != 0)
            //    cantidad = Int64.Parse(txtCantidadComprada.Text);

            //decimal res = cantidad * precioUnitario;

            txtMontoTotal.Text = res.ToString();
        }

        protected void checkInputs()
        {
            if (txtNumeroFactura.Text.Length == 0) return;
            if (long.Parse(dropProveedor.SelectedItem.Value) == 0) return;
            if (long.Parse(dropAdministrador.SelectedItem.Value) == 0) return;
            if (txtFechaCompra.Text.Length == 0) return;
            if (Decimal.Parse(txtMontoTotal.Text) == 0) return;

            btnSubmit.Enabled = true;
        }

        private DataTable createEmptyDataTable()
        {
            DataTable data = new DataTable();
            data.Columns.Add("id");
            data.Columns.Add("description");

            DataRow emptyData = data.NewRow();
            emptyData[0] = 0;
            emptyData[1] = "";
            data.Rows.Add(emptyData);

            DataRow newData = data.NewRow();
            newData[0] = -1;
            newData[1] = "Nuevo...";
            data.Rows.Add(newData);

            return data;
        }

        private void populateDropDown(DataTable dataTable, DropDownList dropDown)
        {
            dropDown.DataSource = new DataView(dataTable);
            dropDown.DataTextField = "description";
            dropDown.DataValueField = "id";
            dropDown.DataBind();
        }

        protected void onAddProductClicked(object sender, EventArgs e)
        {
            decimal res = 0;

            productosAgregados = Session["Agregando"] != null ? (List<Product>)Session["Agregando"] : new List<Product>();
            Product añadir = new Product();
            añadir.Id = Int64.Parse(dropProductos.SelectedValue);
            añadir.Nombre = dropProductos.SelectedItem.Text;
            añadir.Cantidad = int.Parse(txtCantidadComprada.Text);
            añadir.PU = decimal.Parse(txtPrecioUnitario.Text);


            productosAgregados.Add(añadir);

            Session.Add("Agregando", productosAgregados);

            foreach (Product item in productosAgregados)
            {
                res += item.PU*item.Cantidad;
            }

            txtCantidadComprada.Text = "";
            txtPrecioUnitario.Text = "";

            txtMontoTotal.Text = res.ToString();

        }

        protected void onDropProductoChanges(object sender, EventArgs e)
        {
            long idSelected = long.Parse(dropProductos.SelectedValue);

            if (idSelected == -1)
            {
                Session["Comprando"] = true;
                Response.Redirect("~/Pages/Altas/Productos.aspx");
            }
        }

        protected void dropProveedor_SelectedIndexChanged(object sender, EventArgs e)
        {
            long idSelected = long.Parse(dropProveedor.SelectedValue);

            if (idSelected == -1)
            {
                Session["Comprando"] = true;
                Response.Redirect("~/Pages/Altas/AgregarProveedor.aspx");
            }
        }
    }

}