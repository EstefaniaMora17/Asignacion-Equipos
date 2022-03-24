<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="ListaEstadoEquipo.aspx.cs" Inherits="AsignacionUI.pages.ListaEstadoEquipo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- Lita -->
    <div class="row">
        <div class="col">
            <div class="card-header">
                <div class="row align-items-center">
                    <div class="col-8">
                        <h3 class="mb-0">lista Estado Equipo</h3>
                    </div>
                </div>
            </div>
            <!-- Card header -->
            <div class="card-header border-0">
                <h3 class="mb-0">Lista</h3>
            </div>
            <div class="table-responsive">
                <table id="DataEstadoEquipo" class="table align-items-center table-flush">
                    <thead class="thead-light">
                        <tr>

                            <th scope="col" class="sort" data-sort="budget">id Estado Equipo</th>
                            <th scope="col" class="sort" data-sort="name">Estado Equipo</th>
                        </tr>
                    </thead>
                    <tbody class="list" runat="server" id="dataEstadoEquipo">
                    </tbody>
                </table>
            </div>
            <!-- Light table -->
          <%--  <div class="table-responsive">

                <asp:GridView GridLinesVisibility="None" ID="GridDataEstadoEquipo" CssClass="table table-condensed table-hover" AutoGenerateColumns="false" runat="server">
                    <Columns>
                        <asp:BoundField DataField="idEstadoEquipo" HeaderText="id Estado Equipo" />
                        <asp:BoundField DataField="estadoEquipo" HeaderText="estado Eqipo" />
                    </Columns>

                </asp:GridView>

            </div>--%>
        </div>
    </div>
   <script src="../assets/vendor/jquery/dist/jquery.min.js"></script>

    <script type="text/javascript">
        $(document).ready(function () {
            $('#DataEstadoEquipo').DataTable({
                dom: 'Bfrtip',
                buttons: [
                    'excelHtml5'
                ]
            });
        });
    </script>
</asp:Content>
