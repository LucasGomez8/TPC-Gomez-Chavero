<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TPC_Gomez_Chavero.Default" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="/css/Default.css" type="text/css" rel="stylesheet" />
    <div class="container">
        <div class="row">
            <div class="col-md-12 text-center mt-5">
                <h3>Bienvenido a tu centro de Control de ventas</h3>
            </div>
        </div>
        <div class="col-md-12 mt-5 text-center">
            <asp:Label ID="lblBienvenida" runat="server"></asp:Label>
        </div>
        <div class="row mt-5" id="adminSession" runat="server">
            <div class="col-md-3 item">
                <a href="/Pages/MisCompras.aspx">
                <h3>Gestiona Tus Compras</h3>
                    <p>Aqui podras gestionar tus compras</p>
                </a>
            </div>
            <div class="col-md-3 item">
                <a href="/Pages/MisVentas.aspx">
                <h3>Gestiona Tus Ventas</h3>
                    <p>Aqui podras gestionar tus ventas</p>
                </a>
            </div>
            <div class="col-md-3 item">
                <a href="/Pages/Altas/AgregarVendedor.aspx">
                <h3>Dar de Alta un usuario</h3>
                    <p>Aqui podras dar de alta a los usuarios correspondientes</p>
                </a>
            </div>
            <div class="col-md-3 item">
                <a href="/Pages/Altas/Productos.aspx">
                <h3>Dar de Alta un Producto</h3>
                    <p>Aqui podras dar de alta a los Productos correspondientes</p>
                </a>
            </div>
        </div>
    </div>
</asp:Content>
