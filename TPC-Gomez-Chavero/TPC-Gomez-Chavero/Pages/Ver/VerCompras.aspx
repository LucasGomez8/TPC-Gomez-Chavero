<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="VerCompras.aspx.cs" Inherits="TPC_Gomez_Chavero.Pages.Ver.VerCompras" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <link href="../../css/Vistas.css" rel="stylesheet" type="text/css" />
        <div class="container-xxl mt-4 viewStyle" data-aos="flip-up">
        <div class="row justify-content-center">
            <div class="col-md-12 text-center mt-3">
                <h2>Compras</h2>
            </div>
        </div>
        <div class="row justify-content-center mt-3">
            <div class="col-md-3 text-center">
                <asp:CheckBox  ID="chkOrdenarFactura" runat="server" AutoPostBack="true" Text="Ordenar por Nro Factura" OnCheckedChanged="chkOrdenarFactura_CheckedChanged"/>
            </div>
            <div class="col-md-3 text-center">
                <asp:CheckBox  ID="chkProveedor" runat="server" AutoPostBack="true" Text="Ordenar por Proveedor" OnCheckedChanged="chkProveedor_CheckedChanged"/>
            </div>
            <div class="col-md-3 text-center">
                <asp:CheckBox  ID="chkVendedor" runat="server" AutoPostBack="true" Text="Ordenar por Vendedor" OnCheckedChanged="chkVendedor_CheckedChanged"/>
            </div>
            <div class="col-md-3 text-center">
                <asp:CheckBox  ID="chkFecha" runat="server" AutoPostBack="true" Text="Ordenar por Fecha" OnCheckedChanged="chkFecha_CheckedChanged"/>
            </div>
        </div>
        <div class="row mt-3">
            <div class="col-md-4 ms-5" style="display:flex">
                <asp:TextBox ID="txtBuscar" runat="server" Width="72%" placeholder="Buscar por Numero Factura..." onkeydown="return (event.keyCode != 13);" CssClass="form-control me-2"></asp:TextBox>
                <asp:Button ID="btnBuscar" runat="server" Text="🔎" Width="25%" AutoPostBack="true" CssClass="btn btn-success" OnClick="btnBuscar_Click" />
            </div>
            <div class="col-md-6" id="colError" runat="server" visible="false">
                <asp:Label ID="lblErroBuscar" runat="server" CssClass="text-danger"></asp:Label>
            </div>
        </div>
        <div class="row mb-5 mt-5">
            <div class="col-md-12">
               <asp:GridView ID="dgvCompras" AllowPaging="true" OnPageIndexChanging="dgvCompras_PageIndexChanging1" runat="server" CssClass="table border-0" AutoGenerateColumns="false">
                   <Columns>
                       <asp:BoundField HeaderText="ID" DataField="ID" />
                       <asp:BoundField HeaderText="Numero Factura" DataField="NumeroFactura" />
                       <asp:BoundField HeaderText="Tipo Factura" DataField="TiposFactura.Descripcion" />
                       <asp:BoundField HeaderText="Vendedor" DataField="Usuario.Nick" />
                       <asp:BoundField HeaderText="Proveedor" DataField="Proveedor.Nombre" />
                       <asp:BoundField HeaderText="Producto" DataField="Producto.Nombre" />
                       <asp:BoundField HeaderText="Cantidad Comprada" DataField="CantidadComprada" />
                       <asp:BoundField HeaderText="Precio Unitario" DataField="PrecioUnitario" />
                       <asp:BoundField HeaderText="Monto Total" DataField="MontoTotal" />
                       <asp:BoundField HeaderText="Fecha de Venta" DataField="FechaVenta" />
                       <asp:BoundField HeaderText="Detalle de la Venta" DataField="Detalle" />
                   </Columns>
                  <PagerStyle CssClass="pagination" />
               </asp:GridView>
           </div>
        </div>
    </div>

</asp:Content>
