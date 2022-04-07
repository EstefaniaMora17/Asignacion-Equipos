<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="RegistroUsuarioEquipo.aspx.cs" Inherits="AsignacionUI.pages.RegistroUsuarioEquipo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-xl-12 order-xl-1">
            <div class="card">
                <div class="card-header">
                    <div class="row">
                        <div class=" align-items-center">
                            <div class="col-12">
                                <h3 class="mb-0">Registro de Usuario Equipo</h3>
                            </div>
                        </div>
                        <div class="col">
                            <asp:Label ID="lblMensaje" runat="server" Text="" CssClass="diseñoMsj"></asp:Label>
                        </div>
                        <div class="col">
                            <asp:Label ID="mensajeExcepcion" runat="server" Text="" CssClass="diseñoMsj"></asp:Label>
                        </div>
                    </div>
                </div>
                <div class="card-body">
                    <h6 class="heading-small text-muted mb-4">Informacion Asesor Equipo</h6>
                    <div class="pl-lg-4">
                        <div class="row">
                            <div class="col-lg-6">
                                <div class="form-group">
                                    <label class="form-control-label">ID</label><asp:Label ID="Label1" class="mensajeID" runat="server" Text="*este campo solo se utiliza para Buscar"></asp:Label>
                                    <asp:TextBox ID="txtId" CssClass="form-control" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" ControlToValidate="txtId" runat="server" ErrorMessage="* Campo Obligatorio Solo se utiliza para consultar" ValidationGroup="txtId"></asp:RequiredFieldValidator>

                                </div>
                            </div>
                            <div class="col-lg-6">
                                <div class="form-group focused">
                                    <label class="form-control-label">cedula</label>
                                    <asp:DropDownList ID="DLLcedula" runat="server" CssClass="form-control ">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="DLLcedula" runat="server" ErrorMessage="* Campo Obligatorio " InitialValue="0"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-lg-6">
                                <div class="form-group">
                                    <label class="form-control-label">IMEI</label>
                                    <asp:DropDownList ID="DLLimei" runat="server" CssClass="form-control ">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="DLLimei" runat="server" ErrorMessage="* Campo Obligatorio" InitialValue="0"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="col-lg-6">
                                <div class="form-group">
                                    <label class="form-control-label">ICCID</label>
                                    <asp:DropDownList ID="DLLiccid" runat="server" CssClass="form-control  js-example-placeholder.single">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="DLLiccid" runat="server" ErrorMessage="* Campo Obligatorio" InitialValue="0"></asp:RequiredFieldValidator>
                                </div>
                            </div>

                        </div>
                        <div class="row">
                            <div class="col-lg-6">
                                <div class="form-group">
                                    <div class="form-group">
                                        <label class="form-control-label" for="input-first-name">Estado Sim</label>
                                        <asp:DropDownList ID="DLLidestadoSim" runat="server" CssClass="form-control">
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ControlToValidate="DLLidestadoSim" runat="server" ErrorMessage="* Campo Obligatorio" InitialValue="0"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                            <div class="col-lg-6">
                                <div class="form-group">
                                    <label class="form-control-label">Estado Equipo</label>
                                    <asp:DropDownList ID="DLLidestadoEquipo" runat="server" CssClass="form-control">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" ControlToValidate="DLLidestadoEquipo" runat="server" ErrorMessage="* Campo Obligatorio" InitialValue="0"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-lg-6">
                                <div class="form-group">
                                    <label class="form-control-label" for="input-first-name">Observacion</label>
                                    <asp:TextBox ID="txtObservacion" CssClass="form-control" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ControlToValidate="txtObservacion" runat="server" ErrorMessage="* Campo Obligatorio"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="col-lg-6">
                                <label class="form-control-label">Archivo</label>
                                <asp:FileUpload ID="fuploadImagen" runat="server" CssClass="form-control" AllowMultiple="true" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" ControlToValidate="fuploadImagen" runat="server" ErrorMessage="* Campo Obligatorio"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-lg-6">
                                <label class="form-control-label">Imagen</label>
                                <asp:Image ID="Image1" runat="server" Width="200" Height="200" />
                            </div>

                        </div>
                    </div>
                    <div class="row pt-5">
                        <div class="col-lg-6 d-flex justify-content-center">
                            <asp:Button ID="btnGuardar" CssClass="btn btn-outline-danger textobutton" OnClick="btnGuardar_Click" runat="server" Text="Guardar" />
                        </div>
                        <div class=" col-lg-6 d-flex justify-content-center">
                            <asp:Button ID="btnBuscar" CssClass="btn btn-outline-danger textobutton" OnClick="btnBuscar_Click" runat="server" Text="Buscar" ValidationGroup="txtId" />
                        </div>
                    </div>
                    <div>
                    </div>
                </div>

            </div>
        </div>
    </div>


    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    <script type="text/javascript">
        $(function () {
            $("[id*=DLLimei]").select2();
        });
        $(function () {
            $("[id*=DLLcedula]").select2();
        });
        $(function () {
            $("[id*=DLLiccid]").select2();
        });

    </script>
</asp:Content>
