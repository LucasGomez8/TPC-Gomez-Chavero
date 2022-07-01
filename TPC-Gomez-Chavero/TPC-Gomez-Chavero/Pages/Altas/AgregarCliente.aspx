<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AgregarCliente.aspx.cs" Inherits="TPC_Gomez_Chavero.Pages.Altas.AgregarCliente" %>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="../../css/AñadirProducto.css" rel="stylesheet" type="text/css"/>
    <div class="container frmStyle">
        <div class="row mt-3">
            <div class="col-md-12 text-center">
                <h3>Clientes</h3>
            </div>
        </div>
        <div class="row mt-5">
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
                    <asp:Button ID="btnSubmit" cssClass="btn btn-primary" OnClick="btnSubmit_Click" runat="server" Text="Agregar" Enabled="false" />
                    <asp:Button ID="btnReload" cssClass="btn btn-primary" OnClick="btnReload_Click" runat="server" Text="Continuar" Visible="false" />
                    <asp:Button ID="btnReturn" cssClass="btn btn-primary" OnClick="btnReturn_Click" runat="server" Visible="false" Text="Agregar y Volver" Enabled="false" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
