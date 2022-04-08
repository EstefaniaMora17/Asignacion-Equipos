<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="RegistroEstadoEquipo.aspx.cs" Inherits="AsignacionUI.pages.RegistroEstadoEquipo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-xl-12 order-xl-1">
            <div class="card">
                <div class="card-header">
                    <div class="row">
                        <div class=" align-items-center">
                            <div class="col-12">
                                <h3 class="mb-0">Registro de Estado Equipo</h3>
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
                    <div class="nav-wrapper">
                        <ul class="nav nav-pills nav-fill flex-column flex-md-row" id="tabs-icons-text" role="tablist">
                            <li class="nav-item">
                                <a class="nav-link mb-sm-3 mb-md-0 active" id="tabs-icons-text-1-tab" data-toggle="tab" href="#tabs-icons-text-1" role="tab" aria-controls="tabs-icons-text-1" aria-selected="true">Registrar</a>
                            </li>
                            <li class="nav-item">
                                <a class="nav-link mb-sm-3 mb-md-0" id="tabs-icons-text-2-tab" data-toggle="tab" href="#tabs-icons-text-2" role="tab" aria-controls="tabs-icons-text-2" aria-selected="false">Actualizar</a>
                            </li>
                        </ul>
                    </div>
                    <div class="card shadow">
                        <div class="card-body">
                            <div class="tab-content" id="myTabContent">
                                <div class="tab-pane fade show active" id="tabs-icons-text-1" role="tabpanel" aria-labelledby="tabs-icons-text-1-tab">
                                    <div class="row">

                                        <div class="col-lg-12">
                                            <div class="form-group">
                                                <label class="form-control-label" for="input-username">Estado Equipo</label>
                                                <asp:TextBox ID="txtestadoEquipo" CssClass="form-control" runat="server"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txtestadoEquipo" runat="server" ErrorMessage="* Campo Obligatorio" ValidationGroup="GuardarCampo"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col  d-flex justify-content-center">
                                            <asp:Button ID="btnGuardar" CssClass="btn btn-outline-danger btnmargin" OnClick="btnGuardar_Click" runat="server" Text="Guardar" ValidationGroup="GuardarCampo" />
                                        </div>

                                    </div>

                                </div>
                                <div class="tab-pane fade" id="tabs-icons-text-2" role="tabpanel" aria-labelledby="tabs-icons-text-2-tab">
                                    <div class="row">

                                        <div class="col-lg-6">
                                            <div class="form-group">
                                                <label class="form-control-label" for="input-username">
                                                    Esatado Equipo
                                                </label>
                                                <asp:DropDownList ID="DllestadoEquipo" CssClass="form-control" runat="server">
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="DllestadoEquipo" runat="server" ErrorMessage="* Campo Obligatorio" InitialValue="0" ValidationGroup="ActualizarCargo"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>

                                        <div class="col-lg-6">
                                            <div class="form-group">
                                                <label class="form-control-label" for="input-username">Estado Equipo</label>
                                                <asp:TextBox ID="txtEstadoEquipoUpdate" CssClass="form-control" runat="server"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ControlToValidate="txtEstadoEquipoUpdate" runat="server" ErrorMessage="* Campo Obligatorio" ValidationGroup="ActualizarEstadoEquipo"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                    </div>
                                      <div class="row">
                                        <div class="col  d-flex justify-content-center ">
                                            <asp:Button ID="Button2" CssClass="btn btn-outline-danger btnmargin" OnClick="btnEditar_Click" runat="server" Text="Editar" ValidationGroup="ActualizarEstadoEquipo" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>

                </div>
            </div>
        </div>
    </div>
</asp:Content>
