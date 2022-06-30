<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="VerProveedores.aspx.cs" Inherits="TPC_Gomez_Chavero.Pages.Ver.VerProveedores" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

        <div class="container-xxl mt-4" data-aos="fade-up">
        <div class="row justify-content-center">
            <div class="col-md-12 text-center">
                <h2>Proveedores</h2>
            </div>
        </div>
        <div class="row">
            <div class="col-md-12">
               <asp:GridView ID="dgvProveedores" runat="server" CssClass="table border-0" AutoGenerateColumns="false">
                   <Columns>
                       <asp:BoundField HeaderText="ID" DataField="ID" />
                       <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                       <asp:HyperLinkField text="Eliminar" />
                       <asp:HyperLinkField text="Editar" />
                   </Columns>
               </asp:GridView>
                            </div>
            </div>
    </div>

</asp:Content>
