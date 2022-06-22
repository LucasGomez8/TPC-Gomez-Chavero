<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditarProveedor.aspx.cs" Inherits="TPC_Gomez_Chavero.Pages.Modificaciones.EditarProveedor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <link href="../../css/AñadirProducto.css" rel="stylesheet" type="text/css"/>
    <div class="container mb-4 frmStyle">
        <div class="row mt-3 justify-content-center">
            <div class="col-md-8  text-center">
                <h3>Modificacion de datos de Proveedor</h3>
            </div>
        </div>
        <div class="row mb-3">
            <form>
                <div class="col-md-4">
                    <div class="form-group">
                        <label for="dropMarca">Selecciona el Proveedor</label>
                        <asp:DropDownList cssClass="form-control" ID="dropProveedor" runat="server" AutoPostBack="true"></asp:DropDownList>
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
                        <label for="txtPNombre">Nombre de Proveedor</label>
                        <asp:TextBox ID="txtPNombre" runat="server" Enabled="false" CssClass="form-control" AutoPostBack="true" />
                        <asp:Label ID="lblSuccess" runat="server" Visible="false" />
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
