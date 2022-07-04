<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="VerUsuarios.aspx.cs" Inherits="TPC_Gomez_Chavero.Pages.Ver.VerUsuarios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

        <div class="container-xxl mt-4" data-aos="fade-up">
        <div class="row justify-content-center">
            <div class="col-md-12 text-center">
                <h2>Usuarios</h2>
            </div>
        </div>
        <div class="row">
            <div class="col-md-12">
               <asp:GridView ID="dgvUsuarios" runat="server" CssClass="table border-0" OnSelectedIndexChanged="dgvUsuarios_SelectedIndexChanged" AutoGenerateColumns="false">
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
               </asp:GridView>
                            </div>
            </div>
    </div>

</asp:Content>
