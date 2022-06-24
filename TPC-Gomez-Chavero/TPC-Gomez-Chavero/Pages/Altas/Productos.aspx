<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Productos.aspx.cs" Inherits="TPC_Gomez_Chavero.Pages.Altas.Productos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <link href="../../css/AñadirProducto.css" rel="stylesheet" type="text/css"/>
    <div class="container frmStyle mb-4 ">
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
                <textarea maxlength="250" id="descripcion" runat="server" class="form-control"></textarea>
              </div>
              <div class="form-group mb-3">
                  <div class="row mb-2">
                      <div class="col-md-4">
                          <label for="categoria">Categoria</label>
                          <asp:DropDownList CssClass="form-control" ID="dropCategoria" runat="server" OnSelectedIndexChanged="dropCategoriaChanged" AutoPostBack="true" />
                      </div>
                      <div class="col-md-4">
                          <label for="marca">Marca</label>
                          <asp:DropDownList CssClass="form-control" ID="dropMarca" runat="server" OnSelectedIndexChanged="dropMarcaChanged"  AutoPostBack="true" />
                      </div>
                      <div class="col-md-4">
                          <label for="tipoProducto">Tipo Producto</label>
                          <asp:DropDownList CssClass="form-control" ID="dropProducto" runat="server" OnSelectedIndexChanged="dropProductoChanged"  AutoPostBack="true" />
                      </div>
                  </div>
                  <div class="row">
                    <div class="col-md-4" style="display: flex; height: 40px;">
                        <asp:TextBox ID="addCategoryTxt" style="width: 75%;" runat="server" Visible="false" CssClass="form-control" />
                        <asp:Button ID="addCategoryBtn" style="margin-left: 10px;" runat="server" Visible="false" Text="Agregar..." CssClass="btn btn-secondary"/>
                    </div>
                    <div class="col-md-4" style="display: flex; height: 40px;">
                        <asp:TextBox ID="addBranchTxt" style="width: 75%;" runat="server" Visible="false" CssClass="form-control" />
                        <asp:Button ID="addBranchBtn" style="margin-left: 10px;" runat="server" Visible="false" Text="Agregar..." CssClass="btn btn-secondary"/>
                    </div>
                    <div class="col-md-4" style="display: flex; height: 40px;">
                        <asp:TextBox ID="addTypeTxt" style="width: 75%;" runat="server" Visible="false" CssClass="form-control" />
                        <asp:Button ID="addTypeBtn" style="margin-left: 10px;" runat="server" Visible="false" Text="Agregar..." CssClass="btn btn-secondary"/>
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
            </form>
            <div class="row justify-content-center">
                <div class="col-md-4 text-center">
              <asp:Button ID="btnSubmit" runat="server" CssClass="btn btn-primary" onClick="btnSubmit_Click" Text="Agregar" />
                </div>
            </div>
        <%--</div>--%>
    </div>
</asp:Content>
