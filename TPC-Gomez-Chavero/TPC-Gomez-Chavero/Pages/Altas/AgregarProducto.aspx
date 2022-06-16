<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AgregarProducto.aspx.cs" Inherits="TPC_Gomez_Chavero.WebForm1" %>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="../../css/AñadirProducto.css" rel="stylesheet" type="text/css"/>
    <div class="container frmStyle">
        <div class="row mt-3 mb-5 text-center ">
            <div class="col-md-12">
                <h3>Productos</h3>
            </div>
        </div>
        <div class="row mt-5 mb-5 ">
            <form class="frmStyle">
              <div class="form-group mb-3">
                <label for="txtNombre">Nombre</label>
                 <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control"></asp:TextBox>
              </div>
              <div class="form-group mb-3">
                <label for="descripcion">Descripcion</label>
                <textarea maxlength="250" id="descripcion" class="form-control"></textarea>
              </div>
              <div class="form-group mb-3">
                  <div class="row">
                      <div class="col-md-4">
                          <label for="categoria">Categoria</label>
                          <asp:DropDownList CssClass="form-control" ID="dropCategoria" runat="server"></asp:DropDownList>
                      </div>
                      <div class="col-md-4">
                          <label for="marca">Marca</label>
                          <asp:DropDownList CssClass="form-control" ID="dropMarca" runat="server"></asp:DropDownList>
                      </div>
                      <div class="col-md-4">
                          <label for="tipoProducto">Tipo Producto</label>
                          <asp:DropDownList CssClass="form-control" ID="dropProducto" runat="server"></asp:DropDownList>
                      </div>
                  </div>
                </div>
                  <div class="form-group mb-5">
                      <div class="row ">
                          <div class="col-md-4">
                              <label for="txtStock">Stock Actual</label>
                              <asp:TextBox ID="txtStock" runat="server" TextMode="Number" CssClass="form-control"></asp:TextBox>
                          </div>
                          <div class="col-md-4">
                              <label for="txtStockMinimo">Stock Minimo</label>
                              <asp:TextBox ID="txtStockMinimo" runat="server" TextMode="Number" CssClass="form-control"></asp:TextBox>
                          </div>
                          <div class="col-md-4">
                              <label for="porcentajeVenta">Porcentaje de Venta</label>
                              <asp:TextBox ID="txtPorcentajeVenta" runat="server" TextMode="Number" CssClass="form-control"></asp:TextBox>
                          </div>
                      </div>
                  </div>
                <div class="form-group mb-5">
                    <input type="file" name="name" class="form-control" value="" placeholder="+"/>
                </div>
              <button type="submit" id="submit" class="btn btn-primary">Agregar</button>
            </form>
        </div>
    </div>
</asp:Content>
