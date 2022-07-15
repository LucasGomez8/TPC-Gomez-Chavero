<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MisVentas.aspx.cs" Inherits="TPC_Gomez_Chavero.MisVentas" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <link href="../../css/Ventas.css" rel="stylesheet" type="text/css" />
        <div class="container venStyle mb-4 " data-aos="fade-left">
        <div class="row mt-3 mb-5 text-center ">
            <div class="col-md-12">
                <h3>Registrar Venta</h3>
            </div>
        </div>
        <div class="row mt-5 mb-5 ">
            <form class="frmStyle">
              <div class="form-group mb-3">
                  <div class="col-md-3">
                    <label for="txtNumeroFactura">Numero de Factura</label>
                    <asp:TextBox ID="txtNumeroFactura" runat="server"  CssClass="form-control"></asp:TextBox>
                  </div>
              </div>
              <div class="form-group mb-3">
                  <div class="row">
                      <div class="col-md-4">
                          <label for="dropTipoFactura">Tipo de Factura</label>
                          <asp:DropDownList CssClass="form-control" ID="dropTipoFactura" runat="server" Enabled="false"/>
                      </div>
                      <div class="col-md-4">
                          <label for="dropCliente">Cliente</label>
                          <asp:DropDownList CssClass="form-control" ID="dropCliente" OnSelectedIndexChanged="dropCliente_SelectedIndexChanged" AutoPostBack="true" runat="server" />
                      </div>
                      <div class="col-md-4">
                          <label for="dropUsuario">Usuario que realiza la venta</label>
                          <asp:DropDownList CssClass="form-control" ID="dropUsuario" runat="server"  />
                      </div>
                  </div>
                </div>
                  <div class="form-group mb-4">
                      <div class="row">
                          <div class="col-md-3">
                              <label for="dropProductos">Producto</label>
                              <asp:DropDownList CssClass="form-control" ID="dropProductos" runat="server" AutoPostBack="true" OnSelectedIndexChanged="onDropProductChange" />
                          </div>
                          <div class="col-md-3">
                              <label for="txtCantidadVendida">Cantidad Vendida</label>
                              <asp:TextBox ID="txtCantidadVendida" MaxLength="6" runat="server" OnTextChanged="txtCantidadVendida_TextChanged" AutoPostBack="true" onkeypress="return isNumberKey(event)" TextMode="Number" CssClass="form-control"></asp:TextBox>
                          </div>
                          <div class="col-md-3">
                              <label for="txtPrecioUnitario">Precio Unitario</label>
                              <asp:TextBox ID="txtPrecioUnitario" Enabled="false" runat="server" CssClass="form-control"></asp:TextBox>
                          </div>
                          <div class="col-md-3">
                              <label for="txtSubTotal">Subtotal</label>
                              <asp:TextBox ID="txtSubTotal" Enabled="false" runat="server" CssClass="form-control"></asp:TextBox>
                          </div>
                          <div class="col-md-3">
                               <asp:Button ID="addProduct" runat="server" Text="Agregar..." CssClass="btn btn-secondary"   OnClick="addProduct_Click" />
                          </div>
                      </div>
                  </div>

                <div class="row mt-2 mb-3" runat="server" visible="true">
                    <label>Productos Agregados:</label>
                    <%if(productosAgregados != null) foreach(domain.Product item in productosAgregados){ %>
                            <div class="col-sm-2">
                                <label class="btn btn-warning"><%=item.Nombre %></label>
                            </div>
                    <%} %>

                </div>
               <div class="row mt-2 mb-4 justify-content-center" runat="server" id="errocantidad" visible="false">
                        <div class="text-center">
                            <asp:Label ID="lblErrorCantidad" CssClass="text-danger" Visible="false" runat="server"></asp:Label>
                        </div>
               </div>

                <div class="form-group mb-4">
                    <div class="row">
                        <div class="col-md-6">
                            <label for="txtFechaVenta">Fecha de Venta</label>
                            <asp:TextBox ID="txtFechaVenta" runat="server" TextMode="date" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="col-md-6">
                            <label for="txtVenta">Monto Total de Venta</label>
                            <asp:TextBox ID="txtVenta" runat="server" Enabled="false" CssClass="form-control" Text="0"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="form-group mb-5">
                    <label for="descripcion">Detalle de Venta</label>
                    <textarea maxlength="250" id="txtDetalleCompra" runat="server" class="form-control"></textarea>
                </div>
            </form>
            <div class="row justify-content-center mb-3">
                <div class="col-md-4 text-center">
              <asp:Button ID="btnSubmit" runat="server"  onclick="btnSubmit_Click"  CssClass="btn btn-primary" Text="Agregar" />
                    <asp:Button ID="btnSeguirVendiendo" runat="server" visible="false" onclick="btnSeguirVendiendo_Click"  CssClass="btn btn-primary" Text="Continuar Vendiendo" />
                    <asp:Button ID="btnVerReporte" runat="server" visible="false" onclick="btnVerReporte_Click"  CssClass="btn btn-success" Text="Ver Reporte" />
                </div>
            </div>
            <div class="row justify-content-center">
                <div class="col-md-4 text-center">
                    <asp:Label ID="lblSuccess" CssClass="text-success" runat="server"></asp:Label>
                    <asp:Label ID="lblError" CssClass="text-danger" Visible="false" runat="server"></asp:Label>
                </div>
            </div>
        </div>
    </div>


               <script>
           function isNumberKey(evt) {
               var charCode = (evt.which) ? evt.which : evt.keyCode;
               if (charCode > 31 && (charCode < 48 || charCode > 57))
                   return false;
               return true;
           }
               </script>





</asp:Content>
