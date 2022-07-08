<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BajaProveedor.aspx.cs" Inherits="TPC_Gomez_Chavero.Pages.Bajas.BajaProveedor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <link href="../../css/Bajas.css" rel="stylesheet" type="text/css" />
     <div class="container bajStyle" data-aos="flip-down">
        <div class="row mt-3 justify-content-center">
            <div class="col-md-8 text-center">
                <h3>Baja Proveedor</h3>
            </div>
        </div>
        <div class="row mt-5 mb-5 justify-content-center">
            <form>
                <div class="col-md-4">
                    <div class="form-group">
                        <label for="deleteProvider">Selecciona el proveedor a eliminar</label>
                        <asp:DropDownList cssClass="form-control" ID="deleteProvider" runat="server"></asp:DropDownList>
                        <asp:Label runat="server" ID="lblSuccess" />
                    </div>
                </div>
                <div class="col-md-4 mt-4">
                    <asp:Button ID="btnSubmit" CssClass="btn btn-primary" onclick="btnSubmit_Click" runat="server" Text="Eliminar" />
                    <asp:Button ID="btnContinuar" CssClass="btn btn-primary" onclick="btnContinuar_Click" Visible="false" runat="server" Text="Continuar" />
                </div>
            </form>
        </div>
    </div>

</asp:Content>
