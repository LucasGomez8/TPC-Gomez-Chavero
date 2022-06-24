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
                          <asp:DropDownList CssClass="form-control" ID="dropTipoFactura" runat="server" AutoPostBack="true" />
                      </div>
                      <div class="col-md-4">
                          <label for="marca">Proveedor</label>
                          <asp:DropDownList CssClass="form-control" ID="dropProveedor" runat="server"  AutoPostBack="true" />
                      </div>
                      <div class="col-md-4">
                          <label for="tipoProducto">Administrador que realiza el registro</label>
                          <asp:DropDownList CssClass="form-control" ID="dropAdministrador" runat="server"  AutoPostBack="true" />
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
                              <label for="txtCantidadComprada">Cantidad Comprada</label>
                              <asp:TextBox ID="txtCantidadComprada" runat="server" TextMode="Number" CssClass="form-control"></asp:TextBox>
                          </div>
                          <div class="col-md-4">
                              <label for="txtPrecioUnitario">Precio Unitario</label>
                              <asp:TextBox ID="txtPrecioUnitario" runat="server" OnTextChanged="txtPrecioUnitario_TextChanged" TextMode="Number" CssClass="form-control"></asp:TextBox>
                          </div>
                      </div>
                  </div>
                <div class="form-group mb-4">
                    <div class="row">
                        <div class="col-md-6">
                            <label for="txtFechaCompra">Fecha de Compra</label>
                            <asp:TextBox ID="txtFechaCompra" runat="server" TextMode="date" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="col-md-6">
                            <label for="txtMontoTotal">Monto Total de Compra</label>
                            <asp:TextBox ID="txtMontoTotal" runat="server" TextMode="number" enabled="false" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="form-group mb-5">
                    <label for="descripcion">Detalle de compra</label>
                    <textarea maxlength="250" id="txtDetalleCompra" runat="server" class="form-control"></textarea>
                </div>
            </form>
            <div class="row justify-content-center">
                <div class="col-md-4 text-center">
              <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" CssClass="btn btn-primary" Text="Agregar" />
                </div>
            </div>
        </div>
    </div>

</asp:Content>
