<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AgregarProducto.aspx.cs" Inherits="TPC_Gomez_Chavero.WebForm1" %>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row mt-3 text-center">
            <div class="col-md-12">
                <h3>Productos</h3>
            </div>
        </div>
        <div class="row mt-5">
            <form>
              <div class="form-group mb-3">
                <label for="nombre">Nombre</label>
                <input class="form-control" type="text" name="nombre" id="nombre" placeholder="Nombre"/>
              </div>
              <div class="form-group mb-3">
                <label for="descripcion">Descripcion</label>
                <textarea maxlength="250" id="descripcion" class="form-control"></textarea>
              </div>
              <div class="form-group mb-3">
                  <div class="row">
                      <div class="col-md-4">
                          <label for="categoria">Categoria</label>
                          <asp:DropDownList CssClass="form-control" ID="categoria" runat="server"></asp:DropDownList>
                      </div>
                      <div class="col-md-4">
                          <label for="marca">Marca</label>
                          <asp:DropDownList CssClass="form-control" ID="marca" runat="server"></asp:DropDownList>
                      </div>
                      <div class="col-md-4">
                          <label for="tipoProducto">Tipo Producto</label>
                          <asp:DropDownList CssClass="form-control" ID="tipoProducto" runat="server"></asp:DropDownList>
                      </div>
                  </div>
                </div>
                  <div class="form-group mb-5">
                      <div class="row ">
                          <div class="col-md-6">
                              <label for="stockNumero">Stock Minimo</label>
                              <input type="number" class="form-control" id="stockNumero" name="numero" placeholder="Stock Minimo" value="0" />
                          </div>
                          <div class="col-md-6">
                              <label for="porcentajeVenta">Porcentaje de Venta</label>
                              <input type="number" class="form-control" name="porcentajeVenta" id="porcentajeVenta" placeholder="Stock Minimo" value="0" />
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
