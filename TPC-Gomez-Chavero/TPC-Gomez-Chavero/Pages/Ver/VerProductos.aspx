<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="VerProductos.aspx.cs" Inherits="TPC_Gomez_Chavero.Pages.Ver.VerProductos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <link href="../../css/Vistas.css" rel="stylesheet" type="text/css" />
    <div class="container-xxl mt-4 viewStyle" data-aos="flip-up">
        <div class="row justify-content-center">
            <div class="col-md-12 text-center mt-3">
                <h2>Productos</h2>
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
           </div>
       </div>
    </div>
</asp:Content>
