<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AgregarUsuario.aspx.cs" Inherits="TPC_Gomez_Chavero.Pages.Altas.AgregarUsuario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="../../css/AñadirProducto.css" rel="stylesheet" type="text/css"/>
    <div class="container frmStyle">
        <div class="row mt-3">
            <div class="col-md-12 text-center">
                <h3>Usuarios</h3>
            </div>
        </div>

        <div class="row justify-content-center mt-5 mb-3" runat="server" id="menu">
            <div class="col-md-6 text-center">
                <asp:Button ID="brnNuevoUsuario" runat="server" CssClass="btn btn-primary" OnClick="brnNuevoUsuario_Click" Text="Nuevo" />
            </div>
            <div class="col-md-6 text-center">
                <asp:Button ID="btnViejoUsuario" runat="server" CssClass="btn btn-warning" OnClick="btnViejoUsuario_Click" Text="Dado de Baja" />
            </div>
        </div>

        <div class="row mt-5" runat="server" id="NuevoUsuario" visible="false">
            <form>
              <div class="form-group mb-3">
                  <div class="row">
                      <div class="col-md-6">
                          <label for="txtNombreUsuario">Nombre</label>
                          <asp:TextBox ID="txtNombreUsuario" CssClass="form-control" runat="server" AutoPostBack="true" />
                          <asp:Label CssClass="text-danger" runat="server" />
                      </div>
                      <div class="col-md-6">
                        <label for="txtApellidoUsuario">Apellido</label>
                        <asp:TextBox ID="txtApellidoUsuario" cssClass="form-control" runat="server" AutoPostBack="true" />
                        <asp:Label CssClass="text-danger" runat="server" />
                      </div>
                  </div>
              </div>
              <div class="form-group mb-3">
                  <div class="row">
                      <div class="col-md-6">
                          <label for="txtFechaNac">Fecha de Nacimiento</label>
                          <input type="date" id="txtFechaNac" runat="server" class="form-control" />
                          <asp:Label CssClass="text-danger" runat="server" />
                      </div>
                      <div class="col-md-6">
                          <label for="txtDni">DNI</label>
                          <asp:TextBox ID="txtDni" CssClass="form-control" runat="server" AutoPostBack="true" OnTextChanged="onTextChanged" />
                          <asp:Label ID="errorDNI" CssClass="text-danger" runat="server" />
                      </div>
                  </div>
                </div>
                <div class="form-group mb-3">
                    <div class="row">
                        <div class="col-md-4">
                            <label for="txtNick">Username</label>
                            <asp:TextBox ID="txtNick" CssClass="form-control" runat="server" AutoPostBack="true" />
                            <asp:Label CssClass="text-danger" runat="server" />
                        </div>
                        <div class="col-md-4">
                            <label for="txtPass">Contraseña</label>
                            <asp:TextBox ID="txtPass" CssClass="form-control" runat="server" AutoPostBack="true" OnTextChanged="onTextChanged" />
                            <asp:Label ID="errorPasswd" CssClass="text-danger" runat="server" />
                        </div>
                        <div class="col-md-4">
                            <label for="dropUserType">Tipo de Usuario</label>
                            <asp:DropDownList class="form-control" id="dropUserType" runat="server" AutoPostBack="true" />
                            <asp:Label CssClass="text-danger" runat="server" />
                        </div>
                    </div>
                </div>
            </form>
            <div class="row justify-content-center mt-3">
                <div class="row justify-content-center mt-4">
                    <div class="col-md-12 text-center">
                        <asp:Label ID="lblSuccess" runat="server" CssClass="text-success" />
                    </div>
                </div>
                <div class="col-md-4 text-center">
                    <asp:Button ID="btnSubmit" cssClass="btn btn-primary" OnClick="btnSubmit_Click" runat="server" Enabled="false" Text="Agregar" />
                    <asp:Button ID="btnVolver2" runat="server" CssClass="btn btn-secondary" onClick="btnVolver2_Click" Enabled="true" Text="Volver" />
                    <asp:Button ID="btnReload" cssClass="btn btn-primary" OnClick="btnReload_Click" runat="server" Text="Continuar" Visible="false" />
                </div>
            </div>
        </div>

        <div class="row justify-content-center" runat="server" visible="false" id="debaja">
            <div class="col-md-4">
                <div class="form-group">
                    <label for="deleteType">Selecciona el usuario a volver a dar el alta</label>
                    <asp:DropDownList cssClass="form-control" ID="dropElimnacionFisica" runat="server"></asp:DropDownList>
                </div>
            </div>
            <div class="col-md-4 mt-4">
                <asp:Button ID="btnOk" CssClass="btn btn-primary" onclick="btnOk_Click" runat="server" Text="Dar de Alta" />
            </div>
            <div class="row justify-content-center mt-4">
                <div class="col-md-12 text-center">
                    <asp:Label ID="lblSucessBaja" runat="server" CssClass="text-success" Visible="false"></asp:Label>
                </div>
            </div>
            <div class="col-md-4 mt-4 text-center">
                <asp:Button ID="btnVolverBaja" runat="server" CssClass="btn btn-secondary" onClick="btnVolverBaja_Click" Text="Volver" />
                <asp:Button ID="btnContinuarBaja" runat="server" CssClass="btn btn-primary" onClick="btnContinuarBaja_Click" Enabled="false" Text="Continuar" />
            </div>
        </div>
    </div>
</asp:Content>
