<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AgregarVendedor.aspx.cs" Inherits="TPC_Gomez_Chavero.WebForm1" %>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="container">
        <div class="row mt-3">
            <div class="col-md-12 text-center">
                <h3>Usuario</h3>
            </div>
        </div>
        <div class="row mt-5">
            <form>
              <div class="form-group mb-3">
                  <div class="row">
                      <div class="col-md-6">
                          <label for="nombreUsuario">Nombre</label>
                          <input class="form-control" type="text" name="nombre" id="nombreUsuario" placeholder="Nombre"/>
                      </div>
                      <div class="col-md-6">
                          <label for="apellidoUsuario">Apellido</label>
                          <input class="form-control" type="text" name="apellido" id="apellidoUsuario" placeholder="Apellido"/>
                      </div>
                  </div>
              </div>
              <div class="form-group mb-3">
                  <div class="row">
                      <div class="col-md-6">
                         <label for="dni">DNI</label>
                         <input type="text" class="form-control" name="dni" id="dni" value="" placeholder="DNI" />
                      </div>
                      <div class="col-md-6">
                         <label for="fechaNac">Fecha de Nacimiento</label>
                         <input type="date" class="form-control" name="fechaNac" id="fechaNac" value="" />
                      </div>
                  </div>
              </div>
              <div class="form-group mb-3">
                  <div class="row">
                      <div class="col-md-4">
                          <label for="tipoUsuario">Tipo Usuario</label>
                          <asp:DropDownList CssClass="form-control" ID="tipoUsuario" runat="server"></asp:DropDownList>
                      </div>
                      <div class="col-md-4">
                          <label for="nick">Nick Usuario</label>
                          <input type="text" name="nick" id="nick" class="form-control" value="" />
                      </div>
                      <div class="col-md-4">
                          <label for="password">Contraseña Usuario</label>
                          <input type="text" name="nick" id="password" class="form-control" value="" />
                      </div>
                  </div>
                </div>
                <div class="form-group mb-5">
                    <input type="file" name="name" class="form-control" value="" placeholder="+"/>
                </div>
    
              <button type="submit" id="submit" class="btn btn-primary">Agregar</button>
            </form>
        </div>
    </div>
</asp:Content>
