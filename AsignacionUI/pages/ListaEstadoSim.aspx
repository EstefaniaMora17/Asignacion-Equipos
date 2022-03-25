<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="ListaEstadoSim.aspx.cs" Inherits="AsignacionUI.pages.ListaEstadoSim" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col">
            <div class="card-header">
                <div class="row align-items-center">
                    <div class="col-8">
                        <h3 class="mb-0">lista Estado Sim</h3>
                    </div> 
                </div>
            </div>
            <!-- Card header -->
            <div class="card-header border-0">
                <h3 class="mb-0">Lista</h3>
            </div>
                <div class="table-responsive">
                <table id="DataEstadoSim" class="table align-items-center table-flush">
                    <thead class="thead-light">
                        <tr>

                            <th scope="col" class="sort" data-sort="budget">id Estado Equipo</th>
                            <th scope="col" class="sort" data-sort="name">Estado Equipo</th>
                        </tr>
                    </thead>
                    <tbody class="list" runat="server" id="dataEstadoSim">
                    </tbody>
                </table>
                     <asp:Label ID="mensajeExcepcion" runat="server" Text=""></asp:Label>
            </div>
     
        </div>
    </div>
      <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>


   <script src="../assets/vendor/jquery/dist/jquery.min.js"></script>

    <script type="text/javascript">
        $(document).ready(function () {
            $('#DataEstadoSim').DataTable({
                dom: 'Bfrtip',
                buttons: [
                    'excelHtml5'
                ]
            });
        });
    </script>
</asp:Content>
