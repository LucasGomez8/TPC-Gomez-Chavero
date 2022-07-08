<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BajaMarca.aspx.cs" Inherits="TPC_Gomez_Chavero.Pages.Bajas.BajaMarca" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <link href="../../css/Bajas.css" rel="stylesheet" type="text/css" />
          <div class="container bajStyle" data-aos="flip-down">
        <div class="row mt-3 justify-content-center">
            <div class="col-md-8 text-center">
                <h3>Baja Marca</h3>
            </div>
        </div>
        <div class="row mt-5 mb-5 justify-content-center">
            <form>
                <div class="col-md-4">
                    <div class="form-group">
                        <label for="deleteMarca">Selecciona la marca a eliminar</label>
                        <asp:DropDownList cssClass="form-control" ID="deleteMarca" runat="server"></asp:DropDownList>
                        <asp:Label runat="server" CssClass="text-success" ID="lblSuccess" />
                    </div>
                </div>
                <div class="col-md-4 mt-4">
                    <asp:Button ID="btnSubmit" CssClass="btn btn-primary" onclick="btnSubmit_Click" runat="server" Text="Eliminar" />
                </div>
            </form>
        </div>
    </div>
</asp:Content>
