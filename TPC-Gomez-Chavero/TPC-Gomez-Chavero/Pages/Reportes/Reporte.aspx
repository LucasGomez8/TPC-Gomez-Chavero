<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Reporte.aspx.cs" Inherits="TPC_Gomez_Chavero.Pages.Reportes.Reporte" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-5">
        <div class="row">
            <div class="col-md-4">
                <label>Numero de Factura</label>
                <asp:Label ID="lblNumeroFactura" runat="server" Text="1111111111111"></asp:Label>
            </div>
            <div class="col-md-8 text-end">
                <asp:Label id="forlblFecha" runat="server" text="Fecha de :"></asp:Label>
                <asp:Label ID="lblFecha" runat="server" Text="5/7/2022"></asp:Label>
            </div>
        </div>
        <div class="row mt-3">
            <div class="col-md-4">
                <div class="row">
                    <div class="col-md-12 d-flex flex-column">
                        <label>Facturar a:</label>
                        <asp:Label ID="lblPersona" runat="server" Text="Lucas"></asp:Label>
                        <div class="col-md-12 d-flex flex-row">
                            <label>DNI o Cuit: </label>
                            <asp:Label ID="lblPersonaCuitDni" runat="server" Text=" 123123123"></asp:Label>
                        </div>
                        <div class="col-md-12 d-flex flex-row">
                            <label>Telefono: </label>
                            <asp:Label ID="lblPersonTelefono" runat="server" Text="15223684"></asp:Label>
                        </div>
                        <div class="col-md-12 d-flex flex-row">
                            <label>Email:</label>
                            <asp:Label ID="lblPersonaEmail" runat="server" Text="asdasd@test"></asp:Label>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-md-8 ms-auto text-end">
                <div class="row ms-auto">
                    <div class="col-md-12 d-flex flex-column">
                         <label>De :</label>
                        <div class="col-md-12">
                            <asp:Label ID="lblUsuarioNombre" runat="server" Text="Lucas"></asp:Label>
                            <asp:Label Id="lblUsuarioApellido" runat="server" Text="Gomez"></asp:Label>
                        </div>
                        <div class="col-md-12">
                            <label>DNI: </label>
                            <asp:Label ID="lblDNIUsuario" runat="server" Text=" 123123123"></asp:Label>
                        </div>
                        <div class="col-md-12">
                            <label>Cargo: </label>
                            <asp:Label ID="lblTipoUsuario" runat="server" Text="administrador"></asp:Label>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="row border mt-5">
            <div class="col-md-6">
                <label>Producto</label>
                <%foreach (domain.Product item in   lista) { %> 
                <div class="row">
                                        <label><%=item.Nombre %></label>
                </div>

                <% }%>
            </div>
            <div class="col-md-2">
                <label>Cantidad</label>
                   <%foreach (domain.Product item in lista) { %> 
                <div class="row">
                    <label><%=item.CantidadVenta %></label>
                </div>
                    
                <% }%>
            </div>
            <div class="col-md-2">
                <label>Precio Unitario</label>
                   <%foreach (domain.Product item in lista) { %> 
                <div class="row">
                                        <label><%=item.PU %></label>
                </div>

                <% }%>
            </div>
            <div class="col-md-2">
                <label>Total</label>
                   <%foreach (domain.Product item in lista) { %> 
                <div class="row">

                    <label><%=item.PU * item.CantidadVenta %></label>
                </div>
                <% }%>
            </div>
        </div>
        <div class="row mt-3 border">
            <div class="col-md-3  border-end">
                <label>Monto Total</label>
            </div>
            <div class="col-md-9 text-end">
                <asp:Label ID="lblMontoTotal" runat="server" Text="$$"></asp:Label>
            </div>
        </div>
        <div class="row mt-5 text-center">
            <div class="col-md-12">
                <asp:Button ID="btnVolverHome" runat="server" CssClass="btn btn-secondary" OnClick="btnVolverHome_Click" text="Volver Home" />
                <asp:Button ID="btnImprimir" runat="server" CssClass="btn btn-success" OnClientClick="javascript:window.print();" Text="Imprimir" />
            </div>
        </div>
    </div>

</asp:Content>
