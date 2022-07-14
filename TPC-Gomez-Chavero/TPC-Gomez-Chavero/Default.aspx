<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TPC_Gomez_Chavero.Default" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="/css/Default.css" type="text/css" rel="stylesheet" />
    <div class="container" data-aos="fade-up" data-aos-anchor-placement="center-center">
        <div class="row">
            <div class="col-md-12 text-center mt-5">
                <h3 class="titulo">Bienvenido a tu App Web</h3>
            </div>
        </div>
        <div class="col-md-12 mt-5 text-center">
            <asp:Label ID="lblBienvenida" runat="server"></asp:Label>
        </div>


        <div class="row mt-5" id="adminSession" runat="server">
            <div class="col-sm-2 col-md-3 item" style="background-image: url('/Assets/img/compras.jpg'); background-size:cover;">
                <a href="/Pages/Compras/MisCompras.aspx" class="itemContent">
                <h3>Gestiona Tus Compras</h3>
                    <p>Aqui podras gestionar tus compras</p>
                </a>
            </div>
            <div class="col-sm-2 col-md-3 item" style="background-image: url('/Assets/img/ventas.jpg'); background-size:cover;">
                <a href="/Pages/Ventas/MisVentas.aspx" class="itemContent">
                <h3>Gestiona Tus Ventas</h3>
                    <p>Aqui podras gestionar tus ventas</p>
                </a>
            </div>
            <div class="col-sm-2 col-md-3 item" style="background-image: url('/Assets/img/adrUsuarioContent.jpg'); background-size: cover;">
                <a href="/Pages/Altas/AgregarUsuario.aspx" class="itemContent">
                <h3>Dar de Alta un usuario</h3>
                    <p>Aqui podras dar de alta a los usuarios correspondientes</p>
                </a>
            </div>
            <div class="col-md-3 item" style="background-image: url('/Assets/img/productos.jpg'); background-size:cover;">
                <a href="/Pages/Altas/Productos.aspx" class="itemContent">
                <h3>Dar de Alta un Producto</h3>
                    <p>Aqui podras dar de alta a los Productos correspondientes</p>
                </a>
            </div>
        </div>

         <div class="row mt-5" id="employeeSession" runat="server" visible="false">
            <div class="col-sm-2 col-md-3 item" style="background-image: url('/Assets/img/productos.jpg'); background-size:cover;">
                <a href="/Pages/Ver/VerProductos.aspx" class="itemContent">
                <h3>Chequea tus productos</h3>
                    <p>Aqui vas a poder visualizar la cantidad de productos que usted posee y los que se encuentran disponibles, ademas de si se encuentra activo o no</p>
                </a>
            </div>
            <div class="col-sm-2 col-md-3 item" style="background-image: url('/Assets/img/ventas.jpg'); background-size:cover;">
                <a href="/Pages/Ventas/MisVentas.aspx" class="itemContent">
                <h3>Realiza ventas</h3>
                    <p>En esta seccion podra realizar las ventas correspondientes</p>
                </a>
            </div>
            <div class="col-sm-2 col-md-3 item" style="background-image: url('/Assets/img/adrUsuarioContent.jpg'); background-size: cover;">
                <a href="/Pages/Altas/AgregarCliente.aspx" class="itemContent">
                <h3>Ver Clientes</h3>
                    <p>En esta seccion podras visualizar los clientes que se encuentran dados de alta en el sistema</p>
                </a>
            </div>
            <div class="col-sm-2 col-md-3 item" style="background-image: url('/Assets/img/verventas.jpg'); background-size:cover;">
                <a href="/Pages/Ver/VerVentas.aspx" class="itemContent">
                <h3>Ver Ventas</h3>
                    <p>Aqui podras visualizar las ventas que se han realizado y ver sus correspondientes facturas</p>
                </a>
            </div>
        </div>
    </div>
</asp:Content>
