<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AgregarTipoProducto.aspx.cs" Inherits="TPC_Gomez_Chavero.Pages.Altas.AgregarTipoProducto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <div class="container frmStyle">
        <div class="row mt-3 justify-content-center">
            <div class="col-md-8  text-center">
                <h3>Alta Tipo de Productos</h3>
            </div>
        </div>
        <div class="row mt-5 mb-5 justify-content-center">
            <form class="frmStyle">
                <div class="col-md-6">
                    <div class="form-group mb-3">
                        <label for="txtNombre">Tipo de Producto</label>
                        <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
                <div class="row justify-content-center">
                    <div class="col-md-4 text-center">
                    <asp:Button ID="btnSubmit" runat="server" Text="Agregar" OnClick="btnSubmit_Click" CssClass="btn btn-primary" />
                    </div>
                </div>
            </form>
        </div>
    </div>
</asp:Content>
