<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="TPC_Gomez_Chavero.Pages.Login" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row mt-2">
            <div class="col-md-12 text-center mt-2">
              <h1>Iniciar Sesion</h1>
            </div>
              <div class="mb-3 row justify-content-center mb-3 mt-5">
                <label for="staticEmail" class="col-sm-2 col-form-label">Email</label>
                <div class="col-sm-6 text-center">
                  <input type="text" class="form-control" id="staticEmail" value="email@example.com">
                </div>
               </div>
               <div class="mb-3 row justify-content-center">
                   <label for="inputPassword" class="col-sm-2 col-form-label">Password</label>
                 <div class="col-sm-6 text-center">
                   <input type="password" class="form-control" id="inputPassword">
                 </div>
               </div>
               <div class="mb-3 row justify-content-center">
                   <div class="col-sm-4 text-center">
                       <button class="btn btn-primary">Confirmar</button>
                   </div>
               </div>

        </div>
    </div>
        <script>
            function onLogin(nick, pass) {
                __doPostBack("onLogin", nick, pass);
            }
        </script>
</asp:Content>
