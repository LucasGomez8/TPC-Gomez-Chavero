<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="VerProductos.aspx.cs" Inherits="TPC_Gomez_Chavero.Pages.Ver.VerProductos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-xxl mt-4" data-aos="fade-up">
        <div class="row justify-content-center">
            <div class="col-md-12 text-center">
                <h2>Productos</h2>
            </div>
        </div>
        <div class="row">
            <div class="col-md-12">
               <asp:GridView ID="dgvProductos" runat="server" CssClass="table border-0" OnPageIndexChanging="dgvProductos_PageIndexChanging" OnSelectedIndexChanged="dgvProductos_SelectedIndexChanged" AutoGenerateColumns="false" AllowPaging="True">
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
               </asp:GridView>
           </div>
       </div>
    </div>
</asp:Content>
