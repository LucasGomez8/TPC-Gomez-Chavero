<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BajaUsuario.aspx.cs" Inherits="TPC_Gomez_Chavero.Pages.Bajas.BajaUsuario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

          <div class="container">
        <div class="row mt-3 justify-content-center">
            <div class="col-md-8 text-center">
                <h3>Baja Producto</h3>
            </div>
        </div>
        <div class="row mt-5 mb-5 justify-content-center">
            <form>
                <div class="col-md-4">
                    <div class="form-group">
                        <label for="deleteUser">Selecciona el usuario a eliminar</label>
                        <asp:DropDownList cssClass="form-control" ID="deleteUser" runat="server"></asp:DropDownList>
                    </div>
                </div>
                <div class="col-md-4">
                    <asp:Button ID="btnSubmit" CssClass="btn btn-primary" onclick="btnSubmit_Click" runat="server" Text="Eliminar" />
                </div>
            </form>
        </div>
    </div>
</asp:Content>
