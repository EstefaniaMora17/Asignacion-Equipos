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
                </table>
            </div>
            <!-- Light table -->
<%--            <div class="table table-hover">
                <asp:GridView GridLinesVisibility="None" ID="GridDataEquipo" CssClass="table table-condensed table-hover" AutoGenerateColumns="false" runat="server"  RowStyle-ForeColor="#000" >
                    <Columns>
                        <asp:BoundField DataField="imei" HeaderText="Imei"/>
                         <asp:BoundField DataField="Referencia" HeaderText="Referencia" />
                        <asp:BoundField DataField="marca" HeaderText="Marca" />
                        <asp:BoundField DataField="rom" HeaderText="Rom" />
                        <asp:BoundField DataField="ram" HeaderText="Ram" />
                        <asp:BoundField DataField="bateria" HeaderText="Bateria" />
                        <asp:BoundField DataField="accesorios" HeaderText="Accesorios" />
                         <asp:BoundField DataField="Precio" HeaderText="Precio" />
                         <asp:BoundField DataField="observacion" HeaderText="observacion" />
                        <asp:BoundField DataField="estadoEquipo" HeaderText="Estado Equipo" />
                        <asp:BoundField DataField="ubicacionEquipo" HeaderText="Ubicacion Equipo" />
                    </Columns>
                </asp:GridView>
               <div>
                <asp:ImageButton ID="btnDescargar" runat="server" src="https://img.icons8.com/color/48/000000/ms-excel.png" onclick="btnDescargar_Click"/>
            </div>
            </div>--%>
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
