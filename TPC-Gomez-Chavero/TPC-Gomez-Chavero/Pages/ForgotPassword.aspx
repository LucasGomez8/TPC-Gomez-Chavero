<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ForgotPassword.aspx.cs" Inherits="TPC_Gomez_Chavero.Pages.ForgotPassword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

        <link href="../../css/Login.css" rel="stylesheet" />
    <div class="container loginStyle">
        <div class="row mt-2">
            <div class="col-md-12 text-center mt-2">
              <p>Ingrese su correo para enviar nueva contraseña</p>
            </div>

               <div class="mb-3 row justify-content-center">
                   <label for="txtEmail" class="col-sm-2 col-form-label">Email: </label>
                 <div class="col-sm-6 text-center">
                   <asp:TextBox ID="txtEmail" CssClass="form-control" runat="server"></asp:TextBox>
                 </div>
               </div>
               <div class="mb-3 row justify-content-center">
                   <div class="col-sm-4 text-center">
                       <asp:Button ID="btnSend" CssClass="btn btn-primary" runat="server" onclick="send_Click" Text="Enviar" />
                   </div>
               </div>
                <div class="col-md-12 text-center">
                    <asp:Label ID="lblError" runat="server"></asp:Label>
                </div>

        </div>
    </div>
</asp:Content>
