<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Productos.aspx.cs" Inherits="TPC_Gomez_Chavero.Pages.Altas.Productos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

        <link href="../../css/AñadirProducto.css" rel="stylesheet" type="text/css"/>
    <div class="container frmStyle mb-4" data-aos="fade-up">
        
        <div class="row mt-3 mb-5 text-center">
            <div class="col-md-12">
                <h3>Alta de Productos</h3>
            </div>
        </div>

        <div class="row justify-content-center" runat="server" id="menu">
            <div class="col-md-6 text-center">
                <asp:Button ID="btnNuevo" OnClick="btnNuevo_Click" CssClass="btn btn-primary"  runat="server" Text="Nuevo" />
            </div>
            <div class="col-md-6 text-center">
                <asp:Button ID="btnExistente" CssClass="btn btn-primary" OnClick="btnExistente_Click" runat="server" Text="Dado de Baja" />
            </div>
        </div>



        <div class="row mt-5 mb-5" id="Nuevo" runat="server" visible="false"> 
            <form class="frmStyle">
              <div class="form-group mb-3">
                <label for="txtNombre">Nombre</label>
                 <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control"></asp:TextBox>
              </div>
              <div class="form-group mb-3">
                <label for="descripcion">Descripcion</label>
                <textarea maxlength="250" id="descripcion" runat="server" class="form-control"></textarea>
              </div>
              <div class="form-group mb-2">
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
                        <asp:TextBox ID="addCategoryTxt" style="width: 75%;" runat="server" Visible="false" CssClass="form-control" Placeholder="Ingrese la nueva categoria..."/>
                        <asp:Button ID="addCategoryBtn" style="margin-left: 10px;" runat="server" Visible="false" Text="Agregar..." CssClass="btn btn-secondary" OnClick="onCreateCategoryClicked"/>
                    </div>
                    <div class="col-md-4" style="display: flex; height: 40px;">
                        <asp:TextBox ID="addBranchTxt" style="width: 75%;" runat="server" Visible="false" CssClass="form-control" Placeholder="Ingrese la nueva marca..." />
                        <asp:Button ID="addBranchBtn" style="margin-left: 10px;" runat="server" Visible="false" Text="Agregar..." CssClass="btn btn-secondary" OnClick="onCreateBranchClicked"/>
                    </div>
                    <div class="col-md-4" style="display: flex; height: 40px;">
                        <asp:TextBox ID="addTypeTxt" style="width: 75%;" runat="server" Visible="false" CssClass="form-control" Placeholder="Ingrese el nuevo tipo..."/>
                        <asp:Button ID="addTypeBtn" style="margin-left: 10px;" runat="server" Visible="false" Text="Agregar..." CssClass="btn btn-secondary" OnClick="onCreateTypeClicked" />
                    </div>
                  </div>
                </div>
                  <div class="form-group mb-5">
                      <div class="row ">
                          <div class="col-md-6">
                              <label for="txtStockMinimo">Stock Minimo</label>
                              <asp:TextBox ID="txtStockMinimo" runat="server" TextMode="Number" CssClass="form-control"></asp:TextBox>
                          </div>
                          <div class="col-md-6">
                              <label for="porcentajeVenta">Porcentaje de Venta</label>
                              <asp:TextBox ID="txtPorcentajeVenta" runat="server" TextMode="Number" CssClass="form-control"></asp:TextBox>
                          </div>
                      </div>
                  </div>
            </form>
            <div class="row justify-content-center">
                <div class="col-md-4 text-center">
                    <asp:Button ID="btnSubmit" runat="server" CssClass="btn btn-primary" onClick="btnSubmit_Click" Text="Agregar" />
                    <asp:Button ID="btnContinue" runat="server" CssClass="btn btn-primary" onClick="btnContinue_Click" Visible="false" Text="Continuar" />
                    <asp:Button ID="btnVolver" runat="server" CssClass="btn btn-primary" onClick="btnContinue_Click" Visible="false" Text="Volver" />
                    <asp:Button ID="btnRetorno" runat="server" CssClass="btn btn-primary" onClick="btnRetorno_Click" Text="Agregar y Volver" Visible="false" />
                </div>
            </div>
            <div class="row justify-content-center">
                <div class="col-md-4 text-center">
                   <asp:Label ID="lblSuccess" runat="server" Visible="false"></asp:Label>
                </div>
            </div>
        </div>


        <div class="row justify-content-center" runat="server" visible="false" id="debaja">
               <div class="col-md-4">
                    <div class="form-group">
                        <label for="deleteType">Selecciona el Producto a volver a dar el alta</label>
                        <asp:DropDownList cssClass="form-control" ID="dropElimnacionFisica" runat="server"></asp:DropDownList>
                    </div>
                </div>
                <div class="col-md-4 mt-4">
                     <asp:Button ID="btnOk" CssClass="btn btn-primary" onclick="btnOk_Click" runat="server" Text="Dar de Alta" />
                </div>
              <div class="row justify-content-center mt-4">
                  <div class="col-md-12 text-center">
                    <asp:Label ID="lblSucessBaja" runat="server" Visible="false"></asp:Label>
                  </div>
              </div>
                <div class="col-md-4 mt-4 text-center">
                    <asp:Button ID="btnContinuarBaja" runat="server" CssClass="btn btn-primary" onClick="btnContinuarBaja_Click" Visible="false" Text="Continuar" />
                    <asp:Button ID="btnVolverBaja" runat="server" CssClass="btn btn-primary" onClick="btnVolverBaja_Click" Visible="false" Text="Volver" />
                </div>
        </div>


    </div>
</asp:Content>
