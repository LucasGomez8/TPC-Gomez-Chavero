﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="VerVentas.aspx.cs" Inherits="TPC_Gomez_Chavero.Pages.Ver.VerVentas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    
    <link href="../../css/Vistas.css" rel="stylesheet" type="text/css" />

    <div class="container-xxl mt-4 viewStyle" data-aos="flip-up">
        <div class="row justify-content-center mt-4">
            <div class="col-md-12 text-center mt-4">
                <h2>Ventas</h2>
            </div>
        </div>
        <div class="row mt-4 mb-5">
            <div class="col-md-12 mb-5">
               <asp:GridView ID="dgvVentas" runat="server" CssClass="table border-0" AllowPaging="true" OnPageIndexChanging="dgvVentas_PageIndexChanging" OnSelectedIndexChanged="dgvVentas_SelectedIndexChanged" AutoGenerateColumns="false">
                   <Columns>
                       <asp:BoundField HeaderText="ID" DataField="ID" />
                       <asp:BoundField HeaderText="Numero Factura" DataField="NumeroFactura" />
                       <asp:BoundField HeaderText="Tipo Factura" DataField="TiposFactura.Descripcion" />
                       <asp:BoundField HeaderText="Vendedor" DataField="Vendedor.Nick" />
                       <asp:BoundField HeaderText="Cliente" DataField="Cliente.Nombre" />
                       <asp:BoundField HeaderText="Producto" DataField="Producto.Nombre" />
                       <asp:BoundField HeaderText="Cantidad Vendida" DataField="CantidadVendida" />
                       <asp:BoundField HeaderText="Precio Unitario" DataField="PrecioUnitario" />
                       <asp:BoundField HeaderText="Monto Total" DataField="MontoTotal" />
                       <asp:BoundField HeaderText="Fecha de Venta" DataField="FechaVenta" />
                       <asp:BoundField HeaderText="Detalle de la Venta" DataField="Detalle" />
                       <asp:CommandField HeaderText="Reporte" ShowSelectButton="true" SelectText="Ver Reporte" />
                   </Columns>
                           <PagerStyle CssClass="pagination" />
               </asp:GridView>
                            </div>
            </div>
    </div>

</asp:Content>
