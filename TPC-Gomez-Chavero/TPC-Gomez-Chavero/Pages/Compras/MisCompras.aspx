<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MisCompras.aspx.cs" Inherits="TPC_Gomez_Chavero.Pages.Compras.MisCompras" %>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <link href="../../css/Compras.css" rel="stylesheet" type="text/css" />
        <div class="container comStyle mb-4 ">
        <div class="row mt-3 mb-5 text-center ">
            <div class="col-md-12">
                <h3>Registrar Compra</h3>
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
                          <label for="categoria">Tipo de Factura</label>
                          <asp:DropDownList CssClass="form-control" ID="dropTipoFactura" runat="server" AutoPostBack="true" OnSelectedIndexChanged="dropTypeTicketOnChange" />
                      </div>
                      <div class="col-md-4">
                          <label for="marca">Proveedor</label>
                          <asp:DropDownList CssClass="form-control" ID="dropProveedor" OnSelectedIndexChanged="dropProveedor_SelectedIndexChanged" runat="server"  AutoPostBack="true" />
                      </div>
                      <div class="col-md-4">
                          <label for="tipoProducto">Administrador que realiza el registro</label>
                          <asp:DropDownList CssClass="form-control" ID="dropAdministrador" Visible="false" runat="server"  AutoPostBack="true" />
                          <asp:TextBox ID="txtUsuarioSession" Enabled="false" runat="server" Visible="false" CssClass="form-control" />
                      </div>
                  </div>
                </div>
                  <div class="form-group">
                      <div class="row ">
                          <div class="col-md-4">
                              <label for="dropProductos">Producto</label>
                          </div>
                          <div class="col-md-4">
                              <label for="txtCantidadComprada">Cantidad Comprada</label>
                          </div>
                          <div class="col-md-4">
                              <label for="txtPrecioUnitario">Precio Unitario</label>
                          </div>
                      </div>
                      <div class="row ">
                          <div class="col-md-4">
                              <asp:DropDownList CssClass="form-control" ID="dropProductos"  AutoPostBack="true" OnSelectedIndexChanged="onDropProductoChanges" runat="server"  />
                          </div>
                          <div class="col-md-4">
                              <asp:TextBox ID="txtCantidadComprada" runat="server" TextMode="Number" CssClass="form-control"/>
                          </div>
                          <div class="col-md-4">
                              <asp:TextBox ID="txtPrecioUnitario" runat="server" TextMode="Number" CssClass="form-control"/>
                          </div>
                          <div class="col-md-4">
                               <asp:Button ID="addProduct" runat="server" Text="Agregar..." CssClass="btn btn-secondary" OnClick="onAddProductClicked" />
                          </div>
                      </div>
                      <div class="row mt-4">
                          <label class="mb-3">Productos Agregados: </label>
                      <% if(productosAgregados != null) foreach(domain.Product item in productosAgregados) {%>
                          <div class="col-sm-2">
                             <label class="btn btn-warning"><%=item.Nombre %></label>
                          </div>
                      <% } %>
                      </div>
                      </div>

                     <div class="row mt-2 mb-4 justify-content-center" runat="server" id="errocantidad" visible="false">
                        <div class="text-center">
                            <asp:Label ID="lblErrorCantidad" CssClass="text-danger" Visible="false" runat="server"></asp:Label>
                        </div>
                      </div>

                  </div>

                <div class="form-group mb-4">
                    <div class="row">
                        <div class="col-md-6">
                            <label for="txtFechaCompra">Fecha de Compra</label>
                            <asp:TextBox ID="txtFechaCompra" runat="server" TextMode="date" CssClass="form-control"/>
                        </div>
                        <div class="col-md-6">
                            <label for="txtMontoTotal">Monto Total de Compra</label>
                            <asp:TextBox ID="txtMontoTotal" runat="server" Enabled="false" TextMode="number" CssClass="form-control" Text="0" />
                        </div>
                    </div>
                </div>
                <div class="form-group mb-5">
                    <label for="descripcion">Detalle de compra</label>
                    <textarea maxlength="250" id="txtDetalleCompra" runat="server" class="form-control"></textarea>
                </div>
            </form>
            <div class="row justify-content-center mb-3">
                <div class="col-md-4 text-center">
                    <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" CssClass="btn btn-primary" Text="Agregar" />
                    <asp:Button ID="btnContinuar" runat="server" Visible="false" OnClick="btnContinuar_Click" CssClass="btn btn-primary" Text="Continuar Comprando" />
                </div>
            </div>
            <div class="row justify-content-center">
                <div class="col-md-4 text-center">
                    <asp:Label ID="lblSuccess" CssClass="text-success" runat="server"></asp:Label>
                    <asp:Label ID="lblError" CssClass="text-danger" runat="server" Visible="false"></asp:Label>
                </div>
            </div>
        </div>


</asp:Content>
