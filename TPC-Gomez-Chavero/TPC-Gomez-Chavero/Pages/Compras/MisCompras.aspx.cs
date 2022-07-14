using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Globalization;
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
                if (sessionUser.type.Description != "Administrador")
                {
                    Response.Redirect("~/");
                }
            }
            else
            {
                Response.Redirect("~/");
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
                txtFechaCompra.Text = DateTime.Now.ToString("yyyy-MM-dd");

                if (Session["Comprando"] != null)
                {

                    recargarDatosAnteriores();
                }

            }
        }


        public void recargarDatosAnteriores()
        {


            if (Session["TipoFactura"] != null)
            {
                dropTipoFactura.SelectedValue = (string)Session["TipoFactura"];
                Session.Remove("TipoFactura");
            }
            if (Session["Proveedor"] != null)
            {
                dropProveedor.SelectedValue = (string)Session["Proveedor"];
                Session.Remove("Proveedor");
            }
            if (Session["FechaCompra"] != null)
            {
                txtFechaCompra.Text = (string)Session["FechaCompra"];
                Session.Remove("FechaCompra");
            }
            if (Session["MontoTotal"] != null)
            {
                txtMontoTotal.Text = (string)Session["MontoTotal"];
                Session.Remove("MontoTotal");
            }
            if (Session["Detalle"] != null)
            {
                txtDetalleCompra.Value = (string)Session["Detalle"];
                Session.Remove("Detalle");
            }
            if(Session["Agregando"] != null)
            {
                productosAgregados = (List<Product>)Session["Agregando"];
            }

        }

        private void setTicketNumber(long type)
        {
            long ticketNumber = cc.getTicketNumber(type);
            txtNumeroFactura.Text = StringHelper.completeTicketNumbers(ticketNumber, 1);
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

            if (checkInputs())
            {
                productosAgregados = (List<Product>)Session["Agregando"];

                long numeroFactura = StringHelper.removeTicketNumbers(txtNumeroFactura.Text);
                long tipoFactura = Int64.Parse(dropTipoFactura.SelectedItem.Value);
                long idProv = Int64.Parse(dropProveedor.SelectedItem.Value);
                long idadmin = Int64.Parse(dropAdministrador.SelectedItem.Value);
                string fechaCompra = txtFechaCompra.Text;
                decimal montoTotal = Decimal.Parse(txtMontoTotal.Text);
                string detalle = txtDetalleCompra.Value;

                if (cc.register(numeroFactura, tipoFactura, idProv, idadmin, fechaCompra, montoTotal, detalle, productosAgregados))
                {
                    lblError.Visible = false;
                    lblSuccess.Visible = true;
                    lblSuccess.Text = "Compra cargada de forma exitosa";
                    btnSubmit.Visible = false;
                    btnContinuar.Visible = true;
                    Session.Remove("Agregando");
                }
                else
                {
                    lblError.Visible = true;
                    lblError.Text = "Error al cargar compra";
                }
            }
            else
            {
                lblError.Text = "Faltan Completar Datos, Por Favor, Complete Todos Los Datos";
                lblError.Visible = true;
            }
           
        }

        protected bool checkInputs()
        {

            if (txtNumeroFactura.Text.Length == 0) return false;
            if (long.Parse(dropProveedor.SelectedItem.Value) == 0) return false;
            if (long.Parse(dropAdministrador.SelectedItem.Value) == 0) return false;
            if (txtFechaCompra.Text.Length == 0) return false;
            if (Decimal.Parse(txtMontoTotal.Text) == 0) return false;

            return true;
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



                if (txtCantidadComprada.Text.Length > 0 && int.Parse(dropProductos.SelectedValue) > 0 && int.Parse(txtCantidadComprada.Text) > 0 && decimal.Parse(txtPrecioUnitario.Text) > 0)
                {
                    decimal res = 0;
                    lblErrorCantidad.Visible = false;
                    errocantidad.Visible = false;
                    productosAgregados = Session["Agregando"] != null ? (List<Product>)Session["Agregando"] : new List<Product>();

                    Product añadir = cc.findIt(Int64.Parse(dropProductos.SelectedValue));

                    añadir.Cantidad = int.Parse(txtCantidadComprada.Text);
                    añadir.PU = Decimal.Parse(txtPrecioUnitario.Text);


                    productosAgregados.Add(añadir);

                    Session.Add("Agregando", productosAgregados);

                    foreach (Product item in productosAgregados)
                    {
                        res += item.PU * item.Cantidad;
                    }

                    txtCantidadComprada.Text = "";
                    txtPrecioUnitario.Text = "";
                    txtSubtotal.Text = "";

                    txtMontoTotal.Text = res.ToString();

                }
                else
                {
                    errocantidad.Visible = true;
                    lblErrorCantidad.Text = "Seleccione un producto o ingrese una cantidad comprada";
                    lblErrorCantidad.Visible = true;
                }

        }

        public void guardarEnSession()
        {
            if (int.Parse(dropTipoFactura.SelectedValue) > 0)
            {
                Session["TipoFactura"] = dropTipoFactura.SelectedValue;
            }
            if (int.Parse(dropProveedor.SelectedValue) > 0)
            {
                Session["Proveedor"] = dropProveedor.SelectedValue;
            }
            if (txtFechaCompra.Text.Length > 0 )
            {
                Session["FechaCompra"] = txtFechaCompra.Text;
            }
            if (txtMontoTotal.Text.Length > 0 )
            {
                Session["MontoTotal"] = txtMontoTotal.Text;
            }
            if (txtDetalleCompra.Value.Length > 0 )
            {
                Session["Detalle"] = txtDetalleCompra.Value;
            }
        }

        protected void onDropProductoChanges(object sender, EventArgs e)
        {
            long idSelected = long.Parse(dropProductos.SelectedValue);

            if (idSelected == -1)
            {
                Session["Comprando"] = true;
                guardarEnSession();
                Response.Redirect("~/Pages/Altas/Productos.aspx");
            }
        }

        protected void dropProveedor_SelectedIndexChanged(object sender, EventArgs e)
        {
            long idSelected = long.Parse(dropProveedor.SelectedValue);

            if (idSelected == -1)
            {
                Session["Comprando"] = true;
                guardarEnSession();
                Response.Redirect("~/Pages/Altas/AgregarProveedor.aspx");
            }
        }

        protected void btnContinuar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Pages/Compras/MisCompras.aspx");
        }


        protected bool Nosobrepasar()
        {
            if (txtCantidadComprada.Text.Length>9 || long.Parse(txtCantidadComprada.Text) <0)
            {
                return false;
            }


            return true;
        }

        protected void subtoRelleno (object sender, EventArgs e)
        {

            if (txtCantidadComprada.Text.Length > 0 && txtPrecioUnitario.Text.Length > 0)
            {
                if (Nosobrepasar())
                {
                    long cant = Int64.Parse(txtCantidadComprada.Text);
                    decimal pu;
                    if (!Decimal.TryParse(txtPrecioUnitario.Text, out pu ))
                    {
                        txtPrecioUnitario.Text = "";
                    }
                    if (FormHelper.validateDecimalNumber(txtPrecioUnitario.Text))
                    {
                        pu = Decimal.Parse(txtPrecioUnitario.Text);
                        decimal subto = pu * cant;

                        txtSubtotal.Text = subto.ToString();
                    }
                    else
                    {
                        txtPrecioUnitario.Text = "";
                    }
                }
                else
                {
                    txtCantidadComprada.Text = "";
                }

            }
            else
            {
                txtSubtotal.Text = "";
            }
        }
    }

}