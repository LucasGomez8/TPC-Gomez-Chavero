<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditarUsuario.aspx.cs" Inherits="TPC_Gomez_Chavero.Pages.Modificaciones.EditarUsuario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
         <link href="../../css/Modificacion.css" rel="stylesheet" type="text/css"/>
    <div class="container mb-4 modifStyle">
         <div class="row mt-3 justify-content-center">
            <div class="col-md-8  text-center">
                <h3>Modificacion de datos de Usuarios</h3>
            </div>
        </div>
        <div class="row mb-3">
            <form>
                <div class="col-md-4">
                    <div class="form-group">
                        <label for="deleteProduct">Selecciona el usuario</label>
                        <asp:DropDownList cssClass="form-control" ID="dropUsuarios" runat="server"></asp:DropDownList>
                    </div>
                </div>
                <div class="col-md-4 mt-4">
                    <asp:Button ID="btnSelect" CssClass="btn btn-primary" onclick="btnSelect_Click" runat="server" Text="Seleccionar" />
                </div>
                <div class="row mb-4 mt-4 justify-content-center text-center">
                    <hr style="width: 98%"/>
                </div>
                      <div class="form-group mb-3">
                <div class="row">
                          <div class="col-md-3">
                                <label for="txtNombre">Nombre</label>
                                <asp:TextBox ID="txtNombre" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                          </div>
                          <div class="col-md-3">
                                <label for="txtApellido">Apellido</label>
                                <asp:TextBox ID="txtApellido" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                          </div>
                          <div class="col-md-3">
                                <label for="txtDni">DNI</label>
                                <asp:TextBox ID="txtDni" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                          </div>
                          <div class="col-md-3">
                                <label for="txtFechaNac">Fecha de Nacimiento</label>
                                <input type="date" id="txtFechaNac" runat="server" class="form-control" disabled />
                          </div>
                      </div>
                      <div class="form-group mb-3">
                          <div class="row">
                              <div class="col-md-4">
                                  <label for="dropTipoUsuario">Tipo de Usuario</label>
                                  <asp:DropDownList CssClass="form-control" Enabled="false" ID="dropTipoUsuario" runat="server" AutoPostBack="true" />
                              </div>
                              <div class="col-md-4">
                                <label for="txtNick">Username</label>
                                <asp:TextBox ID="txtNick" runat="server" Enabled="false" CssClass="form-control" AutoPostBack="true" OnTextChanged="onTextChanged" />
                              </div>
                              <div class="col-md-4">
                                <label for="txtPass">Contraseña</label>
                                <asp:TextBox ID="txtPass" runat="server" Enabled="false" CssClass="form-control" OnTextChanged="onTextChanged" />
                                <asp:Label ID="errorPass" CssClass="text-danger" runat="server" />   

                              </div>
                          </div>
                     </div>
                     <asp:Label ID="lblSuccess" visible="false" runat="server" CssClass="text-success"></asp:Label>
                     <asp:Label ID="lblError" visible="false" runat="server" CssClass="text-success"></asp:Label>
                </div>
            </form>
        </div>
        <div class="row mt-4 justify-content-center">
            <div class="col-md-4 text-center">
                <asp:Button ID="btnCancelar" CssClass="btn btn-secondary" onclick="btnCancelar_Click" Enabled="false" runat="server" Text="Cancelar" />
                <asp:Button ID="btnSubmit" CssClass="btn btn-primary" onclick="btnSubmit_Click" Enabled="false" runat="server" Text="Editar" />
                <asp:Button ID="btnContinue" CssClass="btn btn-primary" onclick="btnContinue_Click" visible="false" runat="server" Text="Continuar" />
            </div>
        </div>
    </div>
</asp:Content>
