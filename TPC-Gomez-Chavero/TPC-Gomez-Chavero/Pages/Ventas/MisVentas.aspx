<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MisVentas.aspx.cs" Inherits="TPC_Gomez_Chavero.MisVentas" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <link href="../../css/Ventas.css" rel="stylesheet" type="text/css" />
        <div class="container venStyle mb-4 ">
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
                          <asp:DropDownList CssClass="form-control" ID="dropTipoFactura" runat="server" AutoPostBack="true" />
                      </div>
                      <div class="col-md-4">
                          <label for="dropCliente">Cliente</label>
                          <asp:DropDownList CssClass="form-control" ID="dropCliente" runat="server"  AutoPostBack="true" />
                      </div>
                      <div class="col-md-4">
                          <label for="dropUsuario">Usuario que realiza la venta</label>
                          <asp:DropDownList CssClass="form-control" ID="dropUsuario" runat="server"  AutoPostBack="true" />
                      </div>
                  </div>
                  <div class="row">
                    <div class="col-md-4">
                        <asp:TextBox ID="addCategoryTxt" runat="server" Visible="false" CssClass="form-control" />
                        <asp:Button ID="addCategoryBtn" runat="server" Visible="false" Text="Agregar..." CssClass="btn-outline-dark"/>
                    </div>
                    <div class="col-md-4">
                        <asp:TextBox ID="addBranchTxt" runat="server" Visible="false" CssClass="form-control" />
                        <asp:Button ID="addBranchBtn" runat="server" Visible="false" Text="Agregar..." CssClass="btn-outline-dark"/>
                    </div>
                    <div class="col-md-4">
                        <asp:TextBox ID="addTypeTxt" runat="server" Visible="false" CssClass="form-control" />
                        <asp:Button ID="addTypeBtn" runat="server" Visible="false" Text="Agregar..." CssClass="btn-outline-dark"/>
                    </div>
                  </div>
                </div>
                  <div class="form-group mb-3">
                      <div class="row ">
                          <div class="col-md-4">
                              <label for="dropProductos">Producto</label>
                              <asp:DropDownList CssClass="form-control" ID="dropProductos" runat="server"  AutoPostBack="true" />
                          </div>
                          <div class="col-md-4">
                              <label for="txtCantidadComprada">Cantidad Vendida</label>
                              <asp:TextBox ID="txtCantidadComprada" runat="server" TextMode="Number" CssClass="form-control"></asp:TextBox>
                          </div>
                          <div class="col-md-4">
                              <label for="txtPrecioUnitario">Precio Venta</label>
                              <asp:TextBox ID="txtPrecioUnitario" runat="server" TextMode="Number" CssClass="form-control"></asp:TextBox>
                          </div>
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
                            <asp:TextBox ID="txtVenta" runat="server" TextMode="number" CssClass="form-control"></asp:TextBox>
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
              <asp:Button ID="btnSubmit" runat="server" onclick="btnSubmit_Click" CssClass="btn btn-primary" Text="Agregar" />
                </div>
            </div>
            <div class="row justify-content-center">
                <div class="col-md-4 text-center">
                    <asp:Label ID="lblSuccess" runat="server"></asp:Label>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
