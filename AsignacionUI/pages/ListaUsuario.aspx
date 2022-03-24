﻿<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="ListaUsuario.aspx.cs" Inherits="AsignacionUI.pages.ListaUsuario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col">
            <div class="card-header">
                <div class="row align-items-center">
                    <div class="col-8">
                        <h3 class="mb-0">lista de Asesores</h3>
                    </div>
                </div>
            </div>
            <!-- Card header -->
            <div class="card-header border-0">
                <h3 class="mb-0">Lista De Asesor</h3>
            </div>
            <!-- Light table -->
                </div>
            <div class="table-responsive">
                <table id="DataUsuarios" class="table align-items-center table-flush">
                    <thead class="thead-light">
                        <tr>

                            <th scope="col" class="sort" data-sort="budget">cedula</th>
                            <th scope="col" class="sort" data-sort="name">nombre</th>
                            <th scope="col" class="sort" data-sort="budget">apellido</th>
                            <th scope="col" class="sort" data-sort="budget">telefono</th>
                            <th scope="col" class="sort" data-sort="budget">area</th>
                            <th scope="col" class="sort" data-sort="budget">cargo</th>
                             <th scope="col" class="sort" data-sort="budget">fecha Registro </th>
                        </tr>
                    </thead>
                    <tbody class="list" runat="server" id="dataUsuarioEquipo">
                    </tbody>
                </table>
            </div>
          <%--  <div class="table-responsive">
                <asp:GridView ID="GridDataUsuario" CssClass="table table-condensed table-hover" AutoGenerateColumns="false" runat="server"  RowStyle-ForeColor="#000" >
                    <Columns>
                       <asp:BoundField DataField="cedula" HeaderText="Cedula " />
                        <asp:BoundField DataField="nombre" HeaderText="Nombre " />
                        <asp:BoundField DataField="apellido" HeaderText="Apellido" />
                         <asp:BoundField DataField="telefono" HeaderText="telefono" />
                        <asp:BoundField DataField="area" HeaderText="Area" />
                        <asp:BoundField DataField="cargo" HeaderText="Cargo" />
                        <asp:BoundField DataField="FechaUsuario" HeaderText="Fecha Registro" />
                    </Columns>
                </asp:GridView>
            </div>
             <div>
                <asp:ImageButton ID="btnDescargar" runat="server" src="https://img.icons8.com/color/48/000000/ms-excel.png" onclick="btnDescargar_Click"/>
            </div>--%>
        </div>
    
  <script src="../assets/vendor/jquery/dist/jquery.min.js"></script>

    <script type="text/javascript">
        $(document).ready(function () {
            $('#DataUsuarios').DataTable({
                dom: 'Bfrtip',
                buttons: [
                  
                    'excelHtml5'
                ]
            });
        });
    </script>
</asp:Content>