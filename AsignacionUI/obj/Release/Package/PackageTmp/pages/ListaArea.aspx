<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="ListaArea.aspx.cs" Inherits="AsignacionUI.pages.ListaArea" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col">
            <div class="card-header">
                <div class="row align-items-center">
                    <div class="col-8">
                        <h3 class="mb-0">lista Area</h3>
                    </div>
                </div>
            </div>
            <!-- Card header -->
            <div class="card-header border-0">
                <h3 class="mb-0">Lista</h3>
            </div>
            <div class="table-responsive">
                <table id="DataArea" class="table align-items-center table-flush">
                    <thead class="thead-light">
                        <tr>

                            <th scope="col" class="sort" data-sort="budget">id Area</th>
                            <th scope="col" class="sort" data-sort="name">Area</th>
                        </tr>
                    </thead>
                    <tbody class="list" runat="server" id="dataArea">
                    </tbody>
                </table>
                <asp:Label ID="mensajeExcepcion" runat="server" Text=""></asp:Label>
            </div>
           
        </div>
    </div>
    <script src="../assets/vendor/jquery/dist/jquery.min.js"></script>

    <script type="text/javascript">
        $(document).ready(function () {
            $('#DataArea').DataTable({
                dom: 'Bfrtip',
                buttons: [
                    'excelHtml5'
                ]
            });
        });
    </script>
</asp:Content>
