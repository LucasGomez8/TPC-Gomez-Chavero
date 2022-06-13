<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="TPC_Gomez_Chavero.Pages.Login" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row mt-2">
            <div class="col-md-12 text-center mt-2">
              <h1>Iniciar Sesion</h1>
            </div>
              <div class="mb-3 row justify-content-center mb-3 mt-5">
                <label for="txtNick" class="col-sm-2 col-form-label">Nickname</label>
                <div class="col-sm-6 text-center">
                    <asp:TextBox ID="txtNick" CssClass="form-control" runat="server"></asp:TextBox>
                </div>
               </div>
               <div class="mb-3 row justify-content-center">
                   <label for="txtPass" class="col-sm-2 col-form-label">Password</label>
                 <div class="col-sm-6 text-center">
                   <asp:TextBox ID="txtPass" CssClass="form-control" runat="server"></asp:TextBox>
                 </div>
               </div>
               <div class="mb-3 row justify-content-center">
                   <div class="col-sm-4 text-center">
                       <asp:Button ID="btnAcess" CssClass="btn btn-primary" runat="server" onclick="btnAcess_Click" Text="Confirmar" />
                   </div>
               </div>
                <div>
                    <asp:Label ID="lblError" runat="server"></asp:Label>
                </div>

        </div>
    </div>
        <script>
            function onLogin() {
                var nick = document.getElementById("nickname").value;
                var pass = document.getElementById("inputPassword").value;
                __doPostBack("onLogin", nick, pass);
            }
        </script>
</asp:Content>
