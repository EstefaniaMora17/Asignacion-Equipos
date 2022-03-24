<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="ListaCargo.aspx.cs" Inherits="AsignacionUI.pages.ListaCargo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <div class="row">
        <div class="col">
            <div class="card-header">
                <div class="row align-items-center">
                    <div class="col-8">
                        <h3 class="mb-0">lista Cargo</h3>
                    </div>
                </div>
            </div>
            <!-- Card header -->
            <div class="card-header border-0">
                <h3 class="mb-0">Lista</h3>
            </div>
              <div class="table-responsive">
                <table id="DataCargo" class="table align-items-center table-flush">
                    <thead class="thead-light">
                        <tr>

                            <th scope="col" class="sort" data-sort="budget">id Cargo</th>
                            <th scope="col" class="sort" data-sort="name">Cargo</th>
                        </tr>
                    </thead>
                    <tbody class="list" runat="server" id="dataCargo">
                    </tbody>
                </table>
            </div>
            <!-- Light table -->
          <%--  <div class="table-responsive">

                <asp:GridView GridLinesVisibility="None" ID="GridDataCargo" CssClass="table table-condensed table-hover" AutoGenerateColumns="false" runat="server"  RowStyle-ForeColor="#000">
                    <Columns>
                        <asp:BoundField DataField="idcargo" HeaderText="id cargo" />
                        <asp:BoundField DataField="cargo" HeaderText="cargo" />
                    </Columns>

                </asp:GridView>
              
            </div>--%>
        </div>
    </div>
    <script src="../assets/vendor/jquery/dist/jquery.min.js"></script>

    <script type="text/javascript">
        $(document).ready(function () {
            $('#DataCargo').DataTable({
                dom: 'Bfrtip',
                buttons: [
                    'excelHtml5'
                ]
            });
        });
    </script>

</asp:Content>
