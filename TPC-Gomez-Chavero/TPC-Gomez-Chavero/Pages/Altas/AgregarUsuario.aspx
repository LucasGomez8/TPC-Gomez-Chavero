<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AgregarUsuario.aspx.cs" Inherits="TPC_Gomez_Chavero.Pages.Altas.AgregarUsuario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
            <link href="../../css/AñadirProducto.css" rel="stylesheet" type="text/css"/>
     <div class="container frmStyle">
        <div class="row mt-3">
            <div class="col-md-12 text-center">
                <h3>Usuarios</h3>
            </div>
        </div>
        <div class="row mt-5">
            <form>
              <div class="form-group mb-3">
                  <div class="row">
                      <div class="col-md-6">
                          <label for="nombreUsuario">Nombre</label>
                          <asp:TextBox ID="txtNombreUsuario" CssClass="form-control" runat="server"></asp:TextBox>
                      </div>
                      <div class="col-md-6">
                         <label for="ApellidoUsuario">Apellido</label>
                          <asp:TextBox ID="txtApellidoUsuario" cssClass="form-control" runat="server"></asp:TextBox>
                      </div>
                  </div>
              </div>
              <div class="form-group mb-3">
                  <div class="row">
                      <div class="col-md-6">
                          <label for="fechaNac">Fecha de Nacimiento</label>
                          <asp:TextBox ID="txtFechaNac" CssClass="form-control" TextMode="Date" runat="server"></asp:TextBox>
                      </div>
                      <div class="col-md-6">
                          <label for="email">DNI</label>
                          <asp:TextBox ID="txtDni" CssClass="form-control" runat="server"></asp:TextBox>
                      </div>
                  </div>
                </div>
                <div class="form-group mb-3">
                    <div class="row">
                        <div class="col-md-4">
                            <label for="email">Username</label>
                            <asp:TextBox ID="txtNick" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                        <div class="col-md-4">
                            <label for="email">Contraseña</label>
                            <asp:TextBox ID="txtPass" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                        <div class="col-md-4">
                            <label for="email">Tipo de Usuario</label>
                            <asp:DropDownList class="form-control" id="dropUserType" runat="server"></asp:DropDownList>
                        </div>
                    </div>
                </div>
            </form>
            <div class="row justify-content-center">
                <div class="col-md-4 text-center">
                <asp:Button ID="btnSubmit" cssClass="btn btn-primary" OnClick="btnSubmit_Click" runat="server" Text="Agregar" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
