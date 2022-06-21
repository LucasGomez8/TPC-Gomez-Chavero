<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditarCliente.aspx.cs" Inherits="TPC_Gomez_Chavero.Pages.Modificaciones.EditarCliente" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

        <link href="../../css/AñadirProducto.css" rel="stylesheet" type="text/css"/>
    <div class="container mb-4 frmStyle">
         <div class="row mt-3 justify-content-center">
            <div class="col-md-8  text-center">
                <h3>Modificacion de datos de Clientes</h3>
            </div>
        </div>
        <div class="row mb-3">
            <form>
                <div class="col-md-4">
                    <div class="form-group">
                        <label for="deleteProduct">Selecciona el Cliente</label>
                        <asp:DropDownList cssClass="form-control" ID="dropClientes" runat="server"></asp:DropDownList>
                    </div>
                </div>
                <div class="col-md-4 mt-4">
                    <asp:Button ID="btnSelect" CssClass="btn btn-primary" onclick="btnSelect_Click" runat="server" Text="Seleccionar" />
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
                  <div class="row">
                      <div class="col-md-6">
                          <label for="txtDNIoCuit">CUIT o DNI</label>
                          <asp:TextBox ID="txtDNIoCuit" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                      </div>
                      <div class="col-md-6">
                          <label for="txtFechaNac">Fecha de Nacimiento</label>
                          <asp:TextBox ID="txtFechNac" TextMode="Date" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                      </div>
                  </div>
                </div>
                  <div class="form-group mb-5">
                      <div class="row">
                          <div class="col-md-6">
                              <label for="txtTelefono">Telefono</label>
                              <asp:TextBox ID="txtTelefono" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                          </div>
                          <div class="col-md-6">
                              <label for="txtEmail">Email</label>
                              <asp:TextBox ID="txtEmail" runat="server" Enabled="false" TextMode="Email" CssClass="form-control"></asp:TextBox>
                          </div>
                      </div>
                  </div>
                </div>
            </form>
        </div>
        <div class="row mt-4 justify-content-center">
            <div class="col-md-4 text-center">
                <asp:Button ID="btnSubmit" CssClass="btn btn-primary" onclick="btnSubmit_Click" Enabled="false" runat="server" Text="Editar" />
            </div>
        </div>
    </div>

</asp:Content>