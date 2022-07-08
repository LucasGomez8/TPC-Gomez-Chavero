<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AgregarCliente.aspx.cs" Inherits="TPC_Gomez_Chavero.Pages.Altas.AgregarCliente" %>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="../../css/AñadirProducto.css" rel="stylesheet" type="text/css"/>
    <div class="container frmStyle">
        <div class="row mt-3">
            <div class="col-md-12 text-center">
                <h3>Alta Clientes</h3>
            </div>
        </div>

      <div class="row justify-content-center mt-5 mb-3" runat="server" id="menu">
          <div class="col-md-6 text-center">
              <asp:Button ID="btnNuevoCliente" runat="server" CssClass="btn btn-primary" OnClick="btnNuevoCliente_Click" Text="Nuevo" />
          </div>
          <div class="col-md-6 text-center">
              <asp:Button ID="btnViejoCliente" runat="server" CssClass="btn btn-warning" OnClick="btnViejoCliente_Click" Text="Dado de Baja" />
          </div>
      </div>

        <div class="row mt-5" runat="server" id="NuevoCliente" visible="false">
            <form>
                <div class="form-group mb-3">
                    <div class="row">
                        <div class="col-md-6">
                            <label for="nombreCliente">Nombre</label>
                            <asp:TextBox ID="txtNombreCliente" CssClass="form-control" runat="server" AutoPostBack="true" />
                            <asp:Label CssClass="text-danger" runat="server" />
                        </div>
                        <div class="col-md-6">
                            <label for="dni">DNI o CUIT</label>
                            <asp:TextBox ID="txtDNIorCuit" cssClass="form-control" runat="server" AutoPostBack="true" OnTextChanged="onTextChanged" />
                            <asp:Label ID="errorDNIorCuit" CssClass="text-danger" runat="server" />
                        </div>
                    </div>
                </div>
                <div class="form-group mb-3">
                    <div class="row">
                        <div class="col-md-4">
                            <label for="fechaNac">Fecha de Nacimiento</label>
                            <input type="date" id="txtFechaNac" runat="server" class="form-control" />
                            <asp:Label ID="errorBornDate" CssClass="text-danger" runat="server" />
                        </div>
                        <div class="col-md-4">
                            <label for="email">Email</label>
                            <asp:TextBox ID="txtEmail" CssClass="form-control" runat="server" AutoPostBack="true" OnTextChanged="onTextChanged" />
                            <asp:Label ID="errorEmail" CssClass="text-danger" runat="server" />
                        </div>
                        <div class="col-md-4">
                            <label for="telefono">Telefono</label>
                            <asp:TextBox ID="txtTelefono" CssClass="form-control" runat="server" AutoPostBack="true" OnTextChanged="onTextChanged" />
                            <asp:Label ID="errorTelefono" CssClass="text-danger" runat="server" />
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
                    <asp:Button ID="btnVolver2" runat="server" CssClass="btn btn-secondary" onClick="btnVolver2_Click" Enabled="true" Text="Volver" />
                    <asp:Button ID="btnSubmit" cssClass="btn btn-primary" OnClick="btnSubmit_Click" runat="server" Text="Agregar" Enabled="false" />
                    <asp:Button ID="btnReload" cssClass="btn btn-primary" OnClick="btnReload_Click" runat="server" Text="Continuar" Visible="false" />
                    <asp:Button ID="btnReturn" cssClass="btn btn-primary" OnClick="btnReturn_Click" runat="server" Visible="false" Text="Agregar y Volver" Enabled="false" />
                </div>
            </div>
        </div>
                
        <div class="row justify-content-center" runat="server" visible="false" id="debaja">
            <div class="col-md-4">
                <div class="form-group">
                    <label for="deleteType">Selecciona el Cliente a volver a dar el alta</label>
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
                <asp:Button ID="btnVolverBaja" runat="server" CssClass="btn btn-secondary" onClick="btnVolver_Click" Enabled="true" Text="Volver" />
                <asp:Button ID="btnContinuarBaja" runat="server" CssClass="btn btn-primary" onClick="btnContinue_Click" Enabled="false" Text="Continuar" />
            </div>
        </div>
    </div>
</asp:Content>
