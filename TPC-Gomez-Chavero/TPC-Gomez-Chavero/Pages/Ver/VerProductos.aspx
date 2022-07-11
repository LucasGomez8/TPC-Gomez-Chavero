<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="VerProductos.aspx.cs" Inherits="TPC_Gomez_Chavero.Pages.Ver.VerProductos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <link href="../../css/Vistas.css" rel="stylesheet" type="text/css" />
    <div class="container-xxl mt-4 viewStyle" data-aos="flip-up">
        <div class="row justify-content-center">
            <div class="col-md-12 text-center mt-3">
                <h2>Productos</h2>
            </div>
        </div>
        <div class="row justify-content-center mt-3">
            <div class="col-md-3">
                <asp:CheckBox ID="chkNombre" runat="server" AutoPostBack="true" Text="Ordenar por Nombre" OnCheckedChanged="chkNombre_CheckedChanged" />
            </div>
            <div class="col-md-3">
                <asp:CheckBox ID="chkCategoria" runat="server" AutoPostBack="true" Text="Ordenar por Categoria" OnCheckedChanged="chkCategoria_CheckedChanged" />
            </div>
            <div class="col-md-3">
                <asp:CheckBox ID="chkMarca" runat="server" AutoPostBack="true" Text="Ordenar por Marca" OnCheckedChanged="chkMarca_CheckedChanged" />
            </div>
            <div class="col-md-3">
                <asp:CheckBox ID="chkTipo" runat="server" AutoPostBack="true" text="Ordenar por Tipo Producto" OnCheckedChanged="chkTipo_CheckedChanged" />
            </div>
              <div class="col-md-3">
                <asp:CheckBox ID="chkPorcentajeGanancia text-center" runat="server" AutoPostBack="true" text="Ordenar por Porcentaje Ganancia" OnCheckedChanged="chkPorcentajeGanancia_CheckedChanged" />
            </div>
        </div>
        <div class="row mt-3">
            <div class="col-md-4 ms-5" style="display:flex">
                <asp:TextBox ID="txtBuscar" runat="server" Width="72%" placeholder="Buscar por Nombre..." onkeydown="return (event.keyCode != 13);" CssClass="form-control me-2"></asp:TextBox>
                <asp:Button ID="btnBuscar" runat="server" Text="🔎" Width="25%" AutoPostBack="true" CssClass="btn btn-success" OnClick="btnBuscar_Click" />
            </div>
            <div class="col-md-6" id="colError" runat="server" visible="false">
                <asp:Label ID="lblErroBuscar" runat="server" CssClass="text-danger"></asp:Label>
            </div>
        </div>
        <div class="row mt-3 mb-5">
            <div class="col-md-12 mb-5">
               <asp:GridView ID="dgvProductos" runat="server" AllowPaging="true" CssClass="table border-0" OnPageIndexChanging="dgvProductos_PageIndexChanging" OnSelectedIndexChanged="dgvProductos_SelectedIndexChanged" AutoGenerateColumns="false">
                   <Columns>
                       <asp:BoundField HeaderText="ID" DataField="ID" />
                       <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                       <asp:BoundField HeaderText="Descripcion" DataField="Descripcion" />
                       <asp:BoundField HeaderText="Categoria" DataField="Categoria.Descripcion" />
                       <asp:BoundField HeaderText="Marca" DataField="Marca.Descripcion" />
                       <asp:BoundField HeaderText="Tipo de Producto" DataField="Tipo.Descripcion" />
                       <asp:BoundField HeaderText="Stock" DataField="Stock" />
                       <asp:BoundField HeaderText="Stock Minimo" DataField="StockMinimo" />
                       <asp:BoundField HeaderText="Porcentaje de Ganancia" DataField="PorcentajeVenta" />
                       <asp:CheckBoxField HeaderText="Activo" DataField="Estado"/>
                       
                       <asp:CommandField ShowSelectButton="true" SelectText="📝" HeaderText="Acciones" />
                   </Columns>
                  <PagerStyle CssClass="pagination" />
               </asp:GridView>
                <asp:GridView ID="dgvProductosEmployee" runat="server" AllowPaging="true" CssClass="table border-0" OnPageIndexChanging="dgvProductosEmployee_PageIndexChanging" AutoGenerateColumns="false">
                   <Columns>
                       <asp:BoundField HeaderText="ID" DataField="ID" />
                       <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                       <asp:BoundField HeaderText="Descripcion" DataField="Descripcion" />
                       <asp:BoundField HeaderText="Categoria" DataField="Categoria.Descripcion" />
                       <asp:BoundField HeaderText="Marca" DataField="Marca.Descripcion" />
                       <asp:BoundField HeaderText="Tipo de Producto" DataField="Tipo.Descripcion" />
                       <asp:BoundField HeaderText="Stock" DataField="Stock" />
                       <asp:BoundField HeaderText="Stock Minimo" DataField="StockMinimo" />
                       <asp:BoundField HeaderText="Porcentaje de Ganancia" DataField="PorcentajeVenta" />
                       <asp:CheckBoxField HeaderText="Activo" DataField="Estado"/>
                   </Columns>
                  <PagerStyle CssClass="pagination" />
               </asp:GridView>
           </div>
       </div>
    </div>
</asp:Content>
