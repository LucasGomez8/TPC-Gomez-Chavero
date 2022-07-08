<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AgregarCategoria.aspx.cs" Inherits="TPC_Gomez_Chavero.Pages.Altas.AgregarCategoria" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="../../css/AñadirProducto.css" rel="stylesheet" type="text/css"/>
    <div class="container frmStyle" data-aos="fade-up">
        <div class="row mt-3 mb-3 justify-content-center">
            <div class="col-md-8  text-center">
                <h3>Alta Categorias</h3>
            </div>
        </div>

        <div class="row justify-content-center mt-5 mb-3" runat="server" id="menu">
            <div class="col-md-6 text-center">
                <asp:Button ID="btnNuevaCategoria" runat="server" CssClass="btn btn-primary" OnClick="btnNuevaCategoria_Click" Text="Nuevo" />
            </div>
            <div class="col-md-6 text-center">
                <asp:Button ID="btnViejaCategoria" runat="server" CssClass="btn btn-warning" OnClick="btnViejaCategoria_Click" Text="Dado de Baja" />
            </div>
        </div>

        <div class="row mt-5 mb-5 justify-content-center" runat="server" id="nuevaCategoria" visible="false">
            <form class="frmStyle">
                <div class="col-md-6">
                    <div class="form-group mb-3">
                        <label for="txtNombre">Nombre de Categoria</label>
                        <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control"></asp:TextBox>
                        <asp:Label ID="lblSuccess" runat="server" />
                    </div>
                </div>
                <div class="row justify-content-center">
                    <div class="col-md-4 text-center">
                        <asp:Button ID="btnSubmit" runat="server" Text="Agregar" OnClick="btnSubmit_Click" CssClass="btn btn-primary" />
                        <asp:Button ID="btnReload" runat="server" Text="Continuar" CssClass="btn btn-primary" OnClick="btnReload_Click" />
                    </div>
                </div>
            </form>
        </div>

        <div class="row justify-content-center" runat="server" visible="false" id="debaja">
            <div class="col-md-4">
                <div class="form-group">
                    <label for="deleteType">Selecciona la Categoria a volver a dar el alta</label>
                    <asp:DropDownList cssClass="form-control" ID="dropElimnacionFisica" runat="server"></asp:DropDownList>
                </div>
            </div>
            <div class="col-md-4 mt-4">
                <asp:Button ID="btnOk" CssClass="btn btn-primary" onclick="btnOk_Click" runat="server" Text="Dar de Alta" />
            </div>
            <div class="row justify-content-center mt-4">
                <div class="col-md-12 text-center">
                    <asp:Label ID="lblSucessBaja" runat="server" CssClass="text-success" Visible="false"></asp:Label>
                </div>
            </div>
            <div class="col-md-4 mt-4 text-center">
                <asp:Button ID="btnVolverBaja" runat="server" CssClass="btn btn-secondary" onClick="btnVolverBaja_Click" Enabled="true" Text="Volver" />
                <asp:Button ID="btnContinuarBaja" runat="server" CssClass="btn btn-primary" onClick="btnContinuarBaja_Click" Enabled="false" Text="Continuar" />
            </div>
        </div>
    </div>
</asp:Content>
