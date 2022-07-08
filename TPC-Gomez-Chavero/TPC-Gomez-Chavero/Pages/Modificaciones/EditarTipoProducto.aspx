<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditarTipoProducto.aspx.cs" Inherits="TPC_Gomez_Chavero.Pages.Modificaciones.EditarTipoProducto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
             <link href="../../css/Modificacion.css" rel="stylesheet" type="text/css"/>
    <div class="container mb-4 modifStyle">
         <div class="row mt-3 justify-content-center">
            <div class="col-md-8  text-center">
                <h3>Modificacion de datos de Tipo de Producto</h3>
            </div>
        </div>
        <div class="row mb-3">
            <form>
                <div class="col-md-4">
                    <div class="form-group">
                        <label for="dropMarca">Selecciona la Marca</label>
                        <asp:DropDownList cssClass="form-control" ID="dropTipo" runat="server"></asp:DropDownList>
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
                        <label for="txtNTipo">Nombre de Categoria</label>
                        <asp:TextBox ID="txtNTipo" runat="server" Enabled="false" CssClass="form-control" onkeydown="return (event.keyCode != 13);"></asp:TextBox>
                    </div>
                </div>
            </form>
        <div class="row mt-4 justify-content-center">
            <div class="col-md-4 text-center">
                <asp:Button ID="btnSubmit" CssClass="btn btn-primary" onclick="btnSubmit_Click" Enabled="false" runat="server" Text="Editar" />
                <asp:Button ID="Button1" CssClass="btn btn-primary" onclick="btnSubmit_Click" Enabled="false" runat="server" Text="Editar" />
            </div>
        </div>
    </div>
    </div>
</asp:Content>
