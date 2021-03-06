<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditProduct.aspx.cs" Inherits="TPC_Gomez_Chavero.Pages.Modificaciones.EditProduct" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="../../css/Modificacion.css" rel="stylesheet" type="text/css"/>
    <div class="container mb-4 modifStyle" data-aos="flip-left"
     data-aos-easing="ease-out-cubic"
     data-aos-duration="1500">
         <div class="row mt-3 justify-content-center">
            <div class="col-md-8  text-center">
                <h3>Modificacion de datos de Productos</h3>
            </div>
        </div>
        <div class="row mb-3">
            <form>
                <div class="col-md-4">
                    <div class="form-group">
                        <label for="deleteProduct">Selecciona el producto</label>
                        <asp:DropDownList cssClass="form-control" ID="dropProductList" runat="server"></asp:DropDownList>
                    </div>
                </div>
                <div class="col-md-4 mt-4">
                    <asp:Button ID="btnSelect" CssClass="btn btn-primary" OnClick="btnSelect_Click" runat="server" Text="Seleccionar" />
                </div>
                <div class="row mb-4 mt-4 justify-content-center text-center">
                    <hr style="width: 98%"/>
                </div>
                <div class="row">
                      <div class="form-group mb-3">
                <label for="txtNombre">Nombre</label>
                 <asp:TextBox ID="txtNombre" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
              </div>
              <div class="form-group mb-3">
                <label for="descripcion">Descripcion</label>
                <textarea maxlength="250" id="descripcion" disabled="disabled" runat="server" class="form-control"></textarea>
              </div>
              <div class="form-group mb-3">
                  <div class="row">
                      <div class="col-md-4">
                          <label for="categoria">Categoria</label>
                          <asp:DropDownList CssClass="form-control" Enabled="false" ID="dropCategoria" runat="server"></asp:DropDownList>
                      </div>
                      <div class="col-md-4">
                          <label for="marca">Marca</label>
                          <asp:DropDownList CssClass="form-control" Enabled="false" ID="dropMarca" runat="server"></asp:DropDownList>
                      </div>
                      <div class="col-md-4">
                          <label for="tipoProducto">Tipo Producto</label>
                          <asp:DropDownList CssClass="form-control" Enabled="false" ID="dropTipoProducto" runat="server"></asp:DropDownList>

                      </div>
                  </div>
                </div>
                  <div class="form-group mb-5">
                      <div class="row">
                          <div class="col-md-4">
                              <label for="txtStock">Stock Actual</label>
                              <asp:TextBox ID="txtStock" runat="server" Enabled="false" TextMode="Number" CssClass="form-control" onkeypress="return isNumberKey(event)"  AutoPostBack="true" OnTextChanged="onTextChanged" />
                              <asp:Label ID="errorCurrentStock" CssClass="text-danger" runat="server" />
                          </div>
                          <div class="col-md-4">
                              <label for="txtStockMinimo">Stock Minimo</label>
                              <asp:TextBox ID="txtStockMinimo" runat="server" Enabled="false" TextMode="Number" min="1" CssClass="form-control" onkeypress="return isNumberKey(event)"  AutoPostBack="true" OnTextChanged="onTextChanged" />
                              <asp:Label ID="errorMinStock" CssClass="text-danger" runat="server" />
                          </div>
                          <div class="col-md-4">
                              <label for="porcentajeVenta">Porcentaje de Ganancia</label>
                              <asp:TextBox ID="txtPorcentajeVenta" runat="server" Enabled="false" TextMode="Number" min="1" max="100" CssClass="form-control" onkeypress="return isNumberKey(event)"  AutoPostBack="true" OnTextChanged="onTextChanged" />
                              <asp:Label ID="errorSellPercent" CssClass="text-danger" runat="server" />
                          </div>
                      </div>
                  </div>
                </div>
            </form>
            <asp:Label ID="lblSuccess" runat="server" Visible="false"></asp:Label>
        </div>
        <div class="row mt-4 justify-content-center">
            <div class="col-md-4 text-center">
                <asp:Button ID="btnCancelar" CssClass="btn btn-secondary" onclick="btnCancelar_Click" Enabled="false" runat="server" Text="Cancelar" />
                <asp:Button ID="btnSubmit" CssClass="btn btn-primary" onclick="btnSubmit_Click" Enabled="false" runat="server" Text="Editar" />
                <asp:Button ID="btnContinue" CssClass="btn btn-primary" onclick="btnContinue_Click" visible="false" runat="server" Text="Continuar" />
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
