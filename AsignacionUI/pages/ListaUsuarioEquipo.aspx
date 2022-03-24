<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="ListaUsuarioEquipo.aspx.cs" Inherits="AsignacionUI.pages.ListaUsuarioEquipo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col">
            <div class="card-header">
            </div>
            <!-- Card header -->
            <div class="card-header border-0">
                <h3 class="mb-0">Lista De Asesor Equipo</h3>
            </div>
            <div class="table-responsive">
                <table id="DataEquipos" class="table align-items-center table-flush">
                    <thead class="thead-light">
                        <tr>
                            <th scope="col" class="sort" data-sort="budget">id</th>
                            <th scope="col" class="sort" data-sort="name">nombre</th>
                            <th scope="col" class="sort" data-sort="budget">iccid</th>
                            <th scope="col" class="sort" data-sort="budget">Imei</th>
                            <th scope="col" class="sort" data-sort="budget">observacion</th>
                            <th scope="col" class="sort" data-sort="budget">estado Sim</th>
                            <th scope="col" class="sort" data-sort="budget">estado Equipo</th>
                      <%--      <th><asp:Image  ID="imagen1" runat="server" />imagen</th>--%>
                            <th scope="col" class="sort" data-sort="budget">fecha Registro </th>
                        </tr>
                    </thead>
                    <tbody class="list" runat="server" id="dataUsuarioEquipo">
                    </tbody>
                </table>
            </div>
            <%--<div class="table-responsive">
                 <asp:GridView ID="GridDataUsuarioEquipo" CssClass="table table-condensed table-hover" AutoGenerateColumns="false" OnRowDataBound="OnRowDataBound" runat="server" RowStyle-ForeColor="#000">
                    <Columns>
                         <asp:BoundField DataField="id" HeaderText="id " />
                        <asp:BoundField DataField="cedula" HeaderText="Cedula " />
                        <asp:BoundField DataField="imei" HeaderText="Imei" />
                        <asp:BoundField DataField="iccid" HeaderText="Iccid" />
                        <asp:BoundField DataField="observacion" HeaderText="observacion" />
                        <asp:BoundField DataField="estadoSim" HeaderText="Estado Sim" />
                        <asp:BoundField DataField="estadoEquipo" HeaderText="Estado Equipo" />
                        <asp:BoundField DataField="fechaUsuarioEquipo" HeaderText="Fecha Registro" />
                         <asp:TemplateField HeaderText="Image">
                            <ItemTemplate>
                                <asp:Image ID="Image1" Width="100%" runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                  <tbody class="list" runat="server" id="dataUsuarioEquipo">
            </div>--%>
            <div>
                <%--  <asp:ImageButton ID="btnDescargar" runat="server" src="https://img.icons8.com/color/48/000000/ms-excel.png" OnClick="btnDescargar_Click" />--%>
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
