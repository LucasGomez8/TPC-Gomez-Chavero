<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="VerUsuarios.aspx.cs" Inherits="TPC_Gomez_Chavero.Pages.Ver.VerUsuarios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <link href="../../css/Vistas.css" rel="stylesheet" type="text/css" />
        <div class="container-xxl mt-4 viewStyle" data-aos="flip-up">
        <div class="row justify-content-center">
            <div class="col-md-12 text-center mt-5">
                <h2>Usuarios</h2>
            </div>
        </div>
        <div class="row justify-content-center mt-3">
            <div class="col-md-3 text-center">
                <asp:CheckBox ID="chkApellido" runat="server" AutoPostBack="true" Text="Ordenar por Apellido" OnCheckedChanged="chkApellido_CheckedChanged" />
            </div>

            <div class="col-md-3 text-center">
                <asp:CheckBox ID="chkDni" runat="server" AutoPostBack="true" Text="Ordenar por DNI" OnCheckedChanged="chkDni_CheckedChanged" />
            </div>
            <div class="col-md-3 text-center">
                <asp:CheckBox ID="chkTipoUsuario" runat="server" AutoPostBack="true" Text="Ordenar por Tipo Usuario" OnCheckedChanged="chkTipoUsuario_CheckedChanged" />
            </div>
            <div class="col-md-3 text-center">
                <asp:CheckBox ID="chkUsername" runat="server" AutoPostBack="true" Text="Ordenar por Username" OnCheckedChanged="chkUsername_CheckedChanged" />
            </div>
        </div>
        <div class="row mt-3">
            <div class="col-md-4 ms-5" style="display:flex">
                <asp:TextBox ID="txtBuscar" runat="server" Width="72%" placeholder="Buscar por Numero DNI..." onkeydown="return (event.keyCode != 13);" CssClass="form-control me-2"></asp:TextBox>
                <asp:Button ID="btnBuscar" runat="server" Text="🔎" Width="25%" AutoPostBack="true" CssClass="btn btn-success" OnClick="btnBuscar_Click" />
            </div>
            <div class="col-md-6" id="colError" runat="server" visible="false">
                <asp:Label ID="lblErroBuscar" runat="server" CssClass="text-danger"></asp:Label>
            </div>
        </div>
        <div class="row mt-4 mb-5">
            <div class="col-md-12 mb-5">
               <asp:GridView ID="dgvUsuarios" runat="server" AllowPaging="true" OnPageIndexChanging="dgvUsuarios_PageIndexChanging" CssClass="table border-0" OnSelectedIndexChanged="dgvUsuarios_SelectedIndexChanged" AutoGenerateColumns="false">
                   <Columns>
                       <asp:BoundField HeaderText="ID" DataField="ID" />
                       <asp:BoundField HeaderText="Apellido" DataField="Apellido" />
                       <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                       <asp:BoundField HeaderText="Dni" DataField="DNI" />
                       <asp:BoundField HeaderText="Tipo de Usuario" DataField="Type.Description" />
                       <asp:BoundField HeaderText="Username" DataField="Nick" />
                       <asp:CheckBoxField HeaderText="Activo" DataField="Estado" />
                       <asp:CommandField HeaderText="Acciones" SelectText="📝" ShowSelectButton="true" />
                   </Columns>
                   <PagerStyle CssClass="pagination" />
               </asp:GridView>
                            </div>
            </div>
    </div>

</asp:Content>
