<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditarCategoria.aspx.cs" Inherits="TPC_Gomez_Chavero.Pages.Modificaciones.EditarCategoria" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <link href="../../css/Modificacion.css" rel="stylesheet" type="text/css"/>
    <div class="container mb-4 modifStyle">
         <div class="row mt-3 justify-content-center">
            <div class="col-md-8  text-center">
                <h3>Modificacion de datos de Categoria</h3>
            </div>
        </div>
        <div class="row mb-3">
            <form>
                <div class="col-md-4">
                    <div class="form-group">
                        <label for="deleteProduct">Selecciona la Categoria</label>
                        <asp:DropDownList cssClass="form-control" ID="dropCategorias" runat="server"></asp:DropDownList>
                    </div>
                </div>
                <div class="col-md-4 mt-4">
                    <asp:Button ID="btnSelect" CssClass="btn btn-primary" onclick="btnSelect_Click" runat="server" Text="Seleccionar" />
                </div>
                <div class="row mb-4 mt-4 justify-content-center text-center">
                    <hr style="width: 98%"/>
                </div>
                <div class="row">
                      <div class="form-group mb-3">
                <label for="txtNCategoria">Nombre de Categoria</label>
                 <asp:TextBox ID="txtNCategoria" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
              </div>
              </div>
            </form>
            <asp:Label ID="lblSuccess" runat="server" Visible="false" CssClass="text-success"></asp:Label>
        </div>
        <div class="row mt-4 justify-content-center">
            <div class="col-md-4 text-center">
                <asp:Button ID="btnSubmit" CssClass="btn btn-primary" OnClick="btnSubmit_Click" Enabled="false" runat="server" Text="Editar" />
                <asp:Button ID="btnContinue" CssClass="btn btn-primary" OnClick="btnContinue_Click" visible="true" runat="server" Text="Continuar" />
            </div>
        </div>
    </div>

</asp:Content>
