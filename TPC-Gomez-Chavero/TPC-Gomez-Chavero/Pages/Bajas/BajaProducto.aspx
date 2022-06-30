<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BajaProducto.aspx.cs" Inherits="TPC_Gomez_Chavero.Pages.Bajas.BajaProducto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <link href="../../css/Bajas.css" rel="stylesheet" type="text/css" />
      <div class="container bajStyle">
        <div class="row mt-3 justify-content-center">
            <div class="col-md-8 text-center">
                <h3>Baja Producto</h3>
            </div>
        </div>
        <div class="row mt-5 mb-5 justify-content-center">
            <form>
                <div class="col-md-4">
                    <div class="form-group">
                        <label for="deleteProduct">Selecciona el Producto a Eliminar</label>
                        <asp:DropDownList cssClass="form-control" ID="deleteProduct" runat="server"></asp:DropDownList>
                    </div>
                </div>
                <div class="col-md-4 mt-4">
                    <asp:Button ID="btnSubmit" CssClass="btn btn-primary" OnClick="btnSubmit_Click" runat="server" Text="Eliminar" />
                    <asp:Button ID="btnContinue" CssClass="btn btn-primary" OnClick="btnContinue_Click" runat="server" Visible ="false" Text="Continuar" />
                </div>
            </form>
        </div>
       <div class="row justify-content-center mt-3 mb-4">
           <div class="col-md-12 text-center">
               <asp:Label ID="lblSuccess" runat="server" visible="false"></asp:Label>
           </div>
       </div>
    </div>

</asp:Content>
