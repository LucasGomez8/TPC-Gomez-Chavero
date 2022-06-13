<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AgregarCliente.aspx.cs" Inherits="TPC_Gomez_Chavero.WebForm1" %>


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
                          <label for="nombreUsuario">Nombre</label>
                          <input class="form-control" type="text" name="nombre" id="nombreUsuario" placeholder="Nombre"/>
                      </div>
                      <div class="col-md-6">
                         <label for="dni">DNI o CUIT</label>
                         <input type="text" class="form-control" name="dni" id="dni" value="" placeholder="DNI o CUIT" />
                      </div>
                  </div>
              </div>
              <div class="form-group mb-3">
                  <div class="row">
                      <div class="col-md-4">
                          <label for="fechaNac">Fecha de Nacimiento</label>
                          <input type="date" id="fechaNac" class="form-control"name="fechaNac" value="" />
                      </div>
                      <div class="col-md-4">
                          <label for="email">Email</label>
                          <input type="email" name="email" id="email" class="form-control" value="" />
                      </div>
                      <div class="col-md-4">
                          <label for="telefono">Telefono</label>
                          <input type="text" name="telefono" id="telefono" class="form-control" value="" />
                      </div>
                  </div>
                </div>
                <div class="form-group mb-5">
                    <input type="file" name="name" class="form-control" value=""/>
                </div>
    
              <button type="submit" id="submit" class="btn btn-primary">Agregar</button>
            </form>
        </div>
    </div>
</asp:Content>
