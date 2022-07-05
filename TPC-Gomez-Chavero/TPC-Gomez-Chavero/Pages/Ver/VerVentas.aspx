<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="VerVentas.aspx.cs" Inherits="TPC_Gomez_Chavero.Pages.Ver.VerVentas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-xxl mt-4" data-aos="fade-up">
        <div class="row justify-content-center">
            <div class="col-md-12 text-center">
                <h2>Ventas</h2>
            </div>
        </div>
        <div class="row">
            <div class="col-md-12">
               <asp:GridView ID="dgvVentas" runat="server" CssClass="table border-0" OnSelectedIndexChanged="dgvVentas_SelectedIndexChanged" AutoGenerateColumns="false">
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
               </asp:GridView>
                            </div>
            </div>
    </div>

</asp:Content>
