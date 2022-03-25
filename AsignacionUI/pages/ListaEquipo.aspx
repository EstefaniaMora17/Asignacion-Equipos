<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="ListaEquipo.aspx.cs" Inherits="AsignacionUI.pages.ListaEquipo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div class="row">
        <div class="col-md">
            <div class="card-header">
                <div class="row align-items-center">
                    <div class="col-md-8">
                        <h3 class="mb-0">lista de Equipos</h3>
                    </div>
                </div>
            </div>
            <!-- Card header -->
            <div class="card-header border-0">
                <h3 class="mb-0">Lista De Equipos</h3>
            </div>
                 <div class="table-responsive">
                <table id="DataEquipos" class="table align-items-center table-flush">
                    <thead class="thead-light">
                        <tr>
                            <th scope="col" class="sort" data-sort="budget">imei</th>
                            <th scope="col" class="sort" data-sort="name">referencia</th>
                            <th scope="col" class="sort" data-sort="budget">marca</th>
                            <th scope="col" class="sort" data-sort="budget">rom</th>
                            <th scope="col" class="sort" data-sort="budget">ram</th>
                            <th scope="col" class="sort" data-sort="budget">bateria</th>
                            <th scope="col" class="sort" data-sort="budget">accesorios</th>
                             <th scope="col" class="sort" data-sort="budget">precio </th>
                            <th scope="col" class="sort" data-sort="budget">observacion </th>
                            <th scope="col" class="sort" data-sort="budget">estado Equipo </th>
                            <th scope="col" class="sort" data-sort="budget">ubicacion Equipo </th>
                            <th scope="col" class="sort" data-sort="budget">fecha registro </th>
                        </tr>
                    </thead>
                    <tbody class="list" runat="server" id="dataEquipo">
                    </tbody>
                     <asp:Label ID="lblMensaje" runat="server" Text=""></asp:Label>
                </table>
            </div>
           
        </div>
        </div>
  <script src="../assets/vendor/jquery/dist/jquery.min.js"></script>

    <script type="text/javascript">
        $(document).ready(function () {
            $('#DataEquipos').DataTable({
                dom: 'Bfrtip',
                buttons: [
                    'excelHtml5'
                ]
            });
        });
    </script>
</asp:Content>
