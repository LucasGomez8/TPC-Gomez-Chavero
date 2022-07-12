<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="VerClientes.aspx.cs" Inherits="TPC_Gomez_Chavero.Pages.Ver.VerClientes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <link href="../../css/Vistas.css" rel="stylesheet" type="text/css" />
        <div class="container-xxl mt-4 viewStyle" data-aos="flip-up">
        <div class="row justify-content-center mt-5">
            <div class="col-md-12 text-center mt-5">
                <h2>Clientes</h2>
            </div>
        </div>
        <div class="row justify-content-center mt-3">
            <div class="col-md-4">
                <asp:CheckBox ID="chkOrdenarNombre" runat="server" text=" Ordenar por Nombre" AutoPostBack="true" OnCheckedChanged="chkOrdenarNombre_CheckedChanged" />
            </div>
            <div class="col-md-4">
                <asp:CheckBox ID="chkCuitOrDni" runat="server" Text=" Ordenar por DNI/Cuit" AutoPostBack="true" OnCheckedChanged="chkCuitOrDni_CheckedChanged" />
            </div>
        </div>
        <div class="row mt-3">
            <div class="col-md-4 ms-5" style="display:flex">
                <asp:TextBox ID="txtBuscar" runat="server" Width="72%" placeholder="Buscar por CUIT/DNI..." onkeydown="return (event.keyCode != 13);" CssClass="form-control me-2"></asp:TextBox>
                <asp:Button ID="btnBuscar" runat="server" Text="🔎" Width="25%" AutoPostBack="true" CssClass="btn btn-success" OnClick="btnBuscar_Click" />
            </div>
            <div class="col-md-6" id="colError" runat="server" visible="false">
                <asp:Label ID="lblErroBuscar" runat="server" CssClass="text-danger"></asp:Label>
            </div>
        </div>
        <div class="row mt-3 mb-5">
            <div class="col-md-12 mb-5">
               <asp:GridView ID="dgvClientes" runat="server" CssClass="table border-0" AllowPaging="true" OnPageIndexChanging="dgvClientes_PageIndexChanging" OnSelectedIndexChanged="dgvClientes_SelectedIndexChanged" AutoGenerateColumns="false">
                   <Columns>
                       <asp:BoundField HeaderText="ID" DataField="ID" />
                       <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                       <asp:BoundField HeaderText="Cuit o DNI" DataField="CuitOrDni" />
                       <asp:BoundField HeaderText="Fecha Nacimiento" DataField="fechaNac" DataFormatString="{0:dd/MM/yyyy}" />
                       <asp:BoundField HeaderText="Telefono" DataField="Telefono" />
                       <asp:BoundField HeaderText="Email" DataField="Email" />
                       <asp:CheckBoxField HeaderText="Activo" DataField="Estado" />
                       <asp:CommandField ShowSelectButton="true" SelectText="📝" HeaderText="Acciones" />
                   </Columns>
                   <PagerStyle CssClass="pagination" />
               </asp:GridView>

                 <asp:GridView ID="dgvClientesEmployee" runat="server" CssClass="table border-0" AllowPaging="true" OnPageIndexChanging="dgvClientesEmployee_PageIndexChanging" AutoGenerateColumns="false">
                   <Columns>
                       <asp:BoundField HeaderText="ID" DataField="ID" />
                       <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                       <asp:BoundField HeaderText="Cuit o DNI" DataField="CuitOrDni" />
                       <asp:BoundField HeaderText="Fecha Nacimiento" DataField="fechaNac" DataFormatString="{0:dd/MM/yyyy}"/>
                       <asp:BoundField HeaderText="Telefono" DataField="Telefono" />
                       <asp:BoundField HeaderText="Email" DataField="Email" />
                       <asp:CheckBoxField HeaderText="Activo" DataField="Estado" />
                   </Columns>
                   <PagerStyle CssClass="pagination" />
               </asp:GridView>
               </div>
            </div>
    </div>

</asp:Content>
