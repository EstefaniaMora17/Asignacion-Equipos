<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="RegistroEquipos.aspx.cs" Inherits="AsignacionUI.pages.RegistroEquipos" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-xl-12 order-xl-1">
            <div class="card">
                <div class="card-header">
                    <div class="row align-items-center">
                        <div class="col-md-8">
                            <h3 class="mb-0">Registro de Equipos </h3>
                        </div>
                    </div>
                </div>
                <div class="card-body">
                    <h6 class="heading-small text-muted mb-4">Informacion Equipo</h6>
                    <div class="pl-lg-4">
                        <div class="row">
                            <div class="col-lg-6">
                                <div class="form-group">
                                    <label class="form-control-label">IMEI</label>
                                    <asp:TextBox ID="txtImei" CssClass="form-control" runat="server" MaxLength="15"></asp:TextBox>
                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator12" ControlToValidate="txtImei"  runat="server" ErrorMessage="* Campo Obligatorio" ValidationGroup="campo"></asp:RequiredFieldValidator>
                                        <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" FilterType="Numbers" TargetControlID="txtImei" />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator10" ControlToValidate="txtImei" runat="server" ErrorMessage="* Campo Obligatorio" ValidationGroup="imei"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="col-lg-6">
                                <div class="form-group">
                                    <label class="form-control-label">Marca</label>
                                    <asp:DropDownList ID="DLLidMarca" runat="server" CssClass="form-control">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" ControlToValidate="DLLidMarca" InitialValue="0" runat="server" ErrorMessage="* Campo Obligatorio" ValidationGroup="campo"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-lg-6">
                                <div class="form-group">
                                    <label class="form-control-label">Referencia</label>
                                    <asp:TextBox ID="txtReferencia" CssClass="form-control" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" ControlToValidate="txtReferencia" runat="server" ErrorMessage="* Campo Obligatorio" ValidationGroup="campo"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="col-lg-6">
                                <div class="form-group">
                                    <label class="form-control-label">Rom</label>
                                    <asp:TextBox ID="txtRom" CssClass="form-control" runat="server" ValidationGroup="LoginFrame"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtRom" runat="server" ErrorMessage="* Campo Obligatorio" ValidationGroup="campo"></asp:RequiredFieldValidator>
                                </div>
                            </div>

                        </div>
                        <div class="row">
                            <div class="col-lg-6">
                                <div class="form-group">
                                    <label class="form-control-label" for="input-first-name">Ram</label>
                                    <asp:TextBox ID="txtRam" CssClass="form-control" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txtRam" runat="server" ErrorMessage="* Campo Obligatorio" ValidationGroup="campo"></asp:RequiredFieldValidator>
                                </div>

                            </div>
                            <div class="col-lg-6">
                                <div class="form-group">
                                    <label class="form-control-label">Bateria</label>
                                    <asp:TextBox ID="txtBateria" CssClass="form-control" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="txtBateria" runat="server" ErrorMessage="* Campo Obligatorio" ValidationGroup="campo"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-lg-6">
                                <div class="form-group">
                                    <label class="form-control-label">Accesorios</label>
                                    <asp:TextBox ID="txtAccesorios" CssClass="form-control" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" ControlToValidate="txtAccesorios" runat="server" ErrorMessage="* Campo Obligatorio" ValidationGroup="campo"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="col-lg-6">
                                <div class="form-group">
                                    <label class="form-control-label">Precio</label>
                                    <asp:TextBox ID="txtPrecio" CssClass="form-control" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" ControlToValidate="txtObservacion" runat="server" ErrorMessage="* Campo Obligatorio" ValidationGroup="campo"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-lg-6">
                                <div class="form-group">
                                    <label class="form-control-label">Observacion</label>
                                    <asp:TextBox ID="txtObservacion" CssClass="form-control" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ControlToValidate="txtObservacion" runat="server" ErrorMessage="* Campo Obligatorio" ValidationGroup="campo"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="col-lg-6">
                                <div class="form-group">
                                    <label class="form-control-label">Ubicacion Equipo</label>
                                    <asp:DropDownList ID="DLLidUbicacionEquipo" runat="server" CssClass="form-control">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ControlToValidate="DLLidUbicacionEquipo" InitialValue="0" runat="server" ErrorMessage="* Campo Obligatorio" ValidationGroup="campo"></asp:RequiredFieldValidator>
                                </div>

                            </div>
                            <div class="col-lg-6">
                                <div class="form-group">
                                    <label class="form-control-label">Estado Equipo</label>
                                    <asp:DropDownList ID="DLLidEstadoEquipo" runat="server" CssClass="form-control">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="reqFavoriteColor" InitialValue="0" ControlToValidate="DLLidEstadoEquipo" runat="server" />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator11" ControlToValidate="DLLidEstadoEquipo" InitialValue="0" runat="server" ErrorMessage="* Campo Obligatorio" ValidationGroup="campo"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class=" row" style="margin-left: 28%;">
                        <div class="col-lg-4 d-flex justify-content-center " id="Divguardar" runat="server">
                            <asp:Button ID="btnGuardar" CssClass="btn btn-outline-danger" runat="server" OnClick="btnGuardar_Click" Text="Guardar" ValidationGroup="campo"/>
                        </div>
                        <div class="col-lg-4 d-flex justify-content-center" id="Diveditar" runat="server">
                            <asp:Button ID="BtnEditar" CssClass="btn btn-outline-danger" runat="server" OnClick="BtnEditar_Click" Text="Editar" />
                        </div>
                        <div class="col-lg-4 d-flex justify-content-center ">
                            <asp:Button ID="btnBuscar" CssClass="btn btn-outline-danger" runat="server" OnClick="btnBuscar_Click" Text="Buscar" ValidationGroup="imei" />
                        </div>
                    </div>

                    <asp:Label ID="lblMensaje" runat="server" Text=""></asp:Label>

                </div>
            </div>
        </div>
    </div>
</asp:Content>
