<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="ListaUsuario.aspx.cs" Inherits="AsignacionUI.pages.ListaUsuario" %>

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
                  <asp:Label ID="mensajeExcepcion" runat="server" Text=""></asp:Label>
            </div>
         
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
