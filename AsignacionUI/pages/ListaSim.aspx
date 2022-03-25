<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="ListaSim.aspx.cs" Inherits="AsignacionUI.pages.ListaSim" %>

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
                <h3 class="mb-0">Lista De Sim</h3>
            </div>
                  <div class="table-responsive">
                <table id="DataSIM" class="table align-items-center table-flush">
                    <thead class="thead-light">
                        <tr>

                            <th scope="col" class="sort" data-sort="budget">iccid</th>
                            <th scope="col" class="sort" data-sort="name">min</th>
                            <th scope="col" class="sort" data-sort="budget">tipo plan</th>
                            <th scope="col" class="sort" data-sort="budget">estado sim</th>
                            <th scope="col" class="sort" data-sort="budget">fecha sim</th>
                        </tr>
                    </thead>
                    <tbody class="list" runat="server" id="dataSim">
                    </tbody>
                </table>
                <asp:Label ID="mensajeExcepcion" runat="server" Text=""></asp:Label>
            </div>
      
        </div>
        </div>
     <script src="../assets/vendor/jquery/dist/jquery.min.js"></script>

    <script type="text/javascript">
        $(document).ready(function () {
            $('#DataSIM').DataTable({
                dom: 'Bfrtip',
                buttons: [
                    'excelHtml5'
                ]
            });
        });
    </script>
</asp:Content>
