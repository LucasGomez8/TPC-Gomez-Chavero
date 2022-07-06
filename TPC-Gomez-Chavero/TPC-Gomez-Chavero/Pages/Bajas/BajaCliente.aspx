<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BajaCliente.aspx.cs" Inherits="TPC_Gomez_Chavero.Pages.Bajas.BajaCliente" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <link href="../../css/Bajas.css" rel="stylesheet" type="text/css" />
    <div class="container bajStyle">
        <div class="row mt-3 justify-content-center">
            <div class="col-md-8 text-center">
                <h3>Baja Cliente</h3>
            </div>
        </div>
        <div class="row mt-5 mb-5 justify-content-center">
            <form>
                <div class="col-md-4">
                    <div class="form-group">
                        <label for="deleteClient">Selecciona el Cliente a Eliminar</label>
                        <asp:DropDownList cssClass="form-control" ID="deleteClient" runat="server"></asp:DropDownList>
                        <asp:Label runat="server" ID="lblSuccess" />
                    </div>
                </div>
                <div class="col-md-4 mt-4">
                    <asp:Button ID="btnSubmit" CssClass="btn btn-primary" onClick="btnSubmit_Click" runat="server" Text="Eliminar" />
                </div>
            </form>
        </div>
    </div>

</asp:Content>
