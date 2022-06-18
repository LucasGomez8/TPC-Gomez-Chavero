<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AgregarCliente.aspx.cs" Inherits="TPC_Gomez_Chavero.Pages.Altas.AgregarCliente" %>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <div class="container">
        <div class="row mt-3">
            <div class="col-md-12 text-center">
                <h3>Clientes</h3>
            </div>
        </div>
        <div class="row mt-5">
            <form>
              <div class="form-group mb-3">
                  <div class="row">
                      <div class="col-md-6">
                          <label for="nombreCliente">Nombre</label>
                          <asp:TextBox ID="txtNombreCliente" CssClass="form-control" runat="server"></asp:TextBox>
                      </div>
                      <div class="col-md-6">
                         <label for="dni">DNI o CUIT</label>
                          <asp:TextBox ID="txtDNIorCuit" cssClass="form-control" runat="server"></asp:TextBox>
                      </div>
                  </div>
              </div>
              <div class="form-group mb-3">
                  <div class="row">
                      <div class="col-md-4">
                          <label for="fechaNac">Fecha de Nacimiento</label>
                          <asp:TextBox ID="txtFechaNac" CssClass="form-control" TextMode="Date" runat="server"></asp:TextBox>
                      </div>
                      <div class="col-md-4">
                          <label for="email">Email</label>
                          <asp:TextBox ID="txtEmail" CssClass="form-control" runat="server"></asp:TextBox>
                      </div>
                      <div class="col-md-4">
                          <label for="telefono">Telefono</label>
                          <asp:TextBox ID="txtTelefono" CssClass="form-control" runat="server"></asp:TextBox>
                      </div>
                  </div>
                </div>
                <div class="form-group mb-5">
                    <input type="file" name="name" class="form-control" value=""/>
                </div>
            </form>
            <div class="row justify-content-center">
                <div class="col-md-4 text-center">
                <asp:Button ID="btnSubmit" cssClass="btn btn-primary" OnClick="btnSubmit_Click" runat="server" Text="Agregar" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
